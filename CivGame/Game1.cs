using CivGame.ECS.Component;
using CivGame.ECS.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CivGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TextureFactory _textureFactory;

        IPlayer _player;
        IBlock _block;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _textureFactory = new TextureFactory(GraphicsDevice);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create the player.
            _player = new Player(_textureFactory.createColoredTexture(Color.Purple));
            _player.Initialize(null);

            // Create the block.
            _block = new Block(_textureFactory.createColoredTexture(Color.Red));
            _block.Initialize(null);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            _block.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            if(AreEntitiesColliding(_player, _block))
            {
                var motionComponent = _player.GetComponent<MotionComponent>();
                var velocity = motionComponent.Velocity;
                var intersection = GetEntityIntersection(_player, _block);
                var normalizedIntersection = Vector2.Normalize(intersection);

                var offsetX = (float)Math.Round(1 - normalizedIntersection.X) * velocity.X;
                var offsetY = (float)Math.Round(1 - normalizedIntersection.Y) * velocity.Y;
                var offset = new Vector2(offsetX, offsetY);

                _player.Position -= offset;
                motionComponent.Velocity = new Vector2(0, 0);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            _player.Draw(spriteBatch);
            _block.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private bool AreEntitiesColliding(IEntity entity1, IEntity entity2)
        {
            var rect1 = new Rectangle((int)entity1.Position.X, (int)entity1.Position.Y, (int)entity1.Width, (int)entity1.Height);
            var rect2 = new Rectangle((int)entity2.Position.X, (int)entity2.Position.Y, (int)entity2.Width, (int)entity2.Height);

            return rect1.Intersects(rect2);
        }

        private Vector2 GetEntityIntersection(IEntity entity1, IEntity entity2)
        {
            var rect1 = new Rectangle((int)entity1.Position.X, (int)entity1.Position.Y, (int)entity1.Width, (int)entity1.Height);
            var rect2 = new Rectangle((int)entity2.Position.X, (int)entity2.Position.Y, (int)entity2.Width, (int)entity2.Height);

            var intersection = Rectangle.Intersect(rect1, rect2);

            return intersection.Size.ToVector2();
        }
    }
}

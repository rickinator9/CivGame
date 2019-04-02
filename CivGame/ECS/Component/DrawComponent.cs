using CivGame.ECS.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CivGame.ECS.Component
{
    class DrawComponent : Component, IDrawableComponent
    {
        private Texture2D _texture;

        public DrawComponent(IEntity entity, Texture2D texture) : base(entity) {
            _texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Define the destination rectangle for the drawn texture.
            var x = (int)Entity.Position.X;
            var y = (int)Entity.Position.Y;
            var width = _texture.Width;
            var height = _texture.Height;
            var rect = new Rectangle(x, y, width, height);

            // Draw the texture.
            spriteBatch.Draw(_texture, rect, Color.White);
        }
    }
}

using CivGame.ECS;
using CivGame.ECS.Component;
using CivGame.ECS.Entity;
using Microsoft.Xna.Framework.Graphics;

namespace CivGame
{
    interface IPlayer : IEntity
    {
    }

    class Player : Entity, IPlayer
    {
        private Texture2D _texture;

        public Player(Texture2D texture)
        {
            _texture = texture;
            Width = texture.Width;
            Height = texture.Height;
        }

        public override void Initialize(IComponentFactory componentFactory)
        {
            Components.Add(new InputComponent(this));
            Components.Add(new MotionComponent(this));
            Components.Add(new DrawComponent(this, _texture));

            base.Initialize(componentFactory);
        }
    }
}

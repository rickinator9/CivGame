using CivGame.ECS.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CivGame.ECS.Entity
{
    interface IBlock : IEntity
    {
    }

    class Block : Entity, IBlock
    {
        private Texture2D _texture;

        public Block(Texture2D texture)
        {
            _texture = texture;
            Width = texture.Width;
            Height = texture.Height;

            Position = new Vector2(200, 200);
        }

        public override void Initialize(IComponentFactory componentFactory)
        {

            Components.Add(new DrawComponent(this, _texture));

            base.Initialize(componentFactory);
        }
    }
}

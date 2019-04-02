using CivGame.ECS.Entity;
using Microsoft.Xna.Framework.Graphics;

namespace CivGame.ECS.Component
{
    interface IComponent
    {
        /// <summary>
        /// Initializes the component. Called after parent entity has initialized.
        /// </summary>
        void Initialize();
    }

    abstract class Component : IComponent
    {
        protected IEntity Entity { get; private set; }

        public Component(IEntity entity)
        {
            Entity = entity;
        }

        public virtual void Initialize()
        {
            // Empty by default. Only overriden if necessary.
        }
    }

    interface IUpdatableComponent : IComponent
    {
        /// <summary>
        /// Update function.
        /// </summary>
        /// <param name="deltaTime">The elapsed time since the last update.</param>
        void Update(float deltaTime);
    }

    interface IDrawableComponent : IComponent
    {
        /// <summary>
        /// Draw function.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch to issue draw commands.</param>
        void Draw(SpriteBatch spriteBatch);
    }
}

using CivGame.ECS.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivGame.ECS.Entity
{
    interface IEntity
    {
        /// <summary>
        /// The position in the 2D world of the entity.
        /// </summary>
        Vector2 Position { get; set; }

        /// <summary>
        /// The width of this entity.
        /// </summary>
        float Width { get; }

        /// <summary>
        /// The height of this entity.
        /// </summary>
        float Height { get; }

        /// <summary>
        /// Initializes the entity and its components.
        /// </summary>
        /// <param name="componentFactory">The factory used to create components.</param>
        void Initialize(IComponentFactory componentFactory);

        /// <summary>
        /// Draw the Player.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch to issue draw commands.</param>
        void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Update the Player.
        /// </summary>
        /// <param name="deltaTime">The elapsed time since the last update.</param>
        void Update(float deltaTime);

        /// <summary>
        /// Returns a component (if it exists) of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>The found component or null if it does not exist.</returns>
        T GetComponent<T>() where T : IComponent;
    }

    abstract class Entity : IEntity
    {
        protected List<IComponent> Components { get; private set; }

        public Vector2 Position { get; set; }

        public float Width { get; protected set; }

        public float Height { get; protected set; }

        protected Entity()
        {
            Components = new List<IComponent>();
        }

        public virtual void Initialize(IComponentFactory componentFactory)
        {
            foreach(var component in Components)
            {
                component.Initialize();
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in Components)
            {
                // Check if the component is a drawable component.
                var isDrawableComponent = component is IDrawableComponent;
                if (!isDrawableComponent) continue;

                // If it is, call its draw function.
                var drawableComponent = component as IDrawableComponent;
                drawableComponent.Draw(spriteBatch);
            }
        }

        public virtual void Update(float deltaTime)
        {
            foreach (var component in Components)
            {
                // Check if the component is a updatable component.
                var isUpdatableComponent = component is IUpdatableComponent;
                if (!isUpdatableComponent) continue;

                // If it is, call its draw function.
                var drawableComponent = component as IUpdatableComponent;
                drawableComponent.Update(deltaTime);
            }
        }

        public T GetComponent<T>() where T : IComponent
        {
            // Check if there is a component that matches the generic type.
            var type = typeof(T);
            foreach (var component in Components)
            {
                if (type.Equals(component.GetType())) return (T)component;
            }

            // Return null if no component matching the type was found.
            return default(T);
        }
    }
}

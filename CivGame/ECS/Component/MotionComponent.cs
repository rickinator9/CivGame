using CivGame.ECS.Entity;
using Microsoft.Xna.Framework;

namespace CivGame.ECS.Component
{
    class MotionComponent : Component, IUpdatableComponent
    {
        /// <summary>
        /// The direction and speed of the motion.
        /// </summary>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// The speed of the motion.
        /// </summary>
        public float Speed {
            get
            {
                return Velocity.Length();
            }
        }

        /// <summary>
        /// The maximum speed that the motion can assume.
        /// </summary>
        public float MaxSpeed { get; private set; }

        public MotionComponent(IEntity entity) : base(entity) {
            MaxSpeed = 5;
        }

        public void Update(float deltaTime)
        {
            // Apply drag to the velocity.
            Velocity *= 0.85f;

            // Make sure that the velocity is within acceptable bounds.
            if (Speed > MaxSpeed)
            {
                Velocity = Vector2.Normalize(Velocity);
                Velocity *= MaxSpeed;
            }

            // Finally add the velocity to the position.
            Entity.Position += Velocity;
        }

        public void Add(Vector2 delta)
        {
            Velocity += delta;
        }
    }
}

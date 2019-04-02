using CivGame.ECS.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivGame.ECS.Component
{
    class InputComponent : Component, IUpdatableComponent
    {
        private MotionComponent _motionComponent;

        public InputComponent(IEntity entity) : base(entity) { }

        public override void Initialize()
        {
            _motionComponent = Entity.GetComponent<MotionComponent>();

            base.Initialize();
        }

        public void Update(float deltaTime)
        {
            var deltaVelocity = new Vector2();

            // Check for horizontal motion.
            if (Keyboard.GetState().IsKeyDown(Keys.D)) deltaVelocity.X += 1;
            else if (Keyboard.GetState().IsKeyDown(Keys.A)) deltaVelocity.X -= 1;

            // Check for vertical motion.
            if (Keyboard.GetState().IsKeyDown(Keys.W)) deltaVelocity.Y -= 1;
            else if (Keyboard.GetState().IsKeyDown(Keys.S)) deltaVelocity.Y += 1;

            // Add the changes to the velocity of the motion component.
            _motionComponent.Add(deltaVelocity);
        }
    }
}

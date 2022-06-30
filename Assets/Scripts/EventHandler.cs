using UnityEngine;

namespace RoguelikeTutorial
{
    class EventHandler
    {
        public void HandleInput()
        {
            HandleMovement()?.Execute();
        }

        private Action HandleMovement()
        {
            if (RB.KeyDown(KeyCode.W))
            {
                return new MovementAction(0, -1);
            }
            if (RB.KeyDown(KeyCode.S))
            {
                return new MovementAction(0, 1);
            }
            if (RB.KeyDown(KeyCode.A))
            {
                return new MovementAction(-1, 0);
            }
            if (RB.KeyDown(KeyCode.D))
            {
                return new MovementAction(1, 0);
            }

            return null;
        }
    }
}
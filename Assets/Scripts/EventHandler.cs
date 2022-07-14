using Assets.Scripts;
using UnityEngine;

namespace RoguelikeTutorial
{
    class EventHandler
    {
        public void HandleInput(Entity player, GameMap map)
        {
            HandleMovement(player, map)?.Execute();
        }

        private Action HandleMovement(Entity player, GameMap map)
        {
            if (RB.KeyDown(KeyCode.W))
            {
                return new MovementAction(player, map, 0, -1);
            }
            if (RB.KeyDown(KeyCode.S))
            {
                return new MovementAction(player, map, 0, 1);
            }
            if (RB.KeyDown(KeyCode.A))
            {
                return new MovementAction(player, map, -1, 0);
            }
            if (RB.KeyDown(KeyCode.D))
            {
                return new MovementAction(player, map, 1, 0);
            }

            return null;
        }
    }
}
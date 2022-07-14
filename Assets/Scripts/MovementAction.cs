using Assets.Scripts;

namespace RoguelikeTutorial
{
    class MovementAction : Action
    {
        public Entity Actor { get; }
        public GameMap Map { get; }
        public int Dx { get; }
        public int Dy { get; }

        public MovementAction(Entity actor, GameMap map, int dx, int dy)
        {
            Actor = actor;
            Map = map;
            Dx = dx;
            Dy = dy;
        }

        public override void Execute()
        {
            var targetX = Actor.X + Dx;
            var targetY = Actor.Y + Dy;

            if (Map.InBounds(targetX, targetY) && Map.tiles[targetX, targetY].Walkable)
            {
                Actor.Move(Dx, Dy);
            }
        }
    }
}

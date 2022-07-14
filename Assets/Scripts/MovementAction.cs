using Assets.Scripts;

namespace RoguelikeTutorial
{
    class MovementAction : Action
    {
        public Entity Actor { get; }
        public int Dx { get; }
        public int Dy { get; }

        public MovementAction(Entity actor, int dx, int dy)
        {
            Actor = actor;
            Dx = dx;
            Dy = dy;
        }

        public override void Execute()
        {
            Actor.Move(Dx, Dy);
        }
    }
}

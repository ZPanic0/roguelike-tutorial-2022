namespace RoguelikeTutorial
{
    class MovementAction : Action
    {
        public MovementAction(int dx, int dy)
        {
            Player.X += dx;
            Player.Y += dy;
        }

        public override void Execute()
        {
        }
    }
}

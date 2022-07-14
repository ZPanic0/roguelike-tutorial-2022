using UnityEngine;

namespace Assets.Scripts
{
    public class Entity
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public EntityCharacterType Character { get; set; }
        public Color32 Tint { get; set; }

        public Entity(int x, int y, EntityCharacterType character, Color32 tint)
        {
            X = x;
            Y = y;
            Character = character;
            Tint = tint;
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }
}

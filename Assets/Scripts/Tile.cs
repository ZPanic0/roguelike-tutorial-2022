using UnityEngine;

namespace Assets.Scripts
{
    public class Tile
    {
        public TileType TileGraphic { get; set; }
        public Color32 Tint { get; set; }
        public bool Walkable { get; set; }
        public bool Transparent { get; set; }
        public bool Dark { get; set; }

        public static Tile NewFloor() => new()
        { Walkable = true, Transparent = true, Dark = false, TileGraphic = TileType.Floor, Tint = new Color32(99, 73, 0, 255) };
        public static Tile NewWall() => new()
        { Walkable = false, Transparent = false, Dark = true, TileGraphic = TileType.Empty, Tint = new Color(0, 0, 0, 255) };
    }
}

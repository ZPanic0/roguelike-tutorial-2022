using RoguelikeTutorial;

namespace Assets.Scripts
{

    public class GameMap
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public readonly Tile[,] tiles;

        public GameMap(int width, int height)
        {
            Width = width;
            Height = height;

            tiles = new Tile[Width, Height];

            //draw floor
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    tiles[x, y] = Tile.NewFloor();
                }
            }

            //draw test walls
            for (int x = 30; x < 33; x++)
            {
                tiles[x, 22] = Tile.NewWall();
            }            
        }

        /// <summary>
        /// Returns whether x and y are inside the bounds of this map
        /// </summary>
        public bool InBounds(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public void Render()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var tile = tiles[x, y];

                    RB.TintColorSet(tile.Tint);
                    RB.DrawSprite((int)tile.TileGraphic, new Vector2i(x * WorldConfig.TileSize, y * WorldConfig.TileSize));
                }
            }
        }
    }
}

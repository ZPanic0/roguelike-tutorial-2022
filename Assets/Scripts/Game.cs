using UnityEngine;

namespace RoguelikeTutorial
{

    public static class WorldConfig
    {
        public static int DisplayWidth { get; set; } = 80;
        public static int DisplayHeight { get; set; } = 50;
        public static int TileSize { get; set; } = 10;
    }

    public static class Player
    {
        public static int X { get; set; } = WorldConfig.DisplayWidth / 2;
        public static int Y { get; set; } = WorldConfig.DisplayHeight / 2;
    }

    public class Game : RB.IRetroBlitGame
    {
        public bool Initialize()
        {
            var spritesheet = new SpriteSheetAsset();
            spritesheet.Load("spritesheet");
            spritesheet.grid = new SpriteGrid(new Vector2i(WorldConfig.TileSize, WorldConfig.TileSize));

            RB.SpriteSheetSet(spritesheet);

            return true;
        }

        public RB.HardwareSettings QueryHardware()
        {
            return new()
            {
                DisplaySize = new(
                    WorldConfig.DisplayWidth * WorldConfig.TileSize,
                    WorldConfig.DisplayHeight * WorldConfig.TileSize)
            };
        }

        public void Render()
        {
            RB.Clear(new Color32());
            RB.DrawSprite(32, new Vector2i(Player.X * WorldConfig.TileSize, Player.Y * WorldConfig.TileSize));
        }

        void RB.IRetroBlitGame.Update()
        {
            if (RB.AnyKeyDown()) new EventHandler().HandleInput();
        }
    }
}
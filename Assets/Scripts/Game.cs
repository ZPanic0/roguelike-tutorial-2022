using Assets.Scripts;
using UnityEngine;

namespace RoguelikeTutorial
{

    public static class WorldConfig
    {
        public static int DisplayWidth { get; set; } = 80;
        public static int DisplayHeight { get; set; } = 50;
        public static int TileSize { get; set; } = 10;
    }

    public class Game : RB.IRetroBlitGame
    {
        private Entity player;
        private EventHandler eventHandler;

        public bool Initialize()
        {
            var spritesheet = new SpriteSheetAsset();
            spritesheet.Load("spritesheet");
            spritesheet.grid = new SpriteGrid(new Vector2i(WorldConfig.TileSize, WorldConfig.TileSize));

            RB.SpriteSheetSet(spritesheet);

            eventHandler = new EventHandler();

            player = new Entity(WorldConfig.DisplayWidth / 2, WorldConfig.DisplayHeight / 2, EntityCharacterType.Player, Color.white);

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
            RB.DrawSprite(32, new Vector2i(player.X * WorldConfig.TileSize, player.Y * WorldConfig.TileSize));
        }

        void RB.IRetroBlitGame.Update()
        {
            if (RB.AnyKeyDown()) eventHandler.HandleInput(player);
        }
    }
}
using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace RoguelikeTutorial
{

    public static class WorldConfig
    {
        public static int TileSize { get; set; } = 10;
    }

    public class Game : RB.IRetroBlitGame
    {
        private readonly Entity player;
        private readonly EventHandler eventHandler;
        private readonly IList<Entity> entities;
        private readonly GameMap map;

        public Game()
        {
            eventHandler = new();
            map = new(80, 50);

            player = new Entity(map.Width / 2, map.Height / 2, EntityCharacterType.Player, Color.white);
            var npc = new Entity(map.Width / 2 - 5, map.Height / 2, EntityCharacterType.Player, Color.yellow);
            entities = new List<Entity> { player, npc };
        }

        public bool Initialize()
        {
            var spritesheet = new SpriteSheetAsset();
            spritesheet.Load("spritesheet");
            spritesheet.grid = new SpriteGrid(new Vector2i(WorldConfig.TileSize, WorldConfig.TileSize));

            RB.SpriteSheetSet(spritesheet);

            return true;
        }

        public RB.HardwareSettings QueryHardware() => new()
        {
            DisplaySize = new(
                    map.Width * WorldConfig.TileSize,
                    map.Height * WorldConfig.TileSize)
        };

        public void Render()
        {
            RB.TintColorSet(new Color32());
            RB.Clear(new Color32());

            map.Render();

            foreach (var entity in entities)
            {
                RB.TintColorSet(entity.Tint);
                RB.DrawSprite((int)entity.Character, 
                    new Vector2i(entity.X * WorldConfig.TileSize, entity.Y * WorldConfig.TileSize));
            }
        }

        void RB.IRetroBlitGame.Update()
        {
            if (RB.AnyKeyDown()) eventHandler.HandleInput(player, map);
        }
    }
}
using UnityEngine;

public class Game : RB.IRetroBlitGame
{
    public bool Initialize()
    {
        var spritesheet = new SpriteSheetAsset();
        spritesheet.Load("spritesheet");
        spritesheet.grid = new SpriteGrid(new Vector2i(10, 10));

        RB.SpriteSheetSet(spritesheet);

        return true;
    }

    public RB.HardwareSettings QueryHardware()
    {
        var hardware = new RB.HardwareSettings();

        return hardware;
    }

    public void Render()
    {
        RB.DrawSprite(110, new Vector2i(240, 128));
        RB.DrawSprite(106, new Vector2i(250, 128));
        RB.DrawSprite(1, new Vector2i(260, 128));
    }

    void RB.IRetroBlitGame.Update()
    {
    }
}

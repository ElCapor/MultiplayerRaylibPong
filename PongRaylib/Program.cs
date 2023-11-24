using static Raylib_cs.Raylib;
using static Raylib_cs.KeyboardKey;
using Raylib_cs;
using PongRaylib;
using System.Numerics;

static void HandleInput(ref Player p)
{
    if (IsKeyPressed(KeyboardKey.KEY_DOWN))
    {
        p.StartMoveDown();
    }
    else if (IsKeyPressed(KeyboardKey.KEY_UP))
    {
        p.StartMoveUp();
    }
    else if (IsKeyReleased(KeyboardKey.KEY_UP) || IsKeyReleased(KeyboardKey.KEY_DOWN))
    {
        p.StopMove();
    }
}

Player p = new();
Ball b = new(new Vector2(400 , 300), new Vector2(0,0));
InitWindow(800, 600, "Pong");
SetTargetFPS(60);
b.InitialBounce();
while (!WindowShouldClose())
{
    p.Update();
    b.Update(p, new Rectangle(0, 0, 800, 600));
    HandleInput(ref p);
    BeginDrawing();
    ClearBackground(Color.BLACK);
    p.Draw();
    b.Draw();
    EndDrawing();
}

CloseWindow();
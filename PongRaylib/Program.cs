using static Raylib_cs.Raylib;
using static Raylib_cs.KeyboardKey;
using Raylib_cs;

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

InitWindow(800, 600, "Pong");
SetTargetFPS(60);

while (!WindowShouldClose())
{
    p.Update();
    HandleInput(ref p);
    BeginDrawing();
    ClearBackground(Color.BLACK);
    p.Draw();
    EndDrawing();
}

CloseWindow();
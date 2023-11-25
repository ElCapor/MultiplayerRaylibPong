using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

public class Player
{
    Vector2 position;
    Vector2 velocity;
    Vector2 size;

    public EventHandler<Player>? onPlayerMoveDown;
    public EventHandler<Player>? onPlayerMoveUp;
    public EventHandler<Player>? onPlayerStopMove;

    public Player()
    {
        position = new();
        size = new(10, 50);
        velocity = new();
    }

    public void StartMoveUp()
    {
        if (position.Y + size.Y > 0)
        {
            velocity.X = 0;
            velocity.Y = -5;
            onPlayerMoveUp?.Invoke(this, this);
        }
        else
        {
            StopMove();
            position.X = 0;
            position.Y = 0 + size.Y;
        }
    }

    public void StartMoveDown()
    {
        if (position.Y + size.Y < 800)
        {
            velocity.X = 0;
            velocity.Y = 5;
            onPlayerMoveDown?.Invoke(this, this);
        }
        else
        {
            StopMove();
            position.X = 0;
            position.Y = 800 - size.Y;
        }
    }

    public void StopMove()
    {
        velocity.Y = 0;
        velocity.X = 0;
        onPlayerStopMove?.Invoke(this, this);
    }

    public void Update()
    {
        position += velocity;
    }

    public void Draw()
    {
        DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, Color.RED);
    }

    public Rectangle GetRect()
    {
        return new Rectangle(position.X, position.Y, size.X, size.Y);
    }
}

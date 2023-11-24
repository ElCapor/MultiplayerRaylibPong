using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
namespace PongRaylib
{

    public class BallCollideEvent : EventArgs
    {
        public object Collider;
        public BallCollideEvent(object collider) { 
            this.Collider = collider;
        }
    }
    public class Ball
    {
        Vector2 position;
        Vector2 velocity;
        float radius = 20;

        EventHandler<Ball>? onBallVelocityChanged;
        EventHandler<BallCollideEvent>? onBallCollide;

        public Ball(Vector2 pos, Vector2 vel,  float radiuss = 20, EventHandler<Ball>? ballVelocityEvent = null, EventHandler<BallCollideEvent>? ballCollideEvent = null) 
        {
            position = pos;
            velocity = vel;
            radius = radiuss;

            onBallVelocityChanged = ballVelocityEvent;
            onBallCollide = ballCollideEvent;
        }


        public void SetVelocity(Vector2 vel)
        {
            onBallVelocityChanged?.Invoke(this, this);
            velocity = vel;
        }


        void CheckCollisions(Player p1, Rectangle mapBounds)
        {
            if (!CheckCollisionCircleRec(position + new Vector2(radius), radius, mapBounds))
            {
                SetVelocity(velocity * -1);
            }
            else if (CheckCollisionCircleRec(position, radius, p1.GetRect()))
            {
                SetVelocity(velocity * -1);
            }
        }

        public void Update(Player p1, Rectangle mapBounds)
        {
            CheckCollisions(p1, mapBounds);
            position += velocity;
        }

        public void InitialBounce()
        {
            Random rnd = new();
            velocity = new Vector2(rnd.Next(1, 5), rnd.Next(1, 4));
        }

        public void Draw()
        {
            DrawCircle((int)position.X, (int)position.Y, radius, Color.WHITE);
        }
    }

}

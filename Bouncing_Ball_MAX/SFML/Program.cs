using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace SFMLApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MySFMLProgram app = new MySFMLProgram();
            app.StartSFMLProgram();
        }
    }

    internal class MySFMLProgram
    {
        private RenderWindow window;

        private int directionX = 1;

        private int directionY = 1;

        public void StartSFMLProgram()
        {
            window = new RenderWindow(new VideoMode(800, 600), "Bouncing Ball");

            window.SetVerticalSyncEnabled(true);

            window.Closed += (sender, eventArgs) => window.Close();

            Texture balltex = new Texture("ball.png");

            Sprite ballspr = new Sprite(balltex);

               ballspr.Position = new Vector2f(window.Size.X / 2 - balltex.Size.X / 2, window.Size.Y / 2 - balltex.Size.Y / 2); //spawn at middle...if needed

            Time dt = new Time();
            Time elapsedTime = new Time();
            Clock clock = new Clock();

            while (window.IsOpen)

            {
                // window.DispatchEvents(); //makes distortion on movement...idk

                elapsedTime += clock.ElapsedTime;
                dt = clock.ElapsedTime;
                clock.Restart();

                //    if (elapsedTime.AsMilliseconds() > (1000 / 60))  //enable for constant framerate
                {
                    if ((ballspr.Position.X > window.Size.X - balltex.Size.X) || ballspr.Position.X < 0)
                    { directionX = directionX * (-1); }

                    if ((ballspr.Position.Y > window.Size.Y - balltex.Size.Y) || ballspr.Position.Y < 0)
                    { directionY = directionY * (-1); }

                    ballspr.Position = new Vector2f(ballspr.Position.X + directionX * dt.AsMilliseconds(), ballspr.Position.Y + directionY * dt.AsMilliseconds());

                    elapsedTime = new Time();
                }

                window.Clear(Color.Green);

                window.Draw(ballspr);

                window.Display();
            }
        }

        //have to think how to make it work...
        private static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        //keyboard methods when needed

        //private float GetXPos(Sprite spr)
        //{
        //    if (Keyboard.IsKeyPressed(Keyboard.Key.A))
        //    {
        //        return spr.Position.X - 2;
        //    }
        //    else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
        //    {
        //        return spr.Position.X + 2;
        //    }

        //    return spr.Position.X;
        //}

        //private float GetYPos(Sprite spr)
        //{
        //    if (Keyboard.IsKeyPressed(Keyboard.Key.W))
        //    {
        //        return spr.Position.Y - 2;
        //    }
        //    else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
        //    {
        //        return spr.Position.Y + 2;
        //    }

        //    return spr.Position.Y;
        //}

        ///random movement methods
        ///

        //        private float RandomPosX(Sprite spr, float size)
        //        {
        //            if (spr.Position.X > window.Size.X - size || spr.Position.X < 0)
        //            { directionX = directionX * (-1); }

        //            return spr.Position.X + BallSpeed * directionX;
        //        }

        //        private float RandomPosY(Sprite spr, float size)
        //        {
        //            if (spr.Position.Y > window.Size.Y - size || spr.Position.Y < 0)

        //            { directionY = directionY * (-1); }

        //            return spr.Position.Y + BallSpeed * directionY;
        //        }
    }
}
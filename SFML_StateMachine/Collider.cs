using SFML.Graphics;

namespace StateMachine
{
    internal static class Collision
    {
        public static bool TouchLeft(this IntRect r1, IntRect r2)
        {
            return ((r1.Left + r1.Width >= r2.Left) &&
                    (r1.Left <= r2.Left + r2.Width) &&
                    (r1.Top + r1.Height >= r2.Top) &&
                    (r1.Top <= r2.Top + r2.Height) && r1.Left + r1.Width < r2.Left + r2.Width);
        }

        public static bool TouchBottom(this IntRect r1, IntRect r2)
        {
            return ((r1.Left + r1.Width >= r2.Left) &&
                    (r1.Left <= r2.Left + r2.Width) &&
                    (r1.Top + r1.Height >= r2.Top) &&
                    (r1.Top <= r2.Top + r2.Height) && r1.Top + r1.Height > r2.Top + r2.Height);
        }

        public static bool TouchTop(this IntRect r1, IntRect r2)
        {
            return ((r1.Left + r1.Width >= r2.Left) &&
                    (r1.Left <= r2.Left + r2.Width) &&
                    (r1.Top + r1.Height >= r2.Top) &&
                    (r1.Top <= r2.Top + r2.Height) && r1.Top < r2.Top);
        }

        public static bool TouchRight(this IntRect r1, IntRect r2)
        {
            return ((r1.Left + r1.Width >= r2.Left) &&
                    (r1.Left <= r2.Left + r2.Width) &&
                    (r1.Top + r1.Height >= r2.Top) &&
                    (r1.Top <= r2.Top + r2.Height) && r1.Left > r2.Left);
        }
    }
}
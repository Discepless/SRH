using GameplayWorld_DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_StateMachine
{

    static class Collision
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
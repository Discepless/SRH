using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;



namespace StateMachine
{
    class TileCollider
    {
        //public static bool TouchTop(this IntRect r1, IntRect r2)
        //{
        //    return ((r1.Top + r1.Height) >= r2.Top - 1 &&
        //        r1. <= r2.Top + (r2.Height / 2) &&
        //        r1.Right >= r2.Left + (r2.Width / 5) &&
        //        r1.Left <= r2.Right - (r2.Width / 5));
        //}


        //public static bool TouchBottom(this Rectangle r1, Rectangle r2)
        //{
        //    return (r1.Top <= r2.Bottom + (r2.Height / 5) &&
        //        r1.Top >= r2.Bottom - 1 &&
        //        r1.Right >= r2.Left + (r2.Width / 5) &&
        //        r1.Left <= r2.Right - (r2.Width / 5));
        //}

        //public static bool TouchLeft(this Rectangle r1, Rectangle r2)
        //{
        //    return (r1.Right <= r2.Right &&
        //        r1.Right >= r2.Left - 5 &&
        //        r1.Top <= r2.Bottom - (r2.Width / 4) &&
        //        r1.Bottom >= r2.Top + (r2.Width / 4));
        //}


        //public static bool TouchRight(this Rectangle r1, Rectangle r2)
        //{
        //    return (r1.Left >= r2.Left &&
        //        r1.Left <= r2.Right + 5 &&
        //        r1.Top <= r2.Bottom - (r2.Width / 4) &&
        //        r1.Bottom >= r2.Top + (r2.Width / 4));
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML_StateMachine
{
    class Animation
    {
        public int offsetTop;
        public int offsetLeft;
        public int numFrames;

        public Animation(int offsetTop, int offsetLeft, int numFrames)
        {
            this.offsetLeft = offsetLeft;
            this.offsetTop = offsetTop;
            this.numFrames = numFrames;
        }
    }
}

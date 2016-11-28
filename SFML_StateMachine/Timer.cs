using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace StateMachine
{
    class Timer
    {
        Clock timer;
        Time time;
        float float_time;

        public float Current { get { return float_time; } }
        public void Update()
        {

            float_time = time.AsSeconds() + timer.ElapsedTime.AsSeconds();
        }
        public Timer()
        {
            timer = new Clock();
        }


    }
}

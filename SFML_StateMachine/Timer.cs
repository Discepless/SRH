using SFML.System;

namespace StateMachine
{
    internal class Timer
    {
        private Clock timer;
        private Time time;
        private float float_time;

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
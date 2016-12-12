using SFML.System;

namespace StateMachine
{
    internal class Timer
    {
        private Clock splashscreen_timer;
        private Time splashscreen_time;
        private float splashscreen_float_time;

        private Clock textbox_timer;

        public float Current { get { return splashscreen_float_time; } }
        public float GetTextboxClock { get { return textbox_timer.ElapsedTime.AsSeconds(); } }

        public void Update()
        {
            splashscreen_float_time = splashscreen_time.AsSeconds() + splashscreen_timer.ElapsedTime.AsSeconds();

        }

        public Timer()
        {
            splashscreen_timer = new Clock();

            textbox_timer = new Clock();
        }

        public void RestartTextboxTimer()
        {
            textbox_timer.Restart();
        }
    }
}
﻿using SFML.Graphics;
using SFML.Window;
using System;

namespace StateMachine
{
    public class Scene : IDisposable
    {
        public string Name;

        private DateTime currentTime = System.DateTime.Now;

        private DateTime targetTime = System.DateTime.Now;

        private bool pause = false;

        public bool IsPaused
        {
            get { return pause; }
        }

        protected GameObject _gameObject;

        public Color BackgroundColor = Color.Black; //default scene color

        public Scene(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public virtual void InitializeItems()
        {
            // initialize the game
        }

        public virtual void Reset()
        {
            // when the scene resets do smth
        }

        public void Run()
        {
            // kinda main loop

            while (_gameObject.Window.IsOpen)
            {
                currentTime = System.DateTime.Now;

                _gameObject.Window.Clear(this.BackgroundColor);

                if (!pause)
                {
                    this.Update();

                    this.Draw();

                    _gameObject.Window.Display();
                }
                else
                {
                    if (currentTime >= targetTime)
                    {
                        pause = false;
                    }
                    else
                        this.OnPause();
                }

                _gameObject.Window.DispatchEvents();
            }
        }

        public virtual void HandleKeyPress(KeyEventArgs e)
        {
            //  input handler for the scene
        }

        public virtual void HandleKeyReleased(KeyEventArgs e)
        {
            //  input handler for the scene
        }

        public virtual void Update()
        {
        }

        public virtual void Draw()
        {
        }

        public void Pause(int milliseconds)
        {
            targetTime = currentTime.AddMilliseconds(milliseconds);
            pause = true;
        }

        public void Pause()
        {
            targetTime = currentTime.AddYears(10); //dirty trick
            pause = true;
        }

        public void Resume()
        {
            pause = false;
        }

        public virtual void OnPause()
        {
            // called each frame during the pause
        }

        public virtual void Exit()
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free other managed objects that implement
                // IDisposable only
                // see https://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx
            }
        }
    }
}
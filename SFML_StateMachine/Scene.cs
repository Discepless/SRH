using SFML.Graphics;
using SFML.Window;
using System;

namespace StateMachine
{
    public class Scene : IDisposable
    {
        public string Name;

        private bool pause = false;

        public bool IsPaused
        {
            get { return pause; }
        }

        protected GameObject _gameObject;

        public Color BackgroundColor = Color.Transparent; //default scene background color

        public Scene(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public virtual void InitializeItems()
        {
            // initialize the game items
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
                _gameObject.Window.Clear(this.BackgroundColor);

                if (!pause) //if not paused then update - draw loop
                {
                    this.Update();

                    this.Draw();

                    _gameObject.Window.Display();
                }
                else
                {
                    this.OnPause(); //if paused do what you wrote in this function, independent for each scene
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
            //should i really describe this?
        }

        public virtual void Draw()
        {
            //should i really describe this?
        }
    

        public void Pause()
        {
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
            //every scene defines what happens on exit
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //make garbage collector do his work
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free other managed objects that implement IDisposable only
                //
                // see https://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx
            }
        }
    }
}
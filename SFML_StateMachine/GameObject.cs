using SFML.Graphics;
using SFML.Window;
using System;

namespace StateMachine
{
    public class GameObject : IDisposable
    {
        private RenderWindow _window;

        public RenderWindow Window { get { return this._window; } }

        public SceneManager SceneManager = new SceneManager();

        private uint Xres = 800;
        private uint Yres = 600; //change whatever u want lads HD=1920x1080 16:9, 1280x720 16:9
        public uint XRes { get { return Xres; } }
        public uint YRes { get { return Yres; } }

        public GameObject(string Title)
        {
            // initialize values
            _window = new RenderWindow(new VideoMode(Xres, Yres), Title, Styles.Default);

            _window.SetVisible(true);
            _window.SetVerticalSyncEnabled(true);
            _window.SetFramerateLimit(60);

            //  event handlers
            _window.Closed += _window_Closed;
            _window.KeyPressed += _window_KeyPressed;
            _window.KeyReleased += _window_KeyReleased;
        }

        private void _window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            SceneManager.CurrentScene.HandleKeyPress(e);
        }

        private void _window_KeyReleased(object sender, SFML.Window.KeyEventArgs e)
        {
            SceneManager.CurrentScene.HandleKeyReleased(e);
        }

        private void _window_Closed(object sender, EventArgs e)
        {
            _window.Close();
        }

        public void Close()
        {
            this._window.Close();
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
                _window.Dispose();
            }
        }
    }
}
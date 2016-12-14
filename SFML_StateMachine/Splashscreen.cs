using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace StateMachine
{
    internal class Splashscreen : Scene
    {
        private Texture Splashtexture;
        private Sprite Splashsprite;

        private Timer Timer;

        public Splashscreen(GameObject gameObject) : base(gameObject)
        {
            BackgroundColor = Color.Cyan;
        }

        public override void InitializeItems()
        {
            Splashtexture = new Texture("Resources/Splashscreen/Splashscreen.png");
            Splashsprite = new Sprite(Splashtexture);

            Splashsprite.Position = new Vector2f();
            Splashsprite.Scale = new Vector2f((float)_gameObject.XRes / Splashsprite.Texture.Size.X, (float)_gameObject.YRes / Splashsprite.Texture.Size.Y);

            Timer = new Timer();

            base.InitializeItems();
        }

        public override void Update()
        {
            Timer.Update();

            if (Timer.Current >= 1)
            {
                _gameObject.SceneManager.GotoScene("main");
               // this.Dispose();
            }

            _gameObject.Window.Draw(Splashsprite);
        }
    }
}
using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace StateMachine
{
    internal class Splashscreen : Scene
    {
        private Texture Splashtexture;
        private Sprite Splashsprite;

        private Clock clock;

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

            clock = new Clock();

            base.InitializeItems();
        }

        public override void Update()
        {
            
            if (clock.ElapsedTime.AsSeconds() > 2)

            {
                _gameObject.SceneManager.StartScene("main");
                this.Dispose();
            }

            _gameObject.Window.Draw(Splashsprite);
        }
    }
}
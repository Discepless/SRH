using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace StateMachine
{
    internal class Creditsscreen : Scene
    {
        private Texture Creditstexture;
        private Sprite Creditssprite;

        private Clock clock;

        public Creditsscreen(GameObject gameObject) : base(gameObject)
        {
            BackgroundColor = Color.Cyan;
        }

        public override void InitializeItems()
        {
            Creditstexture = new Texture("Resources/Splashscreen/Credits.png");
            Creditssprite = new Sprite(Creditstexture);

            Creditssprite.Position = new Vector2f();
            Creditssprite.Scale = new Vector2f((float)_gameObject.XRes / Creditssprite.Texture.Size.X, (float)_gameObject.YRes / Creditssprite.Texture.Size.Y);

            clock = new Clock();

            base.InitializeItems();
        }

        public override void Update()
        {
           _gameObject.Window.Draw(Creditssprite);
        }


        public override void HandleKeyPress(KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                
                _gameObject.SceneManager.GotoScene("main");
                _gameObject.SceneManager.GetScene("credits").Dispose();
            }

        }

        public override void Reset()

        {
            InitializeItems();
        }

    }
}
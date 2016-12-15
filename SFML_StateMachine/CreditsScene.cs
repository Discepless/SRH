using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace StateMachine
{
    internal class Creditsscreen : Scene
    {
        private Texture Creditstexture;
        private Sprite Creditssprite;
        private Text text;
        private string t;

        private Clock clock;

        public Creditsscreen(GameObject gameObject) : base(gameObject)
        {
            BackgroundColor = Color.Cyan;
        }

        public override void InitializeItems()
        {
            Font arial = new Font(@"Resources\arial.ttf");
            text = new Text("", arial);
            text.Position = new Vector2f(0, 0);
            text.CharacterSize = 30;
            t = "23123 \n 3123123 \n 1273172371237 \n 12371264125 ";

            text.DisplayedString = t;

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
                
                _gameObject.SceneManager.GotoScene("menu");
                _gameObject.SceneManager.GetScene("credits").Dispose();
            }

        }

        public override void Reset()

        {
            InitializeItems();
        }

    }
}
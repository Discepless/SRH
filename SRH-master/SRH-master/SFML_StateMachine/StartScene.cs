using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace StateMachine
{
    public class StartScene : Scene
    {
        private Text text;

        public StartScene(GameObject gameObject) : base(gameObject)
        {
            this.BackgroundColor = Color.Cyan; //scene background color
        }

        public override void Initialize()
        {
            //load resources etc

            Font arial = new Font(@"Resources\arial.ttf");

            text = new Text("", arial);

            text.Position = new Vector2f(0, 0);

            text.CharacterSize = 30;
        }

        public override void HandleKeyPress(KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Space)
            {
                _gameObject.SceneManager.StartScene("main"); //like eack scene has to target smth on some condition, here its a simple keypress
            }

            if (e.Code == Keyboard.Key.Escape)
                this._gameObject.Window.Close();

            base.HandleKeyPress(e);
        }

        public override void Update()
        {
            string t = "Press [SPACE] To Begin";
            text.DisplayedString = t;
            text.Position = new Vector2f(200, 100);
            text.Draw(this._gameObject.Window, RenderStates.Default);
        }
    }
}
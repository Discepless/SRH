using GameEngine;
using GameplayWorld_DM;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace StateMachine
{
    public class MainScene : Scene
    {
        private Text text;

        private Music music;

        public MainScene(GameObject gameObject) : base(gameObject)
        {
            this.BackgroundColor = Color.Red; //scene background color
        }

        public override void InitializeItems()
        {
            //  called when the scene is added to the scene manager

            Font arial = new Font(@"Resources\arial.ttf");

            text = new Text("", arial);

            text.Position = new Vector2f(0, 0);

            text.CharacterSize = 30;

            //play soundfiles in flac/ogg/wav !!!!NO MP3 SUPPORT

            music = new Music(@"Resources\aherohasfallen.wav");

            base.InitializeItems();
        }

        public override void HandleKeyPress(KeyEventArgs e)

        {
            if (e.Code == Keyboard.Key.BackSpace)
            {
                _gameObject.SceneManager.StartScene("start");
            }

            if (e.Code == Keyboard.Key.M)
            {
                music.Play();
            }

            if (e.Code == Keyboard.Key.F)
            {
                _gameObject.SceneManager.StartScene("fight");
            }

            if (e.Code == Keyboard.Key.X)
            {
                _gameObject.SceneManager.StartScene("OpenWorld");
            }

            base.HandleKeyPress(e);
        }

        public override void HandleKeyReleased(KeyEventArgs e)

        {
        }

        public override void Update() //just test text like everywhere else
        {
            string t = "PRESS [BACKSPACE] OR [M] or [F], [X] for Map";
            text.DisplayedString = t;
            text.Position = new Vector2f(200, 100);
            text.Draw(this._gameObject.Window, RenderStates.Default);
        }

        public override void Exit()

        {
            //code that runs on exiting the scene. IT IS NOT THE EXIT BUTTON. It can be used to store some changes in the scene etc
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using StateMachine;

namespace StateMachine
{
    internal class Credits : Scene
    {
        private Music music;
        private List<TextLine> _text;
        private Text text;
        private Clock clock;

    //    private int CreditsDuration;
        private float XPos, Ypos;

        public Credits(GameObject gameObject) : base(gameObject)
        {
            this.BackgroundColor = Color.Red; //scene background color
        }

        public override void InitializeItems()
        {
            clock = new Clock();
            Font _font = new Font(@"Resources\arial.ttf");
            _text = new List<TextLine>();
            text = new Text("", _font);
            text.Color = Color.Black;
            StreamReader readStream = new StreamReader(File.Open("Credits/Text.txt", FileMode.Open));
            string tmp = readStream.ReadLine();
            uint YRes =  _gameObject.YRes;
            uint Xres =  _gameObject.XRes;
            Ypos = _gameObject.YRes;
            text.CharacterSize = 30;
            while (tmp != null)
            {
                
                _text.Add(new TextLine(new Vector2f(Xres/2 - tmp.Length*text.CharacterSize/4, YRes), tmp));

                YRes += text.CharacterSize *2 ;

                tmp = readStream.ReadLine();
            }

            readStream.Close();


            _text.Reverse();

        }

        public override void Update() 
        {

            if (clock.ElapsedTime.AsSeconds() < 15) //scroll for 15 seconds only
            {
                foreach (TextLine line in _text) {line.Position.Y -= 1;}
            }
             
        }

        public override void Draw()
        {


            foreach (TextLine line in _text)
            {
                text.DisplayedString = line.Text;
                text.Position = line.Position;
                text.Draw(_gameObject.Window, RenderStates.Default);

            }

            }

        public override void HandleKeyPress(KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {

                _gameObject.SceneManager.GotoScene("menu");
                _gameObject.SceneManager.GetScene("credits").Exit();
            }

        }

        public override void Reset()
        {
            InitializeItems();
        }
    }
}


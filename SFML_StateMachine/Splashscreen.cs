using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML_StateMachine;

namespace StateMachine
{
    class Splashscreen : Scene
    {
        private Texture Splashtexture;
        private Sprite Splashsprite;
        

        Timer Timer;
        public Splashscreen(GameObject gameObject) : base(gameObject)
        {
            BackgroundColor = Color.Cyan;
        }

        public override void Initialize()
        {
            Splashtexture = new Texture("Resources/Splashscreen/Splashscreen.png");
            Splashsprite = new Sprite(Splashtexture);

            Splashsprite.Position = new Vector2f();
            Splashsprite.Scale = new Vector2f((float)_gameObject.XRes / Splashsprite.Texture.Size.X, (float)_gameObject.YRes / Splashsprite.Texture.Size.Y);

            Timer = new Timer();



            base.Initialize();
        }

        public override void Update()
        {
            Timer.Update();
            
            if (Timer.Current >= 1)
            {
                _gameObject.SceneManager.StartScene("main");
            }


            _gameObject.Window.Draw(Splashsprite);
            
        }

    }
}

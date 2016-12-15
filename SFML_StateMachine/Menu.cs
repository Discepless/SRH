using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace StateMachine
{
    class Menu : Scene
    {
        Texture menuBackground_img;
        Sprite menuBackground_sprite;

        Texture pointer_img;
        Sprite pointer_sprite;

        Text Start;
        Text Credits;
        Text ExitGame;

        bool Start_pressed = true;
        bool Credits_pressed = false;
        bool ExitGame_pressed = false;

        public Menu (GameObject gameobject) : base(gameobject)
        {

        }

        public override void InitializeItems()
        {
            menuBackground_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/paper.jpg");
            menuBackground_sprite = new Sprite(menuBackground_img);

            menuBackground_sprite.Position = new Vector2f();
            menuBackground_sprite.Scale = new Vector2f((float)_gameObject.XRes / menuBackground_sprite.Texture.Size.X, (float)_gameObject.YRes / menuBackground_sprite.Texture.Size.Y);


            pointer_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/Anzeigepfeil.png");
            pointer_sprite = new Sprite(pointer_img);

             pointer_sprite.Position = new Vector2f(400, 310);
            // pointer_sprite.Position = new Vector2f(400, 510);
            //pointer_sprite.Position = new Vector2f(400, 710);
            pointer_sprite.Scale = new Vector2f(.5f, .5f);


            Font system = new Font(@"Resources\Capture_it.ttf");

            Start = new Text("Start", system);
            Start.Position = new Vector2f(900, 300);
            Start.CharacterSize = 40;
            Start.Color = Color.Blue;

            Credits = new Text("Credits", system);
            Credits.Position = new Vector2f(900, 500);
            Credits.CharacterSize = 40;
            Credits.Color = Color.Green;

            ExitGame = new Text("Exit", system);
            ExitGame.Position = new Vector2f(900, 700);
            ExitGame.CharacterSize = 40;
            ExitGame.Color = Color.Red;

            base.InitializeItems();
        }
        public override void HandleKeyPress(KeyEventArgs e)
        {
            //GoTo Scene
            if (e.Code == Keyboard.Key.Return && Start_pressed)
            {
                _gameObject.SceneManager.GetScene("OpenWorld").Resume(); _gameObject.SceneManager.GetScene("OpenWorld").Reset();
                _gameObject.SceneManager.StartScene("OpenWorld");
            }
            if (e.Code == Keyboard.Key.Return && Credits_pressed)
            {
              //  _gameObject.SceneManager.GetScene("OpenWorld").Resume();
                _gameObject.SceneManager.GotoScene("credits");
            }
            if(e.Code == Keyboard.Key.Return && ExitGame_pressed)
            {
              //  _gameObject.SceneManager.GetScene("OpenWorld").Resume();
              //  _gameObject.SceneManager.GotoScene("OpenWorld");
            }

            //Handle Pointer
            if (e.Code == Keyboard.Key.Down && pointer_sprite.Position.Y <= 700)
                MovePointerDown();
            if (e.Code == Keyboard.Key.Up && pointer_sprite.Position.Y >= 400)
                MovePointerUp();
        }
        public override void Update()
        {
            Console.WriteLine(Start_pressed);
            Console.WriteLine(pointer_sprite.Position.Y);

            if (pointer_sprite.Position.Y == 310)
            {
                Start_pressed = true;
                Credits_pressed = false;
            }
            if (pointer_sprite.Position.Y == 510)
            {
                Credits_pressed = true;
                Start_pressed = false;
                ExitGame_pressed = false;
            }
            if (pointer_sprite.Position.Y == 710)
            {
                ExitGame_pressed = true;
                Credits_pressed = false;
            }



            _gameObject.Window.Draw(menuBackground_sprite);
            _gameObject.Window.Draw(pointer_sprite);
            _gameObject.Window.Draw(Start);
            _gameObject.Window.Draw(Credits);
            _gameObject.Window.Draw(ExitGame);
        }

        public void MovePointerDown()
        {
            pointer_sprite.Position += new Vector2f(0, 200);
        }
        public void MovePointerUp()
        {
            pointer_sprite.Position -= new Vector2f(0, 200);
        }
    }
}

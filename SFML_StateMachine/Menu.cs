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

            Font system = new Font(@"Resources\Capture_it.ttf");

            Start = new Text("Start", system);
            Start.CharacterSize = 60;
            Start.Position = new Vector2f(_gameObject.XRes /2  -Start.CharacterSize * Start.DisplayedString.Length / 4, _gameObject.YRes /3 /2 - Start.CharacterSize/2);
            Start.Color = Color.Red;

            Credits = new Text("Credits", system);
            Credits.CharacterSize = 60;
            Credits.Position = new Vector2f(_gameObject.XRes / 2 - Credits.CharacterSize * Credits.DisplayedString.Length / 4, Start.Position.Y  + _gameObject.YRes / 3);
            Credits.Color = Color.Red;

            ExitGame = new Text("Exit", system);
            ExitGame.CharacterSize = 60;
            ExitGame.Position = new Vector2f(_gameObject.XRes / 2 - ExitGame.CharacterSize * ExitGame.DisplayedString.Length / 4, Credits.Position.Y  + _gameObject.YRes / 3);
            ExitGame.Color = Color.Red;


            pointer_sprite.Position = new Vector2f(Start.Position .X - pointer_img .Size .X   , Start .Position .Y );
            pointer_sprite.Scale = new Vector2f(.5f, .5f);


            base.InitializeItems();
        }


        public override void HandleKeyPress(KeyEventArgs e)
        {
            //GoTo Scene
            if (e.Code == Keyboard.Key.Return && Start_pressed)
            {
                ReviveEnemiesAndItems();
                _gameObject.SceneManager.GetScene("OpenWorld").Resume(); _gameObject.SceneManager.GetScene("OpenWorld").Reset();
                _gameObject.SceneManager.StartScene("OpenWorld");
            }
            if (e.Code == Keyboard.Key.Return && Credits_pressed)
            {
              //  _gameObject.SceneManager.GetScene("OpenWorld").Resume();
                _gameObject.SceneManager.StartScene("credits");
            }
            if(e.Code == Keyboard.Key.Return && ExitGame_pressed)
            {

                _gameObject.Window.Close();
                //  _gameObject.SceneManager.GetScene("OpenWorld").Resume();
                //  _gameObject.SceneManager.GotoScene("OpenWorld");
            }

            //Handle Pointer
            if (e.Code == Keyboard.Key.Down && pointer_sprite.Position.Y < ExitGame .Position .Y )
                MovePointerDown();
            if (e.Code == Keyboard.Key.Up && pointer_sprite.Position.Y > Start .Position .Y)
                MovePointerUp();
        }
        public override void Update()
        {
            Console.WriteLine(Start_pressed);
            Console.WriteLine(pointer_sprite.Position.Y);

            if (pointer_sprite.Position.Y == Start .Position .Y )
            {
                Start_pressed = true;
                Credits_pressed = false;
            }
            if (pointer_sprite.Position.Y == Credits .Position.Y)
            {
                Credits_pressed = true;
                Start_pressed = false;
                ExitGame_pressed = false;
            }
            if (pointer_sprite.Position.Y == ExitGame .Position.Y)
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
            pointer_sprite.Position += new Vector2f(0, _gameObject.YRes / 3);
        }
        public void MovePointerUp()
        {
            pointer_sprite.Position -= new Vector2f(0, _gameObject.YRes / 3);
        }

        public void ReviveEnemiesAndItems()
        {
            Cat.CatIsDead = false;
            Bat.BatIsDead = false;
            EnemyKilledWithSword.EnemyKilledWithSwordIsDead = false;
            Mage.MageIsDead = false;
            FinalBoss.FinalBossIsDead = false;

            ItemsAndNpcs.BowPicked = false;
            ItemsAndNpcs.DoorsOpened = false;
            ItemsAndNpcs.KeyPicked = false;
            ItemsAndNpcs.SwordPicked = false;
        }
    }
}

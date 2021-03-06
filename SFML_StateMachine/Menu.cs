﻿using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace StateMachine
{
    internal class Menu : Scene
    {
        private Texture menuBackground_img;
        private Sprite menuBackground_sprite;

        private Music music;
        private Sound buttonSwitched;
        private Sound buttonPressed;

        private Texture pointer_img;
        private Sprite pointer_sprite;

        private Text Start;
        private Text Credits;
        private Text ExitGame;

        private bool Start_pressed = true;
        private bool Credits_pressed = false;
        private bool ExitGame_pressed = false;

        public Menu(GameObject gameobject) : base(gameobject)
        {
        }

        public override void InitializeItems()
        {
            menuBackground_img = new Texture("Resources/Splashscreen/Menu.png");
            menuBackground_sprite = new Sprite(menuBackground_img);

            menuBackground_sprite.Position = new Vector2f();
            menuBackground_sprite.Scale = new Vector2f((float)_gameObject.XRes / menuBackground_sprite.Texture.Size.X, (float)_gameObject.YRes / menuBackground_sprite.Texture.Size.Y);

            pointer_img = new Texture("Resources/MenuPointer.png");
            pointer_sprite = new Sprite(pointer_img);

            Font system = new Font(@"Resources\Capture_it.ttf");

            Start = new Text("Start", system);
            Start.CharacterSize = 100;
            Start.Position = new Vector2f(_gameObject.XRes / 2 - (Start.CharacterSize * Start.DisplayedString.Length / 4), _gameObject.YRes / 3 / 2 - Start.CharacterSize / 2);
            Start.Color = Color.Red;

            Credits = new Text("Credits", system);
            Credits.CharacterSize = 100;
            Credits.Position = new Vector2f(_gameObject.XRes / 2 - (Credits.CharacterSize * Credits.DisplayedString.Length / 4), Start.Position.Y + _gameObject.YRes / 3);
            Credits.Color = Color.Red;

            ExitGame = new Text("Exit", system);
            ExitGame.CharacterSize = 100;
            ExitGame.Position = new Vector2f(_gameObject.XRes / 2 - (ExitGame.CharacterSize * ExitGame.DisplayedString.Length / 4), Credits.Position.Y + _gameObject.YRes / 3);
            ExitGame.Color = Color.Red;

            pointer_sprite.Scale = new Vector2f(.6f, .6f);
            pointer_sprite.Position = new Vector2f(_gameObject.XRes / 2 - 2 * pointer_sprite.Texture.Size.X, Start.Position.Y + Start.CharacterSize / 2);

            music = new Music(@"Resources\Sounds\Earthy_Crust.wav");
            music.Play();
            music.Loop = true;

            buttonSwitched = new Sound(new SoundBuffer("Resources/Sounds/ButtonSwitch.wav"));
            buttonPressed = new Sound(new SoundBuffer("Resources/Sounds/ButtonPressed.wav"));

            base.InitializeItems();
        }

        public override void HandleKeyPress(KeyEventArgs e)
        {
            //GoTo Scene
            if (e.Code == Keyboard.Key.Return && Start_pressed)
            {
                OpenWorldScene.music.Stop();
                buttonPressed.Play();
                music.Stop();
                //music = new Music(@"Resources\Sounds\Morning_Stroll.wav");
                //music.Play();
                ReviveEnemiesAndItems();
                _gameObject.SceneManager.GetScene("OpenWorld").Resume(); _gameObject.SceneManager.GetScene("OpenWorld").Reset();
                _gameObject.SceneManager.StartScene("OpenWorld");
            }
            if (e.Code == Keyboard.Key.Return && Credits_pressed)
            {
                buttonPressed.Play();
                _gameObject.SceneManager.StartScene("credits");
            }
            if (e.Code == Keyboard.Key.Return && ExitGame_pressed)
            {
                buttonPressed.Play();
                _gameObject.Window.Close();
            }

            //Handle Pointer
            if (e.Code == Keyboard.Key.Down && pointer_sprite.Position.Y < ExitGame.Position.Y + Start.CharacterSize / 2)
                MovePointerDown();
            if (e.Code == Keyboard.Key.Up && pointer_sprite.Position.Y > Start.Position.Y + Start.CharacterSize / 2)
                MovePointerUp();
        }

        public override void Update()
        {
            Console.WriteLine(Start_pressed);
            Console.WriteLine(pointer_sprite.Position.Y);

            if (pointer_sprite.Position.Y == Start.Position.Y + Start.CharacterSize / 2)
            {
                Start_pressed = true;
                Credits_pressed = false;
            }
            if (pointer_sprite.Position.Y == Credits.Position.Y + Start.CharacterSize / 2)
            {
                Credits_pressed = true;
                Start_pressed = false;
                ExitGame_pressed = false;
            }
            if (pointer_sprite.Position.Y == ExitGame.Position.Y + Start.CharacterSize / 2)
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
            buttonSwitched.Play();
        }

        public void MovePointerUp()
        {
            pointer_sprite.Position -= new Vector2f(0, _gameObject.YRes / 3);
            buttonSwitched.Play();
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

        public override void Reset()
        {
            InitializeItems();
            Start_pressed = true;
            Credits_pressed = false;
            ExitGame_pressed = false;
            Fightscene.HP = 100;
            Fightscene.healthLeft = 100;

            MessageText._counterSpeaker = 0;
            MessageText._counterMessage = 0;
        }
    }
}
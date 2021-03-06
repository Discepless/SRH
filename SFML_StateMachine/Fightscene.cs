﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace StateMachine
{
    internal class Fightscene : Scene
    {
        private Inventar_Fightscene Inventar_Fightscene;

        public View view;

        //Objekte und Variablen werden erstellt:

        //Avatar(Character)
        private Texture character_img;

        private Sprite character_sprite;

        //Enemy
        private Texture enemy_img;

        private Sprite enemy_sprite;

        //Buttons
        private Texture nahkampf_button_img;

        private Texture fernkampf_button_img;
        private Texture inventar_button_img;
        private Texture paper_img;
        private Texture inventar_paper_img;
        private Texture arrow_pointer_img;
        private Sprite nahkampf_button_sprite;
        private Sprite fernkampf_button_sprite;
        private Sprite inventar_button_sprite;
        private Sprite paper_sprite;
        private Sprite inventar_paper_sprite;
        private Sprite arrow_pointer_sprite;

        //Text
        private Text Nahkampf_Text;

        private Text Fernkampf_Text;
        private Text Inventar_Text;
        private Text Magic_Text;
        private Text Nachkampf_title_Text;
        private Text Fernkampf_title_Text;
        private Text HP_Text;
        private Text EnemyHP_Text;

        //Textbox
        private Texture textbox_img;

        private Sprite textbox_sprite;

        private Text missed_text;

        //Healthbar
        private Texture healthbar_img;

        private Sprite healthbar_sprite;

        private RectangleShape healthbar_rectangle;

        //Enemy Healthbar
        private Texture enemy_healthbar;

        private Sprite enemy_healthbar_sprite;

        private RectangleShape enemy_healthbar_rectangle;

        //SimpleArrow
        private Texture simpleArrow_img;

        private Sprite simpleArrow_sprite;

        // Fist
        private Texture fist_img;

        private Sprite fist_sprite;

        //SimpleSword
        private Texture simpleSword_img;

        private Sprite SimpleSword_sprite;

        //GoldenSword
        private Texture goldenSword_img;

        private Sprite goldenSword_sprite;

        //MagicBall
        private Texture magicBall_img;

        private Sprite magicBall_sprite;

        //Timer
        private Clock clock_EnemiesTurn;

        private Clock clock_SwordSlideIn;

        //Background
        private Texture background_img;

        private Sprite background_sprite;

        //Character & Enemy SlideIn Speed
        private float Speed = 1;

        //Character Stats
        public static int HP = 100;

        public static int healthLeft = 100;

        //Weapon Stats
        private int Attack_Fist = 5;

        private int Attack_SimpleSword = 20;

        private int Attack_GoldenSword = 1000;
        private int Attack_SimpleArrow = 20;

        private int Attack_Magic = 300;

        //Enemy Stats
        //Pokemon
        private int EnemyHP;

        private int enemyHealthLeft;
        private int EnemyAttack;

        //Handles whos turn it is
        private bool Characters_Turn = true;

        private bool Enemies_Turn = false;

        //Handles  if character got hit
        private bool HealthDown = false;

        private bool EnemiesHealthDown = false;

        //Handles which Attack-Typ is used
        private bool Nahkampf = false;

        private bool Fernkampf = false;

        //Handles which Weapon equipped
        public bool Fist_eqipped = true;

        public bool SimpleSword_equipped = false;

        public bool GoldenSword_equipped = false;

        public static bool SimpleArrow_equipped = false;

        public static bool Magic_equipped = false;

        //Handles start of Attack-Animation
        private bool Arrow_Start = false;

        private bool Fist_Start = false;
        private bool Sword_Start = false;
        private bool GoldenSword_Start = false;

        private bool MagicBall_Start = false;

        //Handles what Attack-Type and weapon got chosen ( + Inventar)
        private bool Nahkampf_Pressed = false;

        private bool Fernkampf_Pressed = false;
        private bool Inventar_Pressed = false;
        private bool Magic_Pressed = false;

        private bool Fist_Pressed = true;
        private bool SimpleSword_Pressed = false;
        private bool GoldenSword_Pressed = false;
        private bool SimpleArrow_Pressed = false;

        private bool Draw_Inventar = false;

        //Handles when character misses
        private bool Missed = false;

        //public static bool MissedMagic = true;

        private bool ShowTextBox = false;

        private bool Extended_Inventar;

        private Timer Timer;
        public static string SetEnemy;

        private bool Credits;

        public Fightscene(GameObject gameObject) : base(gameObject)
        {
            BackgroundColor = Color.Cyan;
        }

        public override void InitializeItems()

        {
            view = new View(new FloatRect(0, 0, 1920, 1080));
            //Objekte werden initialisiert und zugewiesen
            Inventar_Fightscene = new Inventar_Fightscene();
            //Character
            character_img = new Texture(/*"Resources/Character_Fightscene/.png"*/"Resources/Character_Fightscene/Devil.png");
            character_sprite = new Sprite(character_img);

            character_sprite.Position = new Vector2f(1600, 700);
            character_sprite.Scale = new Vector2f(.5f, .5f);
            //character_sprite.Scale = new Vector2f(.6f, .6f);

            //Enemy
            enemy_sprite = new Sprite(enemy_img);

            if (SetEnemy == "Bat")
            {
                enemy_img = new Texture("Resources/Character_Fightscene/Bat.png");
                enemy_sprite = new Sprite(enemy_img);
                enemy_sprite.Scale = new Vector2f(0.8f, 0.8f);
                Enemies_Turn = false;
                Characters_Turn = true;
                EnemyHP = 60;

                enemyHealthLeft = 60;
                EnemyAttack = 15;

                Missed = true;

                healthbar_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/healthbar.png");
                healthbar_sprite = new Sprite(healthbar_img);

                healthbar_sprite.Position = new Vector2f(50, 600);
                healthbar_sprite.Scale = new Vector2f(1f, 1f);
                healthbar_rectangle = new RectangleShape();
                healthbar_rectangle.TextureRect = new IntRect(0, 0, healthbar_sprite.TextureRect.Width * healthLeft / HP, healthbar_sprite.TextureRect.Height);
                healthbar_sprite.TextureRect = healthbar_rectangle.TextureRect;

                //  clock_SwordSlideIn +=
            }
            if (SetEnemy == "Cat")
            {
                enemy_img = new Texture("Resources/Character_Fightscene/Cat.png");
                enemy_sprite = new Sprite(enemy_img);
                enemy_sprite.Scale = new Vector2f(1.5f, 1.5f);
                Enemies_Turn = false;
                Characters_Turn = true;
                EnemyHP = 10;

                enemyHealthLeft = 10;
                EnemyAttack = 5;
                Missed = false;

                healthbar_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/healthbar.png");
                healthbar_sprite = new Sprite(healthbar_img);

                healthbar_sprite.Position = new Vector2f(50, 600);
                healthbar_sprite.Scale = new Vector2f(1f, 1f);
                healthbar_rectangle = new RectangleShape();
                healthbar_rectangle.TextureRect = new IntRect(0, 0, healthbar_sprite.TextureRect.Width * healthLeft / HP, healthbar_sprite.TextureRect.Height);
                healthbar_sprite.TextureRect = healthbar_rectangle.TextureRect;
            }

            if (SetEnemy == "SwordEnemy")
            {
                enemy_img = new Texture("Resources/Character_Fightscene/Warlock.png");
                enemy_sprite = new Sprite(enemy_img);
                enemy_sprite.Scale = new Vector2f(1f, 1f);
                Enemies_Turn = false;
                Characters_Turn = true;
                EnemyHP = 40;

                enemyHealthLeft = 40;
                EnemyAttack = 20;
                Missed = false;

                healthbar_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/healthbar.png");
                healthbar_sprite = new Sprite(healthbar_img);

                healthbar_sprite.Position = new Vector2f(50, 600);
                healthbar_sprite.Scale = new Vector2f(1f, 1f);
                healthbar_rectangle = new RectangleShape();
                healthbar_rectangle.TextureRect = new IntRect(0, 0, healthbar_sprite.TextureRect.Width * healthLeft / HP, healthbar_sprite.TextureRect.Height);
                healthbar_sprite.TextureRect = healthbar_rectangle.TextureRect;
            }

            if (SetEnemy == "FinalBoss")
            {
                enemy_img = new Texture("Resources/Character_Fightscene/Angel.png");
                enemy_sprite = new Sprite(enemy_img);
                enemy_sprite.Scale = new Vector2f(1f, 1f);
                Enemies_Turn = false;
                Characters_Turn = true;

                EnemyHP = 3000;

                enemyHealthLeft = 3000;
                EnemyAttack = 33;
                Missed = false;
                Credits = true;

                healthbar_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/healthbar.png");
                healthbar_sprite = new Sprite(healthbar_img);

                healthbar_sprite.Position = new Vector2f(50, 600);
                healthbar_sprite.Scale = new Vector2f(1f, 1f);
                healthbar_rectangle = new RectangleShape();
                healthbar_rectangle.TextureRect = new IntRect(0, 0, healthbar_sprite.TextureRect.Width * healthLeft / HP, healthbar_sprite.TextureRect.Height);
                healthbar_sprite.TextureRect = healthbar_rectangle.TextureRect;
            }

            if (SetEnemy == "Mage")
            {
                enemy_img = new Texture("Resources/Character_Fightscene/Wizard.png");
                enemy_sprite = new Sprite(enemy_img);
                enemy_sprite.Scale = new Vector2f(.5f, .5f);
                Enemies_Turn = false;
                Characters_Turn = true;

                EnemyHP = 600;

                enemyHealthLeft = 600;
                EnemyAttack = 30;
                Missed = false;

                healthbar_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/healthbar.png");
                healthbar_sprite = new Sprite(healthbar_img);

                healthbar_sprite.Position = new Vector2f(50, 600);
                healthbar_sprite.Scale = new Vector2f(1f, 1f);
                healthbar_rectangle = new RectangleShape();
                healthbar_rectangle.TextureRect = new IntRect(0, 0, healthbar_sprite.TextureRect.Width * healthLeft / HP, healthbar_sprite.TextureRect.Height);
                healthbar_sprite.TextureRect = healthbar_rectangle.TextureRect;
            }

            // enemy_sprite = new Sprite(enemy_img);
            enemy_sprite.Position = new Vector2f(0, 90);

            //SimpleArrow
            simpleArrow_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/arrow.png");
            simpleArrow_sprite = new Sprite(simpleArrow_img);

            //arrow_sprite.Position = new Vector2f(700, 300);
            simpleArrow_sprite.Scale = new Vector2f(.07f, .07f);

            // Fist
            fist_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/Fist.png");
            fist_sprite = new Sprite(fist_img);

            fist_sprite.Scale = new Vector2f(-.5f, .5f);
            //SimpleSword
            simpleSword_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/sword.png");
            SimpleSword_sprite = new Sprite(simpleSword_img);

            SimpleSword_sprite.Position = new Vector2f(1450, 150);
            SimpleSword_sprite.Scale = new Vector2f(.07f, .07f);
            //GoldenSword
            goldenSword_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/goldenSword.png");
            goldenSword_sprite = new Sprite(goldenSword_img);

            goldenSword_sprite.Position = new Vector2f(1450, 150);
            goldenSword_sprite.Scale = new Vector2f(.3f, .3f);
            //MagicBall
            magicBall_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/magic_ball.png");
            magicBall_sprite = new Sprite(magicBall_img);

            simpleArrow_sprite.Scale = new Vector2f(.1f, .1f);
            //Background
            background_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/Fight_Ground.png");
            background_sprite = new Sprite(background_img);

            background_sprite.Position = new Vector2f(character_sprite.Position.X, character_sprite.Position.Y);
            background_sprite.Scale = new Vector2f(3, 3);
            //Buttons
            //Button1
            nahkampf_button_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/Button.png");

            nahkampf_button_sprite = new Sprite(nahkampf_button_img);

            nahkampf_button_sprite.Position = new Vector2f(700, 700);
            nahkampf_button_sprite.Scale = new Vector2f(.7f, .7f);
            //Button2
            fernkampf_button_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/Button.png");

            fernkampf_button_sprite = new Sprite(fernkampf_button_img);

            fernkampf_button_sprite.Position = new Vector2f(700, 850);
            fernkampf_button_sprite.Scale = new Vector2f(.7f, .7f);
            //Button3
            inventar_button_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/Button.png");

            inventar_button_sprite = new Sprite(inventar_button_img);

            inventar_button_sprite.Position = new Vector2f(1200, 850);
            inventar_button_sprite.Scale = new Vector2f(.7f, .7f);

            //Paper
            paper_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/paper.jpg");

            paper_sprite = new Sprite(paper_img);
            paper_sprite.Position = new Vector2f(1350, 650);

            inventar_paper_sprite = new Sprite(paper_img);
            inventar_paper_sprite.Position = new Vector2f(1350 - inventar_paper_sprite.Texture.Size.X, 650);
            //   inventar_paper_sprite. = new Vector2f(5, 5);
            //     inventar_paper_sprite. = paper_sprite.Texture.Size.Y;

            //Arrow_Pointer
            arrow_pointer_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/Anzeigepfeil.png");

            arrow_pointer_sprite = new Sprite(arrow_pointer_img);

            arrow_pointer_sprite.Position = new Vector2f(1300, 755);
            arrow_pointer_sprite.Scale = new Vector2f(.3f, .3f);

            //inventar_arrow_pointer_sprite = new Sprite(arrow_pointer_img);
            //inventar_arrow_pointer_sprite.Position = new Vector2f()

            //Text
            //Buttons
            Font arial = new Font(@"Resources\arial.ttf");
            //Text Nahkampf_Button
            Nahkampf_Text = new Text("", arial);
            Nahkampf_Text.Position = new Vector2f();
            Nahkampf_Text.CharacterSize = 35;
            //Text Fernkampf_Button
            Fernkampf_Text = new Text("", arial);
            Fernkampf_Text.Position = new Vector2f();
            Fernkampf_Text.CharacterSize = 35;
            //Text Inventar_Button
            Inventar_Text = new Text("", arial);
            Inventar_Text.Position = new Vector2f();
            Inventar_Text.CharacterSize = 35;
            //Text Magic_Button
            Magic_Text = new Text("", arial);
            Magic_Text.Position = new Vector2f();
            Magic_Text.CharacterSize = 35;
            //Inventar-Buttons
            //Nahkampf-Title
            Nachkampf_title_Text = new Text("", arial);
            Nachkampf_title_Text.Position = new Vector2f();
            Nachkampf_title_Text.CharacterSize = 25;

            //Fernkampf-Title
            Fernkampf_title_Text = new Text("", arial);
            Fernkampf_title_Text.Position = new Vector2f();
            Fernkampf_title_Text.CharacterSize = 35;
            //HP
            //HP Character
            Font system = new Font(@"Resources\Capture_it.ttf");
            HP_Text = new Text("", system);
            HP_Text.Position = new Vector2f();
            HP_Text.CharacterSize = 40;
            HP_Text.Color = Color.Red;
            //HP Enemy
            EnemyHP_Text = new Text("", system);
            EnemyHP_Text.Position = new Vector2f();
            EnemyHP_Text.CharacterSize = 20;
            EnemyHP_Text.Color = Color.Black;

            //Textbox
            textbox_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/Textbox.jpeg");
            textbox_sprite = new Sprite(textbox_img);

            textbox_sprite.Position = new Vector2f(350, 650);
            textbox_sprite.Scale = new Vector2f(3, 3);

            missed_text = new Text("", system);
            missed_text.Position = new Vector2f();
            missed_text.CharacterSize = 35;
            missed_text.Color = Color.Black;

            Timer = new Timer();
            //Healthbar_img Character
            //healthbar_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/healthbar.png");
            //healthbar_sprite = new Sprite(healthbar_img);

            //healthbar_sprite.Position = new Vector2f(50, 600);
            //healthbar_sprite.Scale = new Vector2f(1f, 1f);
            //healthbar_rectangle = new RectangleShape();

            //Healthbar_img Enemies
            enemy_healthbar = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/healthbar.png");
            enemy_healthbar_sprite = new Sprite(enemy_healthbar);

            enemy_healthbar_sprite.Position = new Vector2f(1485, 20);
            enemy_healthbar_sprite.Scale = new Vector2f(1f, 1f);
            enemy_healthbar_rectangle = new RectangleShape();

            //Timer
            clock_EnemiesTurn = new Clock();
            clock_SwordSlideIn = new Clock();

            base.InitializeItems();
        }

        public override void HandleKeyPress(KeyEventArgs e)
        {
            //Nahkampf
            if (e.Code == Keyboard.Key.Return && Characters_Turn && healthLeft > 0 && Nahkampf_Pressed)
            {
                EnemiesHealthDown = true;
                Attack_SlideInMove();
                Characters_Turn = false;
                Nahkampf = true;
                Fist_Start = true;
                Sword_Start = true;
                GoldenSword_Start = true;
                if (Missed)
                    ShowTextBox = true;
                if (!Missed)
                {
                    Enemies_Turn = true;
                    clock_EnemiesTurn.Restart();
                }
                clock_SwordSlideIn.Restart();
                Timer.RestartTextboxTimer();
            }

            //Fernkampf
            if (e.Code == Keyboard.Key.Return && Characters_Turn && healthLeft > 0 && Fernkampf_Pressed && SimpleArrow_equipped)
            {
                EnemiesHealthDown = true;
                Attack_SlideInMove();
                Characters_Turn = false;
                Fernkampf = true;
                Arrow_Start = true;
                //if (Missed)
                //    ShowTextBox = true;
                //if (!Missed)
                //{
                Enemies_Turn = true;
                clock_EnemiesTurn.Restart();

                Timer.RestartTextboxTimer();
            }

            if (e.Code == Keyboard.Key.Return && Characters_Turn && Inventar_Pressed)
            {
                Draw_Inventar = true;
                Inventar_Pressed = false;
                MovePointerLeft();
            }
            //Equipp Items
            if (e.Code == Keyboard.Key.Return && Draw_Inventar && Fist_Pressed)
            {
                Inventar_Fightscene.Equipp_Fist();
                Fist_eqipped = true;
                SimpleSword_equipped = false;
                GoldenSword_equipped = false;
            }
            if (e.Code == Keyboard.Key.Return && Draw_Inventar && SimpleSword_Pressed)
            {
                Inventar_Fightscene.Equipp_SimpleSword();
                SimpleSword_equipped = true;
                Fist_eqipped = false;
                GoldenSword_equipped = false;
            }
            if (e.Code == Keyboard.Key.Return && Draw_Inventar && GoldenSword_Pressed)
            {
                Inventar_Fightscene.Equipp_GoldenSword();
                GoldenSword_equipped = true;
                Fist_eqipped = false;
                SimpleSword_equipped = false;
            }
            if (e.Code == Keyboard.Key.Return && Draw_Inventar && SimpleArrow_Pressed)
            {
                Inventar_Fightscene.SimpleArrow = true;
                SimpleArrow_equipped = true;
            }
            //Magic
            if (e.Code == Keyboard.Key.Return && Characters_Turn && Magic_Pressed && Magic_equipped)
            {
                EnemiesHealthDown = true;
                Attack_SlideInMove();
                Characters_Turn = false;
                MagicBall_Start = true;
                //if (MissedMagic)
                //    ShowTextBox = true;
                // if (!MissedMagic)
                //{
                Enemies_Turn = true;
                clock_EnemiesTurn.Restart();
                //}
                // Timer.RestartTextboxTimer();
            }

            //Move Pointer
            if (e.Code == Keyboard.Key.Down && !Magic_Pressed)
                MovePointerDown();
            if (e.Code == Keyboard.Key.Up && !Nahkampf_Pressed)
                MovePointerUp();
            //if (e.Code == Keyboard.Key.Left && Draw_Inventar && arrow_pointer_sprite.Position.X > 710)
            //    MovePointerLeft();
            if (Inventar_Fightscene.count == 1)
            {
                if (e.Code == Keyboard.Key.Down && Draw_Inventar &&/*arrow_pointer_sprite.Position.Y < 959*/ arrow_pointer_sprite.Position.Y + 15 < Inventar_Fightscene.unchecked_checkbox_list[0].Position.Y)
                    Inventar_MovePointerDown();
            }
            if (Inventar_Fightscene.count == 2)
            {
                if (e.Code == Keyboard.Key.Down && Draw_Inventar &&/*arrow_pointer_sprite.Position.Y < 959*/ arrow_pointer_sprite.Position.Y + 15 < Inventar_Fightscene.unchecked_checkbox_list[1].Position.Y)
                    Inventar_MovePointerDown();
            }
            if (Inventar_Fightscene.count >= 3 && !Extended_Inventar)
            {
                if (e.Code == Keyboard.Key.Down && Draw_Inventar &&/*arrow_pointer_sprite.Position.Y < 959*/ arrow_pointer_sprite.Position.Y + 15 < Inventar_Fightscene.unchecked_checkbox_list[2].Position.Y)
                    Inventar_MovePointerDown();
            }
            if (Inventar_Fightscene.count == 4 && Extended_Inventar)
            {
                if (e.Code == Keyboard.Key.Down && Draw_Inventar &&/*arrow_pointer_sprite.Position.Y < 959*/ arrow_pointer_sprite.Position.Y + 15 < Inventar_Fightscene.unchecked_checkbox_list[3].Position.Y)
                    Inventar_MovePointerDown();
            }
            if (Inventar_Fightscene.count == 5 && Extended_Inventar)
            {
                if (e.Code == Keyboard.Key.Down && Draw_Inventar &&/*arrow_pointer_sprite.Position.Y < 959*/ arrow_pointer_sprite.Position.Y + 15 < Inventar_Fightscene.unchecked_checkbox_list[4].Position.Y)
                    Inventar_MovePointerDown();
            }
            if (!Extended_Inventar && Draw_Inventar)
            {
                if (e.Code == Keyboard.Key.Up && Draw_Inventar && /*arrow_pointer_sprite.Position.Y > 719 */ arrow_pointer_sprite.Position.Y - 15 > Inventar_Fightscene.unchecked_checkbox_list[0].Position.Y)
                    Inventar_MovePointerUp();
            }

            if (Extended_Inventar)
            {
                if (e.Code == Keyboard.Key.Up && Draw_Inventar && arrow_pointer_sprite.Position.Y - 15 > Inventar_Fightscene.unchecked_checkbox_list[3].Position.Y)
                    Inventar_MovePointerUp();
            }
            if (e.Code == Keyboard.Key.Right && Inventar_Fightscene.count >= 4 && Draw_Inventar && !Extended_Inventar)
            {
                MovePointerRight();
                Extended_Inventar = true;
            }

            if (e.Code == Keyboard.Key.Escape)
            {
                MovePointerExitInventar();
                Extended_Inventar = false;
                Draw_Inventar = false;
            }
            if (e.Code == Keyboard.Key.Left && Extended_Inventar)
            {
                MovePointerLeft();
                Extended_Inventar = false;
            }

            //Textbox
            if (e.Code == Keyboard.Key.Return && ShowTextBox /*&& clock_SwordSlideIn.ElapsedTime.AsSeconds() >= 1*/ && Timer.GetTextboxClock >= 1)
            {
                ShowTextBox = false;
                Enemies_Turn = true;
                clock_EnemiesTurn.Restart();
            }

            //if (e.Code == Keyboard.Key.Escape)
            //{
            //    _gameObject.SceneManager.GetScene("OpenWorld").Resume();
            //    _gameObject.SceneManager.GetScene("OpenWorld").Reset();
            //    _gameObject.SceneManager.GotoScene("OpenWorld");
            //    _gameObject.SceneManager.GetScene("fight").Dispose();
            //}
        }

        public override void Update()
        {
            //if (healthLeft <= 0)
            //    Reset();

            Timer.Update();
            //Fightscene Logic
            Console.WriteLine(Credits);
            //          Console.WriteLine(arrow_pointer_sprite.Position.Y + "Pointer");
            //  Console.WriteLine(Inventar_Fightscene.simpleSword.Position.Y + "SimpleSword");
            //        Console.WriteLine(Inventar_Fightscene.simpleArrow.Position.Y + "SimpleArrow");
            //  Console.WriteLine(Inventar_Fightscene.goldenSword.Position.Y + "GoldenSword");
            //Background Movement
            if (!SlideInMove_character())
                background_sprite.Position = new Vector2f(character_sprite.Position.X - 130, character_sprite.Position.Y + 50);
            //Character Slide In
            if (SlideInMove_character())
                character_sprite.Position -= new Vector2f(15, 0) * Speed;

            //Enemy Slide In
            if (SlideInMove_enemy())
                enemy_sprite.Position += new Vector2f(15, 0) * Speed;

            //Character Slide Down (when dead)
            if (healthLeft <= 0)
                character_sprite.Position += new Vector2f(0, 50);
            if (character_sprite.Position.Y >= 5000)
            {
                MainCharacter.JustCounterForTimer = 0;
                MainCharacter.playerIsDead = true;
                _gameObject.SceneManager.StartScene("menu");
            }
            //Enemy Slide Down (when dead)
            if (enemyHealthLeft <= 0 && enemy_sprite.Position.Y <= 5500)
                enemy_sprite.Position += new Vector2f(0, 50);
            if (enemy_sprite.Position.Y >= 5500 && !Credits)
            {
                MainCharacter.JustCounterForTimer = 0;
                _gameObject.SceneManager.GetScene("OpenWorld").Resume();
                _gameObject.SceneManager.GetScene("OpenWorld").Reset();
                _gameObject.SceneManager.GotoScene("OpenWorld");
                _gameObject.SceneManager.CurrentScene.Dispose();
            }

            //Arrow Move
            if (Arrow_move())
                simpleArrow_sprite.Position += new Vector2f(20, -10);
            else
            {
                simpleArrow_sprite.Position = new Vector2f(650, 550);
                Arrow_Start = false;
            }
            //Fist Move
            if (Fist_move())
                fist_sprite.Position += new Vector2f(20, -10);
            else
            {
                fist_sprite.Position = new Vector2f(950, 400);
                Fist_Start = false;
            }
            //Sword Move
            //SimpleSword
            if (Sword_move() && SimpleSword_equipped)
                SimpleSword_sprite.Rotation += 2;
            else
            {
                SimpleSword_sprite.Rotation = 0;
                Sword_Start = false;
            }

            //GoldenSword Move
            if (GoldenSword_move() && GoldenSword_equipped)
                goldenSword_sprite.Rotation += 2;
            else
            {
                goldenSword_sprite.Rotation = 0;
                GoldenSword_Start = false;
            }

            //MagicBall Move
            if (Magic_move())
                magicBall_sprite.Position += new Vector2f(20, -10);
            else
            {
                magicBall_sprite.Position = new Vector2f(650, 550);
                MagicBall_Start = false;
            }
            //Handle which Attack-Type is active
            if (arrow_pointer_sprite.Position.Y == 755)
            {
                Nahkampf_Pressed = true;
                Fernkampf_Pressed = false;
                Magic_Pressed = false;
            }

            if (arrow_pointer_sprite.Position.Y == 812)
            {
                Fernkampf_Pressed = true;
                Nahkampf_Pressed = false;
                Inventar_Pressed = false;
            }
            if (arrow_pointer_sprite.Position.Y == 869)
            {
                Inventar_Pressed = true;
                Fernkampf_Pressed = false;
                Magic_Pressed = false;
            }
            if (arrow_pointer_sprite.Position.Y == 926)
            {
                Magic_Pressed = true;
                Inventar_Pressed = false;
            }
            if (arrow_pointer_sprite.Position.Y == Inventar_Fightscene.fist.Position.Y + 20 && Draw_Inventar && !Extended_Inventar)
            {
                Fist_Pressed = true;
                SimpleSword_Pressed = false;
                GoldenSword_Pressed = false;
                SimpleArrow_Pressed = false;
            }
            if (ItemsAndNpcs.SwordPicked)
            {
                if (arrow_pointer_sprite.Position.Y == Inventar_Fightscene.simpleSword.Position.Y + 20 && Draw_Inventar)
                {
                    SimpleSword_Pressed = true;
                    Fist_Pressed = false;
                    GoldenSword_Pressed = false;
                    SimpleArrow_Pressed = false;
                }
            }
            if (ItemsAndNpcs.GoldenSwordPicked)
            {
                if (/*arrow_pointer_sprite.Position.Y == 819*/arrow_pointer_sprite.Position.Y == Inventar_Fightscene.goldenSword.Position.Y + 20 && Draw_Inventar)
                {
                    GoldenSword_Pressed = true;
                    SimpleSword_Pressed = false;
                    SimpleArrow_Pressed = false;
                    Fist_Pressed = false;
                }
            }
            //  if (/*Inventar_Fightscene.unchecked_checkbox_list[0].Position + new Vector2f(-165, 15)*/arrow_pointer_sprite.Position.Y == Inventar_Fightscene.simpleSword.Position.Y)
            if (ItemsAndNpcs.BowPicked && Inventar_Fightscene.count < 4)
            {
                if (/*arrow_pointer_sprite.Position.Y == 986*/arrow_pointer_sprite.Position.Y == Inventar_Fightscene.simpleArrow.Position.Y + 20 && Draw_Inventar)
                {
                    SimpleArrow_Pressed = true;
                    GoldenSword_Pressed = false;
                    Fist_Pressed = false;
                    SimpleSword_Pressed = false;
                }
            }

            //Text
            string t1 = "Nahkampf [" + Attack_Fist + " SP]";
            if (Fist_eqipped) { t1 = "Nahkampf [" + Attack_Fist + " SP]"; }
            if (SimpleSword_equipped) { t1 = "Nahkampf [" + Attack_SimpleSword + " SP]"; }
            if (GoldenSword_equipped) { t1 = "Nahkampf [" + Attack_GoldenSword + " SP]"; }
            Nahkampf_Text.DisplayedString = t1;
            Nahkampf_Text.Position = new Vector2f(1500, 745);
            Nahkampf_Text.Color = Color.Black;

            string t2;
            if (SimpleArrow_equipped) { t2 = "Fernkampf [" + Attack_SimpleArrow + " SP]"; }
            else { t2 = "Bow not yet found"; }
            ;
            Fernkampf_Text.DisplayedString = t2;
            Fernkampf_Text.Position = new Vector2f(1500, 800);
            Fernkampf_Text.Color = Color.Black;

            string t3 = "HP " + healthLeft + " / " + HP;
            HP_Text.DisplayedString = t3;
            HP_Text.Position = new Vector2f(110, 530);

            string t4 = "HP " + enemyHealthLeft + " / " + EnemyHP;
            EnemyHP_Text.DisplayedString = t4;
            EnemyHP_Text.Position = new Vector2f(1600, 30);

            string t5 = "Inventar";
            Inventar_Text.DisplayedString = t5;
            Inventar_Text.Position = new Vector2f(1500, 855);
            Inventar_Text.Color = Color.Black;
            string t9;
            if (Magic_equipped) { t9 = "Magic Staff [" + Attack_Magic + "SP]"; }
            else { t9 = "Magic not usable"; }
            Magic_Text.DisplayedString = t9;
            Magic_Text.Position = new Vector2f(1500, 910);
            Magic_Text.Color = Color.Black;

            string t6 = "[X] Esc";
            Nachkampf_title_Text.DisplayedString = t6;
            Nachkampf_title_Text.Position = new Vector2f(770, 650);

            string t7 = "Fernkampf";
            Fernkampf_title_Text.DisplayedString = t7;
            Fernkampf_title_Text.Position = new Vector2f(770, 880);

            string t8 = "OH Damnit! You missed.";
            missed_text.DisplayedString = t8;
            missed_text.Position = new Vector2f(600, 850);

            //string t1 = "Nahkampf [A] [" + Attack_Nahkampf + " SP]";
            //Nahkampf_Text.DisplayedString = t1;
            //Nahkampf_Text.Position = new Vector2f(740, 745);

            //string t2 = "Fernkampf [D] [" + Attack_Fernkampf + " SP]";
            //Fernkampf_Text.DisplayedString = t2;
            //Fernkampf_Text.Position = new Vector2f(740, 895);

            //string t3 = "HP " + healthLeft + " / " + HP;
            //HP_Text.DisplayedString = t3;
            //HP_Text.Position = new Vector2f(110, 530);

            //string t4 = "HP " + enemyHealthLeft + " / " + EnemyHP;
            //EnemyHP_Text.DisplayedString = t4;
            //EnemyHP_Text.Position = new Vector2f(1600, 30);

            //string t5 = "Inventar";
            //Inventar_Text.DisplayedString = t5;
            //Inventar_Text.Position = new Vector2f(1250, 895);

            //Health
            //Character
            if (HealthDown)
            {
                CharacterHealthHandler();
                HealthDown = false;
            }
            //Enemies
            if (EnemiesHealthDown)
            {
                EnemyHealthHandler();
                EnemiesHealthDown = false;
            }

            //Timer (Enemies Turn)
            if (clock_EnemiesTurn.ElapsedTime.AsSeconds() >= 3 && Enemies_Turn && enemyHealthLeft > 0)
            {
                HealthDown = true;
                Enemy_Attack_SlideInMove();
                Enemies_Turn = false;
                Characters_Turn = true;
            }
            //Timer (SwordSlideIn)
            //if (clock_SwordSlideIn.ElapsedTime.AsSeconds() <= 1 )
            //{
            //    Sword_Time = true;
            //}
            //else
            //    Sword_Time = false;

            //Timer(TextboxTimer)
            //Timer.Update();
            if (Credits && enemy_sprite.Position.Y >= 5500)
                GotoCredits();
            //Draws
            _gameObject.Window.SetView(view);
            _gameObject.Window.Draw(background_sprite);
            _gameObject.Window.Draw(character_sprite);
            _gameObject.Window.Draw(enemy_sprite);
            //  _gameObject.Window.Draw(background_sprite);

            if (Draw_Inventar)
            {
                _gameObject.Window.Draw(inventar_paper_sprite);
                Inventar_Fightscene.Draw(_gameObject.Window);
                _gameObject.Window.Draw(Nachkampf_title_Text);
                //_gameObject.Window.Draw(Nachkampf_title_Text);
                //_gameObject.Window.Draw(Fernkampf_title_Text);
            }

            if (healthLeft > 0)
            {
                //_gameObject.Window.Draw(nahkampf_button_sprite);
                //_gameObject.Window.Draw(fernkampf_button_sprite);
                //_gameObject.Window.Draw(inventar_button_sprite);

                _gameObject.Window.Draw(paper_sprite);
                _gameObject.Window.Draw(arrow_pointer_sprite);
                _gameObject.Window.Draw(Nahkampf_Text);
                _gameObject.Window.Draw(Fernkampf_Text);
                _gameObject.Window.Draw(Inventar_Text);
                _gameObject.Window.Draw(Magic_Text);

                _gameObject.Window.Draw(healthbar_sprite);
                _gameObject.Window.Draw(HP_Text);
            }
            if (enemyHealthLeft > 0)
            {
                _gameObject.Window.Draw(enemy_healthbar_sprite);
                _gameObject.Window.Draw(EnemyHP_Text);
            }

            if (Arrow_Start)
                _gameObject.Window.Draw(simpleArrow_sprite);

            if (Fist_Start && Fist_eqipped)
                _gameObject.Window.Draw(fist_sprite);
            if (Sword_Start && SimpleSword_equipped)
                _gameObject.Window.Draw(SimpleSword_sprite);
            if (GoldenSword_Start && GoldenSword_equipped)
                _gameObject.Window.Draw(goldenSword_sprite);
            if (MagicBall_Start)
                _gameObject.Window.Draw(magicBall_sprite);

            if (ShowTextBox && (Missed /*|| MissedMagic*/))
            {
                _gameObject.Window.Draw(textbox_sprite);
                _gameObject.Window.Draw(missed_text);
            }
        }

        //Erstellte Methoden
        public override void Reset()
        {
            InitializeItems();
            base.Reset();
        }

        //Handles objects when to move

        public bool SlideInMove_character()
        {
            if (character_sprite.Position.X <= 1600 && character_sprite.Position.X >= 120)

                return true;

            return false;
        }

        public bool SlideInMove_enemy()
        {
            if (enemy_sprite.Position.X >= 0 && enemy_sprite.Position.X <= 1500)

                return true;

            return false;
        }

        public bool Arrow_move()
        {
            if (simpleArrow_sprite.Position.X >= 650 && simpleArrow_sprite.Position.X <= 1350 && Arrow_Start)
                return true;

            return false;
        }

        public bool Fist_move()
        {
            if (fist_sprite.Position.X >= 950 && fist_sprite.Position.X <= 1350 && Fist_Start)
                return true;

            return false;
        }

        public bool Sword_move()
        {
            if (SimpleSword_sprite.Rotation >= 0 && SimpleSword_sprite.Rotation < 31 && Sword_Start)
                return true;
            return false;
        }

        public bool GoldenSword_move()
        {
            if (goldenSword_sprite.Rotation >= 0 && goldenSword_sprite.Rotation < 31 && GoldenSword_Start)
                return true;
            return false;
        }

        public bool Magic_move()
        {
            if (magicBall_sprite.Position.X >= 650 && magicBall_sprite.Position.X <= 1350 && MagicBall_Start)
                return true;
            return false;
        }

        public void Attack_SlideInMove()
        {
            character_sprite.Position += new Vector2f(150, 0);
        }

        public void Enemy_Attack_SlideInMove()
        {
            enemy_sprite.Position -= new Vector2f(150, 0);
        }

        public void MovePointerDown()
        {
            if (!Draw_Inventar)
                arrow_pointer_sprite.Position += new Vector2f(0, 57);
        }

        public void MovePointerUp()
        {
            if (!Draw_Inventar)
                arrow_pointer_sprite.Position -= new Vector2f(0, 57);
        }

        public void Inventar_MovePointerDown()
        {
            if (Draw_Inventar)
                arrow_pointer_sprite.Position += new Vector2f(0, 100);
            //if (Draw_Inventar && arrow_pointer_sprite.Position.Y > 819)
            //    arrow_pointer_sprite.Position += new Vector2f(0, 40);
        }

        public void Inventar_MovePointerUp()
        {
            if (Draw_Inventar)
                arrow_pointer_sprite.Position -= new Vector2f(0, 100);
            //if (Draw_Inventar && arrow_pointer_sprite.Position.Y > 819)
            //    arrow_pointer_sprite.Position -= new Vector2f(0, 40);
        }

        public void MovePointerLeft()
        {
            if (Draw_Inventar)
                //arrow_pointer_sprite.Position -= new Vector2f(590, 150);
                arrow_pointer_sprite.Position = Inventar_Fightscene.unchecked_checkbox_list[0].Position + new Vector2f(-165, 15);
        }

        public void MovePointerRight()
        {
            if (Draw_Inventar)
                arrow_pointer_sprite.Position = Inventar_Fightscene.unchecked_checkbox_list[3].Position + new Vector2f(-165, 15);
        }

        public void MovePointerExitInventar()
        {
            if (Draw_Inventar)
            {
                arrow_pointer_sprite.Position = new Vector2f(1300, 869);
                Draw_Inventar = false;
            }
        }

        //Handles Health

        public void DecreaseHealth()
        {
            healthLeft -= EnemyAttack;
        }

        public void DecreaseEnemyHealth()
        {
            if (Nahkampf && !Missed)
            {
                if (Fist_eqipped)
                {
                    enemyHealthLeft -= Attack_Fist;
                    Nahkampf = false;
                }
                if (SimpleSword_equipped)
                {
                    enemyHealthLeft -= Attack_SimpleSword;
                    Nahkampf = false;
                }
                if (GoldenSword_equipped)
                {
                    enemyHealthLeft -= Attack_GoldenSword;
                    Nahkampf = false;
                }
            }
            if (SimpleArrow_equipped && Fernkampf)
            {
                enemyHealthLeft -= Attack_SimpleArrow;
                Fernkampf = false;
            }
            if (MagicBall_Start /*&& !MissedMagic*/)
            {
                enemyHealthLeft -= Attack_Magic;
            }
        }

        public void CharacterHealthHandler()
        {
            DecreaseHealth();

            healthbar_rectangle.TextureRect = new IntRect(0, 0, healthbar_sprite.TextureRect.Width * healthLeft / HP, healthbar_sprite.TextureRect.Height);
            healthbar_sprite.TextureRect = healthbar_rectangle.TextureRect;
        }

        public void EnemyHealthHandler()
        {
            DecreaseEnemyHealth();

            enemy_healthbar_rectangle.TextureRect = new IntRect(0, 0, enemy_healthbar_sprite.TextureRect.Width * enemyHealthLeft / EnemyHP, enemy_healthbar_sprite.TextureRect.Height);
            enemy_healthbar_sprite.TextureRect = enemy_healthbar_rectangle.TextureRect;
        }

        public void GotoCredits()
        {
            _gameObject.SceneManager.StartScene("credits");
        }

        //static void SetEnemy(string enemyName)
        //{
        //    if (enemyName == "Pokemon")
        //        CurrentEnemy = _Enemy._pokemon;
        //    if (enemyName == "Bird")
        //        CurrentEnemy = _Enemy._bird;

        //}
    }
}
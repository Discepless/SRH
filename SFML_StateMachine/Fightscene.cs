using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace StateMachine
{
    public class Fightscene : Scene
    {//Objekte und Variablen werden erstellt:
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
        private Texture arrow_pointer_img;
        private Sprite nahkampf_button_sprite;
        private Sprite fernkampf_button_sprite;
        private Sprite inventar_button_sprite;
        private Sprite paper_sprite;
        private Sprite arrow_pointer_sprite;
        //Text
        private Text Nahkampf_Text;

        private Text Fernkampf_Text;
        private Text Inventar_Text;
        private Text HP_Text;
        private Text EnemyHP_Text;

        //Healthbar
        private Texture healthbar_img;

        private Sprite healthbar_sprite;

        private RectangleShape healthbar_rectangle;

        //Enemy Healthbar
        private Texture enemy_healthbar;

        private Sprite enemy_healthbar_sprite;

        private RectangleShape enemy_healthbar_rectangle;

        //Arrow
        private Texture arrow_img;

        private Sprite arrow_sprite;

        //Sword
        private Texture sword_img;

        private Sprite sword_sprite;

        //Timer
        private Clock clock_EnemiesTurn;

        private Clock clock_SwordSlideIn;

        //Character & Enemy SlideIn Speed
        private float Speed = 1;

        //Character Stats
        private int HP = 100;

        private int healthLeft = 100;
        private int Attack_Nahkampf = 20;
        private int Attack_Fernkampf = 10;

        //Enemy Stats
        private int EnemyHP = 70;

        private int enemyHealthLeft = 70;
        private int EnemyAttack = 25;

        //Handles whos turn it is
        private bool Characters_Turn = true;

        private bool Enemies_Turn = false;

        //Handles  if character got hit
        private bool HealthDown = false;

        private bool EnemiesHealthDown = false;

        //Handles which Attack-Typ is used
        private bool Nahkampf = false;

        private bool Fernkampf = false;

        //Handles start of Attack-Animation
        private bool Arrow_Start = false;

        private bool Sword_Start = false;
        private bool Sword_Time = false;

    public Fightscene(GameObject gameObject) : base(gameObject)
        {
            BackgroundColor = Color.White;
        }

    public override void Initialize()
        {//Objekte werden initialisiert und zugewiesen
            //Character
            character_img = new Texture("Resources/Character_Fightscene/Character_fight.png");
            character_sprite = new Sprite(character_img);

            character_sprite.Position = new Vector2f(1600, 700);
            character_sprite.Scale = new Vector2f(.6f, .6f);

            //Enemy
            enemy_img = new Texture("Resources/Character_Fightscene/Enemy_fight.png");
            enemy_sprite = new Sprite(enemy_img);

            enemy_sprite.Position = new Vector2f(0, 90);
            enemy_sprite.Scale = new Vector2f(1f, 1f);

            //Arrow
            arrow_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/arrow.jpg");
            arrow_sprite = new Sprite(arrow_img);

            //arrow_sprite.Position = new Vector2f(700, 300);
            arrow_sprite.Scale = new Vector2f(.07f, .07f);

            //Sword
            sword_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/sword.png");
            sword_sprite = new Sprite(sword_img);

            sword_sprite.Position = new Vector2f(1450, 150);
            sword_sprite.Scale = new Vector2f(.07f, .07f);

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

            //Arrow_Pointer
            arrow_pointer_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/Anzeigepfeil.png");
            arrow_pointer_sprite = new Sprite(arrow_pointer_img);

            arrow_pointer_sprite.Position = new Vector2f(1300, 755);
            arrow_pointer_sprite.Scale = new Vector2f(.3f, .3f);
            //Text
            //Buttons
            Font arial = new Font(@"Resources\arial.ttf");
            //Text Nahkampf_Button
            Nahkampf_Text = new Text("", arial);
            Nahkampf_Text.Position = new Vector2f(0, 0);
            Nahkampf_Text.CharacterSize = 35;
            //Text Fernkampf_Button
            Fernkampf_Text = new Text("", arial);
            Fernkampf_Text.Position = new Vector2f(0, 0);
            Fernkampf_Text.CharacterSize = 35;
            //Text Inventar_Button
            Inventar_Text = new Text("", arial);
            Inventar_Text.Position = new Vector2f(0, 0);
            Inventar_Text.CharacterSize = 35;

            //HP
            //HP Character
            Font system = new Font(@"Resources\Capture_it.ttf");
            HP_Text = new Text("", system);
            HP_Text.Position = new Vector2f(0, 0);
            HP_Text.CharacterSize = 40;
            HP_Text.Color = Color.Red;
            //HP Enemy
            EnemyHP_Text = new Text("", system);
            EnemyHP_Text.Position = new Vector2f(0, 0);
            EnemyHP_Text.CharacterSize = 20;
            EnemyHP_Text.Color = Color.Black;

            //Healthbar_img Character
            healthbar_img = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/healthbar.png");
            healthbar_sprite = new Sprite(healthbar_img);

            healthbar_sprite.Position = new Vector2f(50, 600);
            healthbar_sprite.Scale = new Vector2f(1f, 1f);
            healthbar_rectangle = new RectangleShape();

            //Healthbar_img Enemies
            enemy_healthbar = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/healthbar.png");
            enemy_healthbar_sprite = new Sprite(enemy_healthbar);

            enemy_healthbar_sprite.Position = new Vector2f(1485, 20);
            enemy_healthbar_sprite.Scale = new Vector2f(1f, 1f);
            enemy_healthbar_rectangle = new RectangleShape();

            //Timer
            clock_EnemiesTurn = new Clock();
            clock_SwordSlideIn = new Clock();

            base.Initialize();
        }

        public override void HandleKeyPress(KeyEventArgs e)
        {
            //Nahkampf
            if (e.Code == Keyboard.Key.A && Characters_Turn && healthLeft > 0)
            {
             //   arrow_pointer_sprite.Position.Y += 50; 
                EnemiesHealthDown = true;
                Attack_SlideInMove();
                Characters_Turn = false;
                Enemies_Turn = true;
                Nahkampf = true;
                Sword_Start = true;
                clock_EnemiesTurn.Restart();
                clock_SwordSlideIn.Restart();
            }

            //Fernkampf
            if (e.Code == Keyboard.Key.D && Characters_Turn && healthLeft > 0)
            {
                EnemiesHealthDown = true;
                Attack_SlideInMove();
                Enemies_Turn = true;
                Characters_Turn = false;
                Fernkampf = true;
                Arrow_Start = true;
                clock_EnemiesTurn.Restart();
            }
            if (e.Code == Keyboard.Key.Escape)
                _gameObject.SceneManager.StartScene("OpenWorld");
        }

        public override void Update()
        {//Fightscene Logic
            //   Console.WriteLine(clock_SwordSlideIn.ElapsedTime.AsSeconds());
            //   Console.WriteLine(Sword_Start);
            Console.WriteLine(enemy_sprite.Position.Y);
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
                _gameObject.SceneManager.StartScene("main");

            //Enemy Slide Down (when dead)
            if (enemyHealthLeft <= 0)
                enemy_sprite.Position += new Vector2f(0, 50);
            if (enemy_sprite.Position.Y >= 5500)
                _gameObject.SceneManager.StartScene("OpenWorld");

            //Arrow Move
            if (Arrow_move())
                arrow_sprite.Position += new Vector2f(20, -10);
            else
            {
                arrow_sprite.Position = new Vector2f(650, 550);
                Arrow_Start = false;
            }

            //Sword Move
            if (Sword_move())
                sword_sprite.Rotation += 2;
            else
            {
                sword_sprite.Rotation = 0;
                Sword_Start = false;
            }

            //Text
            string t1 = "Nahkampf [A] [" + Attack_Nahkampf + " SP]";
            Nahkampf_Text.DisplayedString = t1;
            Nahkampf_Text.Position = new Vector2f(1500, 745);

            string t2 = "Fernkampf [D] [" + Attack_Fernkampf + " SP]";
            Fernkampf_Text.DisplayedString = t2;
            Fernkampf_Text.Position = new Vector2f(1500, 800);

            string t3 = "HP " + healthLeft + " / " + HP;
            HP_Text.DisplayedString = t3;
            HP_Text.Position = new Vector2f(110, 530);

            string t4 = "HP " + enemyHealthLeft + " / " + EnemyHP;
            EnemyHP_Text.DisplayedString = t4;
            EnemyHP_Text.Position = new Vector2f(1600, 30);

            string t5 = "Inventar";
            Inventar_Text.DisplayedString = t5;
            Inventar_Text.Position = new Vector2f(1500, 855);
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
            if (clock_SwordSlideIn.ElapsedTime.AsSeconds() <= 1)
            {
                Sword_Time = true;
            }
            else
                Sword_Time = false;
            //Draws
            _gameObject.Window.Draw(character_sprite);
            _gameObject.Window.Draw(enemy_sprite);

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
                _gameObject.Window.Draw(healthbar_sprite);
                _gameObject.Window.Draw(HP_Text);
            }
            if (enemyHealthLeft > 0)
            {
                _gameObject.Window.Draw(enemy_healthbar_sprite);
                _gameObject.Window.Draw(EnemyHP_Text);
            }

            if (Arrow_Start)
                _gameObject.Window.Draw(arrow_sprite);

            if (/*Sword_Start*/Sword_Time)
                _gameObject.Window.Draw(sword_sprite);
        }

        //Erstellte Methoden

        //Handles objects when to move

        public bool SlideInMove_character()
        {
            if (character_sprite.Position.X <= 1600 && character_sprite.Position.X >= 50)

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
            if (arrow_sprite.Position.X >= 650 && arrow_sprite.Position.X <= 1350 && Arrow_Start)
                return true;

            return false;
        }

        public bool Sword_move()
        {
            if (sword_sprite.Rotation >= 0 && sword_sprite.Rotation < 31 && Sword_Start)
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

        //Handles Health

        public void DecreaseHealth()
        {
            healthLeft -= EnemyAttack;
        }

        public void DecreaseEnemyHealth()
        {
            if (Nahkampf)
            {
                enemyHealthLeft -= Attack_Nahkampf;
                Nahkampf = false;
            }
            if (Fernkampf)
            {
                enemyHealthLeft -= Attack_Fernkampf;
                Fernkampf = false;
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
    }
}
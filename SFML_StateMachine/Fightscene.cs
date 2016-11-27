using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using GameEngine;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private Texture attack_button_img;
        private Texture defend_button_img;
        private Sprite attack_button_sprite;
        private Sprite defend_button_sprite;

        //Text
        private Text Nahkampf_Text;
        private Text Fernkampf_Text;
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
        Clock clock_EnemiesTurn;
        Clock clock_SwordSlideIn;

        //Character & Enemy SlideIn Speed
        float Speed = 1;

        //Character Stats
        int HP = 100;
        int healthLeft = 100;
        int Attack_Nahkampf = 20;
        int Attack_Fernkampf = 10;

        //Enemy Stats
        int EnemyHP = 70;
        int enemyHealthLeft = 70;
        int EnemyAttack = 25;

        //Handles whos turn it is
        bool Characters_Turn = true;
        bool Enemies_Turn = false;

        //Handles  if character got hit
        bool HealthDown = false;
        bool EnemiesHealthDown = false;

        //Handles which Attack-Typ is used
        bool Nahkampf = false;
        bool Fernkampf = false;

        //Handles start of Attack-Animation
        bool Arrow_Start = false;
        bool Sword_Start = false;
        bool Sword_Time = false;

        public Fightscene(GameObject gameObject) : base(gameObject)
        {
            BackgroundColor = Color.White;

        }

        public override void Initialize()
        {//Objekte werden initialisiert und zugewiesen

            //Character
            character_img = new Texture("character_fight.png");
            character_sprite = new Sprite(character_img);

            character_sprite.Position = new Vector2f(650, 400);
            character_sprite.Scale = new Vector2f(.3f, .3f);

            //Enemy
            enemy_img = new Texture("Enemy.png");
            enemy_sprite = new Sprite(enemy_img);

            enemy_sprite.Position = new Vector2f(0, 70);
            enemy_sprite.Scale = new Vector2f(.5f, .5f);

            //Arrow
            arrow_img = new Texture("arrow.jpg");
            arrow_sprite = new Sprite(arrow_img);

            arrow_sprite.Position = new Vector2f(220, 200);
            arrow_sprite.Scale = new Vector2f(.07f, .07f);

            //Sword
            sword_img = new Texture("sword.png");
            sword_sprite = new Sprite(sword_img);

            sword_sprite.Position = new Vector2f(470, 100);
            sword_sprite.Scale = new Vector2f(.07f, .07f);

            //Buttons
                 //Button1
            attack_button_img = new Texture("Button.png");

            attack_button_sprite = new Sprite(attack_button_img);

            attack_button_sprite.Position = new Vector2f(350, 400);
            attack_button_sprite.Scale = new Vector2f(0.5f, 0.5f);
                 //Button2
            defend_button_img = new Texture("Button.png");

            defend_button_sprite = new Sprite(defend_button_img);

            defend_button_sprite.Position = new Vector2f(350, 490);
            defend_button_sprite.Scale = new Vector2f(0.5f, 0.5f);

            //Text
                //Buttons
            Font arial = new Font(@"Resources\arial.ttf");
                  //Text Nahkampf_Button
            Nahkampf_Text = new Text("", arial);
            Nahkampf_Text.Position = new Vector2f(0, 0);
            Nahkampf_Text.CharacterSize = 25;
                 //Text Fernkampf_Button
            Fernkampf_Text = new Text("", arial);
            Fernkampf_Text.Position = new Vector2f(0, 0);
            Fernkampf_Text.CharacterSize = 25;

            //HP
                  //HP Character
            Font system = new Font(@"Resources\Capture_it.ttf");
            HP_Text = new Text("", system);
            HP_Text.Position = new Vector2f(0, 0);
            HP_Text.CharacterSize = 20;
            HP_Text.Color = Color.Red;
                 //HP Enemy
            EnemyHP_Text = new Text("", system);
            EnemyHP_Text.Position = new Vector2f(0, 0);
            EnemyHP_Text.CharacterSize = 10;
            EnemyHP_Text.Color = Color.Black;

            //Healthbar_img
            healthbar_img = new Texture("healthbar.png");
            healthbar_sprite = new Sprite(healthbar_img);

            healthbar_sprite.Position = new Vector2f(10, 350);
            healthbar_sprite.Scale = new Vector2f(.5f, .5f);
            healthbar_rectangle = new RectangleShape();          

            //Healthbar Enemies
            enemy_healthbar = new Texture("healthbar.png");
            enemy_healthbar_sprite = new Sprite(enemy_healthbar);

            enemy_healthbar_sprite.Position = new Vector2f(565, 20);
            enemy_healthbar_sprite.Scale = new Vector2f(.5f, .5f);
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
        }

        public override void Update()
        {//Fightscene Logic

            Console.WriteLine(clock_SwordSlideIn.ElapsedTime.AsSeconds());
            Console.WriteLine(Sword_Start);
            Console.WriteLine(Sword_Time);
            //Character Slide In
            if (SlideInMove_character())
                character_sprite.Position -= new Vector2f(15, 0) * Speed;

            //Enemy Slide In
            if (SlideInMove_enemy())
                enemy_sprite.Position += new Vector2f(15, 0) * Speed;

            //Character Slide Down 
            if (healthLeft <= 0)
                character_sprite.Position += new Vector2f(0, 50);

            //Enemy Slide Down
            if (enemyHealthLeft <= 0)
                enemy_sprite.Position += new Vector2f(0, 50);

            //Arrow Move
            if (Arrow_move())
                arrow_sprite.Position += new Vector2f(10, -10);
            else
            {
                arrow_sprite.Position = new Vector2f(250, 300);
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
            Nahkampf_Text.Position = new Vector2f(378, 420);

            string t2 = "Fernkampf [D] [" + Attack_Fernkampf + " SP]";
            Fernkampf_Text.DisplayedString = t2;
            Fernkampf_Text.Position = new Vector2f(378, 510);

            string t3 = "HP " + healthLeft + " / " + HP;
            HP_Text.DisplayedString = t3;
            HP_Text.Position = new Vector2f(38, 320);

            string t4 = "HP " + enemyHealthLeft + " / " + EnemyHP;
            EnemyHP_Text.DisplayedString = t4;
            EnemyHP_Text.Position = new Vector2f(627, 24);

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
                _gameObject.Window.Draw(attack_button_sprite);
                _gameObject.Window.Draw(defend_button_sprite);
                _gameObject.Window.Draw(Nahkampf_Text);
                _gameObject.Window.Draw(Fernkampf_Text);
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

            if (character_sprite.Position.X <= 650 && character_sprite.Position.X >= 30)

                return true;


            return false;

        }

        public bool SlideInMove_enemy()
        {
            if (enemy_sprite.Position.X >= 0 && enemy_sprite.Position.X <= 580)

                return true;

            return false;
        }

        public bool Arrow_move()
        {
            if (arrow_sprite.Position.X >= 250 && arrow_sprite.Position.X <= 450 && Arrow_Start)
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
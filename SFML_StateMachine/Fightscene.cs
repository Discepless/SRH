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
    {
        //Character
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
        private Text Nachkampf_Text;
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
        bool arrow_visible = false;
        //Timer
        Clock clock;


        float Speed = 1;

        int HP = 100;
        int EnemyHP = 70;
        int healthLeft = 100;
        int enemyHealthLeft = 70;
        int Attack_Nahkampf = 20;
        int EnemyAttack = 25;
        int Attack_Fernkampf = 10;

        bool Charcters_Turn = true;
        bool Enemies_Turn = false;

        bool HealthDown = false;
        bool EnemiesHealthDown = false;

        bool Nahkampf = false;
        bool Fernkampf = false;

        bool Arrow_Start = false;

        public Fightscene(GameObject gameObject) : base(gameObject)
        {
            this.BackgroundColor = Color.White;

        }

        public override void Initialize()
        {
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
            //Text Attack_Button
            Nachkampf_Text = new Text("", arial);

            Nachkampf_Text.Position = new Vector2f(0, 0);

            Nachkampf_Text.CharacterSize = 25;

            //Text Defend_Button
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

            //Healthbar
            healthbar_img = new Texture("healthbar.png");
            healthbar_sprite = new Sprite(healthbar_img);

            healthbar_sprite.Position = new Vector2f(10, 350);
            healthbar_sprite.Scale = new Vector2f(.5f, .5f);

            healthbar_rectangle = new RectangleShape();
            // healthbar_rectangle.TextureRect = new IntRect(0, 0, healthbar_sprite.TextureRect.Width * health / 3, healthbar_sprite.TextureRect.Height);

            //Healthbar Enemies
            enemy_healthbar = new Texture("healthbar.png");
            enemy_healthbar_sprite = new Sprite(enemy_healthbar);

            enemy_healthbar_sprite.Position = new Vector2f(565, 20);
            enemy_healthbar_sprite.Scale = new Vector2f(.5f, .5f);

            enemy_healthbar_rectangle = new RectangleShape();

            //Timer
            clock = new Clock();


            base.Initialize();
        }

        public override void HandleKeyPress(KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.A && Charcters_Turn && healthLeft > 0)
            {
                EnemiesHealthDown = true;
                Attack_SlideInMove();
                Charcters_Turn = false;
                Enemies_Turn = true;
                Nahkampf = true;
                clock.Restart();
            }
            if (e.Code == Keyboard.Key.D && Charcters_Turn && healthLeft > 0)
            {
                // HealthHandler();
                EnemiesHealthDown = true;
                Attack_SlideInMove();
                Enemies_Turn = true;
                Charcters_Turn = false;
                Fernkampf = true;
                Arrow_Start = true;
                clock.Restart();
            }
        }

        public override void Update()
        {
            Console.WriteLine(healthLeft);
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
            if (arrow_sprite.Position.X >= 300)
            {
                arrow_sprite.Position = new Vector2f(220, 200);
                arrow_visible = false;
                Arrow_Start = false;
            }
            //Text
            string t1 = "Nahkampf [A] [" + Attack_Nahkampf + " SP]";
            Nachkampf_Text.DisplayedString = t1;
            Nachkampf_Text.Position = new Vector2f(/*button_sprite.Position.X, button_sprite.Position.Y*/378, 420);
            Nachkampf_Text.Draw(_gameObject.Window, RenderStates.Default);

            string t2 = "Fernkampf [D] [" + Attack_Fernkampf + " SP]";
            Fernkampf_Text.DisplayedString = t2;
            Fernkampf_Text.Position = new Vector2f(378, 510);
            //Defend_Text.Draw(_gameObject.Window, RenderStates.Default);

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
            if (clock.ElapsedTime.AsSeconds() >= 2 && Enemies_Turn && enemyHealthLeft > 0)
            {
                HealthDown = true;
                Enemy_Attack_SlideInMove();
                Enemies_Turn = false;
                Charcters_Turn = true;
            }



            //Draws
            _gameObject.Window.Draw(character_sprite);
            _gameObject.Window.Draw(enemy_sprite);

            if (healthLeft > 0)
            {
                _gameObject.Window.Draw(attack_button_sprite);
                _gameObject.Window.Draw(defend_button_sprite);
                _gameObject.Window.Draw(Nachkampf_Text);
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

        }

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
            if (arrow_sprite.Position.X >= 220 && arrow_sprite.Position.X <= 300 && Arrow_Start)
                return true;

            return false;
        }

        public void Attack_SlideInMove()
        {
            character_sprite.Position += new Vector2f(150, 0);
        }

        //public void Arrow_SlideInMove()
        //{
        //    arrow_sprite.Position += new Vector2f(120, 120);
        //}

        public void Enemy_Attack_SlideInMove()
        {
            enemy_sprite.Position -= new Vector2f(150, 0);
        }



        public void DecreaseHealth()
        {
            healthLeft -= EnemyAttack;
            // HP -= Defense;

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
            //enemyhealth -= Attack;
            //EnemyHP -= Attack;
        }
        public void CharacterHealthHandler()
        {

            // attackcooldown -= clock.ElapsedTime.AsMilliseconds() / 1000f;

            // if (attackcooldown <= 5)
            //{
            DecreaseHealth();

            //}
            // attackcooldown = 5f;
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
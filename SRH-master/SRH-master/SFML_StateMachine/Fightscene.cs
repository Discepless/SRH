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
        private Text Fight_Text;
        private Text Defend_Text;
        //Healthbar
        private Texture healthbar_img;
        private Sprite healthbar_sprite;

        private RectangleShape healthbar_rectangle;
        int health = 3;
        // Fight_Buttons fight_buttons;
        //Enemy Healthbar
        private Texture enemy_healthbar;
        private Sprite enemy_healthbar_sprite;

        private RectangleShape enemy_healthbar_rectangle;
        int enemyhealth = 3;

        float Speed = 1;

        //RectangleShape Health_rectangle;

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
            Font arial = new Font(@"Resources\arial.ttf");
                //Text Attack_Button
            Fight_Text = new Text("", arial);

            Fight_Text.Position = new Vector2f(0, 0);

            Fight_Text.CharacterSize = 30;

            //Text Defend_Button
            Defend_Text = new Text("", arial);

            Defend_Text.Position = new Vector2f(0, 0);

            Defend_Text.CharacterSize = 30;

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


            base.Initialize();
        }

        public override void HandleKeyPress(KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.A)
            {
                DecreaseEnemyHealth();
                Attack_SlideInMove();
            }
            if (e.Code == Keyboard.Key.D)
            {
                DecreaseHealth();
                Defend_SlideInMove();
            }
        }

        public override void Update()
        {
            Console.WriteLine(healthbar_sprite.TextureRect.Width);
            //Character Slide In
                if (SlideInMove_character())
                    character_sprite.Position = character_sprite.Position - new Vector2f(15, 0) * Speed;

            //Enemy Slide In
            if (SlideInMove_enemy())
                enemy_sprite.Position = enemy_sprite.Position + new Vector2f(15, 0) * Speed;
                
           //Text
            string t1 = "Attack [A]";
            Fight_Text.DisplayedString = t1;
            Fight_Text.Position = new Vector2f(/*button_sprite.Position.X, button_sprite.Position.Y*/455,420);
            Fight_Text.Draw(_gameObject.Window, RenderStates.Default);

            string t2 = "Defend [D]";
            Defend_Text.DisplayedString = t2;
            Defend_Text.Position = new Vector2f(455, 510);
            //Defend_Text.Draw(_gameObject.Window, RenderStates.Default);

            //Update Health Bar
            healthbar_rectangle.TextureRect = new IntRect(0, 0, healthbar_sprite.TextureRect.Width * health / 3, healthbar_sprite.TextureRect.Height);
            healthbar_sprite.TextureRect = healthbar_rectangle.TextureRect;
             

            //Update Enemy Healthbar
            enemy_healthbar_rectangle.TextureRect = new IntRect(0, 0, enemy_healthbar_sprite.TextureRect.Width * (enemyhealth / 3), enemy_healthbar_sprite.TextureRect.Height);
            enemy_healthbar_sprite.TextureRect = enemy_healthbar_rectangle.TextureRect;


            //Draws
            _gameObject.Window.Draw(character_sprite);
            _gameObject.Window.Draw(enemy_sprite);
            _gameObject.Window.Draw(healthbar_sprite);
            _gameObject.Window.Draw(enemy_healthbar_sprite);
            _gameObject.Window.Draw(attack_button_sprite);
            _gameObject.Window.Draw(defend_button_sprite);
            _gameObject.Window.Draw(Fight_Text);
            _gameObject.Window.Draw(Defend_Text);
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

        public void Attack_SlideInMove()
        {
            character_sprite.Position = character_sprite.Position + new Vector2f(150, 0);
        }

        public void Defend_SlideInMove()
        {
            enemy_sprite.Position = enemy_sprite.Position - new Vector2f(150, 0);
        }
        public void DecreaseHealth()
        {
            health--;
        }
        public void DecreaseEnemyHealth()
        {
            enemyhealth--;
        }
        

    }
}
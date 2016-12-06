using System;
using GameEngine;
using GameplayWorld_DM;
using SFML.Graphics;
using SFML.Window;

namespace SFML_StateMachine
{
    internal class MainCharacter : AnimatedCharacter
    {
        private Map map;
        private IntRect PlayerRectangle;
        

        // Caching our Previos direction (Needed for Collisions)
        private float cachedDirection;

        public MainCharacter(Map map) : base("Resources/Characters/SailorMoon.png", 32,48)
        {
            AnimDown = new Animation(0, 0, 4);
            AnimRight = new Animation(96, 0, 4);
            AnimLeft = new Animation(48, 0, 4);
            AnimUp = new Animation(144, 0, 4);

            Xpos = 100;
            Ypos = 100;
             
            moveSpeed = 150;
            animationSpeed = 0.1f;
            
            this.map = map;
        }

        public override void Update(float deltaTime)
        {
           
            //PlayerRectangle = new SFML.System.Vector2f(Xpos, Ypos);
            PlayerRectangle = new IntRect((int)Xpos, (int)Ypos, 32, 48);
            this.CurrentState = MoveDirection.None;

            
            // KAPUTT! :<
            if (PlayerRectangle.Intersects(this.map.MyScene.myEnemy.EnemyRectangle))
            {
                Console.WriteLine("Intersected with Enemy");
                //map.MyScene.gameObject.SceneManager.StartScene("OpenWorld");
            }
         
            // 1 North, 2 East , 3 South, 4 West  Collision with the Walls

            foreach (var collisionrect in map.CollisionRectangleShapes)
            {               
                if ((PlayerRectangle.Left + PlayerRectangle.Width >= collisionrect.Left) &&
                    (PlayerRectangle.Left <= collisionrect.Left + collisionrect.Width) &&
                    (PlayerRectangle.Top + PlayerRectangle.Height >= collisionrect.Top) &&
                    (PlayerRectangle.Top <= collisionrect.Top + collisionrect.Height))
                {
                    if (cachedDirection == 1)
                    {
                        Ypos = Ypos + 2.5f;
                    }

                    if (cachedDirection == 2)
                    {
                        Ypos = Ypos - 2.5f;
                    }

                    if (cachedDirection == 3)
                    {
                        Xpos = Xpos + 2.5f;
                    }

                    if (cachedDirection == 4)
                    {
                        Xpos = Xpos - 2.5f;
                    }

                }
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                this.CurrentState = MoveDirection.MoveNorth;
                cachedDirection = 1;

            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                this.CurrentState = MoveDirection.MoveSouth;
                cachedDirection = 2;         
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                this.CurrentState = MoveDirection.MoveWest;
                cachedDirection = 3;              
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                this.CurrentState = MoveDirection.MoveEast;
                cachedDirection = 4;

            }
            base.Update(deltaTime);
        }
    }
}
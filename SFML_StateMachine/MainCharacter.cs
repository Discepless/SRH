using System;
using GameplayWorld_DM;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_StateMachine
{
    internal class MainCharacter : AnimatedCharacter
    {
        private Map collisionObject;
        private RectangleShape PlayerRectangle;

        public MainCharacter(Map map) : base("Resources/Characters/SailorMoon.png", 32)
        {
            AnimDown = new Animation(0, 0, 4);
            AnimRight = new Animation(96, 0, 4);
            AnimLeft = new Animation(48, 0, 4);
            AnimUp = new Animation(144, 0, 4);
             
            moveSpeed = 150;
            animationSpeed = 0.1f;

            collisionObject = map;

            PlayerRectangle = new RectangleShape();
            PlayerRectangle.TextureRect = new IntRect(0, 0, 32, 48);
           

        }

        public override void Update(float deltaTime)
        {
            PlayerRectangle.Position = new Vector2f(Xpos, Ypos);

            this.CurrentState = MoveDirection.None;

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                this.CurrentState = MoveDirection.MoveNorth;

             //   if (PlayerRectangle.TextureRect.Intersects(collisionObject.CollisionRectangleShapes.)

              //  foreach (var collisionsprite in collisionObject.CollisionRectangleShapes)
              //  {
              //      if (collisionsprite.TextureRect.Intersects(collisionsprite.TextureRect))
              //      {
              //          Console.WriteLine("Yay");
              //      }
              //  }
              //               
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                this.CurrentState = MoveDirection.MoveSouth;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                this.CurrentState = MoveDirection.MoveWest;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                this.CurrentState = MoveDirection.MoveEast;
            }
            base.Update(deltaTime);
        }
    }
}
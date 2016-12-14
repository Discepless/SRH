using System;
using System.Runtime.CompilerServices;
using GameplayWorld_DM;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_StateMachine
{

    internal class Cat : AnimatedCharacter
    {
        private Map collisionObject;
        public IntRect CatRect;

        // Caching our Previos direction (Needed for Collisions)
        private float cachedDirection;

        public Cat(Map map) : base("Resources/Characters/Cat.png", 32, 48)
        {
            AnimDown = new Animation(0, 0, 4);
            AnimRight = new Animation(64, 0, 4);
            AnimLeft = new Animation(32, 0, 4);
            AnimUp = new Animation(96, 0, 4);

            moveSpeed = 50;
            animationSpeed = 0.1f;

            Xpos = 448;
            Ypos = 774;

            collisionObject = map;
            this.CurrentState = MoveDirection.MoveWest;

        }

        public override void Update(float deltaTime)
        {           
            
            CatRect = new IntRect((int)Xpos, (int)Ypos, 32, 32);


            // 1 North, 2 South , 3 East, 4 West  Collision with the Walls

            foreach (var collisionrect in collisionObject.CollisionRectangleShapes)
            {

                if ((CatRect.Left + CatRect.Width >= collisionrect.Left) &&
                    (CatRect.Left <= collisionrect.Left + collisionrect.Width) &&
                    (CatRect.Top + CatRect.Height >= collisionrect.Top) &&
                    (CatRect.Top <= collisionrect.Top + collisionrect.Height) && CatRect.Left + CatRect.Width < collisionrect.Left + collisionrect.Width)
                {
                     this.CurrentState = MoveDirection.MoveWest;
                }

                if ((CatRect.Left + CatRect.Width >= collisionrect.Left) &&
                    (CatRect.Left <= collisionrect.Left + collisionrect.Width) &&
                    (CatRect.Top + CatRect.Height >= collisionrect.Top) &&
                    (CatRect.Top <= collisionrect.Top + collisionrect.Height) && CatRect.Left > collisionrect.Left)
                {
                    this.CurrentState = MoveDirection.MoveEast;
                }
                
            }        
            base.Update(deltaTime);
        }
    }
}

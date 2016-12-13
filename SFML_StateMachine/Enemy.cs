using System;
using GameplayWorld_DM;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_StateMachine
{

    internal class Enemy : AnimatedCharacter
    {
        private Map collisionObject;
        public IntRect EnemyRectangle;
        private Clock clock;
        private float PassedTime;

        // Caching our Previos direction (Needed for Collisions)
        private float cachedDirection;

        public Enemy(Map map) : base("Resources/Characters/Enemy.png", 96, 96)
        {
            AnimDown = new Animation(0, 0, 4);
            AnimRight = new Animation(192, 0, 4);
            AnimLeft = new Animation(96, 0, 4);
            AnimUp = new Animation(288, 0, 4);

            clock = new Clock();

            moveSpeed = 50;
            animationSpeed = 0.1f;

            Xpos = 449;
            Ypos = 1550;

            collisionObject = map;


        }

        public override void Update(float deltaTime)
        {           
            PassedTime = clock.ElapsedTime.AsSeconds();
            //EnemyRectangle = new SFML.System.Vector2f(Xpos, Ypos);
            EnemyRectangle = new IntRect((int)Xpos, (int)Ypos, 32, 48);
            this.CurrentState = MoveDirection.None;

            // 1 North, 2 East , 3 South, 4 West

            foreach (var collisionrect in collisionObject.CollisionRectangleShapes)
            {
                if ((EnemyRectangle.Left + EnemyRectangle.Width >= collisionrect.Left) &&
                    (EnemyRectangle.Left <= collisionrect.Left + collisionrect.Width) &&
                    (EnemyRectangle.Top + EnemyRectangle.Height >= collisionrect.Top) &&
                    (EnemyRectangle.Top <= collisionrect.Top + collisionrect.Height))
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

            if (PassedTime < 3)
            {
                this.CurrentState = MoveDirection.MoveNorth;
                cachedDirection = 1;

            }
            else if (3 < PassedTime && 6 > PassedTime)
            {
                this.CurrentState = MoveDirection.MoveSouth;
                cachedDirection = 2;
            }
            else if (6 < PassedTime && 9 > PassedTime)
            {
                this.CurrentState = MoveDirection.MoveWest;
                cachedDirection = 3;
            }
            else if (9 < PassedTime && 12 > PassedTime)
            {
                this.CurrentState = MoveDirection.MoveEast;
                cachedDirection = 4;
                clock.Restart();
            }
            base.Update(deltaTime);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameplayWorld_DM;
using SFML.Graphics;

namespace SFML_StateMachine.Enemies
{
    internal class EnemyKilledWithSword : AnimatedCharacter
    {
        private Map collisionObject;
        public IntRect EnemyKilledWithSwordRect;


        public EnemyKilledWithSword(Map map) : base("Resources/Characters/EnemyWithMelee.png", 32, 48)
        {
            AnimDown = new Animation(0, 0, 4);
            AnimRight = new Animation(96, 0, 4);
            AnimLeft = new Animation(48, 0, 4);
            AnimUp = new Animation(144, 0, 4);

            moveSpeed = 50;
            animationSpeed = 0.1f;

            Xpos = 734;
            Ypos = 763;

            collisionObject = map;
            this.CurrentState = MoveDirection.MoveSouth;

        }

        public override void Update(float deltaTime)
        {

            EnemyKilledWithSwordRect = new IntRect((int)Xpos, (int)Ypos, 32, 48);


            // 1 North, 2 South , 3 East, 4 West  Collision with the Walls

            foreach (var collisionrect in collisionObject.CollisionRectangleShapes)
            {

                if ((EnemyKilledWithSwordRect.Left + EnemyKilledWithSwordRect.Width >= collisionrect.Left) &&
                    (EnemyKilledWithSwordRect.Left <= collisionrect.Left + collisionrect.Width) &&
                    (EnemyKilledWithSwordRect.Top + EnemyKilledWithSwordRect.Height >= collisionrect.Top) &&
                    (EnemyKilledWithSwordRect.Top <= collisionrect.Top + collisionrect.Height) && EnemyKilledWithSwordRect.Top < collisionrect.Top)
                {
                    this.CurrentState = MoveDirection.MoveNorth;
                }

                if ((EnemyKilledWithSwordRect.Left + EnemyKilledWithSwordRect.Width >= collisionrect.Left) &&
                     (EnemyKilledWithSwordRect.Left <= collisionrect.Left + collisionrect.Width) &&
                     (EnemyKilledWithSwordRect.Top + EnemyKilledWithSwordRect.Height >= collisionrect.Top) &&
                     (EnemyKilledWithSwordRect.Top <= collisionrect.Top + collisionrect.Height) && EnemyKilledWithSwordRect.Top + EnemyKilledWithSwordRect.Height< collisionrect.Top + collisionrect.Height)
                {
                    this.CurrentState = MoveDirection.MoveNorth;
                }

            }
            base.Update(deltaTime);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GameplayWorld_DM;
using SFML.Graphics;

namespace SFML_StateMachine.Enemies
{
    internal class Mage : AnimatedCharacter
    {

        public IntRect MageRect;
        private Map collisionObject;

        // Caching our Previos direction (Needed for Collisions)

        public Mage(Map map) : base("Resources/Characters/Mage.png", 32, 56)
        {
            AnimDown = new Animation(0, 0, 4);
            AnimRight = new Animation(112, 0, 4);
            AnimLeft = new Animation(56, 0, 4);
            AnimUp = new Animation(168, 0, 4);

            moveSpeed = 50;
            animationSpeed = 0.1f;

            Xpos = 845;
            Ypos = 1140;

            this.CurrentState = MoveDirection.MoveWest;
            MageRect = new IntRect((int)Xpos, (int)Ypos, 32, 48);
            collisionObject = map;
        }

        public override void Update(float deltaTime)
        {
            MageRect = new IntRect((int)Xpos, (int)Ypos, 32, 32);



            // 1 North, 2 South , 3 East, 4 West  Collision with the Walls

            foreach (var collisionrect in collisionObject.CollisionRectangleShapes)
            {

                if ((MageRect.Left + MageRect.Width >= collisionrect.Left) &&
                    (MageRect.Left <= collisionrect.Left + collisionrect.Width) &&
                    (MageRect.Top + MageRect.Height >= collisionrect.Top) &&
                    (MageRect.Top <= collisionrect.Top + collisionrect.Height) && MageRect.Left + MageRect.Width < collisionrect.Left + collisionrect.Width)
                {
                    this.CurrentState = MoveDirection.MoveWest;
                }

                if ((MageRect.Left + MageRect.Width >= collisionrect.Left) &&
                    (MageRect.Left <= collisionrect.Left + collisionrect.Width) &&
                    (MageRect.Top + MageRect.Height >= collisionrect.Top) &&
                    (MageRect.Top <= collisionrect.Top + collisionrect.Height) && MageRect.Left > collisionrect.Left)
                {
                    this.CurrentState = MoveDirection.MoveEast;
                }

            }
            base.Update(deltaTime);
        }
    }
}

using SFML.Graphics;

namespace StateMachine
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
            MageRect = new IntRect((int) Xpos, (int) Ypos, 32, 48);
            collisionObject = map;
        }

        public override void Update(float deltaTime)
        {
            MageRect = new IntRect((int) Xpos, (int) Ypos, 32, 32);
            Collision();
            base.Update(deltaTime);
        }

        public void Collision()
        {
            foreach (var collisionrect in collisionObject.CollisionRectangleShapes)
            {
                if (MageRect.TouchTop(collisionrect))
                {
                }
                if (MageRect.TouchRight(collisionrect))
                {
                    this.CurrentState = MoveDirection.MoveEast;
                }
                if (MageRect.TouchLeft(collisionrect))
                {
                    this.CurrentState = MoveDirection.MoveWest;
                }
                if (MageRect.TouchBottom(collisionrect))
                {
                }
            }
        }
    }
}
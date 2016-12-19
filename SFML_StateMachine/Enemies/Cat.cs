using SFML.Graphics;

namespace StateMachine
{
    internal class Cat : AnimatedCharacter
    {
        private Map collisionObject;
        public IntRect CatRect;
        public static bool CatIsDead;

        /// <summary>
        /// Init for Cat
        /// </summary>
        /// <param name="map"></param>
        public Cat(Map map) : base("Resources/Characters/Cat.png", 32, 32)
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
            Collision();
            base.Update(deltaTime);
        }

        /// <summary>
        /// Collisions
        /// </summary>
        public void Collision()
        {
            foreach (var collisionrect in collisionObject.CollisionRectangleShapes)
            {
                if (CatRect.TouchTop(collisionrect))
                {
                }
                if (CatRect.TouchRight(collisionrect))
                {
                    this.CurrentState = MoveDirection.MoveEast;
                }
                if (CatRect.TouchLeft(collisionrect))
                {
                    this.CurrentState = MoveDirection.MoveWest;
                }
                if (CatRect.TouchBottom(collisionrect))
                {
                }
            }
        }
    }
}
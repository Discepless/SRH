using SFML.Graphics;

namespace StateMachine
{
    internal class EnemyKilledWithSword : AnimatedCharacter
    {
        private Map collisionObject;
        public IntRect EnemyKilledWithSwordRect;
        public static bool EnemyKilledWithSwordIsDead;

        public EnemyKilledWithSword(Map map) : base("Resources/Characters/EnemyWithMelee.png", 32, 48)
        {
            AnimDown = new Animation(0, 0, 4);
            AnimRight = new Animation(96, 0, 4);
            AnimLeft = new Animation(48, 0, 4);
            AnimUp = new Animation(144, 0, 4);

            moveSpeed = 50;
            animationSpeed = 0.1f;

            Xpos = 734;
            Ypos = 500;

            collisionObject = map;
            this.CurrentState = MoveDirection.MoveSouth;
        }

        public override void Update(float deltaTime)
        {
            EnemyKilledWithSwordRect = new IntRect((int)Xpos, (int)Ypos, 32, 48);

            Collision();
            base.Update(deltaTime);
        }

        public void Collision()
        {
            foreach (var collisionrect in collisionObject.CollisionRectangleShapes)
            {
                if (EnemyKilledWithSwordRect.TouchTop(collisionrect))
                {
                    this.CurrentState = MoveDirection.MoveNorth;
                }
                if (EnemyKilledWithSwordRect.TouchRight(collisionrect))
                {
                }
                if (EnemyKilledWithSwordRect.TouchLeft(collisionrect))
                {
                }
                if (EnemyKilledWithSwordRect.TouchBottom(collisionrect))
                {
                    this.CurrentState = MoveDirection.MoveSouth;
                }
            }
        }
    }
}
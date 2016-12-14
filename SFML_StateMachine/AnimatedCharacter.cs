using SFML.Graphics;
using SFML.System;
using System;

namespace StateMachine
{
    public enum MoveDirection
    {
        None,
        MoveEast,
        MoveWest,
        MoveNorth,
        MoveSouth
    }

    internal abstract class AnimatedCharacter
    {
        public float Xpos { get; set; }
        public float Ypos { get; set; }

        private Sprite _sprite;
        private IntRect _spriteRect;
        private int frameSizeWidth, frameSizeHeight;

        protected Animation AnimUp;
        protected Animation AnimDown;
        protected Animation AnimLeft;
        protected Animation AnimRight;

        public MoveDirection CurrentState { get; set; }

        //private MoveDirection MoveDirection;

        private Clock animationClock;
        protected float moveSpeed = 40;
        protected float animationSpeed = 0.1f;

        public AnimatedCharacter(String filename, int frameSizeWidth, int frameSizeHeight)
        {
            this.frameSizeWidth = frameSizeWidth;
            this.frameSizeHeight = frameSizeHeight;

            Texture myTexture = new Texture(filename);

            _spriteRect = new IntRect(0, 0, frameSizeWidth, frameSizeHeight);
            _sprite = new Sprite(myTexture, _spriteRect);

            //Setting the Animation set

            animationClock = new Clock();
        }

        public virtual void Update(float deltaTime)
        {
            Animation currentAnimation = null;

            switch (CurrentState)
            {
                case MoveDirection.MoveNorth:
                    currentAnimation = AnimUp;
                    Ypos -= moveSpeed * deltaTime;
                    break;

                case MoveDirection.MoveEast:
                    Xpos += moveSpeed * deltaTime;
                    currentAnimation = AnimRight;
                    break;

                case MoveDirection.MoveSouth:
                    Ypos += moveSpeed * deltaTime;
                    currentAnimation = AnimDown;
                    break;

                case MoveDirection.MoveWest:
                    Xpos -= moveSpeed * deltaTime;
                    currentAnimation = AnimLeft;
                    break;
            }

            _sprite.Position = new Vector2f(Xpos, Ypos);

            if (animationClock.ElapsedTime.AsSeconds() > animationSpeed)
            {
                if (currentAnimation != null)
                {
                    _spriteRect.Top = currentAnimation.offsetTop;

                    if (_spriteRect.Left == (currentAnimation.numFrames - 1) * frameSizeWidth)
                        _spriteRect.Left = 0;
                    else
                        _spriteRect.Left += frameSizeWidth;
                }
                animationClock.Restart();
            }
            _sprite.TextureRect = _spriteRect;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(_sprite);
        }
    }
}
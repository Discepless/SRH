using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameplayWorld_DM;
using SFML.Graphics;

namespace SFML_StateMachine.Enemies
{
    internal class Bat : AnimatedCharacter
    {

        public IntRect BatRect;

        // Caching our Previos direction (Needed for Collisions)
        private float cachedDirection;

        public Bat(Map map) : base("Resources/Characters/Bat.png", 32, 48)
        {
            AnimDown = new Animation(0, 0, 4);
            AnimRight = new Animation(64, 0, 4);
            AnimLeft = new Animation(32, 0, 4);
            AnimUp = new Animation(96, 0, 4);

            moveSpeed = 0;
            animationSpeed = 0.1f;

            Xpos = 2241;
            Ypos = 500;

            this.CurrentState = MoveDirection.MoveWest;
            BatRect = new IntRect((int)Xpos,(int)Ypos,32,48);
        }
    }

}

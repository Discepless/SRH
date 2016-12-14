﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameplayWorld_DM;
using SFML.Graphics;

namespace SFML_StateMachine.Enemies
{
    internal class FinalBoss : AnimatedCharacter
    {

        public IntRect finalBossRect;

        // Caching our Previos direction (Needed for Collisions)

        public FinalBoss(Map map) : base("Resources/Characters/FinalBoss.png", 32, 48)
        {
            AnimDown = new Animation(0, 0, 4);
            AnimRight = new Animation(64, 0, 4);
            AnimLeft = new Animation(32, 0, 4);
            AnimUp = new Animation(96, 0, 4);

            moveSpeed = 0;
            animationSpeed = 0.1f;

            Xpos = 1933;
            Ypos = 1315;

            this.CurrentState = MoveDirection.None;
            finalBossRect = new IntRect((int)Xpos, (int)Ypos, 32, 48);
        }
    }
}

﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using StateMachine;

namespace StateMachine
{
    internal class MainCharacter : AnimatedCharacter
    {
        private Map map;

        private OpenWorldScene OpenworldScene;
        private IntRect PlayerRectangle;
        private Teleport teleport;
        private ItemsAndNpcs ItemsAndNpcs;
        private Clock teleportClock;
        private float teleportCooldown;
        public static bool playerIsDead;
        public static float currentPositionY;
        public static float currentPositionX;


        // Caching our Previos direction (Needed for Collisions)
        private float cachedDirection;

        public MainCharacter(Map map) : base("Resources/Characters/MainCharacter.png", 32, 48)
        {
            teleportClock = new Clock();
            ;


            AnimDown = new Animation(0, 0, 4);
            AnimRight = new Animation(96, 0, 4);
            AnimLeft = new Animation(48, 0, 4);
            AnimUp = new Animation(144, 0, 4);

            Xpos = 449;
            Ypos = 1546;

            moveSpeed = 150f;
            animationSpeed = 0.1f;

            this.map = map;

            teleport = new Teleport();
            ItemsAndNpcs = new ItemsAndNpcs();
            ;
        }

        public override void Update(float deltaTime)
        {
            currentPositionX = Xpos;
            currentPositionY = Ypos;
            Revive();

            PlayerRectangle = new IntRect((int) Xpos, (int) Ypos, 32, 48);
            this.CurrentState = MoveDirection.None;

            moveSpeed = 150;

            teleportCooldown = teleportClock.ElapsedTime.AsSeconds();

            IntersectionsWithEnemies();
            IntersectionWithItemsAndRest();
            Collision();
            PlayerControl();
           // Console.WriteLine("X" + Xpos);
           //Console.Write("Y" + Ypos);
            base.Update(deltaTime);


        }

        public void Collision()
        {
            foreach (var collisionrect in map.CollisionRectangleShapes)
            {
                // 1 North, 4 East , 2 South, 3 West  Collision with the Walls
                if (PlayerRectangle.TouchTop(collisionrect))
                    if (cachedDirection == 2)
                    {
                        moveSpeed = 0;
                    }

                if (PlayerRectangle.TouchRight(collisionrect))
                    if (cachedDirection == 3)
                    {
                        moveSpeed = 0;
                    }

                if (PlayerRectangle.TouchLeft(collisionrect))
                    if (cachedDirection == 4)
                    {
                        moveSpeed = 0;
                    }

                if (PlayerRectangle.TouchBottom(collisionrect))
                    if (cachedDirection == 1)
                    {
                        moveSpeed = 0;
                    }
            }
        }

        public void PlayerControl()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                this.CurrentState = MoveDirection.MoveNorth;
                cachedDirection = 1;
                Collision();
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                this.CurrentState = MoveDirection.MoveSouth;
                cachedDirection = 2;
                Collision();
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                this.CurrentState = MoveDirection.MoveWest;
                cachedDirection = 3;
                Collision();
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                this.CurrentState = MoveDirection.MoveEast;
                cachedDirection = 4;
                Collision();
            }
        }

        public void IntersectionsWithEnemies()
        {
            // Intersection with a Cat
            if ((PlayerRectangle.Intersects(map.MyScene.cat.CatRect) && !Cat.CatIsDead))
            {
                Cat.CatIsDead = true;
                //condition above should changed or this one should, or cat will die every intersect 
                Fightscene.SetEnemy = "Cat";
                map.MyScene.gameObject.SceneManager.StartScene("fight");
            }

            if ((PlayerRectangle.Intersects(map.MyScene.bat.BatRect) && !Bat.BatIsDead))
            {
                Bat.BatIsDead = true;
                Fightscene.SetEnemy = "Bat";
                map.MyScene.gameObject.SceneManager.StartScene("fight");
            }

            if (PlayerRectangle.Intersects(map.MyScene.enemyKilledWithSword.EnemyKilledWithSwordRect) && !EnemyKilledWithSword.EnemyKilledWithSwordIsDead)
            {
                EnemyKilledWithSword.EnemyKilledWithSwordIsDead = true;
                Fightscene.SetEnemy = "SwordEnemy";
                map.MyScene.gameObject.SceneManager.StartScene("fight");
            }

            if (PlayerRectangle.Intersects(map.MyScene.finalBoss.finalBossRect) && !FinalBoss.FinalBossIsDead)
            {
                FinalBoss.FinalBossIsDead = true;
                Fightscene.SetEnemy = "FinalBoss";
                map.MyScene.gameObject.SceneManager.StartScene("fight");
            }

            if (PlayerRectangle.Intersects(map.MyScene.mage.MageRect) && !Mage.MageIsDead)
            {
                Mage.MageIsDead = true;
                Fightscene.SetEnemy = "Mage";
                map.MyScene.gameObject.SceneManager.StartScene("fight");
            }
        }

        public void IntersectionWithItemsAndRest()
        {
            //Intersection with NPC
            if (PlayerRectangle.Intersects(ItemsAndNpcs.NPCRect))
            {
                //TODO GIVE ITEM
            }

            //Intersection with Bow
            if (PlayerRectangle.Intersects(ItemsAndNpcs.BowRect))
            {
                ItemsAndNpcs.BowPicked = true;
            }


            //Intersection with Key

            if (PlayerRectangle.Intersects(ItemsAndNpcs.KeyRect))
            {
                ItemsAndNpcs.KeyPicked = true;
                //TODO LOGIC
            }

            //Intersection with Door

            if (PlayerRectangle.Intersects(ItemsAndNpcs.DoorsRect) && cachedDirection == 2)
            {
                if (ItemsAndNpcs.KeyPicked == true) ItemsAndNpcs.DoorsOpened = true;

                if (ItemsAndNpcs.KeyPicked == false) moveSpeed = 0;
                //Ypos = ItemsAndNpcs .DoorsYpos  -50;
            }

            // Intersection with Healing

            if (PlayerRectangle.Intersects(ItemsAndNpcs.HealingRect) || PlayerRectangle.Intersects(ItemsAndNpcs.HealingRect1) || PlayerRectangle.Intersects(ItemsAndNpcs.HealingRect2))
            {
                //TODO HEAL UP LOGIC
            }

            if (PlayerRectangle.Intersects(teleport.TeleportA) && teleportCooldown > 2)
            {
                Xpos = teleport.BxPos + 20;
                Ypos = teleport.ByPos + 58;
                teleportClock.Restart();
            }

            if (PlayerRectangle.Intersects(teleport.TeleportB) && teleportCooldown > 2)
            {
                Xpos = teleport.AxPos + 20;
                Ypos = teleport.AyPos + 58;
                teleportClock.Restart();
            }
        }

        public void Revive()
        {
            if (playerIsDead)
            {
                Xpos = 449;
                Ypos = 1546;
                playerIsDead = false;
            }
        }

        
}
}
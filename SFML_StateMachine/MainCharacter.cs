using System;
using GameEngine;
using GameplayWorld_DM;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_StateMachine
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
        
        

        // Caching our Previos direction (Needed for Collisions)
        private float cachedDirection;

        public MainCharacter(Map map) : base("Resources/Characters/MainCharacter.png", 32,48)
        {

            teleportClock = new Clock(); ;

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
            ItemsAndNpcs = new ItemsAndNpcs(); ;
        }

        public override void Update(float deltaTime)
        {




            //PlayerRectangle = new SFML.System.Vector2f(Xpos, Ypos);
            PlayerRectangle = new IntRect((int)Xpos, (int)Ypos, 32, 48);
            this.CurrentState = MoveDirection.None;

            moveSpeed = 150;

            teleportCooldown = teleportClock.ElapsedTime.AsSeconds();


            // Intersection with a Cat
            if (PlayerRectangle.Intersects(map.MyScene.cat.CatRect))
            {              
                map.MyScene.gameObject.SceneManager.StartScene("fight");
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

            if (PlayerRectangle.Intersects(ItemsAndNpcs.DoorsRect ) && cachedDirection ==2)
            {
                if (ItemsAndNpcs.KeyPicked == true) ItemsAndNpcs.DoorsOpened  = true;

                if (ItemsAndNpcs.KeyPicked == false) moveSpeed = 0; //Ypos = ItemsAndNpcs .DoorsYpos  -50;
            }


            // Intersection with Healing

            if (PlayerRectangle.Intersects(ItemsAndNpcs.HealingRect))
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
<<<<<<< HEAD
            // 1 North, 2 South , 3 East, 4 West  Collision with the Walls
=======
            // 1 North, 4 East , 2 South, 3 West  Collision with the Walls
>>>>>>> origin/master

            foreach (var collisionrect in map.CollisionRectangleShapes)
            {

                if ((PlayerRectangle.Left + PlayerRectangle.Width >= collisionrect.Left) &&
                    (PlayerRectangle.Left <= collisionrect.Left + collisionrect.Width) &&
                    (PlayerRectangle.Top + PlayerRectangle.Height >= collisionrect.Top) &&
                    (PlayerRectangle.Top <= collisionrect.Top + collisionrect.Height) && PlayerRectangle.Left + PlayerRectangle.Width < collisionrect.Left + collisionrect.Width)
                {
                    if (cachedDirection == 4)
                    {
                        moveSpeed = 0;
                    }
                }

                if ((PlayerRectangle.Left + PlayerRectangle.Width >= collisionrect.Left) &&
                    (PlayerRectangle.Left <= collisionrect.Left + collisionrect.Width) &&
                    (PlayerRectangle.Top + PlayerRectangle.Height >= collisionrect.Top) &&
                    (PlayerRectangle.Top <= collisionrect.Top + collisionrect.Height) && PlayerRectangle.Top + PlayerRectangle.Height > collisionrect.Top + collisionrect.Height)
                {
                    if (cachedDirection == 1)
                    {
                        moveSpeed = 0;
                    }
                }
                    if ((PlayerRectangle.Left + PlayerRectangle.Width >= collisionrect.Left) &&
                    (PlayerRectangle.Left <= collisionrect.Left + collisionrect.Width) &&
                    (PlayerRectangle.Top + PlayerRectangle.Height >= collisionrect.Top) &&
                    (PlayerRectangle.Top <= collisionrect.Top + collisionrect.Height) && PlayerRectangle.Top < collisionrect.Top)
                {
                    if (cachedDirection == 2)
                    {
                        moveSpeed = 0;                       
                    }
                }

                if ((PlayerRectangle.Left + PlayerRectangle.Width >= collisionrect.Left) &&
                    (PlayerRectangle.Left <= collisionrect.Left + collisionrect.Width) &&
                    (PlayerRectangle.Top + PlayerRectangle.Height >= collisionrect.Top) &&
                    (PlayerRectangle.Top <= collisionrect.Top + collisionrect.Height) && PlayerRectangle.Left > collisionrect.Left)
                {
                    if (cachedDirection == 3)
                    {
                        moveSpeed = 0;
                    }
                }
            }

            // Movement

            Console.WriteLine("X" + Xpos);
            Console.Write("Y" + Ypos);

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                this.CurrentState = MoveDirection.MoveNorth;
                cachedDirection = 1;

            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                this.CurrentState = MoveDirection.MoveSouth;
                cachedDirection = 2;         
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                this.CurrentState = MoveDirection.MoveWest;
                cachedDirection = 3;              
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                this.CurrentState = MoveDirection.MoveEast;
                cachedDirection = 4;

            }
            base.Update(deltaTime);
        }
    }
}
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using SFML.Audio;
using StateMachine;

namespace StateMachine
{
    internal class MainCharacter : AnimatedCharacter
    {
        private Map map;

        private Sound CatSound;
        private Sound PickupSound;
        private Sound HealSound;

        private OpenWorldScene OpenworldScene;
        private IntRect PlayerRectangle;
        private Teleport teleport;
        private ItemsAndNpcs ItemsAndNpcs;
        private Clock teleportClock;
        private float teleportCooldown;
        public static bool playerIsDead;
        public static bool CharIsTalking;
        public static float currentPositionY;
        public static float currentPositionX;

        public MessageBox messageBox;
        public MessageText messageText;

        public static int JustCounterForTimer;

        private int x,y;


        // Caching our Previos direction (Needed for Collisions)
        private float cachedDirection;

        public MainCharacter(Map map) : base("Resources/Characters/MainCharacter.png", 32, 48)
        {
            teleportClock = new Clock();

            CatSound = new Sound(new SoundBuffer("Resources/Sounds/Meow.wav"));
            PickupSound  = new Sound(new SoundBuffer("Resources/Sounds/Pickup_Coin.wav"));
            HealSound = new Sound(new SoundBuffer("Resources/Sounds/Healing.wav"));

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

            messageBox = new MessageBox();
            messageText = new MessageText();

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

            if (OpenWorldScene.TalkingTimerInteger > constants.FreezeTime)
            {
                PlayerControl();
            }
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
        /// <summary>
        /// Simple Player Control
        /// </summary>
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
        /// <summary>
        /// Intersections with Enemies
        /// </summary>
        public void IntersectionsWithEnemies()
        {
            // Intersection with a Cat
            if ((PlayerRectangle.Intersects(map.MyScene.cat.CatRect) && !Cat.CatIsDead))
            {
               
                TalkingCounter();

                if (OpenWorldScene.TalkingTimerInteger > constants.FreezeTime - 0.1f)
                {
                    OpenWorldScene.musicIsPlaying = false;
                    OpenWorldScene.music.Pause();
                    CatSound.Play();
                    MessageCounterMechanic();
                    Cat.CatIsDead = true;
                    
                    Fightscene.SetEnemy = "Cat";

                    map.MyScene.gameObject.SceneManager.StartScene("fight");
                }
            }

            //condition above should changed or this one should, or cat will die every intersect 



            if ((PlayerRectangle.Intersects(map.MyScene.bat.BatRect) && !Bat.BatIsDead))
            {
                TalkingCounter();
                if (OpenWorldScene.TalkingTimerInteger > constants.FreezeTime - 0.1f)
                {
                    OpenWorldScene.musicIsPlaying = false;
                    OpenWorldScene.music.Pause();
                    MessageCounterMechanic();
                    Bat.BatIsDead = true;
                    Fightscene.SetEnemy = "Bat";
                    map.MyScene.gameObject.SceneManager.StartScene("fight");
                }
            }

            if (PlayerRectangle.Intersects(map.MyScene.enemyKilledWithSword.EnemyKilledWithSwordRect) && !EnemyKilledWithSword.EnemyKilledWithSwordIsDead)
            { 
                TalkingCounter();

                if (OpenWorldScene.TalkingTimerInteger > constants.FreezeTime - 0.1f)
                {
                    OpenWorldScene.musicIsPlaying = false;
                    OpenWorldScene.music.Pause();
                    MessageCounterMechanic();
                    EnemyKilledWithSword.EnemyKilledWithSwordIsDead = true;
                    Fightscene.SetEnemy = "SwordEnemy";
                    map.MyScene.gameObject.SceneManager.StartScene("fight");
                }
            }

            if (PlayerRectangle.Intersects(map.MyScene.finalBoss.finalBossRect) && !FinalBoss.FinalBossIsDead)
            {
                TalkingCounter();
                if (OpenWorldScene.TalkingTimerInteger > constants.FreezeTime - 0.1f)
                {
                    OpenWorldScene.musicIsPlaying = false;
                    OpenWorldScene.music.Pause();
                    FinalBoss.FinalBossIsDead = true;
                    Fightscene.SetEnemy = "FinalBoss";
                    map.MyScene.gameObject.SceneManager.StartScene("fight");
                }
            }

            if (PlayerRectangle.Intersects(map.MyScene.mage.MageRect) && !Mage.MageIsDead)
            {
                TalkingCounter();
                if (OpenWorldScene.TalkingTimerInteger > constants.FreezeTime - 0.1f)
                {
                    OpenWorldScene.musicIsPlaying = false;
                    OpenWorldScene.music.Pause();
                    //Fightscene.MissedMagic = false;
                    MessageCounterMechanic();
                    Mage.MageIsDead = true;
                    Fightscene.SetEnemy = "Mage";
                    map.MyScene.gameObject.SceneManager.StartScene("fight");
                }
            }
        }

        /// <summary>
        /// Counter for Message Boxes (We are jumping to another dialog )
        /// </summary>
        private static void MessageCounterMechanic()
        {
            CharIsTalking = false;
            MessageText._counterMessage++;
            MessageText._counterSpeaker++;
        }

        /// <summary>
        /// Intersections with other things
        /// </summary>
        public void IntersectionWithItemsAndRest()
        {
            //Intersection with NPC
            if (PlayerRectangle.Intersects(ItemsAndNpcs.NPCRect) && !ItemsAndNpcs.NpcSwordGiven)
            {
                TalkingCounter();
                
                if (OpenWorldScene.TalkingTimerInteger > constants.FreezeTime - 0.1f)
                {
                    MessageCounterMechanic();
                    ItemsAndNpcs.NpcSwordGiven = true;
                    ItemsAndNpcs.SwordPicked = true;
                    Inventar_Fightscene.SimpleSword = true;
                    Inventar_Fightscene.GoldenSword = true;
                    JustCounterForTimer = 0;
                }
            }

            //Intersection with Bow
            if (PlayerRectangle.Intersects(ItemsAndNpcs.BowRect) && !ItemsAndNpcs.BowPicked)
            {
                TalkingCounter();

                if (OpenWorldScene.TalkingTimerInteger > constants.FreezeTime - 0.1f)
                {
                    PickupSound.Play();
                    MessageCounterMechanic();
                    ItemsAndNpcs.BowPicked = true;
                    Fightscene.SimpleArrow_equipped = true;
                    Inventar_Fightscene.SimpleArrow = true;
                    JustCounterForTimer = 0;
                }
            }


            //Intersection with Key

            if (PlayerRectangle.Intersects(ItemsAndNpcs.KeyRect) && !ItemsAndNpcs.KeyPicked)
            {
                TalkingCounter();
                if (OpenWorldScene.TalkingTimerInteger > constants.FreezeTime - 0.1f)
                {
                    PickupSound.Play();
                    MessageCounterMechanic();
                    ItemsAndNpcs.KeyPicked = true;
                    JustCounterForTimer = 0;
                }
            }
            //Intersection with a Staff
            if (PlayerRectangle.Intersects(ItemsAndNpcs.StaffRect) && !ItemsAndNpcs.StaffPicked)
            {
                Fightscene.Magic_equipped = true;
                TalkingCounter();
                if (OpenWorldScene.TalkingTimerInteger > constants.FreezeTime - 0.1f)
                {
                    PickupSound.Play();
                    MessageCounterMechanic();
                    ItemsAndNpcs.StaffPicked = true;
                    JustCounterForTimer = 0;
                }
            }
            //Intersection with a GoldenSword
            if (PlayerRectangle.Intersects(ItemsAndNpcs.GoldenSwordRect) && !ItemsAndNpcs.GoldenSwordPicked)
            {
                TalkingCounter();
                if (OpenWorldScene.TalkingTimerInteger > constants.FreezeTime - 0.1f)
                {
                    PickupSound.Play();
                    MessageCounterMechanic();
                    ItemsAndNpcs.GoldenSwordPicked = true;
                    JustCounterForTimer = 0;
                }
            }

            //Intersection with Door

            if (PlayerRectangle.Intersects(ItemsAndNpcs.DoorsRect) && cachedDirection == 2 && !ItemsAndNpcs.DoorsOpened)
            {
                if (ItemsAndNpcs.KeyPicked)
                {
                    TalkingCounter();
                    if (OpenWorldScene.TalkingTimerInteger > constants.FreezeTime - 0.1f)
                    {
                        MessageCounterMechanic();
                        ItemsAndNpcs.DoorsOpened = true;
                        JustCounterForTimer = 0;
                    }
                }
                if (!ItemsAndNpcs.KeyPicked)
                {                                             
                        moveSpeed = 0;
                }                
            }

            // Intersection with Healing

            if (PlayerRectangle.Intersects(ItemsAndNpcs.HealingRect) || PlayerRectangle.Intersects(ItemsAndNpcs.HealingRect1) || PlayerRectangle.Intersects(ItemsAndNpcs.HealingRect2))
            {
                
                HealSound.Play();
                Fightscene.healthLeft = Fightscene.HP;
            }

            //Teleport ( Just swap the position of a player ) 
            //+ Cooldown
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

        /// <summary>
        /// Dirty Trick. For the Glory. It works, so let it work. (Russian ducktape bro)
        /// </summary>
        private static void TalkingCounter()
        {
            if (JustCounterForTimer <= 1)
            {
                OpenWorldScene.TalkingClock.Restart();
                OpenWorldScene.TalkingTimerInteger = 0;
                JustCounterForTimer++;
            }
            OpenWorldScene.TalkingTimerInteger = (int)OpenWorldScene.TalkingClock.ElapsedTime.AsSeconds();
            CharIsTalking = true;
        }

        
        /// <summary>
        /// Setting the Player to the prev position 
        /// </summary>
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
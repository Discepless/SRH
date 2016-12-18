using SFML.Graphics;
using SFML.System;

namespace StateMachine
{
    class ItemsAndNpcs
    {
        public IntRect BowRect, KeyRect, HealingRect, HealingRect1, HealingRect2, NPCRect, DoorsRect, StaffRect, GoldenSwordRect;
        public Texture BowTexture, KeyTexture, DoorsOpenedTexture, DoorsClosedTexture, NPCTexture, StaffTexture, GoldenSwordTexture;
        public Sprite BowSprite, KeySprite, DoorsOpenedSprite, DoorsClosedSprite, NPCSprite, StaffSprite,GoldenSwordSprite;
        public static bool NpcSwordGiven;

        public static bool BowPicked, KeyPicked, SwordPicked, DoorsOpened,StaffPicked,GoldenSwordPicked;

        public int
            ///Positions for ItemsAndNpcs and Things on a map//////
            ///////////
            BowXpos,
            BowYPos,
            BowWidth,
            BowHeight,
            //////////
            HealingXpos,
            HealingXPos1,
            HealingXPos2,
            HealingYpos,
            HealingYpos1,
            HealingYpos2,
            HealingWidth,
            HealingWidth1,
            HealingWidth2,
            HealingHeight,
            HealingHeight1,
            HealingHeight2,
            //////////
            KeyXpos,
            KeyYpos,
            KeyWidth,
            KeyHeight,
            //////////
            NPCXpos,
            NPCYpos,
            NPCWidth,
            NPCHeight,
            //////////
            DoorsXpos,
            DoorsYpos,
            DoorsWidth,
            DoorsHeight,
            //////////
            StaffXPos,
            StaffYPos,
            StaffWidth,
            StaffHeight,
            //////////
            GoldenSwordXPos,
            GoldenSwordYPos,
            GoldenSwordWidth,
            GoldenSwordHeight;

        public ItemsAndNpcs()
        {
            BowXpos = 1930;
            BowYPos = 473;
            BowWidth = 16;
            BowHeight = 16;

            KeyXpos = 2306;
            KeyYpos = 529;
            KeyWidth = 16;
            KeyHeight = 16;

            StaffXPos = 880;
            StaffYPos = 1163;
            StaffWidth = 16;
            StaffHeight = 16;

            GoldenSwordXPos = 1566;
            GoldenSwordYPos = 1515;
            GoldenSwordWidth = 16;
            GoldenSwordHeight = 16;

            NPCXpos = 392;
            NPCYpos = 628;
            NPCWidth = 48;
            NPCHeight = 32;

            KeyXpos = 2305;
            KeyYpos = 530;
            KeyWidth = 68;
            KeyHeight = 60;
            
            DoorsXpos = 896;
            DoorsYpos = 704;
            DoorsWidth = 96;
            DoorsHeight = 32;

            HealingXpos = 1887;
            HealingYpos = 383;
            HealingXPos1 = 1959;
            HealingYpos1 = 383;
            HealingXPos2 = 1667;
            HealingYpos2 = 1453;

            HealingWidth = 62;
            HealingHeight = 34;
            HealingWidth1 = 47;
            HealingHeight1 = 30;
            HealingWidth2 = 54;
            HealingHeight2 = 18;

            KeyRect = new IntRect(KeyXpos, KeyYpos, KeyWidth, KeyHeight);
            KeyTexture = new Texture("Resources/Items/Key.png");
            KeySprite = new Sprite(KeyTexture) { Position = new Vector2f(KeyXpos, KeyYpos), Scale = new Vector2f(0.5f, 0.5f) };

            BowRect = new IntRect(BowXpos, BowYPos, BowWidth, BowHeight);
            BowTexture = new Texture("Resources/Items/Bow.png");
            BowSprite = new Sprite(BowTexture) { Position = new Vector2f(BowXpos, BowYPos), Scale = new Vector2f(0.5f, 0.5f) };

            GoldenSwordRect = new IntRect(GoldenSwordXPos, GoldenSwordYPos, GoldenSwordWidth, GoldenSwordHeight);
            GoldenSwordTexture = new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/goldenSword.png");
            GoldenSwordSprite = new Sprite(GoldenSwordTexture) { Position = new Vector2f(GoldenSwordXPos, GoldenSwordYPos), Scale = new Vector2f(0.5f, 0.5f) };

            StaffRect = new IntRect(StaffXPos, StaffYPos, StaffWidth, StaffHeight);
            StaffTexture = new Texture("Resources/Items/Staff.png");
            StaffSprite = new Sprite(StaffTexture) { Position = new Vector2f(StaffXPos, StaffYPos), Scale = new Vector2f(0.5f, 0.5f) };

            NPCRect = new IntRect(NPCXpos, NPCYpos, NPCWidth, NPCHeight);
            NPCTexture = new Texture("Resources/Characters/NPCSword.png");
            NPCSprite = new Sprite(NPCTexture) { Position = new Vector2f(NPCXpos, NPCYpos) }; ;

            DoorsRect = new IntRect(DoorsXpos, DoorsYpos, DoorsWidth, DoorsHeight);
            DoorsOpenedTexture = new Texture("Resources/Items/DoorOpened.png");
            DoorsClosedTexture = new Texture("Resources/Items/DoorClosed.png");
            DoorsOpenedSprite = new Sprite(DoorsOpenedTexture) { Position = new Vector2f(DoorsXpos, DoorsYpos), Scale = new Vector2f(1f, 1f) };
            DoorsClosedSprite = new Sprite(DoorsClosedTexture) { Position = new Vector2f(DoorsXpos, DoorsYpos), Scale = new Vector2f(1f, 1f) };

            HealingRect = new IntRect(HealingXpos, HealingYpos, HealingWidth, HealingHeight);
            HealingRect1 = new IntRect(HealingXPos1, HealingYpos1, HealingWidth1, HealingHeight1);
            HealingRect2 = new IntRect(HealingXPos2, HealingYpos2, HealingWidth2, HealingHeight2);
        }

        public void Draw(RenderWindow window)
        {
            if (BowPicked == false)
            {
                window.Draw(BowSprite);
            }

            if (StaffPicked == false)
            {
                window.Draw(StaffSprite);
            }

            if (GoldenSwordPicked == false)
            {
                window.Draw(GoldenSwordSprite);
            }

            if (KeyPicked == false)
            {
                window.Draw(KeySprite);
            }

            if (!NpcSwordGiven)
            {
                window.Draw(NPCSprite);
            }

            if (DoorsOpened == true)
            {
                window.Draw(DoorsOpenedSprite);
            }

            else { window.Draw(DoorsClosedSprite); }
        }
    }
}
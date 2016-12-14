using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace SFML_StateMachine
{
    class ItemsAndNpcs
    {
        public IntRect BowRect,KeyRect, HealingRect,NPCRect;
        public Texture BowTexture, KeyTexture, NPCTexture;
        public Sprite BowSprite,KeySprite,NPCSprite;

        public static bool BowPicked,KeyPicked,SwordPicked;

        public int
            ///Positions for ItemsAndNpcs and Things on a map//////
            ///////////
            BowXpos,
            BowYPos,
            BowWidth,
            BowHeight,
            //////////
            HealingXpos,
            HealingYpos,
            HealingWidth,
            HealingHeight,
            //////////
            KeyXpos,
            KeyYpos,
            KeyWidth,
            KeyHeight,
            //////////
            NPCXpos,
            NPCYpos,
            NPCWidth,
            NPCHeight;




        public ItemsAndNpcs()
        {
            BowXpos = 450;
            BowYPos = 1530;
            BowWidth = 16;
            BowHeight = 16;

            KeyXpos = 2306;
            KeyYpos = 529;
            KeyWidth = 16;
            KeyHeight = 16;

            NPCXpos = 392;
            NPCYpos = 628;
            NPCWidth = 48;
            NPCHeight = 32;

            KeyRect = new IntRect(KeyXpos,KeyYpos,KeyWidth,KeyHeight);
            KeyTexture = new Texture("Resources/Items/Key.png");
            KeySprite = new Sprite(KeyTexture) { Position = new Vector2f(KeyXpos, KeyYpos), Scale = new Vector2f(0.5f, 0.5f) };

            BowRect = new IntRect(BowXpos,BowYPos, BowWidth, BowHeight);
            BowTexture = new Texture("Resources/Items/Bow.png");
            BowSprite = new Sprite(BowTexture) {Position = new Vector2f(BowXpos, BowYPos), Scale = new Vector2f(0.5f,0.5f)};

            NPCRect = new IntRect(NPCXpos,NPCYpos,NPCWidth,NPCHeight);
            NPCTexture = new Texture("Resources/Characters/NPCSword.png");
            NPCSprite = new Sprite(NPCTexture) {Position = new Vector2f(NPCXpos, NPCYpos)}; ;

            HealingRect = new IntRect(HealingXpos,HealingYpos,HealingWidth,HealingHeight);
        }

        public void Draw(RenderWindow window)
        {
            if (BowPicked == false)
            {
                window.Draw(BowSprite);
            }

            if (KeyPicked == false)
            {
                window.Draw(KeySprite);
            }
            window.Draw(NPCSprite);
        }
    }
}

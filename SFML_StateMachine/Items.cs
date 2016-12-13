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
    class Items
    {
        public IntRect BowRect, HealingRect;
        public Texture BowTexture;
        public Sprite BowSprite;
        public static bool BowPicked;

        public int
            ///Positions for Items and Things on a map//////
            ///////////
            BowXpos,
            BowYPos,
            BowWidth,
            BowHeight,
            //////////
            HealingXpos,
            HealingYpos,
            HealingWidth,
            HealingHeight;

        public Items()
        {
            BowXpos = 450;
            BowYPos = 1530;
            BowWidth = 16;
            BowHeight = 16;
           
            BowRect = new IntRect(BowXpos,BowYPos, BowWidth, BowHeight);
            BowTexture = new Texture("Resources/Items/Bow.png");
            BowSprite = new Sprite(BowTexture) {Position = new Vector2f(BowXpos, BowYPos), Scale = new Vector2f(0.5f,0.5f)};
        }

        public void Draw(RenderWindow window)
        {
            if (BowPicked == false)
            {
                window.Draw(BowSprite);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using GameEngine;


namespace StateMachine
{
    class Inventar_Fightscene 
    {
        public List<Sprite> itemList;
        public List<Sprite> unchecked_checkbox_list;
        public List<Sprite> checked_checkbox_list;

        Fightscene Fightscene;

        bool SimpleSword = true;
        bool GoldenSword = false;
        bool SimpleArrow = true;

        Sprite simpleSword;
        Sprite goldenSword;
        Sprite simpleArrow;

        public Inventar_Fightscene()
        {

            //public void InitializeItem()
            {
                itemList = new List<Sprite>();

                itemList.Add(new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/sword.png")) { Position = new Vector2f(1000, 700), Scale = new Vector2f(.03f, .03f) });

                itemList.Add(new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/goldenSword.png")) { Position = new Vector2f(1000, 800), Scale = new Vector2f(.12f, .12f) });

                itemList.Add(new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/arrow.jpg")) { Position = new Vector2f(1000, 950), Scale = new Vector2f(.04f, .04f) });


                unchecked_checkbox_list = new List<Sprite>();

                unchecked_checkbox_list.Add(new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox-unchecked.png")) { Position = new Vector2f(900, 705), Scale = new Vector2f(.1f, .1f) });

                unchecked_checkbox_list.Add(new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox-unchecked.png")) { Position = new Vector2f(900, 805), Scale = new Vector2f(.1f, .1f) });

                unchecked_checkbox_list.Add(new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox-unchecked.png")) { Position = new Vector2f(900, 945), Scale = new Vector2f(.1f, .1f) });


                checked_checkbox_list = new List<Sprite>();

                checked_checkbox_list.Add(simpleSword = new Sprite (new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox_checked.png")) { Position = new Vector2f(900, 705), Scale = new Vector2f(.065f, .065f) });
 
                checked_checkbox_list.Add(goldenSword = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox_checked.png")) { Position = new Vector2f(900, 805), Scale = new Vector2f(.065f, .065f) });

                checked_checkbox_list.Add(simpleArrow = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox_checked.png")) { Position = new Vector2f(900, 945), Scale = new Vector2f(.065f, .065f) });


                
            }
        }
        public void Draw(RenderWindow window)
        {
            foreach (Sprite itemsprite in itemList)
                window.Draw(itemsprite);
            foreach (Sprite unchecked_checkbox in unchecked_checkbox_list)
                window.Draw(unchecked_checkbox);
            foreach (Sprite checked_checkbox in checked_checkbox_list)
            {
                if (SimpleSword)
                    window.Draw(simpleSword);
                if (GoldenSword)
                    window.Draw(goldenSword);
                if (SimpleArrow)
                    window.Draw(simpleArrow);
            }
        }


        // Equippes Item
        public void Equipp_SimpleSword()
        {
            SimpleSword = true;
            GoldenSword = false;
        }
        public void Equipp_GoldenSword()
        {
            GoldenSword = true;
            SimpleSword = false;
        }
        public void Equipp_SimpleArrow()
        {
            SimpleArrow = true;
        }
        //public void DrawItems()
        //{
        //    _gameObject.Window.Draw(simple_sword_item);
        //    _gameObject.Window.Draw(golden_sword_item);
        //    _gameObject.Window.Draw(simple_arrow_item);
        //}
    }
}

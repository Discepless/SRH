using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace StateMachine
{
    internal class Inventar_Fightscene
    {
        public List<Sprite> itemList;
        public List<Sprite> unchecked_checkbox_list;
        public List<Sprite> checked_checkbox_list;


        public static bool Fist = true;
        public static bool SimpleSword = false;
        public static bool GoldenSword = false;
        public static bool SimpleArrow = false;

        private Sprite checked_fist;
        private Sprite checked_simpleSword;
        private Sprite checked_goldenSword;
        private Sprite checked_simpleArrow;

        private Sprite unchecked_fist;
        private Sprite unchecked_simpleSword;
        private Sprite unchecked_goldenSword;
        private Sprite unchecked_simpleArrow;

        public static Sprite fist;
        public static Sprite simpleSword;
        public static Sprite goldenSword;
        public static Sprite simpleArrow;


        public static int count;

        public Inventar_Fightscene()
        {
            //public void InitializeItem()
            {
                unchecked_checkbox_list = new List<Sprite>();


                unchecked_checkbox_list.Add(unchecked_fist = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox-unchecked.png")) { /*Position = new Vector2f(820, 705)*//*itemList[0].Position + new Vector2f(-100,5)*/ Scale = new Vector2f(.1f, .1f) });
                if (ItemsAndNpcs.SwordPicked)
                    unchecked_checkbox_list.Add(unchecked_simpleSword = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox-unchecked.png")) { /*Position = new Vector2f(820, 805)*//*itemList[0].Position + new Vector2f(-100,5)*/ Scale = new Vector2f(.1f, .1f) });
                if (ItemsAndNpcs.StaffPicked)
                    unchecked_checkbox_list.Add(unchecked_goldenSword = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox-unchecked.png")) { /*Position = new Vector2f(820, 905)*//*itemList[1].Position + new Vector2f(-100, 5)*/ Scale = new Vector2f(.1f, .1f) });
                if (ItemsAndNpcs.BowPicked)
                    unchecked_checkbox_list.Add(unchecked_simpleArrow = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox-unchecked.png")) { /*Position = new Vector2f(1120, 705)*//*itemList[2].Position + new Vector2f(-100, 5)*/ Scale = new Vector2f(.1f, .1f) });

                count = unchecked_checkbox_list.Count;


                itemList = new List<Sprite>();

                itemList.Add(fist = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/Fist.png")) { Scale = new Vector2f(.3f, .3f) });
                if (ItemsAndNpcs.SwordPicked)
                    itemList.Add(simpleSword = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/sword.png")) { /*Position = /*new Vector2f(1000, 700) unchecked_checkbox_list[count-1].Position + new Vector2f(100,-5),*/ Scale = new Vector2f(.03f, .03f) });
                if (ItemsAndNpcs.StaffPicked)
                    itemList.Add(goldenSword = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/goldenSword.png")) { /*Position = /*new Vector2f(1000, 800) unchecked_checkbox_list[count-1].Position + new Vector2f(100, -5),*/ Scale = new Vector2f(.12f, .12f) });
                if (ItemsAndNpcs.BowPicked)
                    itemList.Add(simpleArrow = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/arrow.png")) { /*Position = /*new Vector2f(1000, 950) unchecked_checkbox_list[count -1].Position + new Vector2f(100, -5),*/ Scale = new Vector2f(.04f, .04f) });


                checked_checkbox_list = new List<Sprite>();

                checked_checkbox_list.Add(checked_fist = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox_checked.png")) { /*Position = unchecked_fist.Position*/ Scale = new Vector2f(.065f, .065f) });
                if (ItemsAndNpcs.SwordPicked)
                    checked_checkbox_list.Add(checked_simpleSword = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox_checked.png")) { /*Position = unchecked_simpleSword.Position,*/ Scale = new Vector2f(.065f, .065f) });
                if (ItemsAndNpcs.StaffPicked)
                    checked_checkbox_list.Add(checked_goldenSword = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox_checked.png")) { /*Position = unchecked_goldenSword.Position,*/ Scale = new Vector2f(.065f, .065f) });
                if (ItemsAndNpcs.BowPicked)
                    checked_checkbox_list.Add(checked_simpleArrow = new Sprite(new Texture("Resources/Weapons_Buttons_Healthbar_Fightscene/checkbox_checked.png")) { /*Position = unchecked_simpleArrow.Position,*/ Scale = new Vector2f(.065f, .065f) });

                if (count >= 1)
                    unchecked_checkbox_list[0].Position = new Vector2f(820, 705);
                if (count >= 2)
                    unchecked_checkbox_list[1].Position = new Vector2f(820, 805);
                if (count >= 3)
                    unchecked_checkbox_list[2].Position = new Vector2f(820, 905);
                if (count >= 4)
                    unchecked_checkbox_list[3].Position = new Vector2f(1120, 705);

                if (count >= 1)
                    itemList[0].Position = unchecked_checkbox_list[0].Position + new Vector2f(100, -5);
                if (count >= 2)
                    itemList[1].Position = unchecked_checkbox_list[1].Position + new Vector2f(100, -5);
                if (count >= 3)
                    itemList[2].Position = unchecked_checkbox_list[2].Position + new Vector2f(100, -5);
                if (count >= 4)
                    itemList[3].Position = unchecked_checkbox_list[3].Position + new Vector2f(100, -5);

                if (count >= 1)
                    checked_checkbox_list[0].Position = itemList[0].Position + new Vector2f(-100, 5);
                if (count >= 2)
                    checked_checkbox_list[1].Position = itemList[1].Position + new Vector2f(-100, 5);
                if (count >= 3)
                    checked_checkbox_list[2].Position = itemList[2].Position + new Vector2f(-100, 5);
                if (count >= 4)
                    checked_checkbox_list[3].Position = itemList[3].Position + new Vector2f(-100, 5);
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
                    window.Draw(checked_simpleSword);
                if (GoldenSword)
                    window.Draw(checked_goldenSword);
                if (SimpleArrow)
                    window.Draw(checked_simpleArrow);
                if (Fist)
                    window.Draw(checked_fist);
            }
        }

        // Equippes Item
        public void Equipp_SimpleSword()
        {
            SimpleSword = true;
            GoldenSword = false;
            Fist = false;
        }

        public void Equipp_GoldenSword()
        {
            GoldenSword = true;
            SimpleSword = false;
            Fist = false;
        }
        public void Equipp_Fist()
        {
            Fist = true;
            SimpleSword = false;
            GoldenSword = false;
        }

        //public void Equipp_SimpleArrow()
        //{
        //    SimpleArrow = true;
        //}

        //public void DrawItems()
        //{
        //    _gameObject.Window.Draw(simple_sword_item);
        //    _gameObject.Window.Draw(golden_sword_item);
        //    _gameObject.Window.Draw(simple_arrow_item);
        //}
    }
}
using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML_StateMachine;
using SFML_StateMachine.Enemies;

namespace GameplayWorld_DM
{
    internal class OpenWorldScene : Scene
    {
        private Map _map;

        private Clock clock = new Clock();
        public MainCharacter myCharacter;
        public Cat cat;
        public Bat bat;
        public EnemyKilledWithSword enemyKilledWithSword;
        public ItemsAndNpcs ItemsAndNpcs;
        public GameObject gameObject;
        public View view;


        public OpenWorldScene(GameObject gameObject) : base(gameObject)
        {
            view = new View(new Vector2f(0, 0), new Vector2f(1920, 1080));
            _map = new Map(this);
            myCharacter = new MainCharacter(_map);
            cat = new Cat(_map);
            bat = new Bat(_map);
            enemyKilledWithSword = new EnemyKilledWithSword(_map);
            ItemsAndNpcs = new ItemsAndNpcs();
            this.gameObject = gameObject;
        }

        public override void Draw()
        {
           

           _map.Draw(_gameObject.Window);
           myCharacter.Draw(_gameObject.Window);
           cat.Draw(_gameObject.Window);
           bat.Draw(_gameObject.Window);
           enemyKilledWithSword.Draw(_gameObject.Window);
           
            
           ItemsAndNpcs.Draw(_gameObject.Window);
           
           
           _gameObject.Window.SetView(view);

            base.Draw();
        }

        public override void Update()
        {
            
            float deltatime = clock.Restart().AsSeconds();
            myCharacter.Update(deltatime);
            enemyKilledWithSword.Update(deltatime);
            cat.Update(deltatime);
            bat.Update(deltatime);
            
            view.Center = new Vector2f((myCharacter.Xpos + 32), (myCharacter.Ypos + 32));

            //ReWork Animation classes into small pieces
            base.Update();
        }
    }
}
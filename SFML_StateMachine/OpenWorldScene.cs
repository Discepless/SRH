using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML_StateMachine;

namespace GameplayWorld_DM
{
    internal class OpenWorldScene : Scene
    {
        private Map _map;

        private Clock clock = new Clock();
        public MainCharacter myCharacter;
        public Enemy myEnemy;
        public Items items;
        public GameObject gameObject;
        private View view = new View(new Vector2f(0, 0), new Vector2f(576, 480));

        public OpenWorldScene(GameObject gameObject) : base(gameObject)
        {
            _map = new Map(this);
            myCharacter = new MainCharacter(_map);
            myEnemy = new Enemy(_map);
            items = new Items();
            this.gameObject = gameObject;
        }

        public override void Draw()
        {
            base.Draw();

            _map.Draw(_gameObject.Window);
            myCharacter.Draw(_gameObject.Window);
           // myEnemy.Draw(_gameObject.Window);
           items.Draw(_gameObject.Window);
           

            _gameObject.Window.SetView(view);
        }

        public override void Update()
        {
            float deltatime = clock.Restart().AsSeconds();
            myCharacter.Update(deltatime);
          //  myEnemy.Update(deltatime);
            view.Center = new Vector2f((myCharacter.Xpos + 32), (myCharacter.Ypos + 32));

            //ReWork Animation classes into small pieces
            base.Update();
        }
    }
}
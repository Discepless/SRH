using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML_StateMachine;

namespace GameplayWorld_DM
{
    class OpenWorldScene:Scene
    {
        private Map _map;
       
        Clock clock = new Clock();
        MainCharacter myCharacter = new MainCharacter();
        View view = new View(new Vector2f(0,0), new Vector2f(400,300));
        

        public OpenWorldScene(GameObject gameObject) : base(gameObject)
        {
            _map = new Map();

        }

        public override void Draw()
        {
            
            base.Draw();
            
            _map.Draw(_gameObject.Window);
            myCharacter.Draw(_gameObject.Window);
            _gameObject.Window.SetView(view);

        }

        public override void Update()
        {
            float deltatime = clock.Restart().AsSeconds();
            myCharacter.Update(deltatime);
            view.Center = new Vector2f((myCharacter.Xpos+32),(myCharacter.Ypos+32));
            
            //ReWork Animation classes into small pieces
            base.Update();
            
        }
    }
}

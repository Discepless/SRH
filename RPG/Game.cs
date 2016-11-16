using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace RPG
{
    class Game
    {
        private GameState _currentGameState;
        private uint _windowSizeHeight = 600;
        private uint _windowSizeWidth = 800;
        readonly RenderWindow _window = new RenderWindow(new VideoMode(800,600), "RPG");
        

        public void Start()
        {
            //RenderWindow window = new RenderWindow(new VideoMode(_windowSizeWidth,_windowSizeHeight), "RPG");
            _window.SetFramerateLimit(60);
            _window.Closed += Window_Closed;

            _currentGameState = GameState.MainMenu;
                



            //Init
           // Map map = new Map();

            while (_window.IsOpen)
            {
                switch (_currentGameState)
                {                    
                    case GameState.MainMenu:
                        MainMenuUpdate();
                        break;
                    case GameState.GamePlay:
                        GamePlayUpdate();
                        break;
                }

                _window.DispatchEvents();                

                //window.Clear(new Color(47, 129, 54));

            //Logik
                //map.Draw(window);

                _window.Display();
            }
        }

        private void MainMenuUpdate()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                _currentGameState = GameState.GamePlay;
            }
        }

        private void GamePlayUpdate()
        {
            XMap map = new XMap();
          //  _window.Clear(new Color(47, 129, 54));
            map.Draw(_window);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }
    }
}

using GameEngine;
using GameplayWorld_DM;

//namespace with all engine related shit. Check that every class for player/item/etc runs in this namespace.

namespace StateMachine
{
    internal static class Program
    {
        private static void Main()
        {
            var game = new GameObject("State Machine");

            // build the startup menu scene

            OpenWorldScene _openWorldScene = new OpenWorldScene(game);
            _openWorldScene.Name = "OpenWorld";
            game.SceneManager.AddScene(_openWorldScene);

            Fightscene _fightscene = new Fightscene(game);
            _fightscene.Name = "fight";

            game.SceneManager.AddScene(_fightscene);

            MainScene _mainScene = new MainScene(game);
            _mainScene.Name = "main";

            game.SceneManager.AddScene(_mainScene);

            //StartScene _startScene = new StartScene(game);
            //_startScene.Name = "start";
            //game.SceneManager.AddScene(_startScene);
            Splashscreen _splashcreen = new Splashscreen(game);
            _splashcreen.Name = "start";
            game.SceneManager.AddScene(_splashcreen);

            //create here as many screens as we need but dont forget to make a class for each

            // Start the game
            game.SceneManager.StartScene("start"); //it is one of the above names, scene is called by its name!
        }
    }
}
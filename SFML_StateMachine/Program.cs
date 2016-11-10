using GameEngine; //namespace with all engine related shit. Check that every class for player/item/etc runs in this namespace.

namespace StateMachine
{
    internal static class Program
    {
        private static void Main()
        {
            var game = new GameObject("State Machine");

            // build the startup menu scene

            MainScene _mainScene = new MainScene(game);
            _mainScene.Name = "main";

            game.SceneManager.AddScene(_mainScene);

            StartScene _startScene = new StartScene(game);
            _startScene.Name = "start";
            game.SceneManager.AddScene(_startScene);

            //create here as many screens as we need but dont forget to make a class for each

            // Start the game
            game.SceneManager.StartScene("start"); //it is one of the above names, scene is called by its name!
        }
    }
}
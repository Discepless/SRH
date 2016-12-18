//namespace with all engine related shit. Check that every class for player/item/etc runs in this namespace.

namespace StateMachine
{
    internal static class Program
    {
        private static void Main()
        {
            var game = new GameObject("Horny Adventures");

            // build the startup menu scene

            OpenWorldScene _openWorldScene = new OpenWorldScene(game);
            _openWorldScene.Name = "OpenWorld";
            game.SceneManager.AddScene(_openWorldScene);

            Fightscene _fightscene = new Fightscene(game);
            _fightscene.Name = "fight";
            game.SceneManager.AddScene(_fightscene);

            Credits _creditsscreen = new Credits(game);
            _creditsscreen.Name = "credits";
            game.SceneManager.AddScene(_creditsscreen);

            Splashscreen _splashcreen = new Splashscreen(game);
            _splashcreen.Name = "splashscreen";
            game.SceneManager.AddScene(_splashcreen);

            Menu _menu = new Menu(game);
            _menu.Name = "menu";
            game.SceneManager.AddScene(_menu);
            //create here as many screens as we need but dont forget to make a class for each

            // Start the game
            game.SceneManager.StartScene("splashscreen"); //it is one of the above names, scene is called by its name!
        }
    }
}
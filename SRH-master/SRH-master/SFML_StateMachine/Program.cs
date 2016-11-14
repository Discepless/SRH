﻿using GameEngine; //namespace with all engine related shit. Check that every class for player/item/etc runs in this namespace.
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace StateMachine
{
    internal static class Program
    {
        private static void Main()
        {
            var game = new GameObject("State Machine");
            Sprite sprite;
            // build the startup menu scene
            
            Fightscene _fightscene = new Fightscene(game);
            _fightscene.Name = "fight";

            game.SceneManager.AddScene(_fightscene);

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
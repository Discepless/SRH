using System.Collections.Generic;

namespace GameEngine
{
    public class SceneManager
    {
        public Dictionary<string, Scene> _scenes = new Dictionary<string, Scene>(); //array with names and corresponding scenes

        public Scene CurrentScene = null;

        public void AddScene(Scene s)
        {
            _scenes.Add(s.Name, s);
            s.InitializeItems();
        }

        public void StartScene(string name)
        {
            if (CurrentScene != null)
                CurrentScene.Exit();

            CurrentScene = _scenes[name];

            CurrentScene.Reset();
            CurrentScene.Run();
        }

        public void GotoScene(string name)
        {
            CurrentScene = _scenes[name];
            CurrentScene.Run();
        }

        public Scene GetScene(string name)
        {
            return _scenes[name];
        }
    }
}
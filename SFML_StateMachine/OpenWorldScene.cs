using System.Resources;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace StateMachine
{
    internal class OpenWorldScene : Scene
    {
        private Map _map;

        
        private Clock clock = new Clock();
        public MainCharacter myCharacter;
        public Cat cat;
        public Bat bat;
        public Mage mage;
        public FinalBoss finalBoss;
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
            mage = new Mage(_map);
            finalBoss = new FinalBoss(_map);
            enemyKilledWithSword = new EnemyKilledWithSword(_map);
            ItemsAndNpcs = new ItemsAndNpcs();
            this.gameObject = gameObject;
        }

        public override void Draw()
        {
            _map.Draw(_gameObject.Window);
            myCharacter.Draw(_gameObject.Window);

            if (!Cat.CatIsDead) cat.Draw(_gameObject.Window);
            if (!Bat.BatIsDead) bat.Draw(_gameObject.Window);
            if (!Mage.MageIsDead) mage.Draw(_gameObject.Window);
            if (!FinalBoss.FinalBossIsDead) finalBoss.Draw(_gameObject.Window);
            if (!EnemyKilledWithSword.EnemyKilledWithSwordIsDead) enemyKilledWithSword.Draw(_gameObject.Window);

            ItemsAndNpcs.Draw(_gameObject.Window);

            _gameObject.Window.SetView(view);

            base.Draw();
        }

        public override void Update()
        {
            _gameObject.Window.SetFramerateLimit(30);

            float deltatime = clock.Restart().AsSeconds();
            myCharacter.Update(deltatime);

            if (!EnemyKilledWithSword.EnemyKilledWithSwordIsDead) enemyKilledWithSword.Update(deltatime);
            if(!Cat.CatIsDead) cat.Update(deltatime);
            if(!Bat.BatIsDead) bat.Update(deltatime);
            if(!FinalBoss.FinalBossIsDead)finalBoss.Update(deltatime);
            if(!Mage.MageIsDead) mage.Update(deltatime);

            view.Center = new Vector2f((myCharacter.Xpos + 32), (myCharacter.Ypos + 32));

            //ReWork Animation classes into small pieces
            base.Update();
        }

        public override void HandleKeyPress(KeyEventArgs e)
        {

            if (e.Code == Keyboard.Key.Escape && !_gameObject.SceneManager.GetScene("OpenWorld").IsPaused )
            {
                _gameObject.SceneManager.GetScene("OpenWorld").Pause();
            }
            else if (e.Code == Keyboard.Key.Escape && _gameObject.SceneManager.GetScene("OpenWorld").IsPaused)
            { Reset(); _gameObject.SceneManager.GetScene("OpenWorld").Resume(); }

            //if (e.Code == Keyboard.Key.V)
            //{
            //    Reset();
            //    _gameObject.SceneManager.GetScene("OpenWorld").Resume();
            //}

            base.HandleKeyPress(e);
        }

       

        public override void Reset()
        {
            clock.Restart();
        }
    }
}
using System;
using System.Resources;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace StateMachine
{
    /// <summary>
    /// Just a scene where all things are created :)
    /// </summary>
    internal class OpenWorldScene : Scene
    {
        private Map _map;

        
        private Clock clock = new Clock();
        public static Clock TalkingClock = new Clock();
        public static int TalkingTimerInteger;
        public MainCharacter myCharacter;
        public Cat cat;
        public Bat bat;
        public Mage mage;
        public FinalBoss finalBoss;
        public EnemyKilledWithSword enemyKilledWithSword;
        public ItemsAndNpcs ItemsAndNpcs;
        public GameObject gameObject;
        public MessageBox messageBox;
        public MessageText messageText;
        public static View view;
        public static Music music;

        public static bool musicIsPlaying;

        public static int ViewPortX, ViewPortY; 
        


        public OpenWorldScene(GameObject gameObject) : base(gameObject)
        {
            ViewPortX = 800;
            ViewPortY = 600;

            music = new Music(@"Resources\Sounds\Morning_Stroll.wav");

            view = new View(new Vector2f(0, 0), new Vector2f(ViewPortX, ViewPortY));
            _map = new Map(this);
            myCharacter = new MainCharacter(_map);
            cat = new Cat(_map);
            bat = new Bat(_map);
            mage = new Mage(_map);
            finalBoss = new FinalBoss(_map);
            enemyKilledWithSword = new EnemyKilledWithSword(_map);
            ItemsAndNpcs = new ItemsAndNpcs();
            messageBox = new MessageBox();
            messageText = new MessageText();
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

            //Message box showed only 3 seconds
            if (MainCharacter.CharIsTalking)
            {
                messageBox.Draw(_gameObject.Window);
                messageText.Draw(_gameObject.Window);
            }

            base.Draw();
        }

        public override void Update()
        {
            if(!musicIsPlaying)
            { 
            music.Play();
            musicIsPlaying = true;
            }

            TalkingTimerInteger = (int)TalkingClock.ElapsedTime.AsSeconds();
           _gameObject.Window.SetFramerateLimit(60);
            float deltatime = clock.Restart().AsSeconds();
            myCharacter.Update(deltatime);
            if (MainCharacter.CharIsTalking)
            {
                messageBox.Update();
            }

            if (!EnemyKilledWithSword.EnemyKilledWithSwordIsDead) enemyKilledWithSword.Update(deltatime);
            if(!Cat.CatIsDead) cat.Update(deltatime);
            if(!Bat.BatIsDead) bat.Update(deltatime);
            if(!FinalBoss.FinalBossIsDead)finalBoss.Update(deltatime);
            if(!Mage.MageIsDead) mage.Update(deltatime);

            view.Center = new Vector2f((myCharacter.Xpos + 32), (myCharacter.Ypos + 32));          
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

            base.HandleKeyPress(e);
        }

       
        /// <summary>
        /// Reset Functions for the deltatime (The Characters won't jump )
        /// </summary>
        public override void Reset()
        {
            clock.Restart();
            music = new Music(@"Resources\Sounds\Morning_Stroll.wav");
        }
    }
}
﻿using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace StateMachine
{
    internal class Splashscreen : Scene
    {
        private Texture Splashtexture;
        private Sprite Splashsprite;

        private Timer Timer;

        public Splashscreen(GameObject gameObject) : base(gameObject)
        {
            BackgroundColor = Color.Cyan;
        }

        public override void Initialize()
        {
            Splashtexture = new Texture("Resources/Splashscreen/Splashscreen.png");
            Splashsprite = new Sprite(Splashtexture);

            Splashsprite.Position = new Vector2f();
            Splashsprite.Scale = new Vector2f((float)_gameObject.XRes / Splashsprite.Texture.Size.X, (float)_gameObject.YRes / Splashsprite.Texture.Size.Y);

            Timer = new Timer();

            base.Initialize();
        }

        public override void Update()
        {
            Timer.Update();

            if (Timer.Current >= 3)
            {
                _gameObject.SceneManager.StartScene("main");
                this.Dispose();
            }

            _gameObject.Window.Draw(Splashsprite);
        }
    }
}
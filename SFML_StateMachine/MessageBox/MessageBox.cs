﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace StateMachine
{
    class MessageBox
    {
        private Sprite _spriteBox;
        private Texture _textureBox;

    public MessageBox()
        {
            _textureBox = new Texture("Resources/Map/MessageBox.png");
            _spriteBox = new Sprite(_textureBox);           
        }

        public void Update()
        {
            _spriteBox.Position = new Vector2f((MainCharacter.currentPositionX - OpenWorldScene.ViewPortX / 4),
            MainCharacter.currentPositionY + OpenWorldScene.ViewPortY / 4);
        }
        public void Draw(RenderWindow window)
        {
            
            
            _spriteBox.Scale = new Vector2f(0.5f, 0.2f);
            window.Draw(_spriteBox);
            Console.WriteLine(_spriteBox.Position.Y);
        }
    }
}
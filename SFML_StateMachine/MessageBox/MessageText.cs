using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace StateMachine
{
    class MessageText
    {
        private Text _textSpeaker,_textMessage;
        private Font _font;
        public static int _counterMessage;
        public static int _counterSpeaker;


        private static readonly string[] Speaker = new string[3]
        {
           "Cat:",
           "123123123",
           "j2374sdf134"
        };

        private static readonly string[] Message = new string[3]
{
           "Meow Meow (Who the fuck are you?)",
           "123123123",
           "j2374sdf134"
};

        public MessageText()
        {
            _font = new Font(@"Resources\arial.ttf");
            _textSpeaker = new Text("", _font);
            _textMessage = new Text("", _font);
            _textMessage.CharacterSize = 12;
            _textSpeaker.CharacterSize = 18;
        }

        public void Draw(RenderWindow window)
        {
            _textSpeaker.DisplayedString = Speaker[_counterSpeaker];
            _textSpeaker.Position = new Vector2f((MainCharacter.currentPositionX - OpenWorldScene.ViewPortX / 4 + 20),
           (MainCharacter.currentPositionY + OpenWorldScene.ViewPortY / 4) + 5);

            _textMessage.DisplayedString = Message[_counterMessage];           
            _textMessage.Position = new Vector2f(_textSpeaker.Position.X, _textSpeaker.Position.Y + 25);
            window.Draw(_textMessage);
            window.Draw(_textSpeaker);

        }
    }
}

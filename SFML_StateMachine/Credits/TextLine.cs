using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace StateMachine
{
    class TextLine
    {
        public Vector2f Position;
        public string Text;

        public TextLine(Vector2f thePosition, string theText)
        {
            Position = thePosition;
            Text = theText;
        }
    }
}

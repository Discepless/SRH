using SFML.System;

namespace StateMachine
{
    internal class TextLine
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
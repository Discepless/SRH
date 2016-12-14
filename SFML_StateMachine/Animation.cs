namespace StateMachine
{
    internal class Animation
    {
        public int offsetTop;
        public int offsetLeft;
        public int numFrames;

        public Animation(int offsetTop, int offsetLeft, int numFrames)
        {
            this.offsetLeft = offsetLeft;
            this.offsetTop = offsetTop;
            this.numFrames = numFrames;
        }
    }
}
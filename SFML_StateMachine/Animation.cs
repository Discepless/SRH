namespace StateMachine
{ 
    internal class Animation
    {
        public int offsetTop;
        public int offsetLeft;
        public int numFrames;
        /// <summary>
        /// Builder for Anim Class
        /// </summary>
        /// <param name="offsetTop"></param>
        /// <param name="offsetLeft"></param>
        /// <param name="numFrames"></param>
        public Animation(int offsetTop, int offsetLeft, int numFrames)
        {
            this.offsetLeft = offsetLeft;
            this.offsetTop = offsetTop;
            this.numFrames = numFrames;
        }
    }
}
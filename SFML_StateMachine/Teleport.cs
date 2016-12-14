using SFML.Graphics;

namespace StateMachine
{
    internal class Teleport
    {
        public IntRect TeleportA, TeleportB;

        public int AxPos, AyPos, Awidth, Aheight,
                   BxPos, ByPos, Bwidth, Bheight;

        public Teleport()
        {
            AxPos = 458;
            AyPos = 1200;
            Awidth = 61;
            Aheight = 58;
            BxPos = 597;
            ByPos = 856;
            Bwidth = 66;
            Bheight = 30;

            TeleportA = new IntRect(AxPos, AyPos, Awidth, Aheight);
            TeleportB = new IntRect(BxPos, ByPos, Bwidth, Bheight);
        }
    }
}
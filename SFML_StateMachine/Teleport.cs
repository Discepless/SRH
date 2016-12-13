using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameplayWorld_DM;
using SFML.Graphics;

namespace SFML_StateMachine
{
    class Teleport
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

         TeleportA = new IntRect(AxPos,AyPos,Awidth,Aheight);
         TeleportB = new IntRect(BxPos, ByPos, Bwidth, Bheight);
        }
    }
}

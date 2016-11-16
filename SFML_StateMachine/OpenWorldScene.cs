using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace GameplayWorld_DM
{
    class OpenWorldScene:Scene
    {
        private Map _map;

        public OpenWorldScene(GameObject gameObject) : base(gameObject)
        {
            _map = new Map();
        }

        public override void Draw()
        {
            base.Draw();
            _map.Draw(_gameObject.Window);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}

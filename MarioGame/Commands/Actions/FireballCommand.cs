using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class FireballCommand : ICommand
    {
        PlayerContext player;

        public FireballCommand(PlayerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            // player.throwFireball() ? for future
        }
    }
}

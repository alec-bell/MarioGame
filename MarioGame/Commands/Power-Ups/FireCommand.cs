using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class FireCommand : ICommand
    {
        PlayerContext player;

        public FireCommand(PlayerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.Flower();
        }
    }
}

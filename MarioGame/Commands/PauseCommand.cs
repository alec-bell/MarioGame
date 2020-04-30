using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class PauseCommand : ICommand
    {
        PlayerContext player;

        public PauseCommand(PlayerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            // player.pause() ? for future
        }
    }
}

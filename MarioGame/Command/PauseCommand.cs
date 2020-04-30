using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class PauseCommand : ICommand
    {
        playerContext player;

        public PauseCommand(playerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            // player.pause() ? for future
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class MoveRightCommand : ICommand
    {
        playerContext player;

        public MoveRightCommand(playerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.changeToRunning();
            // player.moveRight() ? for future
        }
    }
}

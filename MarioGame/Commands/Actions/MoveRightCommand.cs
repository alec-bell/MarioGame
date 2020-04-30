using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class MoveRightCommand : ICommand
    {
        PlayerContext player;

        public MoveRightCommand(PlayerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.MoveRight();
            // player.moveRight() ? for future
        }
    }
}

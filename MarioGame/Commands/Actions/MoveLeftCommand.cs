using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class MoveLeftCommand : ICommand
    {
        PlayerContext player;

        public MoveLeftCommand(PlayerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.MoveLeft();
            

            // player.moveLeft() ? for future
        }
    }
}

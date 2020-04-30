using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class BigCommand : ICommand
    {
        PlayerContext player;

        public BigCommand(PlayerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.ChangeToSuperMario();
        }
    }
}

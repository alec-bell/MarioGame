using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class CrouchCommand : ICommand
    {
        PlayerContext player;

        public CrouchCommand(PlayerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.ChangeToCrouching();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class CrouchCommand : ICommand
    {
        playerContext player;

        public CrouchCommand(playerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.changeToCrouching();
        }
    }
}

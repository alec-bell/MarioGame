using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class JumpCommand : ICommand
    {
        playerContext player;

        public JumpCommand(playerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.changeToJumping();
            // player.Jump() ? for future
        }
    }
}

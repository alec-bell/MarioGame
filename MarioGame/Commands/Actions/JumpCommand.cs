using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class JumpCommand : ICommand
    {
        PlayerContext player;

        public JumpCommand(PlayerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.ChangeToJumping();
            // player.Jump() ? for future
        }
    }
}

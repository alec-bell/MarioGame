using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class TakeDamageCommand : ICommand
    {
        PlayerContext player;

        public TakeDamageCommand(PlayerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.Damage();
        }
    }
}

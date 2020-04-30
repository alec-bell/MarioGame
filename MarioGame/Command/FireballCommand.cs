using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class FireballCommand : ICommand
    {
        playerContext player;

        public FireballCommand(playerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            // player.throwFireball() ? for future
        }
    }
}

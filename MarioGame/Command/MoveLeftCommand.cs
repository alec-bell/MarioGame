﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class MoveLeftCommand : ICommand
    {
        playerContext player;

        public MoveLeftCommand(playerContext player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.changeToRunning();
            // player.moveLeft() ? for future
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class UsedBlock : IBlockState
    {
        

        public UsedBlock()
        {

        }
        public void HitBottom(PlayerContext player)
        {
            //stop player somehow
        }

        public void HitSideTop(PlayerContext player)
        {
            //stop player somehow
        }
    }
}

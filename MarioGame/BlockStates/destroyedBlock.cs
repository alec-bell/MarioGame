using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class DestroyedBlock : IBlockState
    {

        public DestroyedBlock ()
        {

        }

        public void HitBottom(PlayerContext player)
        {
            //do nothing
        }

        public void HitSideTop(PlayerContext player)
        {
            //do nothing
        }
    }
}

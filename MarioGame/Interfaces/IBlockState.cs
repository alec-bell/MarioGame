using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface IBlockState
    {
        //if the block was hit from the side or top
        void HitSideTop(PlayerContext player);
        //if the block was hit from the bottom
        void HitBottom(PlayerContext player);

    }
}

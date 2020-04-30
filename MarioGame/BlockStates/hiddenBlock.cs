using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class HiddenBlock : IBlockState
    {

        BlockContext context;

        public HiddenBlock (BlockContext context)
        {
            this.context = context;
        }

        public void HitBottom(PlayerContext player)
        {
            context.CurrentBlock = context.GetBrickBlockState();
            context.SetBlockType(BlockContext.Blocks.BRICK);
            context.EntityType = TileMapInterpreter.Entities.BRICK_NOITEM;
            //context.currentBlock.hitBottom(player);
        }

        public void HitSideTop(PlayerContext player)
        {
            //do nothing
        }
    }
}

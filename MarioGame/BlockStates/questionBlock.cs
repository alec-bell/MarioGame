using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class QuestionBlock : IBlockState
    {

        BlockContext context;
        public QuestionBlock(BlockContext context)
        {
            this.context = context;
        }
        public void HitBottom(PlayerContext player)
        {
            //release item
            context.CurrentBlock = context.GetUsedBlockState();
            context.SetBlockType(BlockContext.Blocks.USED);
            context.EntityType = TileMapInterpreter.Entities.USED;
            context.bump = true;
        }

        public void HitSideTop(PlayerContext player)
        {
            //stop player
        }
    }
}

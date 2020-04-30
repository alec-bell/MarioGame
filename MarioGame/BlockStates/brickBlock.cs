using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class BrickBlock : IBlockState
    {

        BlockContext context;

        public BrickBlock(BlockContext context)
        {
            this.context = context;
        }
        public void HitBottom(PlayerContext player)
        {
            //write in if block contains item then it just turns into a used block (later)
            //stop player somehow (later)
            if(player.GetCurrentState().Equals(MarioState.Small))
            {
                context.bump = true;
            }
            else
            {
                context.CurrentBlock = context.GetDestoryedBlockState();
                context.SetBlockType(BlockContext.Blocks.DESTROYED);
                context.EntityType = TileMapInterpreter.Entities.DESTROYED;
                //destroy
            }
        }

        public void HitSideTop(PlayerContext player)
        {
            //stop player
        }
    }
}

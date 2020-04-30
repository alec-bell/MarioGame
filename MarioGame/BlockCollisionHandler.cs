using MarioGame.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class BlockCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(CollisionDetector.Collision collision, Level1 level)
        {
            CollisionDetector.CollisionSide side = collision.GetSide();
            PlayerContext player = null;
            if (collision.entity1 is PlayerContext)
            {
                player = (PlayerContext)collision.entity1;


            }
            else if (collision.entity2 is PlayerContext)
            {
                player = (PlayerContext)collision.entity2;
            }

            if(collision.entity2 is BlockContext)
            {
                if (side == CollisionDetector.CollisionSide.Left)
                {
                    side = CollisionDetector.CollisionSide.Right;
                }
                else if (side == CollisionDetector.CollisionSide.Right)
                {
                    side = CollisionDetector.CollisionSide.Left;
                }
                else if (side == CollisionDetector.CollisionSide.Top)
                {
                    side = CollisionDetector.CollisionSide.Bottom;
                    ((BlockContext)collision.entity2).bump = true;
                }
                else if (side == CollisionDetector.CollisionSide.Bottom)
                {
                    side = CollisionDetector.CollisionSide.Top;
                }
                
            }else if (side == CollisionDetector.CollisionSide.Bottom)
            {
                ((BlockContext)collision.entity2).bump = true;
            }
        }
    }
}

using MarioGame.Levels;
using MarioGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class EnemyCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(CollisionDetector.Collision collision, Level1 level)
        {
            PlayerContext player = null;
            if (collision.entity1 is PlayerContext)
            {
                player = (PlayerContext)collision.entity1;


            }
            else if (collision.entity2 is PlayerContext)
            {
                player = (PlayerContext)collision.entity2;
            }


            CollisionDetector.CollisionSide side = collision.GetSide();
            
            if (collision.entity2 is GreenKoopaSprite || collision.entity2 is RedKoopaSprite || collision.entity2 is RedGoombaSprite)
            {
                if (side == CollisionDetector.CollisionSide.Bottom)
                {
                    side = CollisionDetector.CollisionSide.Top;
                    level.Remove(collision.entity2);
                    //make this damage them instead of remove
                }
            }
            else if (side == CollisionDetector.CollisionSide.Top)
            {
                level.Remove(collision.entity1);
            }
        }
    }
}

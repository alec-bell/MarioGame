using MarioGame.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class ItemCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(CollisionDetector.Collision collision, Level1 level)
        {
            if (collision.entity1 is PlayerContext)
            {
                level.Remove(collision.entity2);
            }
            else if (collision.entity2 is PlayerContext)
            {
                level.Remove(collision.entity1);
            }
        }
    }
}

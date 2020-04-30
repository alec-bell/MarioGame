using MarioGame.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarioGame.CollisionDetector;
using static MarioGame.EntityCollisionHandler;

namespace MarioGame
{
    public interface ICollisionHandler
    {
        void HandleCollision(Collision collision, Level1 level);
    }
}

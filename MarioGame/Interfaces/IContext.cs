using MarioGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    interface IContext : IBoundable
    {
        TileMapInterpreter.Entities EntityType { get; set; }
        bool IsCollidable { get; set; }
        bool WasHit { get; set; }

        Vector2 Velocity {get; set;}

        void HitTop(IContext entity, PlayerContext player, Rectangle overlap);
        void HitBottom(IContext entity, PlayerContext player, Rectangle overlap);
        void HitLeft(IContext entity, PlayerContext player, Rectangle overlap);
        void HitRight(IContext entity, PlayerContext player, Rectangle overlap);
    }

}

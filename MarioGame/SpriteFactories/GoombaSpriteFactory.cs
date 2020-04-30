using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public enum GoombaFrame
    {
        StartWalk,
        ContinueWalk,
        Dead
    }

    public enum GoombaColor
    {
        Red,
        Blue //does nothing atm
    }
    public static class GoombaSpriteFactory
    {
        public static readonly int KOOPA_WIDTH = 15;
        private static readonly int KOOPA_HORIZONTAL_SPACE_BETWEEN = 2;

        public static readonly int GOOMBA_WIDTH = 16;
        public static readonly int GOOMBA_HEIGHT = 16;
        private static readonly int GOOMBA_HORIZONTAL_SPACE_BETWEEN = 2;
        private static readonly int GOOMBA_HEIGHT_FROM_TOP = 4;

        //Returns the location of the goomba in the sprite sheet given the color and frame
        //only red works atm
        //returns new rectangle if bad input
        public static Rectangle Goomba(GoombaColor color, GoombaFrame frame)
        {
            Rectangle rectangle = new Rectangle();
            if (color == GoombaColor.Red)
            {
                if (frame == GoombaFrame.StartWalk)
                {
                    rectangle = new Rectangle(4 + (KOOPA_WIDTH + KOOPA_HORIZONTAL_SPACE_BETWEEN) * 4, GOOMBA_HEIGHT_FROM_TOP, GOOMBA_WIDTH, GOOMBA_HEIGHT);
                }
                else if (frame == GoombaFrame.ContinueWalk)
                {
                    rectangle = new Rectangle(4 + (KOOPA_WIDTH + KOOPA_HORIZONTAL_SPACE_BETWEEN) * 4 + GOOMBA_WIDTH + GOOMBA_HORIZONTAL_SPACE_BETWEEN, GOOMBA_HEIGHT_FROM_TOP, GOOMBA_WIDTH, GOOMBA_HEIGHT);
                }
                if (frame == GoombaFrame.Dead)
                {
                    rectangle = new Rectangle(4 + (KOOPA_WIDTH + KOOPA_HORIZONTAL_SPACE_BETWEEN) * 4 + GOOMBA_WIDTH * 2 + GOOMBA_HORIZONTAL_SPACE_BETWEEN, GOOMBA_HEIGHT_FROM_TOP, GOOMBA_WIDTH, GOOMBA_HEIGHT);

                }
            }
            return rectangle;
        }
    }

    
}

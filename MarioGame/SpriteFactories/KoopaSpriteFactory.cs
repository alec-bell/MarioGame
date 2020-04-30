using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public enum KoopaFrame
    {
        StartWalkLeft,
        ContinueWalkLeft,
        StartWalkRight,
        ContinueWalkRight
        //more cases for in shell when jumped on (later)
    }

    public enum KoopaColor
    {
        Red,
        Green
    }
    public static class KoopaSpriteFactory
    {
        public static readonly int KOOPA_WIDTH = 15;
        public static readonly int KOOPA_HEIGHT = 24;
        private static readonly int KOOPA_VERTICAL_SPACE_BETWEEN = 5;
        private static readonly int KOOPA_HORIZONTAL_SPACE_BETWEEN = 2;


        //Returns the location of the koopa in the sprite sheet given the color and frame
        //returns new Rectangle if given bad input
        public static Rectangle Koopa(KoopaColor color, KoopaFrame frame)
        {
            Rectangle rectangle = new Rectangle();
            if (color == KoopaColor.Green)
            {
                if (frame == KoopaFrame.StartWalkLeft)
                {
                    rectangle = new Rectangle(KOOPA_WIDTH + KOOPA_HORIZONTAL_SPACE_BETWEEN, 0, KOOPA_WIDTH, KOOPA_HEIGHT);
                }
                else if (frame == KoopaFrame.ContinueWalkLeft)
                {
                    rectangle = new Rectangle(0, 0, KOOPA_WIDTH, KOOPA_HEIGHT);
                }

            }
            else if (color == KoopaColor.Red)
            {
                if (frame == KoopaFrame.StartWalkLeft)
                {
                    rectangle = new Rectangle(KOOPA_WIDTH + KOOPA_HORIZONTAL_SPACE_BETWEEN, KOOPA_HEIGHT + KOOPA_VERTICAL_SPACE_BETWEEN, KOOPA_WIDTH + 0, KOOPA_HEIGHT);
                }
                else if (frame == KoopaFrame.ContinueWalkLeft)
                {
                    rectangle = new Rectangle(0, KOOPA_HEIGHT + KOOPA_VERTICAL_SPACE_BETWEEN, KOOPA_WIDTH + 0, KOOPA_HEIGHT);
                }
            }
            return rectangle;
        }
    }
}

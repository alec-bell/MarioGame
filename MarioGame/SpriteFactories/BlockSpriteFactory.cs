using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public enum MysteryBlockFrame
    {
        FirstFrame,
        Flash1,
        Flash2
    }

    public enum HiddenBlockType
    {
        Hidden,
        Exposed
    }

    public static class BlockSpriteFactory
    {
        public static readonly int BLOCK_HEIGHT = 16;
        public static readonly int BLOCK_WIDTH = 16;
        public static readonly int EXPLODED_BLOCK_HEIGHT = 8;
        public static readonly int EXPLODED_BLOCK_WIDTH = 8;

        public static Rectangle BrickBlock()
        {
            return new Rectangle(BLOCK_WIDTH * 2, 0, BLOCK_WIDTH, BLOCK_HEIGHT);
        }

        public static Rectangle ExplodedBrickBlock()
        {
            return new Rectangle(BLOCK_WIDTH * 2, 0, EXPLODED_BLOCK_HEIGHT, EXPLODED_BLOCK_WIDTH);
        }

        public static Rectangle UsedBlock()
        {
            return new Rectangle(BLOCK_WIDTH * 3, 0, BLOCK_WIDTH, BLOCK_HEIGHT);
        }

        public static Rectangle MysteryBlock(MysteryBlockFrame frame)
        {
            switch (frame)
            {
                case MysteryBlockFrame.FirstFrame:
                    return new Rectangle(BLOCK_WIDTH * 23, 0, BLOCK_WIDTH, BLOCK_HEIGHT);
                case MysteryBlockFrame.Flash1:
                    return new Rectangle(BLOCK_WIDTH * 24, 0, BLOCK_WIDTH, BLOCK_HEIGHT);
                case MysteryBlockFrame.Flash2:
                    return new Rectangle(BLOCK_WIDTH * 25, 0, BLOCK_WIDTH, BLOCK_HEIGHT);
                default:
                    return new Rectangle();
            }
        }

        public static Rectangle StairBlock()
        {
            return new Rectangle(0, BLOCK_HEIGHT, BLOCK_WIDTH, BLOCK_HEIGHT);
        }

        public static Rectangle FloorBlock()
        {
            return new Rectangle(0, 0, BLOCK_WIDTH, BLOCK_HEIGHT);
        }

        public static Rectangle HiddenBlock(HiddenBlockType type)
        {
            switch (type)
            {
                case HiddenBlockType.Hidden:
                    return new Rectangle(400, 400, 0, 0);
                case HiddenBlockType.Exposed:
                    return new Rectangle(BLOCK_WIDTH * 3, 0, BLOCK_WIDTH, BLOCK_HEIGHT);
                default:
                    return new Rectangle();
            }
        }

        public static Rectangle EmptyBlock()
        {
            return new Rectangle(400, 400, 0, 0);
        }
    }
}

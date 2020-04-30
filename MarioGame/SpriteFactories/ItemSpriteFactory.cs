using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public enum CoinFrame
    {
        FirstFrame,
        Rotate1,
        Rotate2,
        Rotate3
    }

    //Two types of coins-- 'block' coins come from hitting blocks, 'static' coins are in the stage
    public enum CoinType
    {
        Block,
        Static
    }

    public enum FireFlowerFrame
    {
        FirstFrame,
        Flash1,
        Flash2,
        Flash3
    }

    public enum StarmanFrame
    {
        FirstFrame,
        Flash1,
        Flash2,
        Flash3
    }

    public enum MushroomType
    {
        Super,
        _1Up
    }

    public static class ItemSpriteFactory
    {
        public static readonly int ITEM_HEIGHT = 16;
        public static readonly int ITEM_WIDTH = 16;
        
        public static Rectangle Coin(CoinType type, CoinFrame frame)
        {
            Rectangle rectangle = new Rectangle();
            if (type == CoinType.Static)
            {
                if (frame == CoinFrame.FirstFrame)
                {
                    rectangle = new Rectangle(0, ITEM_HEIGHT * 5, ITEM_WIDTH, ITEM_HEIGHT);
                }
                else if (frame == CoinFrame.Rotate1)
                {
                    rectangle = new Rectangle(ITEM_WIDTH, ITEM_HEIGHT * 5, ITEM_WIDTH, ITEM_HEIGHT);
                }
                else if (frame == CoinFrame.Rotate2)
                {
                    rectangle = new Rectangle(ITEM_WIDTH * 2, ITEM_HEIGHT * 5, ITEM_WIDTH, ITEM_HEIGHT);
                }
                else if (frame == CoinFrame.Rotate3)
                {
                    rectangle = new Rectangle(ITEM_WIDTH * 3, ITEM_HEIGHT * 5, ITEM_WIDTH, ITEM_HEIGHT);
                }
            }
            else if (type == CoinType.Block)
            {
                if (frame == CoinFrame.FirstFrame)
                {
                    rectangle = new Rectangle(0, ITEM_HEIGHT * 6, ITEM_WIDTH, ITEM_HEIGHT);
                }
                else if (frame == CoinFrame.Rotate1)
                {
                    rectangle = new Rectangle(ITEM_WIDTH, ITEM_HEIGHT * 6, ITEM_WIDTH, ITEM_HEIGHT);
                }
                else if (frame == CoinFrame.Rotate2)
                {
                    rectangle = new Rectangle(ITEM_WIDTH * 2, ITEM_HEIGHT * 6, ITEM_WIDTH, ITEM_HEIGHT);
                }
                else if (frame == CoinFrame.Rotate3)
                {
                    rectangle = new Rectangle(ITEM_WIDTH * 3, ITEM_HEIGHT * 6, ITEM_WIDTH, ITEM_HEIGHT);
                }
            }
            return rectangle;
        }

        public static Rectangle Mushroom(MushroomType type)
        {
            Rectangle rectangle = new Rectangle();
            if (type == MushroomType.Super)
            {
                rectangle = new Rectangle(0, 0, ITEM_WIDTH, ITEM_HEIGHT);
            }
            else if (type == MushroomType._1Up)
            {
                rectangle = new Rectangle(ITEM_WIDTH, 0, ITEM_WIDTH, ITEM_HEIGHT);
            }
            return rectangle;
        }

        public static Rectangle FireFlower(FireFlowerFrame frame)
        {
            Rectangle rectangle = new Rectangle();
            if (frame == FireFlowerFrame.FirstFrame)
            {
                rectangle = new Rectangle(0, ITEM_HEIGHT * 2, ITEM_WIDTH, ITEM_HEIGHT);
            }
            else if (frame == FireFlowerFrame.Flash1)
            {
                rectangle = new Rectangle(ITEM_WIDTH, ITEM_HEIGHT * 2, ITEM_WIDTH, ITEM_HEIGHT);
            }
            else if (frame == FireFlowerFrame.Flash2)
            {
                rectangle = new Rectangle(ITEM_WIDTH * 2, ITEM_HEIGHT * 2, ITEM_WIDTH, ITEM_HEIGHT);
            }
            else if (frame == FireFlowerFrame.Flash3)
            {
                rectangle = new Rectangle(ITEM_WIDTH * 3, ITEM_HEIGHT * 2, ITEM_WIDTH, ITEM_HEIGHT);
            }

            return rectangle;
        }

        public static Rectangle Starman(StarmanFrame frame)
        {
            Rectangle rectangle = new Rectangle();
            if (frame == StarmanFrame.FirstFrame)
            {
                rectangle = new Rectangle(0, ITEM_HEIGHT * 3, ITEM_WIDTH, ITEM_HEIGHT);
            }
            else if (frame == StarmanFrame.Flash1)
            {
                rectangle = new Rectangle(ITEM_WIDTH, ITEM_HEIGHT * 3, ITEM_WIDTH, ITEM_HEIGHT);
            }
            else if (frame == StarmanFrame.Flash2)
            {
                rectangle = new Rectangle(ITEM_WIDTH * 2, ITEM_HEIGHT * 3, ITEM_WIDTH, ITEM_HEIGHT);
            }
            else if (frame == StarmanFrame.Flash3)
            {
                rectangle = new Rectangle(ITEM_WIDTH * 3, ITEM_HEIGHT * 3, ITEM_WIDTH, ITEM_HEIGHT);
            }

            return rectangle;
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public enum MarioState
    {
        Dead,
        Fire,
        Small,
        BigStar,
        SmallStar,
        Super
    }

    public enum MarioColor
    {
        Red,
        Green //does nothing atm
    }

    //The walk and run frames are the "in-progress" frames, i.e. the animation
    //walk1,walk2,walk3 will not start with idle
    public enum MarioFrame
    {
        Idle,
        IdleStar,
        Crouching,
        CrouchingStar, //Needed for flashing
        Falling,
        FallingStar, //Needed for flashing
        Walking1,
        Walking2,
        Walking3,
        WalkingStar1, //Needed for flashing
        WalkingStar2,
        WalkingStar3,
        Running1,
        Running2,
        Running3,
        Running4, //small mario only has 3 running frames and the walking frames are the same as the running frames
        Running5,
        RunningStar1,
        RunningStar2,
        RunningStar3,
        RunningStar4, //small mario only has 3 running frames and the walking frames are the same as the running frames
        RunningStar5,
        Jumping,
        JumpingStar, //Needed for flashing
        Dying
    }

    public static class MarioSpriteFactory
    {
        public static readonly int BIG_MARIO_HEIGHT = 32;
        public static readonly int BIG_MARIO_WIDTH = 16;
        public static readonly int SMALL_MARIO_HEIGHT = 16;
        public static readonly int SMALL_MARIO_WIDTH = 16;
        public static readonly int SEPARATING_MARIO_LINE = 1;

        public static Rectangle Mario(MarioColor color, MarioState state, MarioFrame frame)
        {
            Rectangle rectangle = new Rectangle();
            if (color == MarioColor.Red)
            {
                if (state == MarioState.Dead)
                {
                    rectangle = new Rectangle((SMALL_MARIO_WIDTH * 6 + SEPARATING_MARIO_LINE * 7), (BIG_MARIO_HEIGHT + SEPARATING_MARIO_LINE * 2), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                }
                else if (state == MarioState.Fire)
                {
                    if (frame == MarioFrame.Crouching)
                    {
                        rectangle = new Rectangle((BIG_MARIO_WIDTH * 6) + (SEPARATING_MARIO_LINE * 7), (SMALL_MARIO_HEIGHT + BIG_MARIO_HEIGHT) * 2 + (SEPARATING_MARIO_LINE * 5), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);
                    }
                    else if (frame == MarioFrame.Falling || frame == MarioFrame.Jumping)
                    {
                        rectangle = new Rectangle((BIG_MARIO_WIDTH * 5) + (SEPARATING_MARIO_LINE * 6), (SMALL_MARIO_HEIGHT + BIG_MARIO_HEIGHT) * 2 + (SEPARATING_MARIO_LINE * 5), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);
                    }
                    else if (frame == MarioFrame.Idle)
                    {
                        rectangle = new Rectangle(SEPARATING_MARIO_LINE, (SMALL_MARIO_HEIGHT + BIG_MARIO_HEIGHT) * 2 + (SEPARATING_MARIO_LINE * 5), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);
                    }
                    else if (frame == MarioFrame.Running1)
                    {
                        rectangle = new Rectangle((BIG_MARIO_WIDTH * 16) + (SEPARATING_MARIO_LINE * 17), (SMALL_MARIO_HEIGHT + BIG_MARIO_HEIGHT) * 2 + (SEPARATING_MARIO_LINE * 5), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);
                    }
                    else if (frame == MarioFrame.Running2)
                    {
                        rectangle = new Rectangle((BIG_MARIO_WIDTH * 17) + (SEPARATING_MARIO_LINE * 18), (SMALL_MARIO_HEIGHT + BIG_MARIO_HEIGHT) * 2 + (SEPARATING_MARIO_LINE * 5), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);
                    }
                    else if (frame == MarioFrame.Running3)
                    {
                        rectangle = new Rectangle((BIG_MARIO_WIDTH * 18) + (SEPARATING_MARIO_LINE * 19), (SMALL_MARIO_HEIGHT + BIG_MARIO_HEIGHT) * 2 + (SEPARATING_MARIO_LINE * 5), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);
                    }

                    else if (frame == MarioFrame.Running4)
                    {
                        rectangle = new Rectangle((BIG_MARIO_WIDTH * 19) + (SEPARATING_MARIO_LINE * 20), (SMALL_MARIO_HEIGHT + BIG_MARIO_HEIGHT) * 2 + (SEPARATING_MARIO_LINE * 5), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);
                    }
                    else if (frame == MarioFrame.Running5)
                    {
                        rectangle = new Rectangle((BIG_MARIO_WIDTH * 20) + (SEPARATING_MARIO_LINE * 21), (SMALL_MARIO_HEIGHT + BIG_MARIO_HEIGHT) * 2 + (SEPARATING_MARIO_LINE * 5), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Walking1)
                    {
                        rectangle = new Rectangle((BIG_MARIO_WIDTH) + (SEPARATING_MARIO_LINE * 2), (SMALL_MARIO_HEIGHT + BIG_MARIO_HEIGHT) * 2 + (SEPARATING_MARIO_LINE * 5), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Walking2)
                    {
                        rectangle = new Rectangle((BIG_MARIO_WIDTH * 2) + (SEPARATING_MARIO_LINE * 3), (SMALL_MARIO_HEIGHT + BIG_MARIO_HEIGHT) * 2 + (SEPARATING_MARIO_LINE * 5), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Walking3)
                    {
                        rectangle = new Rectangle((BIG_MARIO_WIDTH * 3) + (SEPARATING_MARIO_LINE * 4), (SMALL_MARIO_HEIGHT + BIG_MARIO_HEIGHT) * 2 + (SEPARATING_MARIO_LINE * 5), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Dying)
                    {
                        rectangle = new Rectangle((BIG_MARIO_WIDTH * 3) + (SEPARATING_MARIO_LINE * 4), SMALL_MARIO_HEIGHT * 2 + BIG_MARIO_HEIGHT * 3 + (SEPARATING_MARIO_LINE * 6), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);
                    }
                }

                else if (state == MarioState.Small)
                {
                    if (frame == MarioFrame.Crouching || frame == MarioFrame.Idle)
                    {
                        rectangle = new Rectangle(SEPARATING_MARIO_LINE, BIG_MARIO_HEIGHT + (SEPARATING_MARIO_LINE * 2), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Falling || frame == MarioFrame.Jumping)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH * 5 + SEPARATING_MARIO_LINE * 6, BIG_MARIO_HEIGHT + (SEPARATING_MARIO_LINE * 2), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running1 || frame == MarioFrame.Walking1)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH + (SEPARATING_MARIO_LINE * 2), BIG_MARIO_HEIGHT + (SEPARATING_MARIO_LINE * 2), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running2 || frame == MarioFrame.Walking2)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH * 2 + (SEPARATING_MARIO_LINE * 3), BIG_MARIO_HEIGHT + (SEPARATING_MARIO_LINE * 2), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running3 || frame == MarioFrame.Walking3)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH * 3 + (SEPARATING_MARIO_LINE * 4), BIG_MARIO_HEIGHT + (SEPARATING_MARIO_LINE * 2), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running4)
                    {
                        //Small mario only has 3 running frames and the walking frames are the same as the running frames
                    }
                    else if (frame == MarioFrame.Running5)
                    {
                        //Small mario only has 3 running frames and the walking frames are the same as the running frames
                    }
                    else if (frame == MarioFrame.Dying)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH * 6 + (SEPARATING_MARIO_LINE * 7), BIG_MARIO_HEIGHT + (SEPARATING_MARIO_LINE * 2), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                }
                else if (state == MarioState.Super)
                {
                    if (frame == MarioFrame.Crouching)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 6 + SEPARATING_MARIO_LINE * 7, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Falling || frame == MarioFrame.Jumping)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 5 + SEPARATING_MARIO_LINE * 6, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Idle)
                    {
                        rectangle = new Rectangle(SEPARATING_MARIO_LINE, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running1)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 16 + SEPARATING_MARIO_LINE * 17, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running2)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 17 + SEPARATING_MARIO_LINE * 18, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running3)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 18 + SEPARATING_MARIO_LINE * 19, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running4)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 19 + SEPARATING_MARIO_LINE * 20, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running5)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 20 + SEPARATING_MARIO_LINE * 21, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Walking1)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH + (SEPARATING_MARIO_LINE * 2), SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Walking2)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 2 + (SEPARATING_MARIO_LINE * 3), SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Walking3)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 3 + (SEPARATING_MARIO_LINE * 4), SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Dying)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH * 6 + (SEPARATING_MARIO_LINE * 7), BIG_MARIO_HEIGHT + (SEPARATING_MARIO_LINE * 2), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                }
                else if (state == MarioState.SmallStar)
                {
                    if (frame == MarioFrame.CrouchingStar || frame == MarioFrame.IdleStar)
                    {
                        rectangle = new Rectangle(SEPARATING_MARIO_LINE, (BIG_MARIO_HEIGHT * 5) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 10), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.FallingStar || frame == MarioFrame.JumpingStar)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH * 5 + SEPARATING_MARIO_LINE * 6, (BIG_MARIO_HEIGHT * 5) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 10), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.RunningStar4)
                    {
                        //small mario only has 3 running frames and the walking frames are the same as the running frames
                    }
                    else if (frame == MarioFrame.RunningStar5)
                    {
                        //small mario only has 3 running frames and the walking frames are the same as the running frames
                    }
                    else if (frame == MarioFrame.WalkingStar1 || frame == MarioFrame.RunningStar1)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH + SEPARATING_MARIO_LINE * 2, (BIG_MARIO_HEIGHT * 5) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 10), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.WalkingStar2 || frame == MarioFrame.RunningStar2)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH * 2 + SEPARATING_MARIO_LINE * 3, (BIG_MARIO_HEIGHT * 5) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 10), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.WalkingStar3 || frame == MarioFrame.RunningStar3)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH * 3 + SEPARATING_MARIO_LINE * 4, (BIG_MARIO_HEIGHT * 5) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 10), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Dying)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH * 6 + SEPARATING_MARIO_LINE * 7, (BIG_MARIO_HEIGHT * 5) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 10), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    if (frame == MarioFrame.Crouching || frame == MarioFrame.Idle)
                    {
                        rectangle = new Rectangle(SEPARATING_MARIO_LINE, BIG_MARIO_HEIGHT + (SEPARATING_MARIO_LINE * 2), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Falling || frame == MarioFrame.Jumping)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH * 5 + SEPARATING_MARIO_LINE * 6, BIG_MARIO_HEIGHT + (SEPARATING_MARIO_LINE * 2), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running1 || frame == MarioFrame.Walking1)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH + (SEPARATING_MARIO_LINE * 2), BIG_MARIO_HEIGHT + (SEPARATING_MARIO_LINE * 2), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running2 || frame == MarioFrame.Walking2)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH * 2 + (SEPARATING_MARIO_LINE * 3), BIG_MARIO_HEIGHT + (SEPARATING_MARIO_LINE * 2), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running3 || frame == MarioFrame.Walking3)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH * 3 + (SEPARATING_MARIO_LINE * 4), BIG_MARIO_HEIGHT + (SEPARATING_MARIO_LINE * 2), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                }
                else if (state == MarioState.BigStar)
                {
                    if (frame == MarioFrame.CrouchingStar)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 6 + SEPARATING_MARIO_LINE * 7, (BIG_MARIO_HEIGHT * 4) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 9), SMALL_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.FallingStar || frame == MarioFrame.JumpingStar)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 5 + SEPARATING_MARIO_LINE * 6, (BIG_MARIO_HEIGHT * 4) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 9), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.IdleStar)
                    {
                        rectangle = new Rectangle(SEPARATING_MARIO_LINE, (BIG_MARIO_HEIGHT * 4) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 9), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.RunningStar1)
                    {

                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 16 + SEPARATING_MARIO_LINE * 17, (BIG_MARIO_HEIGHT * 4) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 9), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);


                    }
                    else if (frame == MarioFrame.RunningStar2)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 17 + SEPARATING_MARIO_LINE * 18, (BIG_MARIO_HEIGHT * 4) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 9), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.RunningStar3)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 18 + SEPARATING_MARIO_LINE * 19, (BIG_MARIO_HEIGHT * 4) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 9), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.RunningStar4)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 19 + SEPARATING_MARIO_LINE * 20, (BIG_MARIO_HEIGHT * 4) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 9), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.RunningStar5)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 20 + SEPARATING_MARIO_LINE * 21, (BIG_MARIO_HEIGHT * 4) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 9), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.WalkingStar1)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH + SEPARATING_MARIO_LINE * 2, (BIG_MARIO_HEIGHT * 4) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 9), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.WalkingStar2)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 2 + SEPARATING_MARIO_LINE * 3, (BIG_MARIO_HEIGHT * 4) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 9), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.WalkingStar3)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 3 + SEPARATING_MARIO_LINE * 4, (BIG_MARIO_HEIGHT * 4) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 9), BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Dying)
                    {
                        rectangle = new Rectangle(SMALL_MARIO_WIDTH * 6 + SEPARATING_MARIO_LINE * 7, (BIG_MARIO_HEIGHT * 5) + (SMALL_MARIO_HEIGHT * 4) + (SEPARATING_MARIO_LINE * 10), SMALL_MARIO_WIDTH, SMALL_MARIO_HEIGHT);

                    }
                    if (frame == MarioFrame.Crouching)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 6 + SEPARATING_MARIO_LINE * 7, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Falling || frame == MarioFrame.Jumping)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 5 + SEPARATING_MARIO_LINE * 6, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Idle)
                    {
                        rectangle = new Rectangle(SEPARATING_MARIO_LINE, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running1)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 16 + SEPARATING_MARIO_LINE * 17, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running2)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 17 + SEPARATING_MARIO_LINE * 18, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running3)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 18 + SEPARATING_MARIO_LINE * 19, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running4)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 19 + SEPARATING_MARIO_LINE * 20, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Running5)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 20 + SEPARATING_MARIO_LINE * 21, SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Walking1)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH + (SEPARATING_MARIO_LINE * 2), SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Walking2)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 2 + (SEPARATING_MARIO_LINE * 3), SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                    else if (frame == MarioFrame.Walking3)
                    {
                        rectangle = new Rectangle(BIG_MARIO_WIDTH * 3 + (SEPARATING_MARIO_LINE * 4), SEPARATING_MARIO_LINE, BIG_MARIO_WIDTH, BIG_MARIO_HEIGHT);

                    }
                }
            }
            return rectangle;
        }

    }
}

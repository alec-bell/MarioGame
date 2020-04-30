using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class RunningMario : IActionState
    {
        PlayerContext context;

        public RunningMario(PlayerContext context)
        {
            this.context = context;
        }

        public void Idle()
        {
            context.ActionState = context.GetIdleMarioState();
            context.SetCurrentFrame(MarioFrame.Idle);
        }
        public void Crouching()
        {
            context.ActionState = context.GetCrouchingMarioState();
            context.SetCurrentFrame(MarioFrame.Crouching);
        }

        public void Jumping()
        {
            context.ActionState = context.GetJumpingMarioState();
            context.SetCurrentFrame(MarioFrame.Jumping);
        }

        public void Falling()
        {
            context.ActionState = context.GetFallingMarioState();
            context.SetCurrentFrame(MarioFrame.Falling);
        }

        public void Running()
        {

        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Sprites;

namespace MarioGame
{
    class FallingMario : IActionState
    {
        PlayerContext context;

        public FallingMario(PlayerContext context)
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
            
        }

        public void Running()
        {
            context.ActionState = context.GetRunningMarioState();
            context.SetCurrentFrame(MarioFrame.Walking1);
        }
    }
}

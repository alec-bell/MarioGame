using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace MarioGame
{
    class IdleMario : IActionState
    {
        PlayerContext context;

        public IdleMario(PlayerContext context)
        {
            this.context = context;
        }

        public void Idle()
        {

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
            context.ActionState = context.GetRunningMarioState();
            context.SetCurrentFrame(MarioFrame.Walking1);
        }
    }
}

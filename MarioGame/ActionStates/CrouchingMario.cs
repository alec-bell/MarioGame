using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Sprites;

namespace MarioGame
{
    class CrouchingMario : IActionState
    {
        PlayerContext context;
        public CrouchingMario(PlayerContext context)
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

        }

        //if player is crouching and 'jumps', PBI states should go to idle state instead
        public void Jumping()
        {
            context.ActionState = context.GetIdleMarioState();
            context.SetCurrentFrame(MarioFrame.Idle);
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

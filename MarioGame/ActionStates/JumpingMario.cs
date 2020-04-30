using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class JumpingMario : IActionState
    {
        PlayerContext context;

        public JumpingMario(PlayerContext context)
        {
            this.context = context;
        }

        public void Idle()
        {
            context.ActionState = context.GetIdleMarioState();
            context.SetCurrentFrame(MarioFrame.Idle);

        }

        //PBI states that 'crouching' while jumping makes the player go to idle state
        public void Crouching()
        {
            context.ActionState = context.GetIdleMarioState();
            context.SetCurrentFrame(MarioFrame.Idle);
        }

        public void Jumping()
        {

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

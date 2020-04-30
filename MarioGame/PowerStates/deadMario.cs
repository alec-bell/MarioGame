using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class DeadMario : IPowerState
    {

        PlayerContext context;

        public DeadMario (PlayerContext context)
        {
            this.context = context;
        }
        public void Damage()
        {
            
        }

        public void Flower()
        {
            context.PowerState = context.GetFireMarioState();
            context.SetCurrentState(MarioState.Fire);
            context.WidthHeight = new Vector2(MarioSpriteFactory.BIG_MARIO_WIDTH, MarioSpriteFactory.BIG_MARIO_WIDTH);
            context.GrowUp();
            context.PowerState.Transition();
        }

        public void Mushroom()
        {
            
        }

        public void ChangeToSmallMario()
        {
            context.PowerState = context.GetSmallMarioState();
            context.SetCurrentState(MarioState.Small);
            context.PowerState.Transition();
        }

        public void Star()
        {
            
        }

        public void ChangeToSuperMario()
        {
            context.PowerState = context.GetSuperMarioState();
            context.SetCurrentState(MarioState.Super);
            context.WidthHeight = new Vector2(MarioSpriteFactory.BIG_MARIO_WIDTH, MarioSpriteFactory.BIG_MARIO_HEIGHT);
            context.GrowUp();
            context.PowerState.Transition();
        }

        public void Transition()
        {
            //when he makes dead mario
        }

        public void ChangeToFireMario()
        {
            context.PowerState = context.GetSuperMarioState();
            context.SetCurrentState(MarioState.Fire);
            context.WidthHeight = new Vector2(MarioSpriteFactory.BIG_MARIO_WIDTH, MarioSpriteFactory.BIG_MARIO_HEIGHT);
            context.GrowUp();
            context.PowerState.Transition();
        }
    }
}

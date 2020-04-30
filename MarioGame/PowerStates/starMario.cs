using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    class StarMario : IPowerState
    {

        PlayerContext context;

        public StarMario(PlayerContext context, IPowerState returnState)
        {
            this.context = context;
            this.context.returnState = returnState;
            this.context.timer.Start();
        }

        public void ChangeToFireMario()
        {
            context.PowerState = context.GetSuperMarioState();
            context.SetCurrentState(MarioState.Fire);
            context.WidthHeight = new Vector2(MarioSpriteFactory.BIG_MARIO_WIDTH, MarioSpriteFactory.BIG_MARIO_HEIGHT);
            context.GrowUp();
            context.PowerState.Transition();
        }

        public void ChangeToSmallMario()
        {
            
        }

        public void ChangeToSuperMario()
        {
            
        }

        public void Damage()
        {
            
        }

        public void Flower()
        {
            
        }

        public void Mushroom()
        {
            
        }

        public void SmallMario()
        {
            
        }
        public void Star()
        {
            context.timer.Restart();
        }

        public void Transition()
        {
            
        }
    }
}

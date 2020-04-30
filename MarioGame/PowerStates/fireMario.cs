
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class FireMario : IPowerState
    {

        PlayerContext context;

        public FireMario (PlayerContext context)
        {
            this.context = context;
            
        }
        public void Damage()
        {
            context.PowerState = context.GetSuperMarioState();
            context.SetCurrentState(MarioState.Super);
            context.PowerState.Transition();
        }

        public void Flower()
        {
            
        }

        public void Mushroom()
        {
            
        }

        public void ChangeToSmallMario()
        {
            context.PowerState = context.GetSmallMarioState();
            context.SetCurrentState(MarioState.Small);
            context.WidthHeight = new Microsoft.Xna.Framework.Vector2(MarioSpriteFactory.SMALL_MARIO_WIDTH, MarioSpriteFactory.SMALL_MARIO_HEIGHT);
            context.GrowDown();
            context.PowerState.Transition();
        }

        public void Star()
        {
            context.PowerState = new StarMario(context, this);
            context.SetCurrentState(MarioState.BigStar);
        }

        public void ChangeToSuperMario()
        {
            context.PowerState = context.GetSuperMarioState();
            context.SetCurrentState(MarioState.Super);
            context.PowerState.Transition();
        }

        public void Transition()
        {
            //mess with sprites
        }

        public void ChangeToFireMario()
        {
            //do nothing
        }
    }
}

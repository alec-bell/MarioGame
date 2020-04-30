using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class SuperMario : IPowerState
    {
        PlayerContext context;
        public SuperMario(PlayerContext context)
        {
            this.context = context;
        }
        public void Damage()
        {
            context.PowerState = context.GetSmallMarioState();
            context.SetCurrentState(MarioState.Small);
            context.WidthHeight = new Microsoft.Xna.Framework.Vector2(MarioSpriteFactory.SMALL_MARIO_WIDTH, MarioSpriteFactory.SMALL_MARIO_HEIGHT);
            context.GrowDown();
            context.PowerState.Transition();
        }

        public void Flower()
        {
            context.PowerState = context.GetFireMarioState();
            context.SetCurrentState(MarioState.Fire);
            context.PowerState.Transition();
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

        public void Transition()
        {
            //context.setCurrentSprite(new Sprites.MarioSprite((int)context.location.X, (int)context.location.Y, context.getCurrentState(), Sprites.MarioColor.Red, Sprites.MarioFrame.Idle));
        }

        public void ChangeToSuperMario()
        {
            
        }

        public void ChangeToFireMario()
        {
            context.PowerState = context.GetFireMarioState();
            context.SetCurrentState(MarioState.Fire);
            context.WidthHeight = new Vector2(MarioSpriteFactory.BIG_MARIO_WIDTH, MarioSpriteFactory.BIG_MARIO_HEIGHT);
            context.PowerState.Transition();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    class SmallMario : IPowerState
    {

        private PlayerContext context;

        public SmallMario(PlayerContext context)
        {
            this.context = context;
        }
        public void Damage()
        {
            context.PowerState = context.GetDeadMarioState();
            context.SetCurrentState(MarioState.Dead);
            context.PowerState.Transition();
        }
        public void Flower()
        {
            context.PowerState = context.GetFireMarioState();
            context.SetCurrentState(MarioState.Fire);
            context.WidthHeight = new Microsoft.Xna.Framework.Vector2(MarioSpriteFactory.BIG_MARIO_WIDTH, MarioSpriteFactory.BIG_MARIO_HEIGHT);
            context.GrowUp();
            context.PowerState.Transition();
        }

        public void Mushroom()
        {
            context.PowerState = context.GetSuperMarioState();
            context.SetCurrentState(MarioState.Super);
            context.WidthHeight = new Microsoft.Xna.Framework.Vector2(MarioSpriteFactory.BIG_MARIO_WIDTH, MarioSpriteFactory.BIG_MARIO_HEIGHT);
            context.GrowUp();
            context.PowerState.Transition();
        }

        public void Star()
        {
            context.PowerState = new StarMario(context, this);
            context.SetCurrentState(MarioState.SmallStar);
        }

        public void ChangeToSuperMario()
        {
            context.PowerState = context.GetSuperMarioState();
            context.SetCurrentState(MarioState.Super);
            context.WidthHeight = new Microsoft.Xna.Framework.Vector2(MarioSpriteFactory.BIG_MARIO_WIDTH, MarioSpriteFactory.BIG_MARIO_HEIGHT);
            context.GrowUp();
            context.PowerState.Transition();
        }

        public void Transition()
        {
            //context.setCurrentSprite(new Sprites.MarioSprite((int)context.location.X, (int)context.location.Y, context.getCurrentState(), Sprites.MarioColor.Red, Sprites.MarioFrame.Idle));

        }

        public void ChangeToSmallMario()
        {
            
        }

        public void ChangeToFireMario()
        {
            context.PowerState = context.GetFireMarioState();
            context.SetCurrentState(MarioState.Fire);
            context.WidthHeight = new Vector2(MarioSpriteFactory.BIG_MARIO_WIDTH, MarioSpriteFactory.BIG_MARIO_HEIGHT);
            context.GrowUp();
            context.PowerState.Transition();
        }
    }
}

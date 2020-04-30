using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    
    
    class MarioSprite : ISprite, IEntity
    {
        public MarioColor Color { get; set; }
        public MarioState State { get; set; }
        public bool Direction { get; set; }
        float ElapsedFrames { get; set; }
        public bool IsBounded { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 WidthHeight { get; set; }
        public bool IsCollidable { get; set; }
        public Rectangle Boundary { get; set; }
        public Vector2 Velocity { get; set; }
        public bool WasHit { get; set; }
        public Color hitColor = Microsoft.Xna.Framework.Color.White;
        public int screenWidth;
        public int screenHeight;

        public MarioFrame _frame;
        MarioFrame Frame {
            get {
                return _frame;
            }
            set
            {
                if(_frame != value)
                {
                    _frame = value;
                    ElapsedFrames = 0;
                }
            }
        }

        public TileMapInterpreter.Entities EntityType { get; set; }

        public MarioSprite(Vector2 loc, int sWidth, int sHeight, MarioState state, MarioColor color, MarioFrame frame, bool direction, bool IsBounded)
        {
            hitColor = Microsoft.Xna.Framework.Color.White;
            Location = loc;
            if(state == MarioState.Small || state == MarioState.SmallStar || state == MarioState.Dead)
            {
                WidthHeight = new Vector2(MarioSpriteFactory.SMALL_MARIO_WIDTH, MarioSpriteFactory.SMALL_MARIO_HEIGHT);
            }
            else
            {
                WidthHeight = new Vector2(MarioSpriteFactory.BIG_MARIO_WIDTH, MarioSpriteFactory.BIG_MARIO_HEIGHT);
            }
            screenWidth = sWidth;
            screenHeight = sHeight;
            this.Color = color;
            this.State = state;
            this.Frame = frame;
            this.Direction = direction; //flips the sprite
            this.IsBounded = IsBounded;
            EntityType = TileMapInterpreter.Entities.PLAYER;
        }

        public void Draw(SpriteBatch sprite)
        {
            if (Direction)
            {
                if (State == MarioState.Small || State == MarioState.SmallStar || State == MarioState.Dead || Frame == MarioFrame.Dying)
                {
                    sprite.Draw(SpriteFactory.marioSpriteSheet, new Rectangle((int)Location.X, (int)Location.Y, MarioSpriteFactory.SMALL_MARIO_WIDTH, MarioSpriteFactory.SMALL_MARIO_HEIGHT), MarioSpriteFactory.Mario(Color, State, Frame), hitColor, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
                }
                else
                {
                    sprite.Draw(SpriteFactory.marioSpriteSheet, new Rectangle((int)Location.X, (int)Location.Y, MarioSpriteFactory.BIG_MARIO_WIDTH, MarioSpriteFactory.BIG_MARIO_HEIGHT), MarioSpriteFactory.Mario(Color, State, Frame), hitColor, 0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0f);
                }
            }
            else
            {
                if (State == MarioState.Small || State == MarioState.SmallStar || State == MarioState.Dead || Frame == MarioFrame.Dying)
                {
                    sprite.Draw(SpriteFactory.marioSpriteSheet, new Rectangle((int)Location.X, (int)Location.Y, MarioSpriteFactory.SMALL_MARIO_WIDTH, MarioSpriteFactory.SMALL_MARIO_HEIGHT), MarioSpriteFactory.Mario(Color, State, Frame), hitColor);
                }
                else
                {
                    sprite.Draw(SpriteFactory.marioSpriteSheet, new Rectangle((int)Location.X, (int)Location.Y, MarioSpriteFactory.BIG_MARIO_WIDTH, MarioSpriteFactory.BIG_MARIO_HEIGHT), MarioSpriteFactory.Mario(Color, State, Frame), hitColor);
                }
            }

           if (IsBounded)
            {
                if (State == MarioState.Small || State == MarioState.SmallStar || State == MarioState.Dead || Frame == MarioFrame.Dying)
                {
                    BoundingBox.DrawRectangle(new Rectangle((int)Location.X, (int)Location.Y, MarioSpriteFactory.SMALL_MARIO_WIDTH, MarioSpriteFactory.SMALL_MARIO_HEIGHT), Microsoft.Xna.Framework.Color.Yellow);

                }
                else
                {
                    BoundingBox.DrawRectangle(new Rectangle((int)Location.X, (int)Location.Y, MarioSpriteFactory.BIG_MARIO_WIDTH, MarioSpriteFactory.BIG_MARIO_HEIGHT), Microsoft.Xna.Framework.Color.Yellow);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            ElapsedFrames += (float)gameTime.ElapsedGameTime.TotalSeconds * 60;

            if (WasHit)
            {
                hitColor = Microsoft.Xna.Framework.Color.Black;
            }
            else
            {
                hitColor = Microsoft.Xna.Framework.Color.White;
            }
            if ((Frame == MarioFrame.Running1 && ElapsedFrames > 5) && !(State == MarioState.Small || State == MarioState.SmallStar || State == MarioState.BigStar))
            {
                Frame = MarioFrame.Running2;
                ElapsedFrames = 0;
            }
            else if ((Frame == MarioFrame.Running2 && ElapsedFrames > 5) && !(State == MarioState.Small || State == MarioState.SmallStar || State == MarioState.BigStar))
            {
                Frame = MarioFrame.Running3;
                ElapsedFrames = 0;
            }
            else if ((Frame == MarioFrame.Running3 && ElapsedFrames > 5) && !(State == MarioState.Small || State == MarioState.SmallStar || State == MarioState.BigStar))
            {
                Frame = MarioFrame.Running4;
                ElapsedFrames = 0;
            }
            else if ((Frame == MarioFrame.Running4 && ElapsedFrames > 5) && !(State == MarioState.Small || State == MarioState.SmallStar || State == MarioState.BigStar))
            {
                Frame = MarioFrame.Running5;
                ElapsedFrames = 0;
            }
            else if ((Frame == MarioFrame.Running5 && ElapsedFrames > 5) && !(State == MarioState.Small || State == MarioState.SmallStar || State == MarioState.BigStar))
            {
                Frame = MarioFrame.Running1;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Running1 && ElapsedFrames > 2 && State == MarioState.Small)
            {
                Frame = MarioFrame.Running2;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Running2 && ElapsedFrames > 2 && State == MarioState.Small)
            {
                Frame = MarioFrame.Running3;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Running3 && ElapsedFrames > 2 && State == MarioState.Small )
            {
                Frame = MarioFrame.Running1;
                ElapsedFrames = 0;
            }
            else if(Frame == MarioFrame.Walking1 && ElapsedFrames > 5 && !(State == MarioState.SmallStar || State == MarioState.BigStar)){
                Frame = MarioFrame.Walking2;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Walking2 && ElapsedFrames > 5 && !(State == MarioState.SmallStar || State == MarioState.BigStar))
            {
                Frame = MarioFrame.Walking3;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Walking3 && ElapsedFrames > 5 && !(State == MarioState.SmallStar || State == MarioState.BigStar))
            {
                Frame = MarioFrame.Walking1;
                ElapsedFrames = 0;
            }else if (Frame == MarioFrame.Falling && (MarioState.BigStar == State || MarioState.SmallStar == State) && ElapsedFrames > 5)
            {
                Frame = MarioFrame.FallingStar;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.FallingStar && (MarioState.BigStar == State || MarioState.SmallStar == State) && ElapsedFrames > 5)
            {
                Frame = MarioFrame.Falling;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Crouching && (MarioState.BigStar == State || MarioState.SmallStar == State) && ElapsedFrames > 5)
            {
                Frame = MarioFrame.CrouchingStar;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.CrouchingStar && (MarioState.BigStar == State || MarioState.SmallStar == State) && ElapsedFrames > 5)
            {
                Frame = MarioFrame.Crouching;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Idle && (MarioState.BigStar == State || MarioState.SmallStar == State) && ElapsedFrames > 5)
            {
                Frame = MarioFrame.IdleStar;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.IdleStar && (MarioState.BigStar == State || MarioState.SmallStar == State) && ElapsedFrames > 5)
            {
                Frame = MarioFrame.Idle;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Jumping && (MarioState.BigStar == State || MarioState.SmallStar == State) && ElapsedFrames > 5)
            {
                Frame = MarioFrame.JumpingStar;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Running1 && MarioState.BigStar == State && ElapsedFrames > 5)
            {
                ElapsedFrames = 0;
                Frame = MarioFrame.RunningStar2;
            }
            else if (Frame == MarioFrame.RunningStar2 && MarioState.BigStar == State && ElapsedFrames > 5)
            {
                Frame = MarioFrame.Running3;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Running3 && MarioState.BigStar == State && ElapsedFrames > 5)
            {
                Frame = MarioFrame.RunningStar4;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.RunningStar4 && MarioState.BigStar == State && ElapsedFrames > 5)
            {
                Frame = MarioFrame.Running5;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Running5 && MarioState.BigStar == State && ElapsedFrames > 5)
            {
                Frame = MarioFrame.RunningStar1;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.RunningStar1 && MarioState.BigStar == State && ElapsedFrames > 5)
            {
                Frame = MarioFrame.Running2;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Running2 && MarioState.BigStar == State && ElapsedFrames > 5)
            {
                Frame = MarioFrame.RunningStar3;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.RunningStar3 && MarioState.BigStar == State && ElapsedFrames > 5)
            {
                Frame = MarioFrame.Running4;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Running4 && MarioState.BigStar == State && ElapsedFrames > 5)
            {
                Frame = MarioFrame.RunningStar5;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.RunningStar5 && MarioState.BigStar == State && ElapsedFrames > 5)
            {
                Frame = MarioFrame.Running1;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Walking1 && (MarioState.BigStar == State || MarioState.SmallStar == State) && ElapsedFrames > 5)
            {
                Frame = MarioFrame.WalkingStar2;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.WalkingStar2 && (MarioState.BigStar == State || MarioState.SmallStar == State) && ElapsedFrames > 5)
            {
                Frame = MarioFrame.Walking3;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Walking3 && (MarioState.BigStar == State || MarioState.SmallStar == State) && ElapsedFrames > 5)
            {
                Frame = MarioFrame.WalkingStar1;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.WalkingStar1 && (MarioState.BigStar == State || MarioState.SmallStar == State) && ElapsedFrames > 5)
            {
                Frame = MarioFrame.Walking2;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Walking2 && (MarioState.BigStar == State || MarioState.SmallStar == State) && ElapsedFrames > 5)
            {
                Frame = MarioFrame.WalkingStar3;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.WalkingStar3 && (MarioState.BigStar == State || MarioState.SmallStar == State) && ElapsedFrames > 5)
            {
                Frame = MarioFrame.Walking1;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Running1 &&  MarioState.SmallStar == State && ElapsedFrames > 3)
            {
                Frame = MarioFrame.RunningStar2;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.RunningStar2 && MarioState.SmallStar == State && ElapsedFrames > 3)
            {
                Frame = MarioFrame.Running3;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Running3 && MarioState.SmallStar == State && ElapsedFrames > 3)
            {
                Frame = MarioFrame.RunningStar1;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.RunningStar1 && MarioState.SmallStar == State && ElapsedFrames > 3)
            {
                Frame = MarioFrame.Running2;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.Running2 && MarioState.SmallStar == State && ElapsedFrames > 3)
            {
                Frame = MarioFrame.RunningStar3;
                ElapsedFrames = 0;
            }
            else if (Frame == MarioFrame.RunningStar3 && MarioState.SmallStar == State && ElapsedFrames > 3)
            {
                Frame = MarioFrame.Running1;
                ElapsedFrames = 0;
            }
        }

        public void HitTop(IEntity entity, PlayerContext player, Rectangle overlap)
        {
            throw new NotImplementedException();
        }

        public void HitBottom(IEntity entity, PlayerContext player, Rectangle overlap)
        {
            throw new NotImplementedException();
        }

        public void HitLeft(IEntity entity, PlayerContext player, Rectangle overlap)
        {
            throw new NotImplementedException();
        }

        public void HitRight(IEntity entity, PlayerContext player, Rectangle overlap)
        {
            throw new NotImplementedException();
        }
    }
}

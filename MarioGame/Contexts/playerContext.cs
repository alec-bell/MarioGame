using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Sprites;
using MarioGame.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace MarioGame
{
    public class PlayerContext : IEntity
    {

        private const int STAR_TIME = 20;

        public int screenWidth;
        public int screenHeight;

        //Power states
        private IPowerState fireMario;
        private IPowerState smallMario;
        private IPowerState superMario;
        private IPowerState deadMario;

        //Action states
        private IActionState idleMario;
        private IActionState crouchingMario;
        private IActionState jumpingMario;
        private IActionState fallingMario;
        private IActionState runningMario;

        //Player sprite
        private ISprite Mario;

        //Flags to keep track of directional, state, and action changes
        private bool stateChanged = false;
        private bool frameChanged = false;
        private bool facingLeft = false;
        public bool IsBounded { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 WidthHeight { get; set; }
        public Vector2 Velocity { get; set; }

        //Store current state and frame
        public MarioState currentState;
        private MarioFrame currentFrame;

        //used for star state (future sprint)
        public IPowerState returnState;
        public Stopwatch timer = new Stopwatch();
        public TileMapInterpreter.Entities EntityType { get; set; }
        Rectangle playerRect;
        public int horizontalMovementFactor = 2;
        public int verticalMovementFactor = 3;
        public bool IsCollidable { get; set; }
        public Rectangle Boundary { get; set; }
        public bool WasHit { get; set; }
        float ElapsedFrames { get; set; }

        public PlayerContext(int sWidth, int sHeight, Vector2 loc)
        {
            //Instantiate power states
            loc.Y += MarioSpriteFactory.BIG_MARIO_HEIGHT - MarioSpriteFactory.SMALL_MARIO_HEIGHT;
            Location = loc;
            fireMario = new FireMario(this);
            smallMario = new SmallMario(this);
            superMario = new SuperMario(this);
            deadMario = new DeadMario(this);

            //Instantiate action states
            idleMario = new IdleMario(this);
            runningMario = new RunningMario(this);
            jumpingMario = new JumpingMario(this);
            fallingMario = new FallingMario(this);
            crouchingMario = new CrouchingMario(this);

            screenWidth = sWidth;
            screenHeight = sHeight;

            //Set initial states
            PowerState = smallMario;

            ActionState = idleMario;

            currentState = MarioState.Small;

            currentFrame = MarioFrame.Idle;

            WidthHeight = new Vector2(MarioSpriteFactory.SMALL_MARIO_WIDTH, MarioSpriteFactory.SMALL_MARIO_HEIGHT);

            Mario = new MarioSprite(Location, sWidth, sHeight, MarioState.Small, MarioColor.Red, MarioFrame.Idle, facingLeft, IsBounded);
            playerRect = new Rectangle((int)Location.X, (int)Location.Y, MarioSpriteFactory.SMALL_MARIO_WIDTH, MarioSpriteFactory.SMALL_MARIO_HEIGHT);
            EntityType = TileMapInterpreter.Entities.PLAYER;
            Velocity = new Vector2(horizontalMovementFactor,verticalMovementFactor);
        }

        //update star timer/sprite
        public void Update(GameTime gameTime)
        {
            Mario.IsBounded = IsBounded;
            Mario.Location = Location;
            Mario.WasHit = WasHit;

            ElapsedFrames += (float)gameTime.ElapsedGameTime.TotalSeconds * 60;

            if (WasHit)
            {
                if (ElapsedFrames > 5)
                {
                    WasHit = false;
                    ElapsedFrames = 0;
                }
            }
            Boundary = new Rectangle((int)Location.X, (int)Location.Y, (int)WidthHeight.X, (int)WidthHeight.Y);
            KeyboardState currentKeyboardState = Keyboard.GetState();
            GamePadState currentGamePadState = GamePad.GetState(0);
            if (stateChanged || frameChanged)
            {
                ElapsedFrames = 0;
                stateChanged = false;
                frameChanged = false;
                SetCurrentSprite(new MarioSprite(Location, screenWidth, screenHeight, GetCurrentState(), MarioColor.Red, GetCurrentFrame(), facingLeft, IsBounded));
            }
            if(currentState != MarioState.Dead)
            {
                if (ActionState == runningMario)
                {
                    if (facingLeft && (currentGamePadState.IsButtonDown(Buttons.DPadLeft) || currentKeyboardState.IsKeyDown(Keys.Left) || currentKeyboardState.IsKeyDown(Keys.A))) //Add A key
                    {
                        if ((int)Location.X - horizontalMovementFactor > 0)
                        {
                            Location -= new Vector2(Velocity.X, 0);
                        }
                        else
                        {
                            ChangeToIdle();
                        }
                    }
                    else if (!facingLeft && (currentGamePadState.IsButtonDown(Buttons.DPadRight) || currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.D)))
                    {
                        if ((int)Location.X + horizontalMovementFactor < screenWidth - Mario.WidthHeight.X)
                        {
                            Location += new Vector2(Velocity.X, 0);

                        }
                        else
                        {
                            ChangeToIdle();

                        }
                    }
                    else
                    {
                        ChangeToIdle();
                    }
                }
                else if (ActionState == jumpingMario)
                {
                    if (currentGamePadState.IsButtonDown(Buttons.DPadUp) || currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.W)) //Add W
                    {
                        if ((int)Location.Y - verticalMovementFactor > 0)
                        {
                            Location -= new Vector2(0, Velocity.Y);
                        }

                    }
                    else
                    {
                        ChangeToIdle();
                    }
                }
                else if (ActionState == crouchingMario)
                {
                    if (currentGamePadState.IsButtonDown(Buttons.DPadDown) || currentKeyboardState.IsKeyDown(Keys.Down) || currentKeyboardState.IsKeyDown(Keys.S))
                    {
                        if ((int)Location.Y + verticalMovementFactor < screenHeight - Mario.WidthHeight.Y)
                        {
                            Location += new Vector2(0, Velocity.Y);
                        }

                    }
                    else
                    {
                        ChangeToIdle();
                    }
                }
            }
            

            Mario.Update(gameTime); 
        }
    

        public void Draw(SpriteBatch spriteBatch)
        {
            Mario.Draw(spriteBatch);
        }

        //current power state
        public IPowerState PowerState { get; set; }

        //current action state
        public IActionState ActionState { get; set; }


        //setter
        public void SetCurrentState(MarioState state)
        {
            currentState = state;
            stateChanged = true;
        }

        public void SetCurrentFrame(MarioFrame frame)
        {
            currentFrame = frame;
            frameChanged = true;
        }

        public void SetCurrentSprite(ISprite sprite)
        {
            Mario = sprite;
        }

        //actions that can be taken
        public void Damage()
        {
            PowerState.Damage();
        }
        public void Flower()
        {
            PowerState.Flower();
        }
        public void Mushroom()
        {
            PowerState.Mushroom();
        }
        //NOT CORRECTLY IMPLEMENTED YET
        public void Star()
        {
            PowerState.Star();
        }
        public void ChangeToSmallMario()
        {
            PowerState.ChangeToSmallMario();
        }
        public void ChangeToSuperMario()
        {
            PowerState.ChangeToSuperMario();
        }

        public void ChangeToFireMario()
        {
            PowerState.ChangeToFireMario();
        }

        //Action state changes
        public void ChangeToIdle()
        {
            ActionState.Idle();
        }

        public void ChangeToRunning()
        {
            ActionState.Running();
        }

        public void ChangeToJumping()
        {
            ActionState.Jumping();
        }

        public void ChangeToCrouching()
        {
            ActionState.Crouching();
        }

        public void ChangeToFalling()
        {
            ActionState.Falling();
        }

        public void ChangeDirection()
        {
            frameChanged = true;
            facingLeft = !facingLeft;
        }


        //getter functions
        public IPowerState GetFireMarioState()
        {
            return fireMario;
        }
        public IPowerState GetSmallMarioState()
        {
            return smallMario;
        }
        public IPowerState GetSuperMarioState()
        {
            return superMario;
        }
        public IPowerState GetDeadMarioState()
        {
            return deadMario;
        }

        //Get action states
        public IActionState GetIdleMarioState()
        {
            return idleMario;
        }

        public IActionState GetRunningMarioState()
        {
            return runningMario;
        }

        public IActionState GetFallingMarioState()
        {
            return fallingMario;
        }

        public IActionState GetCrouchingMarioState()
        {
            return crouchingMario;
        }

        public IActionState GetJumpingMarioState()
        {
            return jumpingMario;
        }

        public MarioState GetCurrentState()
        {
            return currentState;
        }

        public MarioFrame GetCurrentFrame()
        {
            return currentFrame;
        }

        public bool IsFacingLeft()
        {
            return facingLeft;
        }

        public void MoveLeft()
        {
            if (facingLeft)
            {
                if (ActionState != runningMario && ActionState != crouchingMario)
                {
                    Velocity = new Vector2(horizontalMovementFactor, verticalMovementFactor);
                    ChangeToRunning();
                }
                
                
            }
            else if (!facingLeft)
            {
                if (ActionState == runningMario)
                {
                    ChangeToIdle();
                }
                else
                {
                    ChangeDirection();
                }

            }
        
        }

        public void MoveRight()
        {
            if (!facingLeft)
            {
                if (ActionState != runningMario && ActionState != crouchingMario)
                {
                    Velocity = new Vector2(horizontalMovementFactor, verticalMovementFactor);
                    ChangeToRunning();
                }
                   

            }
            else if (facingLeft)
            {
                if (ActionState == runningMario)
                {
                    ChangeToIdle();
                }
                else
                {
                    ChangeDirection();
                }
            }
        }

        // for making mario grow upwards
        public void GrowUp()
        {
            float x = Location.X;
            float y = Location.Y;
            Location = new Vector2(x, y - MarioSpriteFactory.SMALL_MARIO_HEIGHT);
        }

        public void GrowDown()
        {
            float x = Location.X;
            float y = Location.Y;
            Location = new Vector2(x, y + MarioSpriteFactory.SMALL_MARIO_HEIGHT);
        }

        private void ReactToEntity(IEntity entity, Rectangle overlap)
        {
            
        }

        public void HitTop(IEntity entity, PlayerContext player, Rectangle overlap)
        {
            switch (entity.EntityType)
            {
                case TileMapInterpreter.Entities.FLOOR:
                case TileMapInterpreter.Entities.BRICK_NOITEM:
                case TileMapInterpreter.Entities.BRICK_STAR:
                case TileMapInterpreter.Entities.BRICK_COIN:
                case TileMapInterpreter.Entities.BRICK_COINS:
                case TileMapInterpreter.Entities.HIDDEN_HIDDEN:
                case TileMapInterpreter.Entities.HIDDEN_NONHIDDEN:
                case TileMapInterpreter.Entities.QUESTION_COIN:
                case TileMapInterpreter.Entities.QUESTION_ITEM:
                case TileMapInterpreter.Entities.QUESTION_STAR:
                    Velocity = new Vector2(0, 0);
                    Location = new Vector2(Location.X, Location.Y + overlap.Height);
                    ChangeToIdle();
                    break;

                case TileMapInterpreter.Entities.SUPER_MUSHROOM:
                    ChangeToSuperMario();
                    break;
                case TileMapInterpreter.Entities.UP_MUSHROOM:
                    // add life
                    break;
                case TileMapInterpreter.Entities.STAR:
                    Star();
                    break;
                case TileMapInterpreter.Entities.COIN:
                    // add 1 coin
                    break;
                case TileMapInterpreter.Entities.FLOWER:
                    if (currentState == MarioState.Small)
                    {
                        ChangeToSuperMario();
                    }
                    else
                    {
                        Flower();
                    }
                    break;

                case TileMapInterpreter.Entities.GOOMBA:
                case TileMapInterpreter.Entities.GREEN_KOOPA:
                case TileMapInterpreter.Entities.RED_KOOPA:
                    Location = new Vector2(Location.X, Location.Y + overlap.Height);
                    Damage();
                    break;
            }
        }

        public void HitBottom(IEntity entity, PlayerContext player, Rectangle overlap)
        {
            switch (entity.EntityType)
            {
                case TileMapInterpreter.Entities.FLOOR:
                case TileMapInterpreter.Entities.BRICK_NOITEM:
                case TileMapInterpreter.Entities.BRICK_STAR:
                case TileMapInterpreter.Entities.BRICK_COIN:
                case TileMapInterpreter.Entities.BRICK_COINS:
                case TileMapInterpreter.Entities.HIDDEN_HIDDEN:
                case TileMapInterpreter.Entities.HIDDEN_NONHIDDEN:
                case TileMapInterpreter.Entities.QUESTION_COIN:
                case TileMapInterpreter.Entities.QUESTION_ITEM:
                case TileMapInterpreter.Entities.QUESTION_STAR:
                    Velocity = new Vector2(0, 0);
                    Location = new Vector2(Location.X, Location.Y + overlap.Height);
                    ChangeToIdle();
                    break;
                case TileMapInterpreter.Entities.SUPER_MUSHROOM:
                    ChangeToSuperMario();
                    break;
                case TileMapInterpreter.Entities.UP_MUSHROOM:
                    // add life
                    break;
                case TileMapInterpreter.Entities.STAR:
                    Star();
                    break;
                case TileMapInterpreter.Entities.COIN:
                    // add 1 coin
                    break;
                case TileMapInterpreter.Entities.FLOWER:
                    if (currentState == MarioState.Small)
                    {
                        ChangeToSuperMario();
                    }
                    else
                    {
                        Flower();
                    }
                    break;
                case TileMapInterpreter.Entities.GOOMBA:
                case TileMapInterpreter.Entities.GREEN_KOOPA:
                case TileMapInterpreter.Entities.RED_KOOPA:
                    Location = new Vector2(Location.X, Location.Y - overlap.Height);
                    break;
            }
        }

        public void HitLeft(IEntity entity, PlayerContext player, Rectangle overlap)
        {
            switch (entity.EntityType)
            {
                case TileMapInterpreter.Entities.FLOOR:
                case TileMapInterpreter.Entities.BRICK_NOITEM:
                case TileMapInterpreter.Entities.BRICK_STAR:
                case TileMapInterpreter.Entities.BRICK_COIN:
                case TileMapInterpreter.Entities.BRICK_COINS:
                case TileMapInterpreter.Entities.HIDDEN_HIDDEN:
                case TileMapInterpreter.Entities.HIDDEN_NONHIDDEN:
                case TileMapInterpreter.Entities.QUESTION_COIN:
                case TileMapInterpreter.Entities.QUESTION_ITEM:
                case TileMapInterpreter.Entities.QUESTION_STAR:
                    Velocity = new Vector2(0, 0);
                    Location = new Vector2(Location.X - overlap.Width, Location.Y);
                    ChangeToIdle();
                    break;
                case TileMapInterpreter.Entities.SUPER_MUSHROOM:
                    ChangeToSuperMario();
                    break;
                case TileMapInterpreter.Entities.UP_MUSHROOM:
                    // add life
                    break;
                case TileMapInterpreter.Entities.STAR:
                    Star();
                    break;
                case TileMapInterpreter.Entities.COIN:
                    // add 1 coin
                    break;
                case TileMapInterpreter.Entities.FLOWER:
                    if (currentState == MarioState.Small)
                    {
                        ChangeToSuperMario();
                    }
                    else
                    {
                        Flower();
                    }
                    break;
                case TileMapInterpreter.Entities.GOOMBA:
                case TileMapInterpreter.Entities.GREEN_KOOPA:
                case TileMapInterpreter.Entities.RED_KOOPA:
                    Location = new Vector2(Location.X - overlap.Width, Location.Y);
                    Damage();
                    break;
            }
        }

        public void HitRight(IEntity entity, PlayerContext player, Rectangle overlap)
        {
            switch (entity.EntityType)
            {
                case TileMapInterpreter.Entities.FLOOR:
                case TileMapInterpreter.Entities.BRICK_NOITEM:
                case TileMapInterpreter.Entities.BRICK_STAR:
                case TileMapInterpreter.Entities.BRICK_COIN:
                case TileMapInterpreter.Entities.BRICK_COINS:
                case TileMapInterpreter.Entities.HIDDEN_HIDDEN:
                case TileMapInterpreter.Entities.HIDDEN_NONHIDDEN:
                case TileMapInterpreter.Entities.QUESTION_COIN:
                case TileMapInterpreter.Entities.QUESTION_ITEM:
                case TileMapInterpreter.Entities.QUESTION_STAR:
                    Velocity = new Vector2(0, 0);
                    Location = new Vector2(Location.X + overlap.Width, Location.Y);
                    ChangeToIdle();
                    break;
                case TileMapInterpreter.Entities.SUPER_MUSHROOM:
                    ChangeToSuperMario();
                    break;
                case TileMapInterpreter.Entities.UP_MUSHROOM:
                    // add life
                    break;
                case TileMapInterpreter.Entities.STAR:
                    Star();
                    break;
                case TileMapInterpreter.Entities.COIN:
                    // add 1 coin
                    break;
                case TileMapInterpreter.Entities.FLOWER:
                    if (currentState == MarioState.Small)
                    {
                        ChangeToSuperMario();
                    }
                    else
                    {
                        Flower();
                    }
                    break;
                case TileMapInterpreter.Entities.GOOMBA:
                case TileMapInterpreter.Entities.GREEN_KOOPA:
                case TileMapInterpreter.Entities.RED_KOOPA:
                    Location = new Vector2(Location.X + overlap.Width, Location.Y);
                    Damage();
                    break;
            }
        }
    }
}

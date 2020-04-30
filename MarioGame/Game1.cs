using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using MarioGame.Sprites;
using System;
using MarioGame.Commands;
using System.Linq;
using static MarioGame.Grid;
using MarioGame.Levels;

namespace MarioGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        //keyboard and gamepad controllers
        KeyboardController keyboardController;
        GamepadController[] controllerArray = new GamepadController[4];
        List<IEntity> entities = new List<IEntity>();

        //Dictionaries of recognized key/button presses
        Dictionary<Buttons, ICommand> buttonsMap;
        Dictionary<Keys, ICommand> keysMap;

        //Enemy sprites
        RedGoombaSprite redGoombaSprite = new RedGoombaSprite(250, 100, false);
        RedKoopaSprite redKoopaSprite = new RedKoopaSprite(150, 100);
        GreenKoopaSprite greenKoopaSprite = new GreenKoopaSprite(200, 100);

        //Item sprites
        CoinSprite blockCoinSprite = new CoinSprite(100, 150, CoinType.Block, CoinFrame.FirstFrame);
        CoinSprite staticCoinSprite = new CoinSprite(150, 150, CoinType.Static, CoinFrame.FirstFrame);
        FireFlowerSprite fireFlowerSprite = new FireFlowerSprite(200, 150, FireFlowerFrame.FirstFrame);
        MushroomSprite _1UpMushroomSprite = new MushroomSprite(250, 150, MushroomType._1Up);
        MushroomSprite superMushroomSprite = new MushroomSprite(300, 150, MushroomType.Super);
        StarmanSprite starmanSprite = new StarmanSprite(350, 150, StarmanFrame.FirstFrame);

        //TEMPORARY
        BlockContext[] bunchOBlocks = new BlockContext[6];

        //Temporary background texture
        Texture2D background;

        //Mario sprite being controlled
        PlayerContext playerController;

        ILevel level;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 400;
            //graphics.IsFullScreen = true;
        }


        protected override void Initialize()
        {
            //Here we map the buttons and keys to our Action enum
            buttonsMap = new Dictionary<Buttons, ICommand>();
            keysMap = new Dictionary<Keys, ICommand>();

            level = new Levels.Level1(graphics);

            level.Initialize();

            playerController = level.getPlayerController();

            //BUNCH O BLOCKS TEMPORARY!!!!!!
            //bunchOBlocks[0] = new BlockContext(BlockContext.Blocks.BRICK, new Vector2(100, 250));
            //bunchOBlocks[1] = new BlockContext(BlockContext.Blocks.USED, new Vector2(150, 250));
            //bunchOBlocks[2] = new BlockContext(BlockContext.Blocks.QUESTION, new Vector2(200, 250));
            //bunchOBlocks[3] = new BlockContext(BlockContext.Blocks.STAIR, new Vector2(250, 250));
            //bunchOBlocks[4] = new BlockContext(BlockContext.Blocks.FLOOR, new Vector2(300, 250));
            //bunchOBlocks[5] = new BlockContext(BlockContext.Blocks.HIDDEN, new Vector2(350, 250));

            //add entities
            //entities.Add(bunchOBlocks[0]);

            //entities.Add(bunchOBlocks[1]);
            //entities.Add(bunchOBlocks[2]);
            //entities.Add(bunchOBlocks[3]);
            //entities.Add(bunchOBlocks[4]);
            //entities.Add(bunchOBlocks[5]);

            //entities.Add(player);
            //entities.Add(redGoombaSprite);
            //entities.Add(redKoopaSprite);
            //entities.Add(greenKoopaSprite);

            //entities.Add(_1UpMushroomSprite);
            //entities.Add(staticCoinSprite);
            //entities.Add(blockCoinSprite);
            //entities.Add(fireFlowerSprite);
            //entities.Add(starmanSprite);
            //entities.Add(superMushroomSprite);

            // Instances of commands
            ICommand quitCommand = new QuitCommand(this);

            ICommand moveLeftCommand = new MoveLeftCommand(playerController);
            ICommand moveRightCommand = new MoveRightCommand(playerController);
            ICommand jumpCommand = new JumpCommand(playerController);
            ICommand crouchCommand = new CrouchCommand(playerController);
            ICommand fireballCommand = new FireballCommand(playerController);
            ICommand pauseCommand = new PauseCommand(playerController);

            ICommand fireCommand = new FireCommand(playerController);
            ICommand bigCommand = new BigCommand(playerController);
            ICommand smallCommand = new SmallCommand(playerController);
            ICommand takeDamageCommand = new TakeDamageCommand(playerController);
            ICommand boundingCommand = new BoundingCommand(playerController, ((Level1)level).entities);
            
            // Assign commands to buttons
            buttonsMap.Add(Buttons.Start, quitCommand);
            buttonsMap.Add(Buttons.Back, null);
            buttonsMap.Add(Buttons.DPadLeft, moveLeftCommand);
            buttonsMap.Add(Buttons.DPadRight, moveRightCommand);
            buttonsMap.Add(Buttons.DPadUp, jumpCommand);
            buttonsMap.Add(Buttons.A, jumpCommand);
            buttonsMap.Add(Buttons.DPadDown, crouchCommand);
            buttonsMap.Add(Buttons.B, fireballCommand);
            buttonsMap.Add(Buttons.X, null);
            buttonsMap.Add(Buttons.Y, null);
            //buttonsMap.Add(Buttons.Start, pauseCommand);

            // Assign commands to keys
            keysMap.Add(Keys.Q, quitCommand);
            keysMap.Add(Keys.Left, moveLeftCommand);
            keysMap.Add(Keys.A, moveLeftCommand);
            keysMap.Add(Keys.Right, moveRightCommand);
            keysMap.Add(Keys.D, moveRightCommand);
            keysMap.Add(Keys.Up, jumpCommand);
            keysMap.Add(Keys.W, jumpCommand);
            keysMap.Add(Keys.Down, crouchCommand);
            keysMap.Add(Keys.S, crouchCommand);
            keysMap.Add(Keys.Space, fireballCommand);
            keysMap.Add(Keys.Escape, pauseCommand);
            keysMap.Add(Keys.Y, smallCommand);
            keysMap.Add(Keys.U, bigCommand);
            keysMap.Add(Keys.I, fireCommand);
            keysMap.Add(Keys.O, takeDamageCommand);
            keysMap.Add(Keys.C, boundingCommand);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            BoundingBox.Init(spriteBatch, this.GraphicsDevice);
            
            //instantiate our keyboard and gamepad classes
            keyboardController = new KeyboardController(keysMap);
            for (int i = 0; i < 4; i++)
            {
                controllerArray[i] = new GamepadController(buttonsMap, i);
            }

            background = Content.Load<Texture2D>("MarioBackground");

            SpriteFactory.Init(Content);
        }

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            
            level.Update(gameTime);
            CollisionDetector c = new CollisionDetector(((Level1)level).entities, (Level1)level);
            c.Update();

            




            ////Update enemy sprites
            //redGoombaSprite.Update(gameTime);
            //redKoopaSprite.Update(gameTime);
            //greenKoopaSprite.Update(gameTime);

            ////Update item sprites
            //blockCoinSprite.Update(gameTime);
            //staticCoinSprite.Update(gameTime);
            //fireFlowerSprite.Update(gameTime);
            //_1UpMushroomSprite.Update(gameTime);
            //superMushroomSprite.Update(gameTime);
            //starmanSprite.Update(gameTime);

            //Update states of controllers
            keyboardController.Update();
            foreach (GamepadController controller in controllerArray)
            {
                controller.Update();
            }

            //Temporary block command keys

            if (keyboardController.previousKeyboardState.IsKeyDown(Keys.X))
            {

                Levels.Level1 levelController = (Levels.Level1)level;

                levelController.TestMarioLocation();
            }

            //if (keyboardController.CurrentKeys.Contains(Keys.B))
            //{

            //    grid.Remove(player);
            //    grid.Add(player);
            //    for (int i = 0; i < bunchOBlocks.Length; i++)
            //    {
            //        if (bunchOBlocks[i].GetBlockType().Equals(BlockContext.Blocks.BRICK))
            //        {
            //            bunchOBlocks[i].HitFromBottom(playerController);
            //        }
            //    }
            //}

            //if (keyboardController.CurrentKeys.Contains(Keys.H))
            //{
            //    for (int i = 0; i < bunchOBlocks.Length; i++)
            //    {
            //        if (bunchOBlocks[i].GetBlockType().Equals(BlockContext.Blocks.HIDDEN))
            //        {
            //            bunchOBlocks[i].HitFromBottom(playerController);
            //        }
            //    }
            //}

            ////Update block states
            //for(int i = 0; i<bunchOBlocks.Length; i++)
            //{
            //    bunchOBlocks[i].Update(gameTime);
            //}

            ////Update player state
            //playerController.Update(gameTime);



            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //spriteBatch.Begin();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);

            //Draw the background
            spriteBatch.Draw(background, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

            level.Draw(spriteBatch);
            
            ////Draw the enemies
            //redGoombaSprite.Draw(spriteBatch);
            //redKoopaSprite.Draw(spriteBatch);
            //greenKoopaSprite.Draw(spriteBatch);

            ////Draw the items
            //blockCoinSprite.Draw(spriteBatch);
            //staticCoinSprite.Draw(spriteBatch);
            //fireFlowerSprite.Draw(spriteBatch);
            //_1UpMushroomSprite.Draw(spriteBatch);
            //superMushroomSprite.Draw(spriteBatch);
            //starmanSprite.Draw(spriteBatch);


            ////Temporary drawing of blocks
            //for(int i = 0; i<bunchOBlocks.Length; i++)
            //{
            //    bunchOBlocks[i].Draw(spriteBatch);
            //}

            ////Draw the current player state
            //playerController.Draw(spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
            
        }
    }
}

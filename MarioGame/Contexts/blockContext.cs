using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Sprites;

namespace MarioGame
{
    class BlockContext : IContext
    {
        public IBlockState CurrentBlock { get; set; }
        public bool IsBounded { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 WidthHeight { get; set; }
        public TileMapInterpreter.Entities EntityType { get; set; }
        public bool IsCollidable { get; set; }
        public Rectangle Boundary { get; set; }
        public bool WasHit { get; set; }
        public Vector2 Velocity { get; set; }

        private IBlockState questionBlock;
        private IBlockState hiddenBlock;
        private IBlockState brickBlock;
        private IBlockState usedBlock;
        private IBlockState destroyedBlock;
        private float ElapsedFrames;

        //sprite
        private ISprite sprite;

        //bump?
        public bool bump = false;
        

        public enum Blocks {  QUESTION, HIDDEN, USED, FLOOR, STAIR, BRICK, DESTROYED };
        public Blocks blockType;

        //used for question, hidden, brick
        public BlockContext(Blocks choiceBlock, Vector2 loc)
        {
            Location = loc;
            WidthHeight = new Vector2(BlockSpriteFactory.BLOCK_WIDTH, BlockSpriteFactory.BLOCK_HEIGHT);
            Boundary = new Rectangle((int)Location.X, (int)Location.Y, (int)WidthHeight.X, (int)WidthHeight.Y);
            switch (choiceBlock)
            {
                case Blocks.BRICK:
                    {
                        brickBlock = new BrickBlock(this);
                        destroyedBlock = new DestroyedBlock();
                        usedBlock = new UsedBlock();
                        EntityType = TileMapInterpreter.Entities.BRICK_NOITEM;
                        CurrentBlock = brickBlock;
                        blockType = choiceBlock;
                        sprite = new BrickBlockSprite((int)Location.X, (int)Location.Y, false, false);
                        IsBounded = false;
                        break;
                    }
                case Blocks.HIDDEN:
                    {

                        hiddenBlock = new HiddenBlock(this);
                        brickBlock = new BrickBlock(this);
                        usedBlock = new UsedBlock();
                        destroyedBlock = new DestroyedBlock();
                        EntityType = TileMapInterpreter.Entities.HIDDEN_HIDDEN;
                        CurrentBlock = hiddenBlock;
                        blockType = choiceBlock;
                        sprite = new HiddenBlockSprite((int)Location.X, (int)Location.Y, HiddenBlockType.Hidden);
                        IsBounded = false;
                        break;
                    }
                case Blocks.QUESTION:
                    {
                        questionBlock = new QuestionBlock(this);
                        usedBlock = new UsedBlock();
                        EntityType = TileMapInterpreter.Entities.QUESTION_COIN;
                        CurrentBlock = questionBlock;
                        blockType = choiceBlock;
                        sprite = new MysteryBlockSprite((int)Location.X, (int)Location.Y, MysteryBlockFrame.FirstFrame);
                        IsBounded = false;
                        break;
                    }
                case Blocks.USED:
                    {
                        usedBlock = new UsedBlock();
                        EntityType = TileMapInterpreter.Entities.USED;
                        CurrentBlock = usedBlock;
                        blockType = choiceBlock;
                        sprite = new UsedBlockSprite((int)Location.X, (int)Location.Y);
                        IsBounded = false;
                        break;
                    }
                case Blocks.FLOOR:
                    {
                        usedBlock = new UsedBlock();
                        EntityType = TileMapInterpreter.Entities.FLOOR;
                        CurrentBlock = usedBlock;
                        blockType = choiceBlock;
                        sprite = new FloorBlockSprite((int)Location.X, (int)Location.Y);
                        IsBounded = false;
                        break;
                    }
                case Blocks.STAIR:
                    {
                        usedBlock = new UsedBlock();
                        EntityType = TileMapInterpreter.Entities.STAIR;
                        CurrentBlock = usedBlock;
                        blockType = choiceBlock;
                        sprite = new StairBlockSprite((int)Location.X, (int)Location.Y);
                        IsBounded = false;
                        break;
                    }
                default:
                    break;
            }
        }

        //update
        public void Update(GameTime gameTime)
        {
            ElapsedFrames += (float)gameTime.ElapsedGameTime.TotalSeconds * 60;
            sprite.WasHit = WasHit;
            if (WasHit)
            {
                if (ElapsedFrames > 5)
                {
                    WasHit = false;
                    ElapsedFrames = 0;
                }
            }

            Boundary = new Rectangle((int)Location.X, (int)Location.Y, (int)WidthHeight.X, (int)WidthHeight.Y);
            if (bump)
            {
                bump = false;
                if (GetBlockType().Equals(Blocks.BRICK))
                {
                    sprite = new BrickBlockSprite((int)Location.X, (int)Location.Y, false, true);
                }else if (GetBlockType().Equals(Blocks.USED))
                {
                    sprite = new UsedBlockSprite((int)Location.X, (int)Location.Y);
                }
            }
            sprite.Update(gameTime);

        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
            if (IsBounded)
            {
                BoundingBox.DrawRectangle(Boundary, Color.Blue);
            }
        }

        //possible actions
        public void HitFromBottom(PlayerContext player)
        {
            CurrentBlock.HitBottom(player);
        }

        public void HitFromTopSide(PlayerContext player)
        {
            CurrentBlock.HitSideTop(player);
        }

        //getter functions
        public IBlockState GetUsedBlockState()
        {
            return usedBlock;
        }

        public IBlockState GetDestoryedBlockState()
        {
            return destroyedBlock;
        }

        public IBlockState GetBrickBlockState()
        {
            return brickBlock;
        }

        public Blocks GetBlockType()
        {
            return blockType;
        }

        //setter functions
        public void SetBlockType(Blocks type)
        {
            blockType = type;

            switch (type)
            {
                case Blocks.QUESTION:
                    {
                        sprite = new MysteryBlockSprite((int)Location.X, (int)Location.Y, MysteryBlockFrame.FirstFrame);
                        break;
                    }
                case Blocks.USED:
                    {
                        sprite = new UsedBlockSprite((int)Location.X, (int)Location.Y);
                        break;
                    }
                case Blocks.DESTROYED:
                    {
                        sprite = new BrickBlockSprite((int)Location.X, (int)Location.Y, true, false);
                        break;
                    }
                case Blocks.BRICK:
                    {
                        sprite = new BrickBlockSprite((int)Location.X, (int)Location.Y, false, false);
                        break;
                    }
                default:
                    break;
            }
        }

        public void HitTop(IContext entity, PlayerContext player, Rectangle overlap)
        {
            HitFromTopSide(player);
        }

        public void HitBottom(IContext entity, PlayerContext player, Rectangle overlap)
        {
            HitFromBottom(player);
        }

        public void HitLeft(IContext entity, PlayerContext player, Rectangle overlap)
        {
            
        }

        public void HitRight(IContext entity, PlayerContext player, Rectangle overlap)
        {
            
        }

    }
}

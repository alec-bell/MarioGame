using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    class BrickBlockSprite : ISprite
    { 
        private bool isHit;
        private bool isExplode;
        private int iterations;
        private Rectangle currentFrame;
        private Rectangle[] explodedFrames;
        private int[] explodedPosX;
        private int[] explodedPosY;
        private int[] originalExploX;
        private int[] originalExploY;
        public bool IsBounded  { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 WidthHeight { get; set; }

        public TileMapInterpreter.Entities EntityType { get; set; }

        public bool IsCollidable { get ; set ; }
        public Rectangle Boundary { get; set; }
        public bool WasHit { get; set; }
        public Vector2 Velocity { get; set; }

        public BrickBlockSprite(int posX, int posY, bool explode, bool hit)
        {
            Location = new Vector2(posX, posY);
            WidthHeight = new Vector2(BlockSpriteFactory.BLOCK_WIDTH, BlockSpriteFactory.BLOCK_HEIGHT);
            Boundary = new Rectangle((int)Location.X, (int)Location.Y, (int)WidthHeight.X, (int)WidthHeight.Y);
            isHit = hit;
            isExplode = explode;
            iterations = 0;
            currentFrame = BlockSpriteFactory.BrickBlock();
            EntityType = TileMapInterpreter.Entities.BRICK_NOITEM;

            if (explode)
            {
                EntityType = TileMapInterpreter.Entities.DESTROYED;
                // Remove existing brick
                currentFrame = BlockSpriteFactory.EmptyBlock();

                // Create exploded pieces
                explodedFrames = new Rectangle[4];
                for (int i = 0; i < 4; i++)
                {
                    explodedFrames[i] = BlockSpriteFactory.ExplodedBrickBlock();
                }

                explodedPosX = new int[4];
                explodedPosY = new int[4];
                explodedPosX[0] = posX;
                explodedPosY[0] = posY;
                explodedPosX[1] = posX + 8;
                explodedPosY[1] = posY;
                explodedPosX[2] = posX;
                explodedPosY[2] = posY + 8;
                explodedPosX[3] = posX + 8;
                explodedPosY[3] = posY + 8;

                originalExploY = new int[4];
                originalExploX = new int[4];
                explodedPosX.CopyTo(originalExploX, 0);
                explodedPosY.CopyTo(originalExploY, 0);
            }
        }

        public void Draw(SpriteBatch sprite)
        {
            if (!isExplode)
            {
                if (WasHit)
                {
                    sprite.Draw(SpriteFactory.blockSpriteSheet, Boundary, currentFrame, Color.Black);

                }
                else
                {
                    sprite.Draw(SpriteFactory.blockSpriteSheet, Boundary, currentFrame, Color.White);
                }
            }
            else
            {
                for(int i = 0; i < explodedFrames.Length; i++)
                {
                    sprite.Draw(SpriteFactory.blockSpriteSheet, new Rectangle(explodedPosX[i], explodedPosY[i], BlockSpriteFactory.EXPLODED_BLOCK_WIDTH, BlockSpriteFactory.EXPLODED_BLOCK_HEIGHT), explodedFrames[i], Color.White);
                }
            }
            
        }
        public void Update(GameTime gameTime)
        {
            if (isHit)
            {
                if (iterations < 5)
                {
                    Location -= new Vector2(1, 0);
                }
                else if (iterations < 10)
                {
                    Location += new Vector2(0, 1);
                }
                else
                {
                    isHit = false;
                }

                iterations++;
            }

            if (isExplode)
            {
                explodedPosX[0]--;
                explodedPosX[1]++;
                explodedPosX[2]--;
                explodedPosX[3]++;

                explodedPosY[0] = originalExploY[0] + (int)Math.Pow(iterations - 6, 2) - 36;
                explodedPosY[1] = originalExploY[1] + (int)Math.Pow(iterations - 6, 2) - 36;
                explodedPosY[2] = originalExploY[2] + (int)Math.Pow(iterations - 8, 2) - 64;
                explodedPosY[3] = originalExploY[3] + (int)Math.Pow(iterations - 8, 2) - 64;

                iterations++;
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

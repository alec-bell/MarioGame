
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    class MysteryBlockSprite : ISprite 
    {
        private Rectangle currentFrame;
        private MysteryBlockFrame frame;
        private float elapsedFrames;
        public bool IsBounded { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 WidthHeight { get; set; }
        public TileMapInterpreter.Entities EntityType { get; set; }
        public bool IsCollidable { get; set; }
        public Rectangle Boundary { get; set; }
        public bool WasHit { get; set; }
        public Vector2 Velocity { get; set; }


        public MysteryBlockSprite(int posX, int posY, MysteryBlockFrame frame)
        {
            Location = new Vector2(posX, posY);
            WidthHeight = new Vector2(BlockSpriteFactory.BLOCK_WIDTH, BlockSpriteFactory.BLOCK_HEIGHT);
            Boundary = new Rectangle((int)Location.X, (int)Location.Y, (int)WidthHeight.X, (int)WidthHeight.Y);
            this.frame = frame;
            currentFrame = BlockSpriteFactory.MysteryBlock(frame);
            EntityType = TileMapInterpreter.Entities.QUESTION_COIN;
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(SpriteFactory.blockSpriteSheet,Boundary, currentFrame, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            elapsedFrames += (float)gameTime.ElapsedGameTime.TotalSeconds * 60;

            if (elapsedFrames > 10)
            {
                switch (frame)
                {
                    case MysteryBlockFrame.FirstFrame:
                        frame = MysteryBlockFrame.Flash1;
                        currentFrame = BlockSpriteFactory.MysteryBlock(frame);
                        break;
                    case MysteryBlockFrame.Flash1:
                        frame = MysteryBlockFrame.Flash2;
                        currentFrame = BlockSpriteFactory.MysteryBlock(frame);
                        break;
                    case MysteryBlockFrame.Flash2:
                        frame = MysteryBlockFrame.FirstFrame;
                        currentFrame = BlockSpriteFactory.MysteryBlock(frame);
                        break;
                }

                elapsedFrames = 0;
            }
        }

        public void HitTop(IEntity entity, PlayerContext player, Rectangle overlap)
        {
             
        }

        public void HitBottom(IEntity entity, PlayerContext player, Rectangle overlap)
        {
             
        }

        public void HitLeft(IEntity entity, PlayerContext player, Rectangle overlap)
        {
             
        }

        public void HitRight(IEntity entity, PlayerContext player, Rectangle overlap)
        {
             
        }
    }
}

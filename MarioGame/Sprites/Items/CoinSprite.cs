using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    class CoinSprite : ISprite, IEntity
    {
        private CoinType type;
        private CoinFrame frame;
        private Rectangle currentFrame;
        private float elapsedFrames;
        public bool IsBounded { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 WidthHeight { get; set; }
        public TileMapInterpreter.Entities EntityType { get; set; }
        private Color hitColor = Color.White;
        public bool IsCollidable { get; set; }
        public Rectangle Boundary { get; set; }
        public bool WasHit { get; set; }
        public Vector2 Velocity { get; set; }


        public CoinSprite(int positionX, int positionY, CoinType coinType, CoinFrame coinFrame)
        {
            Location = new Vector2(positionX, positionY);
            WidthHeight = new Vector2(ItemSpriteFactory.ITEM_WIDTH, ItemSpriteFactory.ITEM_HEIGHT);
            Boundary = new Rectangle((int)Location.X, (int)Location.Y, (int)WidthHeight.X, (int)WidthHeight.Y);
            type = coinType;
            frame = coinFrame;
            currentFrame = ItemSpriteFactory.Coin(type, frame);
            EntityType = TileMapInterpreter.Entities.COIN;
        }

        
        public void Draw(SpriteBatch sprite)
        {
            
            if (WasHit)
            {
                sprite.Draw(SpriteFactory.itemSpriteSheet, Boundary, currentFrame, Color.Black);

            }
            else
            {
                sprite.Draw(SpriteFactory.itemSpriteSheet, Boundary, currentFrame, Color.White);
            }
            if (IsBounded)
            {
                BoundingBox.DrawRectangle(Boundary, Color.Green);
            }
        }

        public void Update(GameTime gameTime)
        {

            elapsedFrames += (float)gameTime.ElapsedGameTime.TotalSeconds * 60;

            if (WasHit)
            {
                if (elapsedFrames > 5)
                {
                    WasHit = false;
                    elapsedFrames = 0;
                }
            }
            

            if (elapsedFrames > 5 && frame == CoinFrame.FirstFrame)
            {
                frame = CoinFrame.Rotate1;
                currentFrame = ItemSpriteFactory.Coin(type, frame);
                elapsedFrames = 0;
            }
            else if(elapsedFrames > 5 && frame == CoinFrame.Rotate1)
            {
                frame = CoinFrame.Rotate2;
                currentFrame = ItemSpriteFactory.Coin(type, frame);
                elapsedFrames = 0;
            }
            else if(elapsedFrames > 5 && frame == CoinFrame.Rotate2)
            {
                frame = CoinFrame.Rotate3;
                currentFrame = ItemSpriteFactory.Coin(type, frame);
                elapsedFrames = 0;
            }
            else if(elapsedFrames > 5 && frame == CoinFrame.Rotate3)
            {
                frame = CoinFrame.FirstFrame;
                currentFrame = ItemSpriteFactory.Coin(type, frame);
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

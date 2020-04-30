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
    class FireFlowerSprite : ISprite, IEntity
    { 
        private float elapsedFrames;
        private Rectangle currentFrame;
        private FireFlowerFrame frame;
        public bool IsBounded { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 WidthHeight { get; set; }
        public TileMapInterpreter.Entities EntityType { get; set; }
        public bool IsCollidable { get; set; }
        public Rectangle Boundary { get; set; }
        public bool WasHit { get; set; }
        public Vector2 Velocity { get; set; }
        public FireFlowerSprite(int positionX, int positionY, FireFlowerFrame fireFlowerFrame)
        {
            Location = new Vector2(positionX, positionY);
            WidthHeight = new Vector2(ItemSpriteFactory.ITEM_WIDTH, ItemSpriteFactory.ITEM_HEIGHT);
            Boundary = new Rectangle((int)Location.X, (int)Location.Y, (int)WidthHeight.X, (int)WidthHeight.Y);
            frame = fireFlowerFrame;
            currentFrame = ItemSpriteFactory.FireFlower(frame);
            EntityType = TileMapInterpreter.Entities.FLOWER;
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
            if (elapsedFrames > 5 && frame == FireFlowerFrame.FirstFrame)
            {
                frame = FireFlowerFrame.Flash1;
                currentFrame = ItemSpriteFactory.FireFlower(frame);
                elapsedFrames = 0;
            }
            else if (elapsedFrames > 5 && frame == FireFlowerFrame.Flash1)
            {
                frame = FireFlowerFrame.Flash2;
                currentFrame = ItemSpriteFactory.FireFlower(frame);
                elapsedFrames = 0;
            }
            else if (elapsedFrames > 5 && frame == FireFlowerFrame.Flash2)
            {
                frame = FireFlowerFrame.Flash3;
                currentFrame = ItemSpriteFactory.FireFlower(frame);
                elapsedFrames = 0;
            }
            else if (elapsedFrames > 5 && frame == FireFlowerFrame.Flash3)
            {
                frame = FireFlowerFrame.FirstFrame;
                currentFrame = ItemSpriteFactory.FireFlower(frame);
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

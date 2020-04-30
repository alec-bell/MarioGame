using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using MarioGame.Interfaces;

namespace MarioGame.Sprites
{
    class MushroomSprite : ISprite, IEntity
    {
        public MushroomType type;
        public Rectangle currentFrame;
        private float elapsedFrames;
        public bool IsBounded { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 WidthHeight { get; set; }
        public TileMapInterpreter.Entities EntityType { get; set; }
        public bool IsCollidable { get; set; }
        public Rectangle Boundary { get; set; }
        public bool WasHit { get; set; }
        public Vector2 Velocity { get; set; }

        public MushroomSprite(int positionX, int positionY, MushroomType mushroomType)
        {
            Location = new Vector2(positionX, positionY);
            WidthHeight = new Vector2(ItemSpriteFactory.ITEM_WIDTH, ItemSpriteFactory.ITEM_HEIGHT);
            Boundary = new Rectangle((int)Location.X, (int)Location.Y, (int)WidthHeight.X, (int)WidthHeight.Y);

            type = mushroomType;
            currentFrame = ItemSpriteFactory.Mushroom(type);
            if (mushroomType.Equals(MushroomType.Super))
            {
                EntityType = TileMapInterpreter.Entities.SUPER_MUSHROOM;
            }
            else
            {
                EntityType = TileMapInterpreter.Entities.UP_MUSHROOM;
            }

            IsBounded = false;
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

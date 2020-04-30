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
    class FloorBlockSprite : ISprite
    {
        private Rectangle currentFrame;
        public bool IsBounded { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 WidthHeight { get; set; }
        public TileMapInterpreter.Entities EntityType { get; set; }
        public bool IsCollidable { get; set; }
        public Rectangle Boundary { get; set; }
        public bool WasHit { get; set; }
        public Vector2 Velocity { get; set; }


        public FloorBlockSprite(int posX, int posY)
        {
            Location = new Vector2(posX, posY);
            WidthHeight = new Vector2(BlockSpriteFactory.BLOCK_WIDTH, BlockSpriteFactory.BLOCK_HEIGHT);
            Boundary = new Rectangle((int)Location.X, (int)Location.Y, (int)WidthHeight.X, (int)WidthHeight.Y);
            currentFrame = BlockSpriteFactory.FloorBlock();
            EntityType = TileMapInterpreter.Entities.FLOOR;
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(SpriteFactory.blockSpriteSheet, Boundary, currentFrame, Color.White);
            
        }

        public void Update(GameTime gameTime)
        {

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

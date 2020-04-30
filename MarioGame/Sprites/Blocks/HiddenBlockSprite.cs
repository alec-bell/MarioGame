using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    class HiddenBlockSprite : ISprite
    {
        
        private Rectangle currentFrame;
        // private HiddenBlockType type;
        public bool IsBounded { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 WidthHeight { get; set; }
        public TileMapInterpreter.Entities EntityType { get; set; }
        public bool IsCollidable { get; set; }
        public Rectangle Boundary { get; set; }
        public bool WasHit { get; set; }
        public Vector2 Velocity { get; set; }


        public HiddenBlockSprite(int posX, int posY, HiddenBlockType type)
        {
            Location = new Vector2(posX, posY);
            WidthHeight = new Vector2(BlockSpriteFactory.BLOCK_WIDTH, BlockSpriteFactory.BLOCK_HEIGHT);
            Boundary = new Rectangle((int)Location.X, (int)Location.Y, (int)WidthHeight.X, (int)WidthHeight.Y);
            //this.type = type;
            currentFrame = BlockSpriteFactory.HiddenBlock(type);
            EntityType = TileMapInterpreter.Entities.HIDDEN_HIDDEN;
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

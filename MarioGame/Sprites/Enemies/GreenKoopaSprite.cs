using MarioGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace MarioGame.Sprites
{
    class GreenKoopaSprite : ISprite, IEntity
    {
        private float elapsedFrames;
        private Rectangle koopaFrame;
        public bool IsBounded { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 WidthHeight { get; set; }
        public TileMapInterpreter.Entities EntityType { get; set; }
        public bool IsCollidable { get; set; }
        public Rectangle Boundary { get; set; }
        public bool WasHit { get; set; }
        public Vector2 Velocity { get; set; }


        public GreenKoopaSprite(int posX, int posY)
        {
            //this.isInShell = isInShell;
            Location = new Vector2(posX, posY);
            WidthHeight = new Vector2(KoopaSpriteFactory.KOOPA_WIDTH, KoopaSpriteFactory.KOOPA_HEIGHT);
            Boundary = new Rectangle((int)Location.X , (int)Location.Y, (int)WidthHeight.X, (int)WidthHeight.Y);
            koopaFrame = KoopaSpriteFactory.Koopa(KoopaColor.Green, KoopaFrame.StartWalkLeft);
            EntityType = TileMapInterpreter.Entities.GREEN_KOOPA;
        }

        //make sure to call sprite.Begin() and Sprite.End() around this
        public void Draw(SpriteBatch sprite)
        {
            if (WasHit)
            {
                sprite.Draw(SpriteFactory.enemySpriteSheet, Boundary, koopaFrame, Color.Black);
            }
            else
            {
                sprite.Draw(SpriteFactory.enemySpriteSheet, Boundary, koopaFrame, Color.White);
            }
            
            if (IsBounded)
            {
                BoundingBox.DrawRectangle(Boundary, Color.Red);
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
            if (elapsedFrames > 5 && elapsedFrames < 10)
                {
                    koopaFrame = KoopaSpriteFactory.Koopa(KoopaColor.Green, KoopaFrame.ContinueWalkLeft);
                }
                else if (elapsedFrames > 10)
                {
                    koopaFrame = KoopaSpriteFactory.Koopa(KoopaColor.Green, KoopaFrame.StartWalkLeft);
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


using System;
using MarioGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    class RedGoombaSprite: ISprite, IEntity
    {

        private float elapsedFrames;
        private Rectangle goombaFrame;
        private bool isDead;
        public bool IsBounded { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 WidthHeight { get; set; }
        public TileMapInterpreter.Entities EntityType { get; set ; }

        public bool IsCollidable { get; set; }
        public Rectangle Boundary { get; set; }
        public bool WasHit { get; set; }
        public Vector2 Velocity { get; set; }


        
        public RedGoombaSprite(int posX, int posY, bool isDead)
        {
            this.isDead = isDead;
            Location = new Vector2(posX, posY);
            WidthHeight = new Vector2(GoombaSpriteFactory.GOOMBA_WIDTH, GoombaSpriteFactory.GOOMBA_HEIGHT);
            Boundary = new Rectangle((int)Location.X, (int)Location.Y, (int)WidthHeight.X, (int)WidthHeight.Y);
            goombaFrame = GoombaSpriteFactory.Goomba(GoombaColor.Red, GoombaFrame.StartWalk);
            EntityType = TileMapInterpreter.Entities.GOOMBA;
        }
        public void Draw(SpriteBatch sprite)
        {
            if (WasHit)
            {
                sprite.Draw(SpriteFactory.enemySpriteSheet, Boundary, goombaFrame, Color.Black);
            }
            else
            {
                sprite.Draw(SpriteFactory.enemySpriteSheet, Boundary, goombaFrame, Color.White);
            }
            if (IsBounded)
            {
                BoundingBox.DrawRectangle(Boundary, Color.Red);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (WasHit)
            {
                if (elapsedFrames > 5)
                {
                    WasHit = false;
                    elapsedFrames = 0;
                }
            }
            if (!isDead)
            {
                elapsedFrames += (float)gameTime.ElapsedGameTime.TotalSeconds * 60;
                if (elapsedFrames > 5 && elapsedFrames < 10)
                {
                    goombaFrame = GoombaSpriteFactory.Goomba(GoombaColor.Red, GoombaFrame.ContinueWalk);
                }
                else if (elapsedFrames > 10)
                {
                    goombaFrame = GoombaSpriteFactory.Goomba(GoombaColor.Red, GoombaFrame.StartWalk);
                    elapsedFrames = 0;
                }
            }
            else
            {
                goombaFrame = GoombaSpriteFactory.Goomba(GoombaColor.Red, GoombaFrame.Dead);
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


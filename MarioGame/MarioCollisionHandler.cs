using MarioGame.Levels;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarioGame.EntityCollisionHandler;

namespace MarioGame
{
    public class MarioCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(CollisionDetector.Collision collision, Level1 level)
        {
            if (collision.entity1 is PlayerContext || collision.entity2 is PlayerContext)
            {
                PlayerContext player = null;

                CollisionDetector.CollisionSide side = collision.GetSide();

                if (collision.entity1 is PlayerContext)
                {
                    player = (PlayerContext)collision.entity1;
                }
                else
                {
                    player = (PlayerContext)collision.entity2;

                    if (side == CollisionDetector.CollisionSide.Left)
                    {
                        side = CollisionDetector.CollisionSide.Right;
                    }
                    else if (side == CollisionDetector.CollisionSide.Right)
                    {
                        side = CollisionDetector.CollisionSide.Left;
                    }
                    else if (side == CollisionDetector.CollisionSide.Top)
                    {
                        side = CollisionDetector.CollisionSide.Bottom;
                    }
                    else if (side == CollisionDetector.CollisionSide.Bottom)
                    {
                        side = CollisionDetector.CollisionSide.Top;
                    }

                    Console.WriteLine("E2");
                }
                if(collision.entity1 is BlockContext || collision.entity2 is BlockContext)
                {
                    if (side == CollisionDetector.CollisionSide.Left)
                    {
                        player.Location += new Vector2((float)Math.Ceiling(collision.intersection.width), 0);
                    }
                    else if (side == CollisionDetector.CollisionSide.Right)
                    {
                        player.Location -= new Vector2((float)Math.Ceiling(collision.intersection.width), 0);
                    }
                    else if (side == CollisionDetector.CollisionSide.Top)
                    {
                        player.Location += new Vector2(0, (float)Math.Ceiling(collision.intersection.height));
                    }
                    else if (side == CollisionDetector.CollisionSide.Bottom)
                    {
                        player.Location -= new Vector2(0, (float)Math.Ceiling(collision.intersection.height));
                    }
                }
                else if (collision.entity1 is MushroomSprite || collision.entity2 is MushroomSprite)
                {
                    if (player.currentState == MarioState.Small)
                    {
                        player.ChangeToSuperMario();
                    }
                }
                else if (collision.entity1 is FireFlowerSprite || collision.entity2 is FireFlowerSprite)
                {
                    player.ChangeToFireMario();
                }
                else if(collision.entity1 is GreenKoopaSprite || collision.entity1 is RedKoopaSprite || collision.entity1 is RedGoombaSprite || collision.entity2 is GreenKoopaSprite || collision.entity2 is RedKoopaSprite || collision.entity2 is RedGoombaSprite)
                {
                    if (side == CollisionDetector.CollisionSide.Left)
                    {
                        player.Location += new Vector2((float)Math.Ceiling(collision.intersection.width), 0);
                        player.Damage();
                    }
                    else if (side == CollisionDetector.CollisionSide.Right)
                    {
                        player.Location -= new Vector2((float)Math.Ceiling(collision.intersection.width), 0);
                        player.Damage();
                    }
                    else if (side == CollisionDetector.CollisionSide.Top)
                    {
                        player.Location += new Vector2(0, (float)Math.Ceiling(collision.intersection.height));
                        player.Damage();
                    }
                    else if (side == CollisionDetector.CollisionSide.Bottom)
                    {
                        player.Location -= new Vector2(0, (float)Math.Ceiling(collision.intersection.height));
                    }
                }
            }
        }
    }
}

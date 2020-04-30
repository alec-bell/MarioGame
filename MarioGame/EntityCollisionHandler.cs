using MarioGame.Levels;
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarioGame.CollisionDetector;

namespace MarioGame
{
    public class EntityCollisionHandler : ICollisionHandler
    {
        private Levels.Level1 level;
        private Dictionary<Type, ICollisionHandler> handlers;
        

        public EntityCollisionHandler(Level1 level)
        {
            handlers = new Dictionary<Type, ICollisionHandler>();
            handlers[typeof(PlayerContext)] = new MarioCollisionHandler();
            handlers[typeof(BlockContext)] = new BlockCollisionHandler();
            handlers[typeof(CoinSprite)] = new ItemCollisionHandler();
            handlers[typeof(FireFlowerSprite)] = new ItemCollisionHandler();
            handlers[typeof(MushroomSprite)] = new ItemCollisionHandler();
            handlers[typeof(StarmanSprite)] = new ItemCollisionHandler();
            handlers[typeof(GreenKoopaSprite)] = new EnemyCollisionHandler();
            handlers[typeof(RedKoopaSprite)] = new EnemyCollisionHandler();
            handlers[typeof(RedGoombaSprite)] = new EnemyCollisionHandler();
            this.level = level;

        }
        
        public void HandleCollision(Collision collision, Level1 level)
        {
            ICollisionHandler handler = handlers[collision.entity1.GetType()];

            if (handler != null)
            {
                handler.HandleCollision(collision, level);
            }

            ICollisionHandler secondHandler = handlers[collision.entity2.GetType()];

            if (secondHandler != null)
            {
                secondHandler.HandleCollision(collision, level);
            }
        }
        
    }
}

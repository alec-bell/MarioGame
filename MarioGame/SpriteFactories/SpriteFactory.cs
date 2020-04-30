using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//these sprite sheets suck ass right now so this code is gonna be a little sloppy for a bit
namespace MarioGame
{


    


    public static class SpriteFactory
    {
        private static ContentManager content;
        public static Texture2D enemySpriteSheet { get; private set; }
        public static Texture2D marioSpriteSheet { get; private set; }
        public static Texture2D itemSpriteSheet { get; private set; }
        public static Texture2D blockSpriteSheet { get; private set; }


        

        public static void Init(ContentManager contentManager)
        {
            content = contentManager;
            enemySpriteSheet = content.Load<Texture2D>("EnemySpriteSheet");
            marioSpriteSheet = content.Load<Texture2D>("MarioSpriteSheet");
            itemSpriteSheet = content.Load<Texture2D>("ItemSpriteSheet");
            blockSpriteSheet = content.Load<Texture2D>("BlockSpriteSheet");

        }
    }
}
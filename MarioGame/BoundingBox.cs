using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame 
{
    public static class BoundingBox
    {
        // This method stretches a single pixel into lines, those lines then are drawn to make a rectangle
        private static Texture2D line;
        private static int thickness = 1;
        private static SpriteBatch sprite;

        public static void Init(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            sprite = spriteBatch;
            line = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            line.SetData(new[] { Color.White });
        }
        //Given a rectangle and color this will draw a hollow rectangle in that color
        public static void DrawRectangle(Rectangle rect, Color color)
        {
            // Top
            sprite.Draw(line, new Rectangle(rect.X, rect.Y, rect.Width, thickness), color);
            // Right
            sprite.Draw(line, new Rectangle((rect.X + rect.Width - thickness),rect.Y,thickness,rect.Height), color);
            // Bottom
            sprite.Draw(line, new Rectangle(rect.X, rect.Y + rect.Height - thickness, rect.Width, thickness), color);
            // Left 
            sprite.Draw(line, new Rectangle(rect.X, rect.Y, thickness, rect.Height), color);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Interfaces
{
    public interface IBoundable
    {
        bool IsBounded { get; set; }
        Rectangle Boundary { get; set; }

        Vector2 Location { get; set; }
        Vector2 WidthHeight { get; set; }

        void Draw(SpriteBatch sprite);
        void Update(GameTime gameTime);
    }
}

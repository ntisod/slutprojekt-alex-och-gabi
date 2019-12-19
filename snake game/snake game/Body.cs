using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game
{
    class Body : GameObject
    {
        //position och textur
        public Body(Texture2D texture, float X, float Y) : base(texture, X, Y)
        {

        }

    }
}

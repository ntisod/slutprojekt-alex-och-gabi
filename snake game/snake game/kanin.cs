using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game
{
    class Kanin : GameObject
    {

        //kanin texture och placering axel X och Y
        public Kanin(Texture2D texture, float X, float Y) : base(texture, X, Y)
        {

        }

        public void Update(GameTime GameTime)
        {

        }

        public void Reposition(float x, float y)
        {
            vectore.X = x;
            vectore.Y = y;
        }
    }
}

    


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game
{
    class GameObject
    {
        protected Texture2D texture;
        protected Vector2 vectore;
        protected bool isalive = true;
        // struktur till att skapa objekt

        public GameObject(Texture2D image, float x, float y)
        {
            this.texture = image;
            this.vectore.X = x;
            this.vectore.Y = y;
        }

        //draw bilder på skärmen

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, vectore, Color.White);
        }

        public void MoveTo(Vector2 newPosition)
        {
            // Fylltar object till en ny position.
            this.vectore = newPosition;
        }

        public float X { get { return vectore.X; } }
        public float Y { get { return vectore.Y; } }
        public float Width { get { return texture.Width; } }
        public float Height { get { return texture.Height; } }

        public bool IsAlive
        {
            get { return IsAlive; }
            set { IsAlive = value; }
        }

        public Vector2 Position
        {
            get { return vectore; }
            set { vectore = value; }

        }

        //Koliderar med kaninen
        public bool CheckCollision(GameObject other)
        {
            Rectangle myrect = new Rectangle(Convert.ToInt32(X), Convert.ToInt32(Y), Convert.ToInt32(Width), Convert.ToInt32(other.Height));

            Rectangle otherRect = new Rectangle(Convert.ToInt32(other.X), Convert.ToInt32(other.Y), Convert.ToInt32(other.Width), Convert.ToInt32(other.Height));
            return myrect.Intersects(otherRect);
        }
    }

}
       
           


      
        
          

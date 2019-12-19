using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_game
{
    class Player : GameObject
    {

        KeyboardState oldKs;

        float angel = 0;
        public int Points;

        //lista på ormens delar
        public List<Body> bodyParts;

        Vector2 speed = new Vector2(32, 0);
        //Används för sinka ned hastigheten till någt lämpligt
        int game_speed = 250;  //ändras när man äter en kanin för att spelet ska gå snabbare
        int move_time;
       
        private Vector2 vector;


        //konstruktur för att skapa objektet
        public Player(Texture2D imige, float x, float y, int length) : base(imige, x, y)
        {
            bodyParts = new List<Body>();

            int antBodyParts = 5;

            for (int i = 1; i <= length; i++)
            {
                Body temp = new Body(imige, X - i * 32, y);
                bodyParts.Add(temp);
            }
        }





        //Styrningen, hastighet och riktning.
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();


            if (keyboardState.IsKeyDown(Keys.Right))
            {
                speed.X = 32;
                speed.Y = 0;
                angel = (float)Math.PI;

            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                speed.X = -32;
                speed.Y = 0;
                angel = 0;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                speed.X = 0;
                speed.Y = -32;
                angel = (float)Math.PI / 2;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                speed.X = 0;
                speed.Y = 32;
                angel = (float)Math.PI * 3 / 2f;

            }
            //Räknar ned tid tills den ska flyta plats
            move_time -= gameTime.ElapsedGameTime.Milliseconds;
            if (move_time <= 0)
            {
                //Gör en imagi när den flyttas
                Vector2 newpos = vectore + speed;
                //Sparar den gammla positionen
                Vector2 oldpos = vectore;
                //Flyttar fram huvudet
                vectore = newpos;
                //Använd den gamla positionen som en ny position för nästa kropsdel.
                newpos = oldpos;

                //Flytarr alla kropsdelar
                foreach (Body p in bodyParts)
                {
                    oldpos = new Vector2(p.X, p.Y);
                    p.MoveTo(newpos);
                    newpos = oldpos;
                }
                move_time = game_speed;

                oldKs = keyboardState;


            }
        }

        //Ritar ut en 90 grader rotation och hastighet
        public override void Draw(SpriteBatch spriteBatch)
        {
            // huvudedts rotation
            spriteBatch.Draw(texture, vector + new Vector2(16, 16), null, Color.White, angel + (float)Math.PI / 2,
                new Vector2(texture.Width / 2, texture.Height / 2), 1.0f, SpriteEffects.None, 0);

            foreach (Body p in bodyParts)
            {
                p.Draw(spriteBatch);
            }
        }

        public int points { get { return points; } set { points = value; } }

    }



}
            



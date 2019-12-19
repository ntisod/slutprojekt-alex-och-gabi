using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace snake_game
{
    /// <summary>
    /// Ett snake spel som är gjord och utvcklad av Alex och gabi
    /// branch Alex
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch SpriteBatch;


        Player player;


        //vår kanin
        Kanin kanin;
        Texture2D KaninSprite;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to preform any initialization it needs to before stating to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content. Calling bas.Initialize will enumreate through any components
        /// and initialize them as well
        /// </summary>
        protected override void Initialize()
        {
            //TO: Add your initiallzation logic here


            base.Initialize();
        }

        /// <summary>
        /// LoadeContent will be called once per game and it is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // TO: use this.content to load your game content here


            player = new Player(Content.Load<Texture2D>("snakepart"), 128, 128, 5);

            KaninSprite = Content.Load<Texture2D>("rabbit");
            kanin = new Kanin(KaninSprite, -100, -100);
            Addkanin();
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TO: Unload any non contentManager content here
        }

        // Plasering av kaninen
        protected void Addkanin()
        {
            Random random = new Random();

            int rndX = random.Next(0, Window.ClientBounds.Width - KaninSprite.Width);
            int rndY = random.Next(0, Window.ClientBounds.Height - KaninSprite.Height);

            kanin.Reposition(rndX, rndY);

        }

        /// <summary>
        /// Allows the game to run logic as updating the game world
        /// checking for collisions, gathering input,
        /// </summary>
        /// <pram name= "gameTime">provides a snapshot of timing values.</pram>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TO: Add your update logic here
            player.Update(gameTime);

            base.Update(gameTime);

            // TO. Add your update logic here

            //Kanin ska uppstå slumpmässigt



            //foreach (kanin kn in kaninKanin.Tolist())
            //{
            //    if (kn.Isalive)
            //    {
            //        //(kn.Update(kameTime);

            //        if (kn.CheckCollision(player))
            //        {
            //            kaninKanin.Remove(kn);
            //            player.Pointts++;
            //         }
            //      }
            //      els
            //          kaninKanin.Remove(kn);

            //}

            player.Update(gameTime);

            // poäng varje gång snaken kolidrerar med kaninen
            if (player.CheckCollision(kanin))
            {
                player.Points++; 
                Addkanin();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatch.Begin();
            //TO: Add your drawing code here
            //spriteBatch.Draw(gfx, position, Color.White);
            player.Draw(SpriteBatch);
            kanin.Draw(SpriteBatch);
            //foreach (Kanin kn in kaninKanin)
            //     kn.Draw(spriteBatch);


            SpriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
            
          








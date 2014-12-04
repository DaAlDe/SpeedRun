using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace testgame1
{
   
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;
        Texture2D spielfigur, schiff;
        Texture2D spielboden;

        Vector2 figurposi = new Vector2(100, 100);
        Vector2 raumschiffposi = new Vector2(300, 300);
        Vector2 spielbodenposi = new Vector2(0, 525);

        Rectangle alien;
        Rectangle ship;
        Rectangle sourceRect;
        Rectangle destinationRect;

        Texture2D spriteSheet;
        Texture2D spriteSheet2;
        Texture2D spriteSheet3;
        Texture2D spriteSheet4;
        Texture2D spriteSheet5;

        float timer = 0f;
        float interval = 3000f / 25f;
        int frameCount;
        int currentFrame;
        int spriteWidth = 64;
        int spriteHeight = 64;

        KeyboardState key;
           
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 880;
            graphics.PreferredBackBufferHeight = 600;

            // graphics.IsFullScreen = true;
        }

      
        protected override void Initialize()
        {

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("images/background/EustassKid");
            spielfigur = Content.Load<Texture2D>("images/objects/firsttry");
            schiff = Content.Load<Texture2D>("images/objects/raumschiff");
            spielboden = Content.Load<Texture2D>("images/objects/spielboden_1");

            alien = new Rectangle((int)(figurposi.X - spielfigur.Width / 2),
            (int)(figurposi.Y - spielfigur.Height / 2), spielfigur.Width, spielfigur.Height);
            ship = new Rectangle((int)(raumschiffposi.X - schiff.Width / 2),
            (int)(raumschiffposi.Y - schiff.Height / 2), schiff.Width, schiff.Height);

            
            spriteSheet = Content.Load<Texture2D>("images/objects/vampir_rechts");
            spriteSheet2 = Content.Load<Texture2D>("images/objects/vampir_links");
            spriteSheet3 = Content.Load<Texture2D>("images/objects/vampir_vorne");
            spriteSheet4 = Content.Load<Texture2D>("images/objects/vampir_hinten");
            spriteSheet5 = Content.Load<Texture2D>("images/objects/vampir_stand");
            destinationRect = new Rectangle(0, 0, spriteWidth, spriteHeight);
        }

   
        protected override void UnloadContent()
        {
        }

      
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            

            key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (key.IsKeyDown(Keys.Left))
            {
                frameCount = 4;
                currentFrame = 0;

                this.figurposi.X -= 1;

                this.destinationRect.X -= 2;

                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer > interval)
                {
                    currentFrame++;
                    if (currentFrame > frameCount - 1)
                    {
                        currentFrame = 0;
                    }
                    timer = 0f;
                }
                sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            }

            if (key.IsKeyDown(Keys.Right))
            {
                frameCount = 4;
                currentFrame = 0;

                this.figurposi.X += 1;

                this.destinationRect.X += 2;

                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer > interval)
                {
                    currentFrame++;
                    if (currentFrame > frameCount - 1)
                    {
                        currentFrame = 0;
                    }
                    timer = 0f;
                }
                sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            }
            if (key.IsKeyDown(Keys.Up))
            {
                frameCount = 4;
                currentFrame = 0;

                this.figurposi.Y -= 1;

                this.destinationRect.Y += 0;

                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer > interval)
                {
                    currentFrame++;
                    if (currentFrame > frameCount - 1)
                    {
                        currentFrame = 0;
                    }
                    timer = 0f;
                }
                sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            }
            if (key.IsKeyDown(Keys.Down))
            {
                frameCount = 4;
                currentFrame = 0;

                this.figurposi.Y += 1;

                this.destinationRect.Y += 0;

                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer > interval)
                {
                    currentFrame++;
                    if (currentFrame > frameCount - 1)
                    {
                        currentFrame = 0;
                    }
                    timer = 0f;
                }
                sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            }


            if (alien.Intersects(ship) || !GraphicsDevice.Viewport.Bounds.Contains(alien))
            {

                figurposi = new Vector2(100, 100);
            }

            alien.X = (int)figurposi.X;
            alien.Y = (int)figurposi.Y;

            ship.X = (int)raumschiffposi.X;
            ship.Y = (int)raumschiffposi.Y;

           


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0,
                    graphics.PreferredBackBufferWidth,
                    graphics.PreferredBackBufferHeight),
                    Color.White);

            spriteBatch.Draw(spielfigur, figurposi, Color.White);
            spriteBatch.Draw(schiff, raumschiffposi, Color.White);
            spriteBatch.Draw(spielboden, spielbodenposi, Color.White);

            if (key.IsKeyDown(Keys.Right))
            {
                spriteBatch.Draw(spriteSheet, destinationRect, sourceRect, Color.White);
            }
           
            else if (key.IsKeyDown(Keys.Left))
            {
                spriteBatch.Draw(spriteSheet2, destinationRect, sourceRect, Color.White);
            }
           
            else if (key.IsKeyDown(Keys.Down))
            {
                spriteBatch.Draw(spriteSheet3, destinationRect, sourceRect, Color.White);
            }
            
            else if (key.IsKeyDown(Keys.Up))
            {
                spriteBatch.Draw(spriteSheet4, destinationRect, sourceRect, Color.White);
            }
            else
            {
                spriteBatch.Draw(spriteSheet5, destinationRect, sourceRect, Color.White);
            }

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}

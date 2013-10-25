#region File Description
//-----------------------------------------------------------------------------
// PlatformerGame.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;


namespace XNAGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // Resources for drawing.
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }
		
	
		        // This is a texture we can render.
        Texture2D myTexture;

        // Set the coordinates to draw the sprite at.
        Vector2 spritePosition = Vector2.Zero;
		
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
			myTexture = Content.Load<Texture2D>("mytexture");

        }
		
		Vector2 spriteSpeed = new Vector2(50.0f, 50.0f);
		
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
			// Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == 
                ButtonState.Pressed)
                this.Exit();

            // Move the sprite around.
            UpdateSprite(gameTime);
			
            base.Update(gameTime);
        }
		
		void UpdateSprite(GameTime gameTime) 
        {
            // Move the sprite by speed, scaled by elapsed time.
            spritePosition += 
                spriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            int MaxX = 
                graphics.GraphicsDevice.Viewport.Width - myTexture.Width;
            int MinX = 0;
            int MaxY = 
                graphics.GraphicsDevice.Viewport.Height - myTexture.Height;
            int MinY = 0;

            // Check for bounce.
            if (spritePosition.X > MaxX)
            {
                spriteSpeed.X *= -1;
                spritePosition.X = MaxX;
            }

            else if (spritePosition.X < MinX)
            {
                spriteSpeed.X *= -1;
                spritePosition.X = MinX;
            }

            if (spritePosition.Y > MaxY)
            {
                spriteSpeed.Y *= -1;
                spritePosition.Y = MaxY;
            }

            else if (spritePosition.Y < MinY)
            {
                spriteSpeed.Y *= -1;
                spritePosition.Y = MinY;
            }
        }

        /// <summary>
        /// Draws the game from background to foreground.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
			
			// Draw the sprite.
			//SpriteBlendMode.AlphaBlend
            spriteBatch.Begin();
            spriteBatch.Draw(myTexture, spritePosition, Color.White);
            spriteBatch.End();
			
            base.Draw(gameTime);
        }

    }
}

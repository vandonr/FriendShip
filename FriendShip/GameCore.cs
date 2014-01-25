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

namespace FriendShip
{
	enum Rooms
	{
		LEFT = 0,
		RIGHT = 1,
	}

	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class GameCore : Game
	{
		public GraphicsDeviceManager graphics;
		public SpriteBatch spriteBatch;
		public Texture2D OneWhitePixel;

		private List<Room> _rooms = new List<Room>();

		public GameCore()
		{
			graphics = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferHeight = 1080,
				PreferredBackBufferWidth = 1920,
                IsFullScreen = true,
			};
			//IsMouseVisible = true;

			Content.RootDirectory = "Content";

            _rooms.Add(new Room (this, new Vector2 (253, 211), new Vector2()));//room 1
			//_rooms.Add(new Room (this, new Vector2 (601, 211)));//hall 1
            _rooms.Add(new Room(this, new Vector2(819, 211), new Vector2()));//room 2
           // _rooms.Add(new Room(this, new Vector2(1167, 211)));// hall 2
            _rooms.Add(new Room(this, new Vector2(1385, 211), new Vector2()));//room 3

            _rooms[(int)Rooms.LEFT].Exits.Add(new RoomLink(_rooms[(int)Rooms.RIGHT], new Rectangle(357, 10, 1, 200), new Vector2()));
            _rooms[(int)Rooms.RIGHT].Exits.Add(new RoomLink(_rooms[(int)Rooms.LEFT], new Rectangle(576, 10, 1, 200), new Vector2()));
            _rooms[(int)Rooms.LEFT].Exits.Add(new RoomLink(_rooms[(int)Rooms.RIGHT], new Rectangle(924, 10, 1, 200), new Vector2()));
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			OneWhitePixel = Content.Load<Texture2D>("onewhitepixel");

			foreach(var room in _rooms)
			{
				room.Texture = OneWhitePixel;
			}

			var cireman = Content.Load<Texture2D>("Players/cireman");
			var player = new Player (this, cireman, _rooms[(int)Rooms.LEFT]);
			player.Position = new Vector2 (10, 40);

		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape) || GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
			{
				this.Exit();
			}

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Gold);

			base.Draw(gameTime);

			if(spriteBatch != null)
			{
				spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
				//spriteBatch.Draw(levelMgr.SpecialDisplay, new Vector2(-(float)Math.Cos(-GameCore.Angle), -(float)Math.Sin(-GameCore.Angle)) * 18, Color.White);
				spriteBatch.End();
			}
		}

		/// <summary>
		/// Spritebatch must be initialized (begin) before
		/// </summary>
		public void DrawHitBox(Rectangle r)
		{
			spriteBatch.Draw(OneWhitePixel, r, new Color(255, 0, 0, 8));
		}
	}
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace FriendShip
{
	public class Room : DrawableGameComponent
	{
		public Vector2 Position { get; private set; }
		readonly GameCore _game;

		public Texture2D Texture;
		public List<RoomLink> Exits { get; private set;}

		public Room (GameCore game, Vector2 position)
			: base(game)
		{
			_game = game;
			Position = position;
			Exits = new List<RoomLink> ();

			_game.Components.Add (this);
			this.Enabled = true;
			this.Visible = true;
		}

		public override void Draw (GameTime gameTime)
		{
			if (Texture != null && _game.spriteBatch != null)
			{
				_game.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

				_game.spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, 60, 30), null, Color.White);

				foreach (var exit in Exits)
					exit.DrawHitBox (_game.spriteBatch, _game.OneWhitePixel);

				_game.spriteBatch.End();
			}
			base.Draw (gameTime);
		}
	}
}
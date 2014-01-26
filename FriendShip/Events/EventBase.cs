using System;
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
	public abstract class EventBase : DrawableGameComponent
	{
		public string _text;
		protected GameCore _game;

		public EventBase (GameCore game, string text)
			: base(game)
		{
			_game = game;
			_text = text;
			_game.Components.Add (this);
			Enabled = false;
			Visible = false;
			DrawOrder = 150;
		}

		public virtual void Enable()
		{
			Enabled = true;
			Visible = true;
		}
	}
}

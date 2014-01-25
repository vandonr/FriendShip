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
	public abstract class EventBase : GameComponent
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
		}
	}

	public class AllToMachineRoom : EventBase
	{
		private readonly Room _target;

		public AllToMachineRoom (GameCore game)
			:base(game, "Everyone in the engine room !")
		{
			_target = _game._rooms [RoomType.MACHINES];
		}

		public override void Update (GameTime gameTime)
		{
			bool missingPlayer = false;
			foreach(var player in _game.Players)
			{
				if (player.Enabled && player.currentRoom != _target)
				{
					missingPlayer = true;
					break;
				}
			}

			if (missingPlayer)
				_game.health -= 0.0001f;
			else
				this.Enabled = false;
		}
	}

	public class MustDriveShip : EventBase
	{
		private readonly Room _target;

		public MustDriveShip (GameCore game, string text)
			:base(game, text)
		{
			_target = _game._rooms [RoomType.PILOTAGE];
			Enabled = true; //always enabled
		}

		public override void Update (GameTime gameTime)
		{
			bool missingPlayer = true;
			foreach(var player in _game.Players)
			{
				if (player.Enabled && player.currentRoom == _target)
				{
					missingPlayer = false;
					break;
				}
			}

			if (missingPlayer)
				_game.derive -= 0.001f;
			else
				_game.derive = Math.Min(_game.derive + 0.0005f, 1f);
		}
	}
}

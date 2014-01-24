using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FriendShip
{

	public class Player : DrawableGameComponent
	{
		public Vector2 Position { get; private set; }

		public Player (GameCore game)
			: base(game)
		{

		}
	}
}
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GaiaOnline
{
	public sealed class LocalPlayerMovementController : MovementController
	{
		/// <inheritdoc />
		public override Vector2 GetInputDirection()
		{
			return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		}
	}
}

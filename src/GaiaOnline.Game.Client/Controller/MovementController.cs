using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GaiaOnline
{
	public abstract class MovementController : MonoBehaviour
	{
		/// <summary>
		/// Returns the current input direction.
		/// </summary>
		/// <returns>The direction of the input.</returns>
		public abstract Vector2 GetInputDirection();
	}
}

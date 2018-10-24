using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace GaiaOnline
{
	public sealed class InitializationEngine : MonoBehaviour
	{
		/// <summary>
		/// The list of <see cref="IInitializable"/> listeners.
		/// </summary>
		[SerializeField]
		private UnityEvent InitializationList;

		//TODO: How should we allow configuration?
		[SerializeField]
		private bool Initialize;

		private void FixedUpdate()
		{
			//TODO: What about reiniaitlaize?
			if (Initialize)
			{
				InitializationList?.Invoke();

				Initialize = false;
			}
		}
	}
}

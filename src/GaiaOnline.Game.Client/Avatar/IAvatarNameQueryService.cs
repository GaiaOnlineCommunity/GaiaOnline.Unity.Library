using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaiaOnline
{
	public interface IAvatarNameQueryService
	{
		/// <summary>
		/// Tries to query for the name based on the provided id.
		/// </summary>
		/// <param name="id">The id.</param>
		/// <returns>Future that contains the name of the avatar.</returns>
		Task<string> GetNameById(int id);
	}
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GaiaOnline
{
	/// <summary>
	/// Request that tried to inquire about information related to the <see cref="SessionGuid"/>.
	/// </summary>
	[JsonObject]
	public sealed class SessionClaimInquiryRequest
	{
		/// <summary>
		/// The session guid to inquiry about.
		/// </summary>
		[JsonProperty]
		public Guid SessionGuid { get; private set; }

		/// <summary>
		/// The IP Address asssociated with the current connection. that is trying to
		/// claim the actual session.
		/// </summary>
		[JsonProperty]
		public string IpAddress { get; private set; }

		public SessionClaimInquiryRequest(Guid sessionGuid, string ipAddress)
		{
			//TODO: Check IPAdress format.
			if(string.IsNullOrWhiteSpace(ipAddress)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(ipAddress));

			SessionGuid = sessionGuid;
			IpAddress = ipAddress;
		}

		protected SessionClaimInquiryRequest()
		{
			
		}
	}
}
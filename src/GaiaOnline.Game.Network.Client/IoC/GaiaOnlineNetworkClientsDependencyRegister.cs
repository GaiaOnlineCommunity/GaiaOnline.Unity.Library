using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using JetBrains.Annotations;
using SceneJect.Common;
using TypeSafe.Http.Net;
using UnityEngine;

namespace GaiaOnline
{
	public sealed class GaiaOnlineNetworkClientsDependencyRegister : NonBehaviourDependency
	{
		[SerializeField]
		[Tooltip(@"The main query base url. (Ex. http://www.gaiaonline.com")]
		private string GaiaOnlineQueryBaseUrl;

		[SerializeField]
		[Tooltip(@"The CDN base url. (Ex. http://a2.cdn.gaiaonline.com")]
		private string GaiaOnlineImageCDNBaseUrl;

		/// <inheritdoc />
		public override void Register(ContainerBuilder register)
		{
			if (string.IsNullOrWhiteSpace(GaiaOnlineQueryBaseUrl)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(GaiaOnlineQueryBaseUrl));
			if (string.IsNullOrWhiteSpace(GaiaOnlineImageCDNBaseUrl)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(GaiaOnlineImageCDNBaseUrl));

			//https://stackoverflow.com/questions/4926676/mono-https-webrequest-fails-with-the-authentication-or-decryption-has-failed
			ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			ServicePointManager.CheckCertificateRevocationList = false;

			register.RegisterInstance(TypeSafeHttpBuilder<IGaiaOnlineQueryClient>.Create()
					.RegisterDefaultSerializers()
					.RegisterDotNetXmlSerializer()
					.RegisterDotNetHttpClient(GaiaOnlineQueryBaseUrl, new FiddlerEnabledWebProxyHandler())
					.Build())
				.As<IGaiaOnlineQueryClient>()
				.SingleInstance();

			register.RegisterInstance(TypeSafeHttpBuilder<IGaiaOnlineImageCDNClient>.Create()
					.RegisterDefaultSerializers()
					.RegisterUnityTexture2DSerializer()
					.RegisterDotNetHttpClient(GaiaOnlineImageCDNBaseUrl, new FiddlerEnabledWebProxyHandler())
					.Build())
				.As<IGaiaOnlineImageCDNClient>()
				.SingleInstance();
		}

		//https://stackoverflow.com/questions/4926676/mono-https-webrequest-fails-with-the-authentication-or-decryption-has-failed
		private bool MyRemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
		{
			return true;
		}
	}

	public sealed class FiddlerEnabledWebProxyHandler : HttpClientHandler
	{
		public FiddlerEnabledWebProxyHandler()
		{
			Proxy = new WebProxy("localhost", 8888);
		}
	}
}

using System;
using SCAPI.Proxy.Http;

namespace SCAPI.Proxy
{
	public sealed class ProxyListener : HttpListener
	{
		public ProxyListener(ProxyConfig config)
			: base(config.HttpAddress, config.HttpPort)
		{
			Port = config.HttpPort;
			Version = config.Version;
			Config = config;
		}

		public int Port { get; private set; }
		public ProxyConfig.SocksVersion Version { get; private set; }
		private ProxyConfig Config { get; }

		public override void OnAccept(IAsyncResult ar)
		{
			try
			{
				var NewSocket = ListenSocket.EndAccept(ar);
				if (NewSocket != null)
				{
					var NewClient = new ProxyClient(Config, NewSocket, RemoveClient);
					AddClient(NewClient);
					NewClient.StartHandshake();
				}
			}
			catch
			{
			}
			try
			{
				//Restart Listening
				ListenSocket.BeginAccept(OnAccept, ListenSocket);
			}
			catch
			{
				Dispose();
			}
		}
	}
}
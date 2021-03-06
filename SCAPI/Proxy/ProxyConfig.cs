﻿using System.Net;
using SCAPI.Network.ProxySocket;

namespace SCAPI.Proxy
{
	public class ProxyConfig
	{
		public enum SocksVersion
		{
			Four,
			Five
		}

		public ProxyConfig()
		{
			HttpAddress = IPAddress.Parse("127.0.0.1");
			HttpPort = 12345;
			SocksAddress = IPAddress.Parse("127.0.0.1");
			SocksPort = 9150;
			Version = SocksVersion.Five;
			Username = "";
			Password = "";
		}

		public ProxyConfig(IPAddress httpIP, int httpPort, IPAddress socksIP, int socksPort, SocksVersion version)
		{
			HttpAddress = httpIP;
			HttpPort = httpPort;
			SocksAddress = socksIP;
			SocksPort = socksPort;
			Version = version;
			Username = "";
			Password = "";
		}

		public ProxyConfig(IPAddress httpIP, int httpPort, IPAddress socksIP, int socksPort, SocksVersion version, string username, string password)
		{
			HttpAddress = httpIP;
			HttpPort = httpPort;
			SocksAddress = socksIP;
			SocksPort = socksPort;
			Version = version;
			Username = username;
			Password = password;
		}

		public int HttpPort { get; set; }
		public IPAddress HttpAddress { get; set; }
		public int SocksPort { get; set; }
		public IPAddress SocksAddress { get; set; }
		public SocksVersion Version { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public ProxyTypes ProxyType
		{
			get { return (Version == SocksVersion.Five) ? ProxyTypes.Socks5 : ProxyTypes.Socks4; }
		}
	}
}
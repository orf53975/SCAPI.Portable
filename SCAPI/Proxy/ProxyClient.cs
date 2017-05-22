using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using SCAPI.Network.ProxySocket;
using SCAPI.Proxy.Http;

namespace SCAPI.Proxy
{
	public sealed class ProxyClient : HttpClient
	{
		public ProxyClient(ProxyConfig config, Socket ClientSocket, DestroyDelegate Destroyer)
			: base(ClientSocket, Destroyer)
		{
			Config = config;
		}

		private ProxyConfig Config { get; }

		protected override void ProcessQuery(string Query)
		{
			HeaderFields = ParseQuery(Query);
			if (HeaderFields == null || !HeaderFields.ContainsKey("Host"))
			{
				SendBadRequest();
				return;
			}
			int Port;
			string Host;
			int Ret;
			if (HttpRequestType.ToUpper().Equals("CONNECT"))
			{
				//HTTPS
				Ret = RequestedPath.IndexOf(":");
				if (Ret >= 0)
				{
					Host = RequestedPath.Substring(0, Ret);
					if (RequestedPath.Length > Ret + 1)
						Port = int.Parse(RequestedPath.Substring(Ret + 1));
					else
						Port = 443;
				}
				else
				{
					Host = RequestedPath;
					Port = 443;
				}
			}
			else
			{
				//Normal HTTP
				Ret = HeaderFields["Host"].IndexOf(":");
				if (Ret > 0)
				{
					Host = HeaderFields["Host"].Substring(0, Ret);
					Port = int.Parse(HeaderFields["Host"].Substring(Ret + 1));
				}
				else
				{
					Host = HeaderFields["Host"];
					Port = 80;
				}
				if (HttpRequestType.ToUpper().Equals("POST"))
				{
					var index = Query.IndexOf("\r\n\r\n");
					m_HttpPost = Query.Substring(index + 4);
				}
			}
			try
			{
				DestinationSocket = new ProxySocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				((ProxySocket) DestinationSocket).ProxyEndPoint = new IPEndPoint(Config.SocksAddress, Config.SocksPort);
				((ProxySocket) DestinationSocket).ProxyUser = Config.Username;
				((ProxySocket) DestinationSocket).ProxyPass = Config.Password;
				((ProxySocket) DestinationSocket).ProxyType = Config.ProxyType;

				if (HeaderFields.ContainsKey("Proxy-Connection") && HeaderFields["Proxy-Connection"].ToLower().Equals("keep-alive"))
					((ProxySocket) DestinationSocket).SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, 1);
				((ProxySocket) DestinationSocket).BeginConnect(Host, Port, OnProxyConnected, DestinationSocket);
			}
			catch
			{
				SendBadRequest();
			}
		}

		private void OnProxyConnected(IAsyncResult ar)
		{
			try
			{
				((ProxySocket) DestinationSocket).EndConnect(ar);
				string rq;
				if (HttpRequestType.ToUpper().Equals("CONNECT"))
				{
					//HTTPS
					rq = HttpVersion + " 200 Connection established\r\nProxy-Agent: SocksWebProxy\r\n\r\n";
					ClientSocket.BeginSend(Encoding.ASCII.GetBytes(rq), 0, rq.Length, SocketFlags.None, OnOkSent, ClientSocket);
				}
				else
				{
					//Normal HTTP
					rq = RebuildQuery();
					DestinationSocket.BeginSend(Encoding.ASCII.GetBytes(rq), 0, rq.Length, SocketFlags.None, OnQuerySent, DestinationSocket);
				}
			}
			catch
			{
				Dispose();
			}
		}
	}
}
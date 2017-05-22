using SCAPI.Utils;

namespace SCAPI.Contracts
{
	public class UserAgent
	{
		public static string GetAgent(UserAgents agent)
		{
			switch (agent)
			{
				case UserAgents.Windows_NT_6_1_WOW64:
					return "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.81 Safari/537.36";
				case UserAgents.Intel_Mac_OS_X_10_10_3:
					return "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_3) AppleWebKit/600.6.3 (KHTML, like Gecko) Version/8.0.6 Safari/600.6.3";
				case UserAgents.X11_Ubuntu_Linux_x86_64:
					return "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:38.0) Gecko/20100101 Firefox/38.0";
			}
			return "";
		}
	}
}
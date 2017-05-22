using System.Net;
using System.Reflection;

namespace SCAPI.Helpers
{
	public static class Utils
	{
		public static void SetHeader(HttpWebRequest Request, string Header, string Value)
		{
			// Retrieve the property through reflection.
			PropertyInfo PropertyInfo = Request.GetType().GetRuntimeProperty(Header.Replace("-", string.Empty));
			// Check if the property is available.
			if (PropertyInfo != null)
			{
				// Set the value of the header.
				PropertyInfo.SetValue(Request, Value, null);
			}
			else
			{
				// Set the value of the header.
				Request.Headers[Header] = Value;
			}
		}

	}
}
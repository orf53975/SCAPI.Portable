using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SCAPI.Utils
{
	/// <summary>
	///     JsonSerializer class to serialize and deserialize json replies.
	/// </summary>
	public class JsonSerializer
	{
		/// <summary>
		///     Serializes the specified <see langword="object" />.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj">The <see langword="object" />.</param>
		/// <returns></returns>
		public static string Serialize<T>(T obj)
		{
			var stream = new MemoryStream();
			var serializer = new DataContractJsonSerializer(typeof (T));
			serializer.WriteObject(stream, obj);
			var arr = stream.ToArray();
			var result = Encoding.UTF8.GetString(arr, 0, arr.Length);
			return result;
		}

		/// <summary>
		///     Deserializes the specified <paramref name="json" />.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="json">The <paramref name="json" />.</param>
		/// <returns></returns>
		public static T Deserialize<T>(string json)
		{
			try
			{
				var stream = new MemoryStream(Encoding.Unicode.GetBytes(json));
				var deserializer = new DataContractJsonSerializer(typeof (T));
				var result = (T) deserializer.ReadObject(stream);
				return result;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}

			return default(T);
		}
	}
}
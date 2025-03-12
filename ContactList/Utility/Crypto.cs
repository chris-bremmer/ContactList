using System.Security.Cryptography;
using System.Text;

namespace ContactList.Utility
{
	public class Crypto
	{
		private readonly string Key;
		private readonly string IV;

		public Crypto()
		{
			//usually I would store these securely and pull them in for use when
			//needed, but for the sake of this example I will hard code them
			Key = "SomeRandomGeneratedKey@SilveradoEV2025";
			IV = "1974ThisISaCryptoVectorBUTwillanyonereadthis?";
		}

		public Crypto(string key, string iv)
		{
			if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(iv))
			{
				throw new ArgumentException("Constructor values are required", nameof(key));
			}

			Key = key;
			IV = iv;
		}

		public string Encrypt(string plainText)
		{
			using (var aes = Aes.Create())
			{
				aes.Key = GetBytes(Key, 32);
				aes.IV = GetBytes(IV, 16); 

				var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

				using (var ms = new MemoryStream())
				{
					using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
					{
						using (var sw = new StreamWriter(cs))
						{
							sw.Write(plainText);
						}
					}

					return Convert.ToBase64String(ms.ToArray());
				}
			}
		}

		public string Decrypt(string cipherText)
		{
			using (var aes = Aes.Create())
			{
				aes.Key = GetBytes(Key, 32);
				aes.IV = GetBytes(IV, 16); 

				var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

				using (var ms = new MemoryStream(Convert.FromBase64String(cipherText)))
				{
					using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
					{
						using (var sr = new StreamReader(cs))
						{
							return sr.ReadToEnd();
						}
					}
				}
			}
		}
		private byte[] GetBytes(string str, int length)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			byte[] limitedBytes = new byte[length];
			Array.Copy(bytes, limitedBytes, Math.Min(bytes.Length, length));
			return limitedBytes;
		}
	}
}
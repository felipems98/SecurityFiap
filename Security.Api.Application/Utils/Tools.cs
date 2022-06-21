using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security.Api.Application.Utils
{
    public class Tools
    {
        public string GenerateSha265Hash(string pass)
        {

            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(pass));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }
        public string createJWTSecret()
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            byte[] random = new byte[256];

            rng.GetBytes(random);

            return Convert.ToBase64String(random);
        }
        public Guid AppIdToGuid(long AppId)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(AppId).CopyTo(bytes, 0);
            BitConverter.GetBytes(DateTime.Now.Ticks).CopyTo(bytes, 8); // Filler
            return new Guid(bytes);
        }

    }
}

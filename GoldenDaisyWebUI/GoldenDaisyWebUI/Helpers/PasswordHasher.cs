using System.Security.Cryptography;
using System.Text;

namespace GoldenDaisyWebUI.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password, out string salt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // x2: hexadecimal format
                }

                salt = null;
                return builder.ToString();
            }
        }

        internal static bool VerifyPassword(string password, string hashedPassword)
        {
            throw new NotImplementedException();
        }
    }
}

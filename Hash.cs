using Newtonsoft.Json;
using BCrypt.Net;

namespace PassHash
{
        public static string HashPassword(string password)
        {

            // Must be a value between 4 and 31, with higher values increasing the hash time.
            int workFactor = 16;

            // Hashes Password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, workFactor);

            return hashedPassword;
        }

        // Verifies the password against the hashedPassword
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword) || !hashedPassword.StartsWith("$2a$"))
            {
                Console.WriteLine("Invalid bcrypt hash format.");
                return false;
            }


            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
}

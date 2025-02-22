using System;
using System.Security.Cryptography;


namespace Club_manager
{
    internal class PasswordMaker
    {
        public static string HashPassword (string password)
        {
            // Generate a salt
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16];
                rng.GetBytes(salt);

                // Hash the password with the salt
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
                {
                    byte[] hash = pbkdf2.GetBytes(20);
                    byte[] hashBytes = new byte[36];        // hold password and salt
                    Array.Copy(salt, 0, hashBytes, 0, 16);  // copy salt, from index 0, to hashBytes starting from index 0, 16 elements will be copied
                    Array.Copy(hash, 0, hashBytes, 16, 20); // copy hash, from index 0, to hashBytes starting from index 16, 20 elements will be copied

                    // Convert to base64 string
                    return Convert.ToBase64String(hashBytes);
                }
            }
        }

        public static bool VerifyPassword (string password, string hashedPassword)
        {
            // Extract the bytes
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);      // get hash
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);                            // extract salt

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))// Hash the password with the same salt
            {
                byte[] hash = pbkdf2.GetBytes(20); // generate the hash that will be used for comparison
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i]) // compare with the hash created starting from index 16 , and if a single part doesn't match
                    {
                        return false; // Password does not match
                    }
                }
            }
            return true; // Password matches
        }
    }
}

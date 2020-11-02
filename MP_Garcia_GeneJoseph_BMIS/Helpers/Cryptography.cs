using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * CEASAR CIPHER
 */

namespace MP_Garcia_GeneJoseph_BMIS.Helpers
{
    class Cryptography
    {
        private const int KEY = 5;
        /// <summary>
        /// Each character of the password is shifted by KEY times.
        /// </summary>
        /// <param name="password">The password from the login</param>
        /// <returns>Encrypted password</returns>
        public string Encrypt(string password)
        {
            string hashed = "";
            foreach (char character in password.ToArray())
            {
                char tempChar = (char)(character + KEY);
                hashed += tempChar;
            }
            return hashed;
        }

        /// <summary>
        /// Each character of the hashpassword is shifted backward by KEY times
        /// </summary>
        /// <param name="hashedPassword">The hashed password from the text fule</param>
        /// <returns>Returns the original text of the hashed password</returns>
        public string Decrypt(string hashedPassword)
        {
            string password = "";
            foreach (char character in hashedPassword.ToArray())
            {
                char tempChar = (char)(character- KEY);
                password += tempChar;
            }
            return password;
        }
    }
}

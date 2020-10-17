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
        /// 
        /// </summary>
        /// <param name="password"></param>
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
        /// 
        /// </summary>
        /// <param name="hashedPassword"></param>
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

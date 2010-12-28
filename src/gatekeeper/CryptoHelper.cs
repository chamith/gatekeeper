using System;
using System.Security.Cryptography;
using System.Text;

namespace Gatekeeper
{
    /// <summary>
    /// Summary of CryptoHelper class.
    /// </summary>
    public class CryptoHelper
    {
        private static char[] s_acharval;
        
        #region Static Members - Public Methods

        /// <summary>
        /// Creates a password hash out of a given password and a salt.
        /// </summary>
        /// <param name="password">
        /// A <see cref="string"/> containing the password for which the hash should be created.
        /// </param>
        /// <param name="salt">
        /// A <see cref="string"/> containing the cryptograpic salt which is used for creating the 
        /// password hash.
        /// </param>
        /// <returns>
        /// A <see cref="string"/> containing the hash created for the password.
        /// </returns>
        internal static string CreatePasswordHash(string password, string salt)
        {
            string saltAndPwd = String.Concat(password, salt);

            // hashes the password.
            string hashedPwd =
                  HashPassword(saltAndPwd, "SHA1");

            return hashedPwd;
        }

        /// <summary>
        /// Creates a cryptographic salt of specified length.
        /// </summary>
        /// <param name="size">
        /// An <see cref="int"/> specifying the length of the salt.
        /// </param>
        /// <returns></returns>
        internal static string CreateSalt(int size)
        {
            // generates a cryptographic random number using the cryptographic
            // service provider
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // returns a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        /// <summary>
        /// Hashes the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordFormat">The password format.</param>
        /// <returns></returns>
        internal static string HashPassword(string password, string passwordFormat)
        {
            HashAlgorithm algorithm;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            if (passwordFormat == null)
            {
                throw new ArgumentNullException("passwordFormat");
            }
            if (String.Equals(passwordFormat, "sha1", StringComparison.InvariantCultureIgnoreCase))
            {
                algorithm = SHA1.Create();
            }
            else
            {
                if (!string.Equals(passwordFormat, "md5", StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new ArgumentException("InvalidArgumentValue");
                }
                algorithm = MD5.Create();
            }
			byte[] hash = algorithm.ComputeHash(Encoding.ASCII.GetBytes(password));
			System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
			string hashString = enc.GetString(hash);
			//string hashString = string.//ByteArrayToHexString(hash, hash.Length);
            return hashString;
        }

        /// <summary>
        /// Bytes the array to hex string.
        /// </summary>
        /// <param name="buf">The buf.</param>
        /// <param name="iLen">The i len.</param>
        /// <returns></returns>
        internal static unsafe string ByteArrayToHexString(byte[] buf, int iLen)
        {
            char[] chArray = s_acharval;
            if (chArray == null)
            {
                chArray = new char[0x10];
                int length = chArray.Length;
                while (--length >= 0)
                {
                    if (length < 10)
                    {
                        chArray[length] = (char)(0x30 + length);
                    }
                    else
                    {
                        chArray[length] = (char)(0x41 + (length - 10));
                    }
                }
                s_acharval = chArray;
            }
            if (buf == null)
            {
                return null;
            }
            if (iLen == 0)
            {
                iLen = buf.Length;
            }
            char[] chArray2 = new char[iLen * 2];
            fixed (char* chRef = chArray2)
            {
                fixed (char* chRef2 = chArray)
                {
                    fixed (byte* numRef = buf)
                    {
                        char* chPtr = chRef;
                        for (byte* numPtr = numRef; --iLen >= 0; numPtr++)
                        {
                            chPtr++;
                            chPtr[0] = chRef2[(numPtr[0] & 240) >> 4];
                            chPtr++;
                            chPtr[0] = chRef2[numPtr[0] & 15];
                        }
                    }
                }
            }
			StringBuilder builder = new StringBuilder();
			foreach(char c in chArray)
				builder.Append(c.ToString());
			
			string charStr = new string(chArray2,0, chArray2.Length);
            return builder.ToString();//chArray2.ToString();
        }

        #endregion
    }
}

using System.IO;

namespace System
{
    /// <summary>
    /// A static class that provides methods for encrypting and decrypting data using QInt33.
    /// </summary>
    public static class QInt33Encryptor
    {
        /// <summary>
        /// Creates a QInt33 key by computing a hash from the specified input string.
        /// </summary>
        /// <param name="input">The input string to generate the key from. Cannot be null.</param>
        /// <returns>A QInt33 instance representing the hash of the input string.</returns>
        public static QInt33 KeyFromString(string input)
        {
            var hash = CalculateHash(Text.Encoding.Unicode.GetBytes(input));
            return new QInt33(hash);
        }

        /// <summary>
        /// Encrypts the input data using the provided QInt33 key.
        /// </summary>
        /// <param name="data">Data to encrypt.</param>
        /// <param name="key">Encryption key.</param>
        /// <returns>Encrypted data as a byte array.</returns>
        public static byte[] Encrypt(byte[] data, QInt33 key)
        {
            int len = data.Length / 5;
            if (data.Length - len > 0)
            {
                len += 5;
            }
            MemoryStream memoryStream = new MemoryStream();
            for (int i = 0; i < len - 5; i++)
            {
                QInt33 dataChunk = new QInt33(data, i);
                QInt33 encryptedChunk = dataChunk * key;
                byte[] encryptedBytes = encryptedChunk.ToBinary();
                memoryStream.Write(encryptedBytes, 0, encryptedBytes.Length);
            }
            return memoryStream.ToArray();
        }

        /// <summary>
        /// Encrypts the input string using the provided QInt33 key and returns a Base64-encoded string.
        /// </summary>
        /// <param name="data">String to encrypt.</param>
        /// <param name="key">Encryption key.</param>
        /// <returns>Base64-encoded encrypted string.</returns>
        public static string Encrypt(string data, QInt33 key)
        {
            byte[] dataBytes = Text.Encoding.Unicode.GetBytes(data);
            byte[] encryptedBytes = Encrypt(dataBytes, key);
            return Convert.ToBase64String(encryptedBytes);
        }

        /// <summary>
        /// Decrypts the input data using the provided QInt33 key.
        /// </summary>
        /// <param name="encryptedData">Encrypted data to decrypt.</param>
        /// <param name="key">Decryption key.</param>
        /// <returns>Decrypted data as a byte array.</returns>
        public static byte[] Decrypt(byte[] encryptedData, QInt33 key)
        {
            int len = encryptedData.Length / 5;
            if (encryptedData.Length - len > 0)
            {
                len += 5;
            }
            MemoryStream memoryStream = new MemoryStream();
            for (int i = 0; i < len - 5; i++)
            {
                QInt33 encryptedChunk = new QInt33(encryptedData, i);
                QInt33 decryptedChunk = encryptedChunk / key;
                byte[] decryptedBytes = decryptedChunk.ToBinary();
                memoryStream.Write(decryptedBytes, 0, decryptedBytes.Length);
            }
            return memoryStream.ToArray();
        }

        /// <summary>
        /// Decrypts the input Base64-encoded string using the provided QInt33 key and returns the decrypted string.
        /// </summary>
        /// <param name="encryptedData">Base64-encoded string to decrypt.</param>
        /// <param name="key">Decryption key.</param>
        /// <returns>Decrypted string.</returns>
        public static string Decrypt(string encryptedData, QInt33 key)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);
            byte[] decryptedBytes = Decrypt(encryptedBytes, key);
            return Text.Encoding.Unicode.GetString(decryptedBytes);
        }

        /// <summary>
        /// Returns a 32-byte hash of the input data using a custom algorithm.
        /// </summary>
        /// <param name="data">Input data as a byte array.</param>
        /// <returns>A 32-byte hash of the input data.</returns>
        public static byte[] CalculateHash(byte[] data)
        {
            byte[] hash = new byte[32];
            QInt33 hashValue = new QInt33(0x1F11FF6FF);
            for (int i = 0; i < data.Length - 5; i++)
            {
                hashValue ^= new QInt33(data[i]);
                var bin = hashValue.ToBinary();
                Array.Copy(bin, 0, hash, i, bin.Length);
            }

            return hash;
        }
    }
}

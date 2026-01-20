using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;

namespace DAPII_Encryption
{
    internal class DataProtectionAPI
    {
        [SupportedOSPlatform("windows")]
        public static string Encrypt(string plainText)
        {
            // Convert plain text to bytes
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            // Encrypt using DPAPI with machine-level scope
            byte[] encryptedBytes = ProtectedData.Protect(
                plainBytes,
                GetEntropy(), // Optional entropy (additional password)
                DataProtectionScope.LocalMachine // Machine-level encryption
            );

            // Convert to Base64 string for easy storage/display
            return Convert.ToBase64String(encryptedBytes);
        }

        [SupportedOSPlatform("windows")]
        public static string Decrypt(string encryptedText)
        {
            // Convert Base64 string back to bytes
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            // Decrypt using DPAPI
            byte[] decryptedBytes = ProtectedData.Unprotect(
                encryptedBytes,
                GetEntropy(), // Same entropy used during encryption
                DataProtectionScope.LocalMachine // Same scope as encryption
            );

            // Convert bytes back to string
            return Encoding.UTF8.GetString(decryptedBytes);
        }

        //Just to add more complexity to the encryption, we have added entropy of 200 characters.
        private static byte[] GetEntropy()
        {

            string randomString = DeterministicStringGenerator.GenerateComplex200CharString();

            return Encoding.UTF8.GetBytes(randomString);
        }
    }
}

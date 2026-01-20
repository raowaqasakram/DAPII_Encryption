/*
 * IMPORTANT: Add NuGet Package Reference
 * 
 * For .NET Core/.NET 5+/.NET 6+:
 * Install-Package System.Security.Cryptography.ProtectedData
 * 
 * OR add to your .csproj file:
 * <ItemGroup>
 *   <PackageReference Include="System.Security.Cryptography.ProtectedData" Version="8.0.0" />
 * </ItemGroup>
 * 
 * For .NET Framework 4.x:
 * Add reference to System.Security assembly (already included)
 */

using DAPII_Encryption;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== DPAPI Machine-Level Encryption ===\n");

        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Encrypt Password");
            Console.WriteLine("2. Decrypt Password");
            Console.WriteLine("3. Exit");
            Console.Write("\nYour choice: ");

            // Fix CS8600: Use null-coalescing operator to ensure non-null assignment
            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    EncryptPassword();
                    break;
                case "2":
                    DecryptPassword();
                    break;
                case "3":
                    Console.WriteLine("\nExiting...");
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
        }

        void EncryptPassword()
        {
            Console.Write("\nEnter password to encrypt: ");
            // Fix for CS8600: Use the null-coalescing operator to ensure non-null assignment
            string? password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            try
            {
                string encrypted = DataProtectionAPI.Encrypt(password);
                Console.WriteLine("\n--- Encryption Successful ---");
                Console.WriteLine($"Encrypted Password: {encrypted}");
                Console.WriteLine("\nNote: Save this encrypted value for decryption.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nEncryption failed: {ex.Message}");
            }
        }

        void DecryptPassword()
        {
            Console.Write("\nEnter encrypted password: ");
            // Fix for CS8600 in DecryptPassword: Use the null-coalescing operator to ensure non-null assignment
            string? encryptedPassword = Console.ReadLine();
            if (string.IsNullOrEmpty(encryptedPassword))
            {
                Console.WriteLine("Encrypted password cannot be empty.");
                return;
            }

            try
            {
                string decrypted = DataProtectionAPI.Decrypt(encryptedPassword);
                Console.WriteLine("\n--- Decryption Successful ---");
                Console.WriteLine($"Decrypted Password: {decrypted}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nDecryption failed: {ex.Message}");
            }
        }
    }
}
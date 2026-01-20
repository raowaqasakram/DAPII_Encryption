# DPAPI Encryption - Windows DPAPI with Enhanced Entropy

A production-ready C# implementation of Windows Data Protection API (DPAPI) enhanced with a 200-character complex entropy generator for maximum security when handling passwords, API keys, and sensitive credentials.

## 🔐 Why This Matters

Hardcoding secrets in configuration files is risky. Environment variables are still vulnerable. This library leverages Windows DPAPI with enhanced entropy to provide automatic encryption key management without the complexity.

## ✨ Key Features

- **Zero Key Management** - DPAPI handles encryption keys automatically via Windows security
- **200-Character Complex Entropy** - Deterministic algorithm prevents hardcoded entropy attacks
- **Multi-Layer Protection** - DPAPI + Complex Entropy + Scope binding
- **Simple API** - Just `Encrypt()` and `Decrypt()` methods
- **Production Ready** - Robust error handling and null-safe operations

## 🚀 Quick Start

### Prerequisites
- .NET 6.0 or later
- Windows OS
- NuGet: `System.Security.Cryptography.ProtectedData`

### Installation
```bash
git clone https://github.com/raowaqasakram/DataProtectionAPI.git
cd DataProtectionAPI
dotnet add package System.Security.Cryptography.ProtectedData
dotnet run
```

### Basic Usage
```csharp
using DPAPI_Encryption;

// Encrypt
string password = "MySecretPassword123!";
string encrypted = DataProtectionAPI.Encrypt(password);
File.WriteAllText("secret.enc", encrypted);

// Decrypt
string encryptedData = File.ReadAllText("secret.enc");
string decrypted = DataProtectionAPI.Decrypt(encryptedData);
```

## 📁 Project Structure
```
DataProtectionAPI/
├── Program.cs                        # Interactive CLI demo
├── DataProtectionAPI.cs              # Encryption/decryption wrapper
├── DeterministicStringGenerator.cs   # 200-char entropy generator
└── DPAPI_Encryption.csproj          # Project configuration
```

## 🔒 Security Architecture

- **Layer 1**: Windows DPAPI with machine/user master keys
- **Layer 2**: 200-character deterministic complex entropy
- **Layer 3**: Machine-bound protection (LocalMachine scope)

## 💡 Use Cases

✅ Database connection strings  
✅ API keys and authentication tokens  
✅ Application configuration secrets  
✅ Service account credentials  
✅ Desktop application passwords  

## 📖 Full Documentation

For an in-depth explanation of the implementation, security architecture, and best practices, read the complete article:

**[Securing Sensitive Data on Windows: DPAPI with Enhanced Entropy Protection](https://raowaqasakram.hashnode.dev/securing-sensitive-data-on-windows-dpapi-with-enhanced-entropy-protection)**

## ⚙️ Switching to CurrentUser Scope

To encrypt per-user instead of per-machine, modify `DataProtectionAPI.cs`:
```csharp
DataProtectionScope.CurrentUser  // Instead of LocalMachine
```

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!

## 👤 Author

**Rao Waqas Akram**  
GitHub: [@raowaqasakram](https://github.com/raowaqasakram)

## ⭐ Support

If this project helped secure your Windows applications, please give it a ⭐️!

## 📝 License

MIT License - feel free to use in your projects.

---

**Note**: DPAPI is Windows-only. For cross-platform solutions, consider Azure Key Vault or HashiCorp Vault.

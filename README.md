[![](https://img.shields.io/nuget/vpre/QuantumInteger)](https://www.nuget.org/packages/QuantumInteger/)
[![](https://img.shields.io/nuget/dt/QuantumInteger)](https://www.nuget.org/packages/QuantumInteger/)

# ⚛️ Quantum Integer
**QuantumInteger** is a high-performance library designed for quantum-resistant integer arithmetic. 
Developed to bridge the gap between classical computing and post-quantum cryptography, 
it provides ultra-fast, secure types optimized for quantum-native operations.

## ✨ Key Features
Quantum-Native Types: Built-in support for specialized widths, including `QInt33`.

- **Memory Optimized**: Leverages modern features like Span<T>, Memory<T>, and ref struct to ensure zero-allocation overhead where possible.
- **Post-Quantum Ready**: Engineered for cryptographic resilience against quantum-era threats.
- **High Performance**: Optimized for low-latency encryption and decryption cycles.
- **Hardware acceleration**: The type supports hardware acceleration (requires **Nvidia CUDA** to be installed and enabled)


## 🚀 Getting Started
Installation
Add the library to your project via the .NET CLI:
```bash
dotnet add package QuantumInteger
```

### Basic Usage
The following example demonstrates how to generate a 33-bit quantum key and perform secure string encryption.
Usage example:
```cs
// 1. Prepare your data
string input = "My custom string!!!";

// 2. Generate a 33-bit quantum key from a secret
QInt33 key = QInt33Encryptor.KeyFromString("my secret key");

// 3. Encrypt data (Returns a Base64 encoded string)
string encrypted = QInt33Encryptor.Encrypt(input, key);
Console.WriteLine($"Encrypted: {encrypted}");

// 4. Decrypt data
string decrypted = QInt33Encryptor.Decrypt(encrypted, key);
Console.WriteLine($"Decrypted: {decrypted}");
```

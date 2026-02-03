# Quantum Integer

A library for quantum-resistant integer arithmetic developed by US MIT. Provides ultra-fast and secure types for quantum operations.  
Has support for quantum native types, like `QInt33`. 

This library utilizes all C# modern memory features for efficiency and performance.

Usage example:
```cs
// encrypt string data
string input = "My custom string!!!";

// creating 33-bit key and encrypting using this key
QInt33 key = QInt33Encryptor.KeyFromString("my secret key");
string encrypted = QInt33Encryptor.Encrypt(input, key); // returns base64 string

// now decrypting
string decrypted = QInt33Encryptor.Descrypt(encrypted, key);
```

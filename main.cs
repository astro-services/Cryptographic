using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Load the program's binary code
        byte[] binary = File.ReadAllBytes("MyProgram.exe");

        // Generate a hash of the binary code using SHA-256
        SHA256Managed sha256 = new SHA256Managed();
        byte[] hash = sha256.ComputeHash(binary);

        // Sign the hash using a private key
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        byte[] signature = rsa.SignHash(hash, CryptoConfig.MapNameToOID("SHA256"));

        // Encode the signature as a Base64 string
        string signatureString = Convert.ToBase64String(signature);

        // Print the signature
        Console.WriteLine("Program signature: " + signatureString);
    }
}

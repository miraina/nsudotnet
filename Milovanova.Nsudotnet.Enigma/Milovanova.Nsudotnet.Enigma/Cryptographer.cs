
using System;
using System.IO;
using System.Security.Cryptography;

namespace Milovanova.Nsudotnet.Enigma
{
    class Cryptographer
    {
        private SymmetricAlgorithm getAlgorithm(string typeOfAlgorithm)
        {
            switch (typeOfAlgorithm)
            {
                case "aes":
                    {
                        return new AesCryptoServiceProvider();
                    }
                case "des":
                    {
                        return new DESCryptoServiceProvider();
                    }
                case "rc2":
                    {
                        return new RC2CryptoServiceProvider();
                    }
                case "rijndael":
                    {
                        return new RijndaelManaged();
                    }
                default:
                {
                    throw new Exception("Expected 'AES', 'DES', 'RC2' or 'Rijndael' type of algorithm");
                }
            }
            return null;
        }

        public void DecryptEncrypt(string typeOfCoding, string typeOfAlgorithm, string inFileName, string outFileName, string keyFileName)
        {
            
            using (var algorithm = getAlgorithm(typeOfAlgorithm))
            {
                using (var inStream = new FileStream(inFileName, FileMode.Open, FileAccess.Read))
                {
                    using (var outStream = new FileStream(outFileName, FileMode.Create, FileAccess.Write))
                    {
                        if (typeOfCoding == "encrypt")
                        {
                            algorithm.GenerateIV();
                            algorithm.GenerateKey();
                            string iv = Convert.ToBase64String(algorithm.IV);
                            string key = Convert.ToBase64String(algorithm.Key);
                            using (var streamKey = new StreamWriter(File.Create(keyFileName)))
                            {
                                streamKey.WriteLine(iv);
                                streamKey.WriteLine(key);
                            }
                            using (var cryptoStream = new CryptoStream(outStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                inStream.CopyTo(cryptoStream);
                            }
                        }
                        else
                        {
                            using (var readKey = new StreamReader(File.Open(keyFileName, FileMode.Open)))
                            {
                                algorithm.IV = Convert.FromBase64String(readKey.ReadLine());
                                algorithm.Key = Convert.FromBase64String(readKey.ReadLine());
                            }
                            using (var cryptoStream = new CryptoStream(inStream, algorithm.CreateDecryptor(algorithm.Key, algorithm.IV), CryptoStreamMode.Read))
                            {
                                cryptoStream.CopyTo(outStream);
                            }
                        }
                    }
                }
            }

        }
    }
}

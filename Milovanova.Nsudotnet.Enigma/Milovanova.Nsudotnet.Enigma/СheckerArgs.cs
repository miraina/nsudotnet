using System;
using System.IO;

namespace Milovanova.Nsudotnet.Enigma
{
    class СheckerArgs
    {
        public static void Check(string[] args, out string typeOfCoding, out string typeOfAlgorithm, out string inFileName, out string outFileName, out string keyFileName)
        {
           
            if (args.Length != 4 && args.Length != 5)
            {
                throw new Exception("Expected 4 or 5 arguments");
            }

            string tempTypeOfCoding = args[0].ToLower();
            string tempTypeOfAlgorithm;
            string tempInFileName;
            string tempOutFileName;
            string tempKeyFileName;

            if (tempTypeOfCoding == "encrypt")  // crypto.exe encrypt file.txt rc2 output.bin
            {
                if (args.Length != 4)
                {
                    throw new Exception("Expected 4 arguments");
                }
                tempInFileName = args[1];
                tempTypeOfAlgorithm = args[2].ToLower();
                tempOutFileName = args[3];
                tempKeyFileName = "file.key.txt";
            }
            else if (tempTypeOfCoding == "decrypt") // crypto.exe decrypt output.bin rc2 file.key.txt file.txt
            {
                if (args.Length != 5)
                {
                    throw new Exception("Expected 5 arguments");
                }
                tempInFileName = args[1];
                tempTypeOfAlgorithm = args[2].ToLower();
                tempKeyFileName = args[3];
                tempOutFileName = args[4];
                if (!File.Exists(tempKeyFileName))
                {
                    throw new Exception("The key file not exists");
                }
            }
            else
            {
                throw new Exception("Expected 'encrypt' or 'decrypt' in first argument");
            }


            if (!File.Exists(tempInFileName))
            {
                throw new Exception("The input file not exists");
            }

            typeOfCoding = tempTypeOfCoding;
            typeOfAlgorithm = tempTypeOfAlgorithm;
            inFileName = tempInFileName;
            outFileName = tempOutFileName;
            keyFileName = tempKeyFileName;
        }
    }
}

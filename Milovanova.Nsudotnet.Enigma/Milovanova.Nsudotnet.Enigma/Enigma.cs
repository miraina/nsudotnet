

using System;
using System.IO;

namespace Milovanova.Nsudotnet.Enigma
{
    class Enigma
    {
        static void Main(string[] args)
        {
            try
            {
                string typeOfCoding;
                string typeOfAlgorithm;
                string inFileName;
                string outFileName;
                string keyFileName;
                СheckerArgs.Check(args, out typeOfCoding, out typeOfAlgorithm, out inFileName, out outFileName,
                    out keyFileName);
                Cryptographer cryptographer = new Cryptographer();
                cryptographer.DecryptEncrypt(typeOfCoding, typeOfAlgorithm, inFileName, outFileName, keyFileName);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadKey();
            }

        }
    }
}

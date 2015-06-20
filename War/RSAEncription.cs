using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class RSAEncription
    {
        private static RSAEncription instance;
        private RSAEncription() { }
        public static RSAEncription Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RSAEncription();
                }
                return instance;
            }
        }
        public int Encrypt(String pText, int pPublicKey)
        {
            int privateKey = 0;
            byte [] publicKey=BitConverter.GetBytes(pPublicKey);
            byte[] Exponent = {1,0,1};

            CspParameters cp = new CspParameters();
            cp.KeyContainerName = pText;
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(cp);               

            byte[] byteText = Encoding.ASCII.GetBytes(pText);

            byte[] encryptedText = RSA.Encrypt(byteText, false);

            //byte[] bytePrivateKey = 
            Console.WriteLine(RSA.ToXmlString(true));


            //encriptionProcess
            //return the encripted text and the private key 
            return privateKey;
        }
        public String decrypt(String pTexy , int privateKey)
        {
            String decryptedText="";
            //decrytion Process
            //return the decryptedText
            return decryptedText;
        }
    }
}

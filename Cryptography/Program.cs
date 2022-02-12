using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecureSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is where we read in the information for the username and password
            Aes aes = Aes.Create();
            Console.WriteLine("Please Enter the Key: ");
            string key1 = Console.ReadLine();
            Console.WriteLine("Please Enter the IV: ");
            string iv = Console.ReadLine();
            byte[] myKey = Convert.FromBase64String(key1);
            aes.Key = myKey;
            byte[] myIV = Convert.FromBase64String(iv);
            aes.IV = myIV;

            bool runProgram = true;
            do
            {
                Console.WriteLine("Hello! Would you like to: \n(1) Log in\n(2) Create Account\n(3) Exit Program");
                string input = Console.ReadLine();
                string original = null;
                if (input.Contains("1"))
                {
                    Login(myKey, myIV);
                }
                else if (input.Contains("2"))
                {
                    CreateAccount(myKey, myIV);
                }else if (input.Contains("3"))
                {
                    runProgram = false;
                }
                else
                {
                    //User must retry
                    Console.WriteLine("Failed to validate input. Try entering a number from the menu.");
                }
            } while (runProgram);
            
        }

        private static void Login(byte[] myKey, byte[] myIV)
        {
            Console.WriteLine("Welcome to Log In screen!");
            Console.WriteLine("Enter your username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();
            byte[] cipherText = File.ReadAllBytes(@"accountInformation.txt");
            string plain = Decrypt(cipherText, myKey, myIV);
            if (plain.Contains("'" + username + "'" + password + "|"))
            {
                Console.WriteLine("You successfully logged in");
            }
            else
            {
                Console.WriteLine("An Error Occurred");
            }
        }

        private static void CreateAccount(byte[] myKey, byte[] myIV)
        {
            byte[] cipherText = null;
            string plain = "";
            if (File.Exists(@"accountInformation.txt"))
            {
                cipherText = File.ReadAllBytes(@"accountInformation.txt");
                plain = Decrypt(cipherText, myKey, myIV);
            }
            string accountInfo = "";
            Console.WriteLine("Welcome to account creation!");
            Console.WriteLine("What is your username?\n");
            do
            {
                string input = Console.ReadLine();
                if (input.Length >= 6)
                {
                    if (!plain.Contains("'" + input + "'"))
                    {
                        accountInfo += "'" + input + "'";
                        break;
                    }else
                        Console.WriteLine("Error: Username: " + input + " is taken!");

                }
                else
                    Console.WriteLine("Error: Enter at least 6 characters!");
            } while (true);
           
            Console.WriteLine("What is your password?");
            do
            {
                string input = Console.ReadLine();
                if (input.Length >= 6)
                {
                    accountInfo += input;
                    break;
                }
                else
                    Console.WriteLine("Error: Enter at least 6 characters!");
            } while (true);
           
            accountInfo += "|";
            accountInfo += plain;

            byte[] pass_cipherText = Encrypt(accountInfo, myKey, myIV);
            File.WriteAllBytes(@"accountInformation.txt", pass_cipherText);
        }
        static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            return encrypted;
        }
        static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
    }
}

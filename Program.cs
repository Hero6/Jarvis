using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/* Find all Of the unique characters In Moby Dick.
   1.Use the above To create a simple cypher
   2.Randomize the array of unique characters
   3.Rewrite Moby Dick using the randomized array as a map.
   4.Demonstrate the you can also decode the encrypted text.*/

namespace Cypher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a Hashset for unique characters
            HashSet<char> unique = new HashSet<char>();
            //Read the mobyDick File using ReadAllText.
            string mobyDick = File.ReadAllText("mobydick.txt");
            //for each of the char in mobyDick store
            foreach (char a in mobyDick) unique.Add(a);
            // create the uniqueList char array. 
            char[] uniqueList = unique.ToArray();
            //create the randomizedList to char array.
            char[] randomizedList = uniqueList.Clone() as char[];
            //create the random sequence
            Random rand = new Random();
            for (int i = 0; i < randomizedList.Length; i++)
            {
                char b = randomizedList[i];
                int randomIndex = rand.Next(0, randomizedList.Length);
                randomizedList[i] = randomizedList[randomIndex];
                randomizedList[randomIndex] = b;
            }
            //Create the dictionaries to Encrypt and Decrypt
            Dictionary<char, char> toEncrypt = new Dictionary<char, char>();
            Dictionary<char, char> toDecrypt = new Dictionary<char, char>();
            for (int i = 0; i < randomizedList.Length; i++)
            {
                toEncrypt.Add(uniqueList[i], randomizedList[i]);
                toDecrypt.Add(randomizedList[i],uniqueList[i]);
            }
            //Create the StringBuilders for Encrypt and Decrypt
            StringBuilder encrypted = new StringBuilder();
            StringBuilder decrypted = new StringBuilder();

            //For each loop to append the toEncrypt dictionary to mobyDick
            foreach (char x in mobyDick)
            {
                encrypted.Append(toEncrypt[x]);
            }
            //For each loop to append the toDecrypt dictionary to encrypted.
            foreach (char y in encrypted.ToString())
            { 
                decrypted.Append(toDecrypt[y]);

            }
            //Write files to text for both versions of Encrypted and Decrypted.
            File.WriteAllText("encryptedMoby.txt", encrypted.ToString());
            File.WriteAllText("decryptedMoby.txt", decrypted.ToString());


        }
    }
}






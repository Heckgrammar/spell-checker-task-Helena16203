using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System;

namespace SpellCheckerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
                string[] words = createDictionary();

                Console.WriteLine("Enter a sentence to check spelling:");
                string userInput = Console.ReadLine();
                string[] userWords = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries); //splits a sentence into individual words

                List<string> misspelledWords = new(); //creates a new list of strings
                int correctCount = 0;

                foreach (string ActualWord in userWords)
                {
                    if (Array.Exists(words, w => w.Equals(ActualWord, StringComparison.OrdinalIgnoreCase)))
                    {
                        correctCount++;
                    }
                    else
                    {
                        misspelledWords.Add(ActualWord);
                    }
                }

                double accuracy = (double)correctCount / userWords.Length * 100;
                Console.WriteLine("Spelling Score: " + accuracy + ":F2}%");

                File.WriteAllLines("MisspelledWords.txt", misspelledWords);
        }

                static string[] createDictionary()
                {
                    using StreamReader words = new("WordsFile.txt");
                    int count = 0;
                    string[] dictionaryData = new string[178636];
                    while (!words.EndOfStream)
                    {
                        dictionaryData[count] = words.ReadLine();
                        count++;
                    }
                    words.Close();
                    return dictionaryData;
                 }
    }
}


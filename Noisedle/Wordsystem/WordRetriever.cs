using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Noisedle.Wordsystem
{
    internal class WordRetriever
    {
        public List<string> PossibleWords;
        public List<string> GuessableWords;
        public WordRetriever() {
            PossibleWords = new List<string>();
            GuessableWords = new List<string>();

            string basepath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath1 = Path.Combine(basepath, "Wordsystem\\wordle-La.txt");
            string filePath2 = Path.Combine(basepath, "Wordsystem\\wordle-Ta.txt");
            StreamReader sr = new StreamReader(filePath1);

            var line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine($"Registering word {line}");
                PossibleWords.Add(line);
                GuessableWords.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();

            StreamReader sr2 = new StreamReader(filePath2);

            var line2 = sr2.ReadLine();
            while (line2 != null)
            {
                Console.WriteLine($"Registering Word {line2} as guessable");
                GuessableWords.Add(line2);
                line2 = sr2.ReadLine();
            }
            sr2.Close();
        }
    }
}

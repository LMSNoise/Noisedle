using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Noisedle.Wordsystem
{
    internal class WordRetriever
    {
        public List<string> PossibleWords;
        public List<string> GuessableWords;
        
        public WordRetriever() 
        {
            PossibleWords = new List<string>();
            GuessableWords = new List<string>();

            var assembly = Assembly.GetExecutingAssembly();
            
            // Read wordle-La.txt from embedded resource
            using (Stream stream = assembly.GetManifestResourceStream("Noisedle.Wordsystem.wordle-La.txt"))
            using (StreamReader sr = new StreamReader(stream))
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine($"Registering word {line}");
                    PossibleWords.Add(line);
                    GuessableWords.Add(line);
                    line = sr.ReadLine();
                }
            }

            // Read wordle-Ta.txt from embedded resource
            using (Stream stream = assembly.GetManifestResourceStream("Noisedle.Wordsystem.wordle-Ta.txt"))
            using (StreamReader sr2 = new StreamReader(stream))
            {
                var line2 = sr2.ReadLine();
                while (line2 != null)
                {
                    Console.WriteLine($"Registering Word {line2} as guessable");
                    GuessableWords.Add(line2);
                    line2 = sr2.ReadLine();
                }
            }
        }
    }
}

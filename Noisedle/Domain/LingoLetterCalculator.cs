using Noisedle.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Noisedle.Domain
{
    internal class LingoLetterCalculator
    {
        private string guessedWord { get; set; }
        private string properWord { get; set; }
        public LingoLetterCalculator(string toguess, string attemptedguess) 
        {
            properWord = toguess;
            guessedWord = attemptedguess;
        }

        public static Feedback AllMarks(string attemptedguess, Mark mark)
        {
            var marks = new List<Mark>();
            var characters = attemptedguess.ToCharArray();
            for (int i = 0; i<characters.Length ; i++)
            {
                marks.Add(mark);
            }
            return new Feedback(attemptedguess, marks);
        }

        public static Feedback Calculate(string guess, string target)
        {
            guess = guess.ToLower();
            target = target.ToLower();
            if (guess.Length != target.Length) throw new LingoException("length mismatch");
            char[] actualchars = target.ToCharArray();
            char[] guessedchars = guess.ToCharArray();

            var lettercounts = new Dictionary<char, int>();
            foreach (char c in actualchars)
            {
                lettercounts[c] = 0;
                if (lettercounts.ContainsKey(c))
                {
                    lettercounts[c]++; 
                }
            }

            //fill list with absent
            List<Mark> marks = new List<Mark>();
            for (int i = 0; i < target.Length; i++)
            {
                marks.Add(Mark.ABSENT);
            }

            //check correct
            for (int i = 0; i < guessedchars.Length; i++)
            {
                if (guessedchars[i].Equals(actualchars[i]))
                {
                    marks[i] = Mark.CORRECT;
                    lettercounts[guessedchars[i]]--;
                }
            }

            //check present
            for (int i = 0; i < guessedchars.Length; i++)
            {
                if (actualchars.Contains(guessedchars[i]) && 
                    lettercounts[guessedchars[i]] > 0 &&
                    marks[i] == Mark.ABSENT)
                {
                    marks[i] = Mark.PRESENT;
                    lettercounts[guessedchars[i]]--;
                }

            }


            return new Feedback(guess, marks);

        }


    }

    public enum Mark
    {
        ABSENT,
        PRESENT,
        CORRECT
    }
}

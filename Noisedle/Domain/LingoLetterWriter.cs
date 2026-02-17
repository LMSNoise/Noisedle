using System;
using System.Collections.Generic;
using System.Text;

namespace Noisedle.Domain
{
    internal class LingoLetterWriter
    {
        public static void WriteFeedback(Feedback feedback)
        {
            var letters = feedback.FeedbackWord.ToCharArray();
            int markIndex = 0;
            foreach (char c in letters)
            {
                if (feedback.Marks[markIndex] == Mark.CORRECT)
                {
                    WriteGreenLetter(c);
                }
                else if (feedback.Marks[markIndex] == Mark.PRESENT)
                {
                    WriteYellowLetter(c);
                }
                else
                {
                    WriteLetter(c);
                }
                markIndex++;
            }
            Console.WriteLine();


        }
        public static void WriteLetter(char letter)
        {
            Console.Write(letter);
        }
        public static void WriteYellowLetter(char letter)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(letter);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void WriteGreenLetter(char letter)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(letter);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Noisedle.Domain
{
    internal class Feedback
    {
        public string FeedbackWord { get; set; }
        public List<Mark> Marks { get; set; }
        public Feedback(string feedbackWord, List<Mark> marks) 
        { 
            FeedbackWord = feedbackWord;
            Marks = marks;
        }

        public override string ToString()
        {
            var returnstring = string.Empty;
            foreach (Mark mark in Marks)
            {
                returnstring += mark.ToString() + " ";
            }
            return returnstring;
        }
    }
}

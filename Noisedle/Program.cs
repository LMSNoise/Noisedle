using System.Diagnostics;
using Noisedle.Domain;
using Noisedle.Wordsystem;

var retriever = new WordRetriever();
Random rnd = new Random();
int r = rnd.Next(retriever.PossibleWords.Count);
Console.Clear();
string wordToGuess = retriever.PossibleWords[r];

List<char> absentLetters = new List<char>();

List<Feedback> feedbackhistory = new List<Feedback>();

while(true){
    Console.WriteLine("---NOISEDLE---");
    if (feedbackhistory.Count > 0) 
    {
        Console.WriteLine("Feedback history:");
    }
    foreach (Feedback feedback in feedbackhistory)
    {
        LingoLetterWriter.WriteFeedback(feedback);
    }

    Console.WriteLine();
    //write locked out chars
    if (absentLetters.Count > 0)
    {
        Console.WriteLine("Letters not in word:");
        foreach(char c in absentLetters.Distinct())
        {
            Console.Write(c); 
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    Console.WriteLine("Guess word: ");

    string input = Console.ReadLine();
    if (!retriever.PossibleWords.Contains(input))
    {
        Console.WriteLine("Incorrect input, try again: ");
        input = Console.ReadLine();
    }

    var guessfeedback = LingoLetterCalculator.Calculate(input, wordToGuess);
    feedbackhistory.Add(guessfeedback);
    absentLetters.AddRange(LingoLetterCalculator.GetUnusedLetters(input, wordToGuess));
    if (!guessfeedback.Marks.Contains(Mark.ABSENT) && !guessfeedback.Marks.Contains(Mark.PRESENT))
    {
        Console.WriteLine("You win!");
        break;
    }

    Console.Clear();

}
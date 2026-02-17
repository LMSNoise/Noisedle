using System.Diagnostics;
using Noisedle.Domain;
using Noisedle.Wordsystem;

var retriever = new WordRetriever();
Random rnd = new Random();
int r = rnd.Next(retriever.PossibleWords.Count);
string wordToGuess = retriever.PossibleWords[r];

List<String> absentLetters = new List<string>();

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
    Console.WriteLine("Guess word: ");

    string input = Console.ReadLine();
    if (!retriever.PossibleWords.Contains(input))
    {
        Console.WriteLine("Incorrect input, try again: ");
        input = Console.ReadLine();
    }

    var guessfeedback = LingoLetterCalculator.Calculate(input, wordToGuess);
    feedbackhistory.Add(guessfeedback);
    if (!guessfeedback.Marks.Contains(Mark.ABSENT) && !guessfeedback.Marks.Contains(Mark.PRESENT))
    {
        Console.WriteLine("You win!");
        break;
    }

    Console.Clear();

}
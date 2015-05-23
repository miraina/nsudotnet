using System;

namespace Milovanova.Nsudotnet.NumberGuesser
{
    class NumberGuesser
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter your name");
            string userName = Console.ReadLine();
            
            Random random = new Random();
            int guessNumber = random.Next(0, 101);
            Console.WriteLine("{0}, guess the number between 0 to 100. Enter number.", userName);

            Random randomPhrases = new Random();
            string[] phrases = { "{0} you can do it, I believe!", 
                                    "{0}, it is not hard, really.", 
                                    "Come on, {0}!", 
                                    "Victory is coming! {0}, do it!" };    

            int userAnswer = -1;
            int countAttempts = 0;
            int[] attempts = new int[1000];
            DateTime startTime = DateTime.Now;
            string timeFormat = @"mm\:ss";
            while (userAnswer != guessNumber)
            {
                string attempt = Console.ReadLine();
                if (attempt == "q" || attempt == null) 
                {
                    Console.WriteLine("Goodbye, {0}!", userName);
                    break;
                }
                
                Int32 parsedAttempt;
                bool resParsing = Int32.TryParse(attempt, out parsedAttempt);
                if (!resParsing) 
                {
                    Console.WriteLine("Please, enter number, {0}!", userName);
                    continue;
                }
                
                userAnswer = Int32.Parse(attempt);
                if (userAnswer != guessNumber)
                {
                    Console.WriteLine(userAnswer > guessNumber ? "This number > than you need" : "This number < than you need");
                    if ((countAttempts+1) % 4 == 0) 
                    {
                        String phrase = phrases[randomPhrases.Next(0, phrases.Length)];
                        Console.WriteLine(phrase, userName);
                    }
                    attempts[countAttempts] = userAnswer;
                    countAttempts++;
                }
                else
                {
                    DateTime finishTime = DateTime.Now;
                    Console.WriteLine("You win! Right answer: {0}", guessNumber);
                    Console.WriteLine("Count attempts: {0}", countAttempts);
                    Console.WriteLine("Your attempts:");
                    for (int i = 0; i < countAttempts; i++) 
                    {
                        Console.Write(attempts[i]);
                        Console.WriteLine(attempts[i] > guessNumber ? " >" : " <");
                    }
                    Console.WriteLine("Time: {0}", (finishTime-startTime).ToString(timeFormat));
                    Console.ReadKey();                
                }
            }

        }
    }
}

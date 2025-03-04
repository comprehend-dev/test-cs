namespace NumberGuessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int secretNumber = random.Next(1, 101);
            int guessCount = 0;
            bool isCorrect = false;

            Console.WriteLine("Hello, this is a number guessing game. I'm thinking of a number between 1 and 100. You have 7 guesses.");

            while (guessCount < 7 && !isCorrect)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();
                int guess;

                if (int.TryParse(input, out guess))
                {
                    guessCount++;

                    if (guess == secretNumber)
                    {
                        isCorrect = true;
                        Console.WriteLine("Congratulations! You guessed the number {0} in {1} guesses.", secretNumber, guessCount);
                    }
                    else if (guess < secretNumber)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
                }
            }

            if (!isCorrect)
            {
                Console.WriteLine("Sorry, you ran out of guesses. The number was {0}.", secretNumber);
            }
        }
    }
}

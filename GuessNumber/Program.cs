Random random = new Random();
int numberToGuess;
int numTries = 0;
int gamesPlayed = 0;
List<int> numGuessesPerGame = new List<int>();
bool playing = false;

Console.WriteLine("Hey! Do you want to play a game? (y/n)");
string userAnswer = Console.ReadLine();

while (true)
{
    if (userAnswer == "y")
    {
        playing = true;
        numTries = 0;
    }
    else
    {
        playing = false;
        break;
    }

    numberToGuess = random.Next(1, 21);
    Console.WriteLine("Awesome! Guess a number between 1-20.");
    int userGuess = int.Parse(Console.ReadLine());

    while (playing)
    {
        if (userGuess == numberToGuess)
        {
            numTries++;
            Console.WriteLine("You are correct!");
            Console.WriteLine("Do you want to play again? (y/n)");
            userAnswer = Console.ReadLine();
            playing = false;
            numGuessesPerGame.Add(numTries);
            gamesPlayed++;
        }
        else if (userGuess < 1 && userGuess > 20)
        {
            numTries++;
            Console.WriteLine("Please guess between 1 and 20.");
            userGuess = int.Parse(Console.ReadLine());
        }
        else if (userGuess < numberToGuess)
        {
            numTries++;
            Console.WriteLine("Your guess is too low! Try again!");
            userGuess = int.Parse(Console.ReadLine());
        }
        else if (userGuess > numberToGuess)
        {
            numTries++;
            Console.WriteLine("Your guess is too high! Try again!");
            userGuess = int.Parse(Console.ReadLine());
        }
    }
}

if (gamesPlayed > 0)
{
    int i = 0;
    foreach (int guesses in numGuessesPerGame)
    {
        i++;
        if (guesses > 1)
            Console.WriteLine($"In game {i} you took {guesses} tries.");
        else
            Console.WriteLine($"In game {i} you took {guesses} try.");
    }
}

Console.WriteLine("See you next time!");
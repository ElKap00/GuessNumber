using GuessNumber;

UI ui = new UI();
GuessNumberGame game = new GuessNumberGame();

Console.Write(ui.DrawUI());
Console.WriteLine("\nWhat's your name?");
string playerName = Console.ReadLine();

game.PlayGame(playerName);
using GuessNumber;

UI ui = new UI();
GuessNumberGame game = new GuessNumberGame();

Console.Write(ui.DrawUI());
string playerName = Console.ReadLine();

game.PlayGame(playerName);
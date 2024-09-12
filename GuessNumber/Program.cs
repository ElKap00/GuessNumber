using GuessNumber;

UI ui = new UI();
GuessNumberGame game = new GuessNumberGame();

string playerResponse = ui.DrawUI();
game.PlayGame(playerResponse);
using System;

namespace CMP1903_A1_2324//defines the namespace
{
    internal class Program//declares the class called Program
    {
        static void Main(string[] args) //declares the main method
        {
            Game game = new Game(); //creates a Game object
            game.PlayGame(); //calls the PlayGame() method of the Game object

            Testing testing = new Testing(); //initialises the testing object
            testing.TestGameAndDie(game); //calls the method and passes the game object to the TestGameAndDie() method
        }
    }
}


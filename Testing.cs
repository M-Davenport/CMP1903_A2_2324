using System;
using System.Diagnostics;

namespace CMP1903_A1_2324 //defines the namespace
{
    internal class Testing //declares the class called Testing
    {
        public void TestGameAndDie(Game game) //declares the TestGameAndDie method and takes a Game object as a parameter
        {
            //tests the Game class            
            int total = game.GetTotal(); //calls the gettotal method to get the total of the dice rolls
            //asserts that the total of the three dice rolls is between 3 and 18. If not an error message is produced
            Debug.Assert(total >= 3 && total <= 18, "Total of three dice rolls is not as between 3 and 18.");

            //tests the Die class
            Die die = new Die(); //creates new instance of the die class to test if rolls are between 1 and 6
            int rolledValue = die.Roll(); //calls the roll method and stores the value of the roll
            //asserts that the rolled value is be between 1 and 6. if not an error message is produced
            Debug.Assert(rolledValue >= 1 && rolledValue <= 6, "Rolled value is not between 1 and 6.");
        }
    }
}


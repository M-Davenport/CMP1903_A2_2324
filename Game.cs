using System;

namespace CMP1903_A1_2324 //defines the namespace
{
    internal class Game //declares the game class
    {
        //declares and initialises private fields for each die
        private Die die1 = new Die();
        private Die die2 = new Die();
        private Die die3 = new Die();

        public void PlayGame() //declares the PlayGame method
        {
            bool rollAgain = true; //initialises a boolean variable so that a loop can be created
            while (rollAgain) //starts a while loop which keeps running as long as rollAgain is true
            { 
                try //creates a try block to handle any exceptions
                {
                    //rolls the dice three times and stores the results
                    int roll1 = die1.Roll();
                    int roll2 = die2.Roll();
                    int roll3 = die3.Roll();
                    //prints the results of the dice rolls
                    Console.WriteLine("Die 1 rolled: " + roll1);
                    Console.WriteLine("Die 2 rolled: " + roll2);
                    Console.WriteLine("Die 3 rolled: " + roll3);

                    int total = roll1 + roll2 + roll3; //calculates the total of the dice rolls
                    Console.WriteLine("Total of three rolls: " + total);//prints the total of the dice rolls
                    rollAgain = false; //if the rolls dont encounter an error then the loop is broken by setting rollAgain to false
                }
                catch (Exception ex) //catches any errors that occur during the dice rolls
                {
                    Console.WriteLine("Error whilst rolling the dice: " + ex.Message); //tells the user there is an error and outputs the error message
                    Console.Write("Roll again? (y/n):"); //asks user if they want to roll again after an error occurs
                    string response = Console.ReadLine(); //reads the users response and stores it in a variable
                    if (response != "y") //checks to see if the users response was not "y"
                        rollAgain = false; //breaks the loop by setting rollAgain to false if anything other than "y" is entered
                }
            }
        }

        public int GetTotal() //method to get the total of the three dice rolls
        {
            return die1.Roll() + die2.Roll() + die3.Roll(); //returns the sum of the face values of all three dice
        }
    }
}

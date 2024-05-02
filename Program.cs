using System;

class Program
{
    static void Main() //main method that is the start point for the program
    {
        Statistics stats = new Statistics();//creates a statistics instance for tracking stats
        Testing testing = new Testing(stats);//creates a testing object 
        Game game = null;

        while (true)//loop to keep displaying the menu
        {
            Console.WriteLine("\nMenu:"); //displays each option to the user
            Console.WriteLine("1. Play Sevens Out");
            Console.WriteLine("2. Play Three or More");
            Console.WriteLine("3. Run Tests");
            Console.WriteLine("4. View Statistics");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice)) //if input is not a valid number
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    game = new SevensOut(stats);//instantiation of a sevensou game passing the stats to track the statistics
                    break;
                case 2:
                    game = new ThreeOrMore(stats);//instantiation of threeormore game passing the stats to tracj the statistics
                    break;
                case 3:
                    testing.RunTests();//calls method to run test
                    break;
                case 4:
                    stats.DisplayStats();//method to display the statistics
                    continue;  //skips the game.Play() call
                case 5:
                    return;  //exits the program
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    continue;
            }

            if (game != null)
            {
                game.Play(); //polymorphic call to play the game
                if (game is ThreeOrMore threeOrMore) //checks if the game instance is threeormore
                {
                    //updates the stats with the number of rolls for threeormore
                    stats.UpdateStats("Three Or More", threeOrMore.RollCount, trackHighScore: false);
                }
            }
        }
    }
}

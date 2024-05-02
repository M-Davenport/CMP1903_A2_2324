using System;
using System.Linq;

public class ThreeOrMore : Game//this is inheritance from the game base class
{
    private Die[] dice;//this is encapsulation as the dice array is kept private
    private Random random = new Random(); 
    public int Score { get; private set; }//this is encapsulation with a public getter and private setter for the score
    private int rollCount = 0; 

    //public to access the rollCount outside the class (also encapsulation)
    public int RollCount
    {
        get { return rollCount; }
    }

    private Statistics stats;//statistics object to track game statistics

    //constructor that accepts a statistics instance
    public ThreeOrMore(Statistics stats)
    {
        this.stats = stats;
        dice = new Die[5];//initialises die array with 5 dice objects
        for (int i = 0; i < dice.Length; i++)
        {
            dice[i] = new Die(random); 
        }
    }

    public override void Play() //implementation of an abstract method from the game class (polymorphism)
    {
        Score = 0; //sets the score to 0
        while (Score < 20) //loop whilst the score is less than 20
        {
            Console.WriteLine("\nPress any key to roll all 5 dice");
            Console.ReadKey();  //user presses any key to roll the dice
            RollAllDice(); //calls rollalldie method to roll the dice
            //linq to group dice based on their face values
            Console.WriteLine("\nDice Rolls: " + string.Join(", ", dice.Select(d => d.FaceValue)));
            var groups = dice.GroupBy(d => d.FaceValue).OrderByDescending(g => g.Count());
            var mostCommon = groups.FirstOrDefault(); //retrieves the dixe with the highest count

            if (mostCommon != null)
            {
                int count = mostCommon.Count(); //retrieves the count of the most common value
                if (count == 2) //if 2 of the dice face values are the same
                {
                    //player chooses to reroll or not
                    Console.WriteLine("Rolled a pair. Choose to rethrow all or the remaining dice? (all/remain)");
                    string choice = Console.ReadLine().Trim().ToLower();
                    if (choice == "remain" || choice == "all")
                    {
                        Console.WriteLine("Press any key to perform the reroll...");
                        Console.ReadKey();
                        HandleReroll(choice, mostCommon.Key);
                    }
                }
                groups = dice.GroupBy(d => d.FaceValue).OrderByDescending(g => g.Count()); //calculates groups after the rerolls
                mostCommon = groups.FirstOrDefault(); //updates most common group
                count = mostCommon?.Count() ?? 0;//updates count of most common

                int pointsEarned = CalculatePoints(count); //calculates the points
                Score += pointsEarned;//adds the points to the score
                if (pointsEarned > 0) //if points were eaarned
                {
                    Console.WriteLine($"Scored {pointsEarned} points for {count}-of-a-kind!");
                }
                else
                {
                    Console.WriteLine("No matching dice - 0 points");
                }
            }
            else
            {
                Console.WriteLine("No matching dice - 0 points");
            }

            Console.WriteLine($"Total Score: {Score}");
            if (Score >= 20) //checks if 20 points has been reached yet
            {
                Console.WriteLine("You've reached 20 points");
                Console.WriteLine($"Total dice rolls: {rollCount}");
                stats.UpdateStats("Three Or More", rollCount, trackHighScore: false); //updates statistics with the new number of rolls
                break; //breaks the loop
            }
        }
    }


    private void RollAllDice() //method to roll the dice in the array
    {
        foreach (var die in dice) //goes through each dice in the array
            die.Roll(); //rolls for each dice
        rollCount++;  //increment the roll counter
    }
    //method to reroll
    private void HandleReroll(string choice, int mostCommonValue)
    {
        if (choice == "remain") //if user chooses to roll only the remaining dice
        {
            foreach (var die in dice.Where(d => d.FaceValue != mostCommonValue)) //rerolls each dice where there isnt a duplicate of it
                die.Roll();
            Console.WriteLine("\nRerolled Dice (excluding pair): " + string.Join(", ", dice.Select(d => d.FaceValue)));
        }
        else if (choice == "all") //if user chooses to reroll all the dice
        {
            RollAllDice(); //calls rollalldice to reroll the dice
            Console.WriteLine("\nRerolled All Dice: " + string.Join(", ", dice.Select(d => d.FaceValue)));
        }
        else
        {
            Console.WriteLine("\nInvalid input, no reroll performed."); //handles erroneous inputs
        }
        rollCount++;  //increments the rollcount
    }

    private int CalculatePoints(int count) //nethod to calculate points
    {
        switch (count)
        {
            case 3: return 3; //3 of a kind = 3 points
            case 4: return 6; //4 of a kind = 6 points
            case 5: return 12; //5 of a kind = 12 points
            default: return 0; //no matches = 0 points
        }
    }
}

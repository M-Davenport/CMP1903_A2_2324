using System;

public class SevensOut : Game //sevensout is a subclass of game. THis is inheritance
{
    private Die die1; //two private fields for storing both the die
    private Die die2;//this is encapsulation
    private Random random = new Random();
    private Statistics stats;
    public bool StoppedOnSeven { get; private set; }  //if the game stopped due to rolling a 7

    public SevensOut(Statistics stats)//constructor that accepts a Statistics instance
    {
        this.stats = stats;
        die1 = new Die(random);
        die2 = new Die(random);
    }

    public int Score { get; private set; }//encapsulates the score

    public override void Play()
    {
        Score = 0; //sets the score to 0
        bool continuePlaying = true; //used to create a loop

        while (continuePlaying)
        {
            int roll1 = die1.Roll();//rolls the dice and stores the results
            int roll2 = die2.Roll();
            int rollTotal = roll1 + roll2; //stores sum of both the dice
            Console.WriteLine($"Rolled: {roll1} and {roll2}. Roll total: {rollTotal}"); //outputs the results from the dice rolls

            if (rollTotal == 7) //checks to see if the sum of the dice is 7
            {
                Score += rollTotal; //adds the sum of the current dice to the score
                StoppedOnSeven = true;  //sets stoppedonseven to true
                Console.WriteLine($"Total Score: {Score}"); //outputs the total score
                Console.WriteLine("Rolled a 7, game over!");
                continuePlaying = false; //stops the game by breaking the loop
            }
            else
            {
                if (roll1 == roll2) //if a double got rolled
                {
                    rollTotal *= 2;//doubles the sum of the dice if a double was rolled
                    Console.WriteLine($"Doubles rolled! Points doubled for this roll: {rollTotal}");
                }

                Score += rollTotal; //adds the sum of the current dice to the score
                Console.WriteLine($"Total Score so far: {Score}");

                Console.WriteLine("Roll again? (y/n)");//asks the user if they wasnt to roll the dice
                string response = Console.ReadLine();
                if (response.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    continuePlaying = false; //if player doesnt want to continue rolling the game is stopped
                    Console.WriteLine("Game Over");
                }
            }
        }
    }
}

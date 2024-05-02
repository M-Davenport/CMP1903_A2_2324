using System;
using System.Diagnostics;

public class Testing
{
    private Statistics stats;

    public Testing(Statistics stats) //constructor that accepts a statistics instance
    {
        this.stats = stats;
    }

    public void TestSevensOut() //method to test sevensout game
    {
        SevensOut game = new SevensOut(stats);
        game.Play();//
        //asserts that the game stops after the dice rolls sum is 7
        Debug.Assert(game.StoppedOnSeven, "Test failed: Sevens Out should stop at a roll totaling 7.");

        Console.WriteLine("Sevens Out Test Passed: Game stops at a roll totaling 7.");
    }

    public void TestThreeOrMore() //method to test threeormore game
    {
        ThreeOrMore game = new ThreeOrMore(stats);
        game.Play();
        //asserts that the score is 20 or greater
        Debug.Assert(game.Score >= 20, "Test failed: Three Or More should recognize when total score is at least 20.");

        Console.WriteLine("Three Or More Test Passed: Total score recognized correctly at 20 or more.");
    }

    public void RunTests() //method to run the test
    {
        TestSevensOut(); //runs the sevensout test
        TestThreeOrMore();//runs the threeormore test
        Console.WriteLine("All tests completed successfully.");
    }
}

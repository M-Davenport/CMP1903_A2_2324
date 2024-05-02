using System;
using System.Collections.Generic;

public class Statistics
{
    //public dictionary to store the gamecount, highscores and lowest rolls
    public Dictionary<string, int> GameCounts = new Dictionary<string, int>();
    public Dictionary<string, int> HighScores = new Dictionary<string, int>(); 
    public Dictionary<string, int> LowestRolls = new Dictionary<string, int>(); 

    //updates statistics
    public void UpdateStats(string gameName, int score, bool trackHighScore = true)
    {
        if (!GameCounts.ContainsKey(gameName)) //if the game name is not already a key in gamecounts 
            GameCounts[gameName] = 0; //initialize it with 0
        GameCounts[gameName]++; //increments game count

        if (trackHighScore)
        {
            //if highscores doesnt contain the game or the new score is higher then it updates it 
            if (!HighScores.ContainsKey(gameName) || score > HighScores[gameName])
                HighScores[gameName] = score;
        }
        else
        {
            //if the lowestrolls doesnt contain the game or the new score is lower then it updates it
            if (!LowestRolls.ContainsKey(gameName) || score < LowestRolls[gameName])
                LowestRolls[gameName] = score;
        }
    }

    public void DisplayStats() //method to display the statistics
    {
        foreach (var game in GameCounts.Keys) //iterates over all games in gmaecounts
        {
            Console.WriteLine($"{game} - Plays: {GameCounts[game]}");//outputs the gamecount
            if (HighScores.ContainsKey(game)) //if highscores contains game
            {
                Console.WriteLine($"High Score: {HighScores[game]}"); //outputs the highscore
            }
            if (LowestRolls.ContainsKey(game)) //if lowestrolls conatins game
            {
                Console.WriteLine($"Lowest Rolls: {LowestRolls[game]}");//output the lowest rollcount
            }
        }
    }
}

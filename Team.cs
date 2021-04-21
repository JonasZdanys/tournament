using System;
using System.Collections.Generic;
using System.Text;
public class Team
{
    public string Name { get; set; }
    public int MatchesPlayed { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int Draws { get; set; }
    public int Points { get; set; }
    public Team(string name, int wins, int losses, int draws)
    {
        Name = name;
        MatchesPlayed = wins + losses + draws;
        Wins = wins;
        Losses = losses;
        Draws = draws;
        Points = wins * 3 + draws;
    }
}
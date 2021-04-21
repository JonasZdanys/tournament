using System;
using System.Collections.Generic;
using System.Text;
public class Match
{
    public string FirstTeam { get; set; }
    public string SecondTeam { get; set; }
    public MatchResult Outcome { get; set; }
    public Match (string match)
    {
        string [] matchStrings = match.Split(';');
        FirstTeam = matchStrings[0];
        SecondTeam = matchStrings[1];
        switch (matchStrings[2])
        {
            case "win":
                Outcome = MatchResult.win;
                break;
            case "loss":
                Outcome = MatchResult.loss;
                break;
            case "draw":
                Outcome = MatchResult.draw;
                break;
            default:
                throw new ArgumentException("Match canceled");
        }
    }
}
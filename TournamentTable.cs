using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
public class TournamentTable
{
    private Dictionary<string, Team> _rankings = new Dictionary<string, Team>();
    public TournamentTable()
    {
        var filtered = _rankings.Values
            .OrderByDescending(t => t.Points)
            .ThenBy(t => t.Name)
            .Select(t => String.Format(t.Name, t.MatchesPlayed, t.Wins, t.Losses, t.Draws, t.Points));
    }
    public void AddTeams(Match currentMatch)
    {
        if (!_rankings.ContainsKey(currentMatch.FirstTeam))
        {
            var newTeam = new Team(currentMatch.FirstTeam, 0, 0, 0);
            _rankings.Add(newTeam.Name, newTeam);
        }
        if (!_rankings.ContainsKey(currentMatch.SecondTeam))
        {
            var newTeam = new Team(currentMatch.SecondTeam, 0, 0, 0);
            _rankings.Add(newTeam.Name, newTeam);
        }
        switch (currentMatch.Outcome)
        {
            case MatchResult.win:
                _rankings[currentMatch.FirstTeam].Wins++;
                _rankings[currentMatch.SecondTeam].Losses++;
                _rankings[currentMatch.FirstTeam].MatchesPlayed++;
                _rankings[currentMatch.SecondTeam].MatchesPlayed++;
                _rankings[currentMatch.FirstTeam].Points += 3;
                break;
            case MatchResult.loss:
                _rankings[currentMatch.FirstTeam].Losses++;
                _rankings[currentMatch.SecondTeam].Wins++;
                _rankings[currentMatch.FirstTeam].MatchesPlayed++;
                _rankings[currentMatch.SecondTeam].MatchesPlayed++;
                _rankings[currentMatch.SecondTeam].Points += 3;
                break;
            case MatchResult.draw:
                _rankings[currentMatch.FirstTeam].Draws++;
                _rankings[currentMatch.SecondTeam].Draws++;
                _rankings[currentMatch.FirstTeam].MatchesPlayed++;
                _rankings[currentMatch.SecondTeam].MatchesPlayed++;
                _rankings[currentMatch.FirstTeam].Points++;
                _rankings[currentMatch.SecondTeam].Points++;
                break;
        }
    }
    public IEnumerable<Team> SortTable()
    {
        return _rankings.Values
            .OrderByDescending(t => t.Points)
            .ThenBy(t => t.Name);
    }
}
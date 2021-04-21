using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class Tournament
{   
    public static void Tally(Stream inStream, Stream outStream)
    {
        var fullTable = new TournamentTable();
        using (StreamReader input = new StreamReader(inStream))
        {
            while (!input.EndOfStream)
            {
                string oneMatch = input.ReadLine();
                var currentMatch = new Match(oneMatch);
                fullTable.AddTeams(currentMatch);
            }
        }
        var sorted = fullTable.SortTable();
        string header = "Team                           | MP |  W |  D |  L |  P";
        using (StreamWriter output = new StreamWriter(outStream))
        {
            output.Write(header);
            foreach (var line in sorted)
            {
                output.Write("\n");
                output.Write($"{line.Name,-30} | {line.MatchesPlayed,2} | {line.Wins,2} | {line.Draws,2} | {line.Losses,2} | {line.Points,2}");
            }
        }
    }
}
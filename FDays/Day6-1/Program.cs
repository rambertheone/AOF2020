using System.Diagnostics;
using System.Linq;

namespace adventofcode;
class Program
{
    static void Main(string[] args)
    {

        string[] input = File.ReadAllLines("../../../../adventofcode.com_2020_day_6_input.txt");
        //string[] input = { "abc", "", "a", "b", "c", "", "ab", "ac", "", "a", "a", "a", "a","", "b" };
        string[] teamData = new string[FindNumberOfTeams(input)];
        int[] teamsYesAnswers = new int[FindNumberOfTeams(input)];

        ConsolidateTeamsAnswers(input, teamData);
        TeamYesAnswers(teamData, teamsYesAnswers);
        TotalYes(teamsYesAnswers);


        Console.ReadLine();

    }

    static int FindNumberOfTeams(string[] input)
    {
        int count = 0;

        for(int i=0; i < input.Length; i++)
        {
            if (input[i] == "")
            {
                count++;
            }
        }

        return count + 1;
    }

    static void ConsolidateTeamsAnswers(string[] input, string[] teamData)
    {
        string teamAnswers = "";
        int index = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != "")
            {
                teamAnswers = input[i] + " " + teamAnswers;
            }
            else
            {
                teamData[index] = teamAnswers;
                index++;
                teamAnswers = "";
            }
            
        }

        teamData[index] = teamAnswers;


    }

    static void TeamYesAnswers(string[] teamData, int[] teamYesAnswers)
    {

        for(int i=0; i< teamData.Length; i++)
        {

            string[] teamAnswers = teamData[i].Split(" ");
            teamYesAnswers[i] = CalculatePointsPerTeam(teamAnswers);
            Console.WriteLine(teamYesAnswers[i]);
        }

    }

    static int CalculatePointsPerTeam(string[] answers)
    {
        string YesAnsweredQuestions = "";
        int score = 0;
        for(int i=0; i < answers.Length; i++)
        {
            for(int j=0; j < answers[i].Count(); j++)
            {
                if (YesAnsweredQuestions.Contains(answers[i][j]) == false)
                {
                    YesAnsweredQuestions = answers[i][j] + YesAnsweredQuestions;
                    score++;
                }
            }
        }
        return score;
    }

    static void TotalYes(int[] teamYesAnswers)
    {
        int total = 0;
        for(int i=0; i<teamYesAnswers.Length; i++)
        {
            total += teamYesAnswers[i];
        }
        Console.WriteLine(total);
    }
    
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Team> teams = new Dictionary<string, Team>(); 


            string input = Console.ReadLine();
            while (input != "END")
            {
                try
                {
                    string[] inputInfo = input.Split(';');
                    string name = inputInfo[1];
                    if (inputInfo[0] == "Team")
                    {

                        if (!teams.ContainsKey(name))
                        {
                            Team team = new Team(name);
                            teams.Add(name, team);
                        }
                        else
                        {
                            input = Console.ReadLine();
                            continue;
                        }
                    }
                    if (inputInfo[0] == "Add")
                    {
                        string namePl = inputInfo[2];
                        int endurance = int.Parse(inputInfo[3]);
                        int sprint = int.Parse(inputInfo[4]);
                        int dribble = int.Parse(inputInfo[5]);
                        int passing = int.Parse(inputInfo[6]);
                        int shooting = int.Parse(inputInfo[7]);


                        if (!teams.ContainsKey(name))
                        {
                            Console.WriteLine($"Team {name} does not exist.");

                            input = Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            Player player = new Player(namePl, endurance, sprint, dribble, passing, shooting);
                            teams[name].AddPlayer(player);
                        }

                    }
                    if (inputInfo[0] == "Remove")
                    {
                        if (!teams.ContainsKey(name))
                        {
                            Console.WriteLine($"Team {name} does not exist.");

                            input = Console.ReadLine();
                            continue;
                        }  


                        string namePl = inputInfo[2];

                        bool removed =  teams[name].RemovePlayer(namePl);
                        if (!removed)
                        {
                            Console.WriteLine($"Player {namePl} is not in {name} team.");
                            input = Console.ReadLine();
                            continue;

                        }
                    }
                    if (inputInfo[0] == "Rating")
                    {
                        if (!teams.ContainsKey(name))
                        {
                            Console.WriteLine($"Team {name} does not exist.");

                            input = Console.ReadLine();
                            continue;
                        }

                       
                            Console.WriteLine($"{name} - {teams[name].Stats}");
                       

                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}

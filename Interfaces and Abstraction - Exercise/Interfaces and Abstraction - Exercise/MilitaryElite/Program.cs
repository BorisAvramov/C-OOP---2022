using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ISoldier myPrivate = new Private(1, "Boris", "Avramov", 2000);
            //ISoldier spy = new Spy(1, "Boris", "Avramov", 007);
            //Console.WriteLine(myPrivate);
            //Console.WriteLine();
            //Console.WriteLine(spy);

            //List<IPrivate> privates = new List<IPrivate>();
            List<ISoldier> soldiers = new List<ISoldier>();

            string input = Console.ReadLine();
            while (input != "End")
            {

                string[] stringElements = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(stringElements[1]);
                string firstName = stringElements[2];
                string lastName = stringElements[3];


                if (stringElements[0] == "Spy")
                {
                    
                    int codeNumber = int.Parse(stringElements[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(spy);
                }
                //Private<id> < firstName > < lastName > < salary > "

                decimal salary = decimal.Parse(stringElements[4]);

                if (stringElements[0] == "Private")
                {
                    

                    IPrivate @Private = new Private(id, firstName, lastName, salary);

                    //privates.Add(@Private);
                    soldiers.Add(@Private);
                }
                if (stringElements[0] == "LieutenantGeneral")
                {
                    ILieutenantGeneral lietenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
                    if (stringElements.Length > 5)
                    {
                        for (int i = 5; i < stringElements.Length; i++)
                        {
                            int privateId = int.Parse(stringElements[i]);

                           
                            if (soldiers.Any(p => p.Id == privateId))
                            {
                                IPrivate @Private = soldiers.FirstOrDefault(p => p.Id == privateId) as IPrivate;
                                lietenantGeneral.Privates.Add(@Private);
                                
                            }

                        }
                    }
                    soldiers.Add(lietenantGeneral);

                    
                }
                if (stringElements[0] == "Engineer")
                {
                    string corp = stringElements[5];
                      bool isValidEnum = Enum.TryParse(corp, out Corps result);
                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;

                    }
                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, result);
                    if (stringElements.Length > 5)
                    {
                        for (int i = 6; i < stringElements.Length; i+=2)
                        {
                            string repairPart = stringElements[i];
                            int repairHours = int.Parse(stringElements[i + 1]);

                            IRepair repair = new Repair(repairPart, repairHours);
                            engineer.Repairs.Add(repair);

                            
                            

                        }
                    }

                    soldiers.Add (engineer);
                }
                if (stringElements[0] == "Commando")
                {
                    string corp = stringElements[5];
                    bool isValidEnum = Enum.TryParse(corp, out Corps result);
                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;

                    }
                    ICommando commando = new Commando(id, firstName, lastName, salary, result);
                    if (stringElements.Length > 5)
                    {
                        for (int i = 6; i < stringElements.Length; i += 2)
                        {
                            string missionCodeName = stringElements[i];
                            string missionState = stringElements[i + 1];

                            bool IsValidStateMission = Enum.TryParse(missionState, out State result2);

                            if (!IsValidStateMission)
                            {
                                
                                continue;
                            }
                            
                            IMission mission = new Mission(missionCodeName, result2);
                            if (mission.State.ToString() == "inProgress")
                            {
                                commando.Missions.Add(mission);
                            }
                            

                        }
                    }
                    soldiers.Add(commando);
                }



                
                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
           
        }
    }
}

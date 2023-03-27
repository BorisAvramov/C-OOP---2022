using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Workshops.Contracts;
using Easter.Models.Workshops;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly BunnyRepository bunnies ;
        private readonly EggRepository eggs;
        private readonly IWorkshop workshop;


        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
            workshop = new Workshop();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType == "HappyBunny" || bunnyType == "SleepyBunny")
            {
                IBunny bunny = null;
                if (bunnyType == "HappyBunny")
                {
                    bunny = new HappyBunny(bunnyName);
                }
                else
                {
                    bunny = new SleepyBunny(bunnyName);
                }

                bunnies.Add(bunny);

                return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);

            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }


        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            IDye dye = new Dye(power);

            bunny.AddDye(dye);
            return String.Format(OutputMessages.DyeAdded, power, bunnyName);

        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            eggs.Add(egg);

            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> selectedBunnies = bunnies.Models.Where(b => b.Energy >= 50).OrderByDescending(b=>b.Energy).ToList();

            if (selectedBunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }



            IEgg egg = eggs.FindByName(eggName);

            foreach (var bunny in selectedBunnies)
            {

                workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }

                if (egg.IsDone())
                {
                    break;
                }

            }

            return $"Egg {eggName} is {(egg.IsDone() ? "done" : "not done")}.";
                


            //IEgg egg = eggs.FindByName(eggName);

            //if (!bunnies.Models.Any(b=>b.Energy >= 50))
            //{
            //    throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            //}



            //while (bunnies.Models.Any(b => b.Energy >= 50))
            //{
            //    IBunny maxBunny = null;
            //    int maxEnergy = 50;



            //    foreach (var item in bunnies.Models)
            //    {


            //        if (item.Energy >= maxEnergy && item.Dyes.Sum(s=>s.Power) > 0  )
            //        {        

            //            maxBunny = item;
            //            maxEnergy = item.Energy;

            //        }

            //    }
            //    int maxDues = maxBunny.Dyes.Sum(d => d.Power);
            //    foreach (var item in bunnies.Models)
            //    {
            //        int curBdyePower = item.Dyes.Sum(d => d.Power);

            //        if (maxBunny != item && item.Energy >= maxBunny.Energy && maxDues > 0 && curBdyePower > maxDues )
            //        {
            //            maxBunny = item;
            //            maxDues = curBdyePower;
            //        }

            //    }


            //    workshop.Color(egg, maxBunny);
            //    if (maxBunny.Energy == 0)
            //    {
            //        bunnies.Remove(maxBunny);
            //    }

            //    if (egg.IsDone())
            //    {
            //        break;
            //    }
            //    if (!maxBunny.Dyes.Any())
            //    {
            //        break;
            //    }

            //}

            //if (egg.IsDone())
            //{
            //    return String.Format(OutputMessages.EggIsDone, eggName);
            //}
            //else
            //{
            //    return String.Format(OutputMessages.EggIsNotDone, eggName);
            //}



        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();

            int countEggs = eggs.Models.Count(x => x.IsDone());

            sb.AppendLine($"{countEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var item in bunnies.Models)
            {
               
                sb.AppendLine($"Name: {item.Name}");
                sb.AppendLine($"Energy: {item.Energy}");
                sb.AppendLine($"Dyes {item.Dyes.Count} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

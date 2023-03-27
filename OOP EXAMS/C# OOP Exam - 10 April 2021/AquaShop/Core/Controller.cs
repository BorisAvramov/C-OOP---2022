using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {

        private DecorationRepository decorations;
        private List<IAquarium> aquariums;


        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }



        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            IAquarium aquarium = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";

        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            IDecoration decoration = null;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }

            decorations.Add(decoration);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);

            }

            

            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            IFish fish = null;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
                if (aquarium.GetType().Name == "FreshwaterAquarium")
                {
                    aquarium.AddFish(fish);
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
                else
                {
                    return $"Water not suitable";
                }
            }
            else
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
                if (aquarium.GetType().Name == "SaltwaterAquarium")
                {
                    aquarium.AddFish(fish);
                    return $"Successfully added {fishType} to {aquariumName}.";

                }
                else
                {
                    return $"Water not suitable";
                }


            }


        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal sumFishPrices = aquarium.Fish.Sum(f => f.Price);
            decimal sumDecorationPrices = aquarium.Decorations.Sum(d => d.Price);

            decimal total = sumFishPrices + sumDecorationPrices;

            return $"The value of Aquarium {aquariumName} is {decimal.Round(total, 2)}.";

            throw new NotImplementedException();
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();

            }

            return $"Fish fed: {aquarium.Fish.Count}";


        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquarium.Decorations.Add(decoration);
            decorations.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";

        }

        public string Report()
        {


            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();

        }
    }
}

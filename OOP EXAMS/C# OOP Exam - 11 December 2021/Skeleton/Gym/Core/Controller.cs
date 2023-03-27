using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Equipment;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipmentRepository;
        private ICollection<IGym> gyms;


        public Controller()
        {
            equipmentRepository = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            string gymType = gym.GetType().Name;

            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            else if ((athleteType == "Boxer" && gymType == "WeightliftingGym") 
                || (athleteType == "Weightlifter" && gymType == "BoxingGym"))
            {
                return OutputMessages.InappropriateGym;
            }
            else
            {
                if (athleteType == "Boxer")
                {
                    gym.AddAthlete(new Boxer(athleteName, motivation, numberOfMedals));
                }
                else if (athleteType == "Weightlifter")
                {
                    gym.AddAthlete(new Weightlifter(athleteName, motivation, numberOfMedals));
                }

                return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);

            }


            
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                equipmentRepository.Add(new BoxingGloves());
            }
            else if (equipmentType == "Kettlebell")
            {
                equipmentRepository.Add(new Kettlebell());

            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                gyms.Add(new BoxingGym(gymName));
            }
            else if (gymType == "WeightliftingGym")
            {
                gyms.Add(new WeightliftingGym(gymName));

            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            return String.Format(OutputMessages.SuccessfullyAdded, gymType);

        }  

        public string EquipmentWeight(string gymName)
        {
            var eqWeight = gyms.FirstOrDefault(g => g.Name == gymName).EquipmentWeight;

            return $"The total weight of the equipment in the gym {gymName} is {eqWeight:f2} grams.";

          
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            if (equipmentRepository.FindByType(equipmentType) != null)
            {
                gyms.First(g => g.Name == gymName).AddEquipment(equipmentRepository.FindByType(equipmentType));
                equipmentRepository.Remove(equipmentRepository.FindByType(equipmentType));
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            return String.Format (OutputMessages.EntityAddedToGym, equipmentType, gymName);
           
        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();
            foreach (var item in gyms)
            {
                sb.AppendLine(item.GymInfo());

            }
            return sb.ToString().TrimEnd();

        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);

            foreach (var item in gym.Athletes)
            {
                item.Exercise();
            }

            return String.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}

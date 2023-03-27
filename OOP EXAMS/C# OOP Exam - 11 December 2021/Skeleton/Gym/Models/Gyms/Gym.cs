using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        

        public Gym(string name, int capacity)
        { 
            Name = name;
            Capacity = capacity;
            Athletes = new List<IAthlete>();
            Equipment = new List<IEquipment>();
         }

        public string Name 
        {
            get {return name; }
           private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            
            }

        }

        public int Capacity { get; private set;}  

        //!!!!!!
        public double EquipmentWeight => Equipment.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment { get;}

        public ICollection<IAthlete> Athletes { get;}

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity <= Athletes.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            Athletes.Add(athlete);

        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athl in Athletes)
            {
                athl.Exercise();
            }
        }

        public string GymInfo()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{name} is a {this.GetType().Name}:");
            if (!Athletes.Any())
            {
                sb.AppendLine("Athletes: No athletes");
            }
            else
            {
                sb.AppendLine($"Athletes: {string.Join(", ", Athletes.Select(a => a.FullName))}");
            }
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
            //"{gymName} is a {gymType}:
            //Athletes: { athleteName1}, { athleteName2}, { athleteName3} (…) / No athletes
            //Equipment total count: { equipmentCount}
            //Equipment total weight: { equipmentWeight}
            //grams"

        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }


        
    }
}

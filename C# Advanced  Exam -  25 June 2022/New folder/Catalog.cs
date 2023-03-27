using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public int Count => renovators.Count;

        //•	string AddRenovator(Renovator renovator) - adds a renovator to the catalog's collection, if renovators are still needed. Before adding a renovator, check:

        public string AddRenovator(Renovator renovator)
        {

            if (NeededRenovators > renovators.Count)
            {
                if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
                {
                    return "Invalid renovator's information.";
                }
                if (renovator.Rate > 350)
                {
                    return "Invalid renovator's rate.";
                }

                renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";


            }


            return "Renovators are no more needed.";
            

          
        }

        //•	bool RemoveRenovator(string name) - removes a renovator by given name.

        public bool RemoveRenovator(string name)
        {

            return renovators.Remove(renovators.FirstOrDefault(r => r.Name == name));

            
        }

        //•	int RemoveRenovatorBySpecialty(string type) - removes all renovators by the given specialty.

        public int RemoveRenovatorBySpecialty(string type) 
        {
            int countRemoved = 0;

            for (int i = renovators.Count - 1; i >= 0; i--)
            {
                if (renovators[i].Type == type)
                {
                    renovators.Remove(renovators[i]);
                    countRemoved++;
                }


            }

                
            

            //foreach (var ren in renovators)
            //{
            //    if (ren.Type == type)
            //    {
            //        countRemoved++;

                    
            //    }


            //}
            //renovators.RemoveAll(r => r.Type == type);

            if (countRemoved > 0)
            {
                return countRemoved;
            }
            else
            {
                return 0;
            }

            
        }

        //•	Renovator HireRenovator(string name) 

        public Renovator HireRenovator(string name) 
        {
            Renovator renovator = null;

            if (renovators.Any(r => r.Name == name))
            {
                renovator = renovators.FirstOrDefault(r => r.Name == name);
                renovator.Hired = true;

            }



            return renovator;
        
        }
        //•	List<Renovator> PayRenovators (int days) method – return a list with all renovators that have been working for days days or more.

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> list = new List<Renovator>();

            foreach (var ren in renovators)
            {
                if (ren.Days >= days)
                {
                    list.Add(ren);
                }
            }

           
            return list;

        }
        //•	Report() 
        public string Report()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (var ren in renovators)
            {
                if (ren.Hired == false)
                {
                    sb.AppendLine(ren.ToString());
                }
                

            }

            return sb.ToString().TrimEnd();
        }


    }
}

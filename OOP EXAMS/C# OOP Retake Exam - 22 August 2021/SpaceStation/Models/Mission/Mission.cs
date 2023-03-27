using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {

        public Mission()
        {

        }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> list = planet.Items.Reverse().ToList();

            foreach (var astronaut in astronauts)
            {



                for (int i = list.Count - 1; i >= 0; i--)
                {
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(list[i]);
                    list.Remove(list[i]);
                    if (astronaut.Oxygen <= 0)
                    {
                        break;
                    }

                }


                    //foreach (var item in list)
                    //{
                        
                    //    astronaut.Breath();
                    //    astronaut.Bag.Items.Add(item);
                    //    list.Remove(item);
                    //    if (astronaut.Oxygen <= 0)
                    //    {
                    //        break;
                    //    }

                    //}

                    

            }


        }
    }
}

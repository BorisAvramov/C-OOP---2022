using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {

        public void Color(IEgg egg, IBunny bunny)
        {
            while (true)
            {
                if (bunny.Energy == 0)
                {
                    break;
                }
                if (bunny.Dyes.Count == 0)
                {
                    break;
                }

                if (egg.IsDone())
                { 
                    break;
                }

                IDye dye = bunny.Dyes.First();
                dye.Use();

                if (dye.IsFinished())
                {
                    bunny.Dyes.Remove(dye);
                    
                }
                egg.GetColored();
                bunny.Work();
               



            }

            //if (bunny.Energy > 0 && bunny.Dyes.Any())
            //{


            //    while (!egg.IsDone() && bunny.Energy > 0 /*&& bunny.Dyes.Any(d => d.Power > 0))*/)
            //    {
            //        if (bunny.Dyes.Count == 0)
            //        {
            //            break;
            //        }

            //        IDye dye = bunny.Dyes.FirstOrDefault();
            //        dye.Use();

            //        if (dye.Power == 0)
            //        {
            //            bunny.Dyes.Remove(dye);



            //        }

            //        bunny.Work();

            //        egg.GetColored();



            //    }



            //}



        }
    }
}

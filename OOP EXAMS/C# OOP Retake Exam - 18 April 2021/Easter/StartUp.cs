namespace Easter
{
    using Core;
    using Core.Contracts;
    using Easter.Models.Bunnies;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes;
    using Easter.Models.Dyes.Contracts;
    using Easter.Models.Eggs;
    using Easter.Models.Eggs.Contracts;
    using Easter.Models.Workshops;
    using Easter.Models.Workshops.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            // Don't forget to uncomment Controller class in the Engine!
            IEngine engine = new Engine();
            engine.Run();



            //IBunny bunny = new SleepyBunny("suzi");

            //bunny.Work();

            //IDye dye = new Dye(5);

            //IDye dye2 = new Dye(0);

            //IBunny bunny = new HappyBunny("Suzi");
            //IBunny bunny2 = new SleepyBunny("Bobi");


            //bunny.AddDye(dye);
            //bunny.AddDye(dye2);

            //IWorkshop workshop = new Workshop();

            //IEgg egg = new Egg("red", 20);

            //workshop.Color(egg,bunny);

        }
    }
}

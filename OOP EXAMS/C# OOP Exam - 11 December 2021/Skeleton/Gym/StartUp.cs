namespace Gym
{
    using Gym.Core;
    using Gym.Core.Contracts;

    using Gym.Models.Athletes;
    using Gym.Models.Equipment;
    using Gym.Models.Gyms;

    public class StartUp
    {
        public static void Main()
        {
            
            //BoxingGym gym = new BoxingGym("Box");
            //gym.AddAthlete(new Boxer("Pulev", "strong", 2));
            //gym.AddEquipment(new BoxingGloves());
            //Weightlifter weightlifter = new Weightlifter("Pesho", "beguinner", 0);
            //gym.AddAthlete(weightlifter);
            //gym.Exercise();
            //gym.RemoveAthlete(weightlifter);    
            //gym.AddAthlete(new Boxer("chisora", "max", 2));
            //gym.AddEquipment(new BoxingGloves());
            //System.Console.WriteLine(gym.GymInfo());


            //return;

            // Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();


           
        }
    }
}

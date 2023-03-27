namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle myVec = new Vehicle(150, 70);

            myVec.Drive(10);

            System.Console.WriteLine(myVec.Fuel);


            CrossMotorcycle cross = new CrossMotorcycle(150, 70);

            cross.Drive(10);
            System.Console.WriteLine(cross.Fuel);


            RaceMotorcycle race = new RaceMotorcycle(150, 70);

            race.Drive(5);
            System.Console.WriteLine(race.Fuel);
        }
    }
}

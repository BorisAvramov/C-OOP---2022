using System;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Box myBox = new Box(length, width, height);
                Console.WriteLine($"Surface Area - {myBox.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {myBox.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {myBox.Volume():f2}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



           

        }
    }
}

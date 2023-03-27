namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero = new Hero("borko", 6);
            System.Console.WriteLine(hero.ToString());

            DarkKnight myKnight = new DarkKnight("Sofi", 10);

            System.Console.WriteLine(myKnight);
        }
    }
}
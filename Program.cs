using TestovoeLesta.Weapons;

namespace TestovoeLesta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Game game = new Game();
                game.GameLoop();
            }
        }
    }
}

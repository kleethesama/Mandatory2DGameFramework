using Mandatory2DGameFramework.GameManagement;
using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.Worlds;
using System.Diagnostics;

namespace ExampleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLogger.Instance.AddListener(new ConsoleTraceListener());

            GameManager.DefaultSetup();
            Console.WriteLine(WorldManager.Instance.CurrentWorld);

            Console.WriteLine(GameDifficulty.Instance);

            GameManager.NextTurn();
            Console.WriteLine(GameManager.TurnCount);
        }
    }
}

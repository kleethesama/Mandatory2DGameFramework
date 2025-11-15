using Mandatory2DGameFramework.Config;
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
            TraceListener listener = new ConsoleTraceListener
            {
                Name = "ConfigManagerListener",
                Filter = new EventTypeFilter(SourceLevels.All)
            };
            MyLogger.Instance.AddListener(nameof(ConfigManager), listener);

            GameManager.DefaultSetup();

            Console.WriteLine(WorldManager.Instance.CurrentWorld);

            Console.WriteLine(GameDifficulty.Instance);

            GameManager.NextTurn();
            Console.WriteLine(GameManager.TurnCount);
        }
    }
}

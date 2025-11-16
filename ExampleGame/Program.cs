using ExampleGame.Factory;
using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.GameManagement;
using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.Model.Creatures;
using Mandatory2DGameFramework.Worlds;
using System.Diagnostics;

namespace ExampleGame;

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

        var factory = new BirdFactory(WorldManager.Instance.CurrentWorld);
        List<Creature> creatures = factory.CreateRandoms(5);
        foreach (Creature creature in creatures)
        {
            Console.WriteLine(creature);
        }
    }
}

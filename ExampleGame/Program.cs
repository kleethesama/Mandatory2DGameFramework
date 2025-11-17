using ExampleGame.Factory;
using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.GameManagement;
using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.Model.Creatures;
using Mandatory2DGameFramework.Model.Items.Defence;
using Mandatory2DGameFramework.Model.Items.Defence.Component;
using Mandatory2DGameFramework.Model.Items.Defence.ComponentImplementation;
using Mandatory2DGameFramework.Model.Items.Defence.Decorators;
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
        //MyLogger.Instance.AddListener(nameof(ConfigManager), listener);

        GameManager.DefaultSetup();

        //Console.WriteLine(WorldManager.Instance.CurrentWorld);

        //Console.WriteLine(GameDifficulty.Instance);

        var factory = new BirdFactory(WorldManager.Instance.CurrentWorld);
        List<Creature> creatures = factory.CreateRandoms(5);
        //foreach (Creature creature in creatures)
        //{
        //    Console.WriteLine(creature);
        //}

        DefenceItem ringDefence = new(5, 0, "Ring");
        AddDefence additionBuff = new();
        //ringDefence.ApplyBuff(additionBuff, 10);
        //Console.WriteLine(ringDefence);

        SuperDefenceBuff DoubleBuffAdded = new(additionBuff);
        ringDefence.ApplyBuff(DoubleBuffAdded, 10);
        Console.WriteLine(ringDefence);

        FragileDefenceDebuff halfDefenceDebuff = new(additionBuff);
        ringDefence.ApplyBuff(halfDefenceDebuff, ringDefence.ReduceHitPoint);
        Console.WriteLine(ringDefence);
    }
}

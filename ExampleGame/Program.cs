using ExampleGame.Factory;
using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.GameManagement;
using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.Model.Creatures;
using Mandatory2DGameFramework.Model.Items.Attack;
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
        MyLogger.Instance.AddListener(nameof(Creature), listener);

        GameManager.DefaultSetup();

        //Console.WriteLine(WorldManager.Instance.CurrentWorld);

        //Console.WriteLine(GameDifficulty.Instance);

        var factory = new BirdFactory(WorldManager.Instance.CurrentWorld);
        List<Creature> creatures = factory.CreateRandoms(5);
        //foreach (Creature creature in creatures)
        //{
        //    Console.WriteLine(creature);
        //}

        Creature coolBird = creatures[0];
        Creature badBird = creatures[1];

        DefenceItem ringDefence = new(5, 0, "Cool Ring"); // Take less damage because it's cool.
        AddDefence addBuff = new();
        ringDefence.ApplyBuff(addBuff, 10);
        Console.WriteLine(ringDefence);

        coolBird.AddDefenceItem(ringDefence);

        AttackItem attackItem = new(20, 1, 1, "Sharp Claws");
        badBird.AddAttackItem(attackItem);

        // Move bad bird next to cool bird.
        badBird.MoveRange = int.MaxValue;
        badBird.Move(coolBird.Position - badBird.Position + new WorldPosition(1, 0));
        Console.WriteLine($"Cool bird world position: {coolBird.Position}");
        Console.WriteLine($"Bad bird world position: {badBird.Position}");

        Console.WriteLine($"Cool bird start hitpoints: {coolBird.HitPoint}");
        //Console.WriteLine($"Bad bird start hitpoints: {badBird.HitPoint}");

        // Bad bird gets notified if cool bird receieves a hit.
        coolBird.Attach(badBird);

        // Bad bird attacks the cool bird (not a cool move).
        badBird.Hit(coolBird);
        Console.WriteLine($"Cool bird now has hitpoints: {coolBird.HitPoint}");

        SuperDefenceBuff DoubleBuffAdded = new(addBuff);
        ringDefence.ApplyBuff(DoubleBuffAdded, 3);
        Console.WriteLine(ringDefence);

        badBird.Hit(coolBird);
        Console.WriteLine($"Cool bird now has hitpoints: {coolBird.HitPoint}");
        Console.WriteLine($"Cool bird is dead: {coolBird.IsDead()}");

        FragileDefenceDebuff halfDefenceDebuff = new(addBuff);
        ringDefence.ApplyBuff(halfDefenceDebuff, ringDefence.ReduceHitPoint); // Something happened that made them half as cool.
        //Console.WriteLine(ringDefence);


    }
}

using Mandatory2DGameFramework.GameManagement;
using Mandatory2DGameFramework.Worlds;

namespace ExampleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager.DefaultStart();
            Console.WriteLine(WorldManager.Instance.CurrentWorld);
        }
    }
}

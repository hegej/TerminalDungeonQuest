using DungeonGameLogic;
using DungeonGameLogic.Characters;
using DungeonGameSimulator;

internal class Program
{
    private static void Main(string[] args)
    {
        var simulator = new BattleSimulator();
        simulator.RunSimulation();

        Console.WriteLine("Simulation complete. Logs saved to battle_logs.json");

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}
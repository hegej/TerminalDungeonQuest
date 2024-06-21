using DungeonGameLogic;
using DungeonGameLogic.Characters;
using DungeonGameSimulator;

internal class Program
{
    private static void Main(string[] args)
    {
        GameEngine gameEngine = new GameEngine();

        gameEngine.StartGame();

        var simulator = new BattleSimulator();
        simulator.RunSimulation();
        Console.WriteLine("Simulation complete. Logs saved to battle_logs.json");
    }
}
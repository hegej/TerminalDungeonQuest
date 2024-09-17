using DungeonGameLogic.Enums;
using DungeonGameSimulator;
using DungeonGameSimulator.Utilities;
using Spectre.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        GameConsole.Initialize();
        DisplayStartPage();

        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                RunSimulation();
                break;
            }
        }
    }

    private static void DisplayStartPage()
    {
        GameConsole.DisplayStartPage();
        AnsiConsole.WriteLine("\nPress Enter to start the game simulation");
        AnsiConsole.WriteLine("\nPress 'CTRL+C' to quit");
    }

    private static void RunSimulation()
    {
        Console.Clear();
        SimulationSpeed speed = GetSimulationSpeed();
        var simulator = new BattleSimulator();
        simulator.RunSimulation(speed: speed);

        Logger.LogAction("Simulation complete. Logs saved to battle_logs.json", LogType.Normal, "");

        AnsiConsole.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    private static SimulationSpeed GetSimulationSpeed()
    {
        while (true)
        {
            AnsiConsole.WriteLine("Select Simulation speed:");
            AnsiConsole.WriteLine("1. Fast (0.1 seconds per action)");
            AnsiConsole.WriteLine("2. Slow (1.0 seconds per action)");
            AnsiConsole.WriteLine("3. Manual (press Enter for each action)");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1: return SimulationSpeed.Fast;
                    case 2: return SimulationSpeed.Slow;
                    case 3: return SimulationSpeed.Manual;
                    default:
                        AnsiConsole.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
            else
            {
                AnsiConsole.WriteLine("Invalid input. Enter a number (1-3).");
            }
        }
    }
}
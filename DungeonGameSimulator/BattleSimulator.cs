using DungeonGameLogic;
using DungeonGameLogic.Enums;
using Spectre.Console;

namespace DungeonGameSimulator
{
    public class BattleSimulator
    {

        public BattleSimulator()
        {
        }

        public void RunSimulation(int numberOfSimulations = 5, SimulationSpeed speed = SimulationSpeed.Fast)
        {
            var gameEngine = new GameEngine();
            var simulationResults = new List<string>();
            for (var i = 1; i <= numberOfSimulations; i++)
            {
                Logger.LogAction($"Simulation {i} starting.", LogType.Normal, "");
                try
                {
                    var teams = new List<Team>
            {
                gameEngine.CreateTeam($"Red Team{i}", isEnemy: true),
                gameEngine.CreateTeam($"Blue Team{i}", isEnemy: false)
            };
                    var battleEngine = new BattleEngine(teams, speed);
                    battleEngine.SimulateBattle();
                    var result = ($"Simulation {i} completed.\nWinner is: {DetermineWinner(teams)}");
                    Logger.LogAction(result, LogType.Normal, "");
                    simulationResults.Add(result);
                }
                catch (Exception ex)
                {
                    var errorMessage = $"Error in simulation {i}: {ex.Message}";
                    Logger.LogAction(errorMessage, LogType.Critical, "Error");
                    simulationResults.Add(errorMessage);
                }
                if (speed != SimulationSpeed.Manual)
                {
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Press Enter to start the next simulation");
                    Console.ReadLine();
                }
            }
            DisplaySimulationResults(simulationResults);
        }

        private string DetermineWinner(List<Team> teams)
        {
            foreach (var team in teams)
            {
                if (team.AliveMembers())
                {
                    return team.Name;
                }
            }
            return "No winner (Draw)";
        }

        private void DisplaySimulationResults(List<string> results)
        {
            AnsiConsole.Write(new Rule("[yellow]Simulation Results[/]").RuleStyle(Style.Parse("yellow")).DoubleBorder());

            var table = new Table().Border(TableBorder.Rounded);
            table.AddColumn("Simulation");
            table.AddColumn("Winner");

            for (var i = 0; i < results.Count; i++)
            {
                var result = results[i];
                var winner = result.Split('\n').Last().Trim();
                var coloredWinner = winner.Contains("Red Team") ? $"[red]{winner}[/]" : $"[blue]{winner}[/]";
                table.AddRow($"Simulation {i + 1}", coloredWinner);
            }

            AnsiConsole.Write(table);

            var redWins = results.Count(r => r.Contains("Red Team"));
            var blueWins = results.Count(r => r.Contains("Blue Team"));
            var draws = results.Count - redWins - blueWins;

            var summaryPanel = new Panel(
                Align.Center(
                    new Rows(
                        new Text("Summary"),
                        new BreakdownChart()
                            .Width(60)
                            .AddItem("Red Team", redWins, Color.Red)
                            .AddItem("Blue Team", blueWins, Color.Blue)
                            .AddItem("Draws", draws, Color.Grey)
                    )
                )
            )
            {
                Border = BoxBorder.Rounded,
                Expand = false
            };

            AnsiConsole.Write(summaryPanel);

            AnsiConsole.Write(new Rule());

            AnsiConsole.Write(new BarChart()
                .Width(60)
                .Label("[green]Win Rates[/]")
                .CenterLabel()
                .AddItem("Red Team", (double)redWins / results.Count * 100, Color.Red)
                .AddItem("Blue Team", (double)blueWins / results.Count * 100, Color.Blue));

            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Panel("Simulation complete. Logs saved to battle_logs.json")
                .BorderColor(Color.Green));

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }
    }
}
using DungeonGameLogic;

namespace DungeonGameSimulator
{
    public class BattleSimulator
    {

        public void RunSimulation(int numberOfSimulations = 10)
        {
            var gameEngine = new GameEngine();
            var simulationResults = new List<string>();

            for (var i = 1; i <= numberOfSimulations; i++)
            {
                BattleLogger.Log($"Simulation {i} starting.");
                try
                {
                    var teams = new List<Team>
                {
                    gameEngine.CreateTeam($"Red Team{i}", isEnemy: true),
                    gameEngine.CreateTeam($"Blue Team{i}", isEnemy: false)
                };

                    var battleEngine = new BattleEngine(teams);

                    battleEngine.SimulateBattle(teams);
                    string result = ($"Simulation {i} completed.\n Winner is: {DetermineWinner(teams)}");
                    BattleLogger.Log(result);
                    simulationResults.Add(result);
                }
                catch (Exception ex)
                {
                    string errorMessage = $"Error in simulation {i}: {ex.Message}";
                    BattleLogger.Log(errorMessage);
                    simulationResults.Add(errorMessage);
                }

                System.Threading.Thread.Sleep(2000);
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
            Console.WriteLine("\nSimulation Results:");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            int redWins = results.Count(r => r.Contains("Red Team"));
            int blueWins = results.Count(r => r.Contains("Blue Team"));
            int draws = results.Count - redWins - blueWins;

            Console.WriteLine($"\nRed Team Wins: {redWins}");
            Console.WriteLine($"\nBlue Team Wins: {blueWins}");
            Console.WriteLine($"\nDraws: {draws}");
            Console.WriteLine($"\nRed Team Win Rate: {(double)redWins / results.Count:P2}");
            Console.WriteLine($"\nBlue Team Win Rate: {(double)blueWins / results.Count:P2}");
        }
    }
}
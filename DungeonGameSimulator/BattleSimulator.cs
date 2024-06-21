using DungeonGameLogic;
using System.Text.Json;

namespace DungeonGameSimulator
{
    public class BattleSimulator
    { 

        public void RunSimulation()
        {
            var gameEngine = new GameEngine();
            var battleEngine = new BattleEngine();

            for (int i = 1; i <= 1; i++)
            {
                BattleLogger.Log($"Simulation {i} starting.");
                var teams = new List<Team>
                {
                    gameEngine.CreateTeam("Red Team", isEnemy: true),
                    gameEngine.CreateTeam("Blue Team", isEnemy: false)
                };

                battleEngine.SimulateBattle(teams);

                BattleLogger.Log($"Simulation {i} completed.");
            }
        }  
    }
}
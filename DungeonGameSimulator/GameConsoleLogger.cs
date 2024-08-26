using DungeonGameLogic;
using DungeonGameLogic.Characters;
using DungeonGameLogic.Enums;
using DungeonGameLogic.Interfaces;
using DungeonGameSimulator.Utilities;
using Spectre.Console;

namespace DungeonGameSimulator
{
    public class GameConsoleLogger : IBattleLogger
    {
        public void LogBattleStart()
        {
            GameConsole.LogBattleStart();
        }

        public void LogBattleEnd(string winner)
        {
            GameConsole.LogBattleEnd(winner);
        }

        public void LogAction(string message, LogType type, string action)
        {
            GameConsole.LogAction(message, type, action);
        }

        public void DisplayCharacterStats(DungeonGameLogic.Characters.Character character)
        {
            GameConsole.DisplayCharacterStats(character);
        }

        public void DisplayTeamStats(DungeonGameLogic.Team team)
        {
            GameConsole.DisplayTeamStats(team);
        }
    }
}
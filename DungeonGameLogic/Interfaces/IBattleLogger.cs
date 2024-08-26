using DungeonGameLogic.Characters;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Interfaces
{
    public interface IBattleLogger
    {
        void LogBattleStart();
        void LogBattleEnd(string winner);
        void LogAction(string message, LogType type, string action);
        void DisplayCharacterStats(Character character);
        void DisplayTeamStats(Team team);
    }
}

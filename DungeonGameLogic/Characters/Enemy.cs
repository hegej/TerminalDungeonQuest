using DungeonGameLogic.Characters.CharacterParameters;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters
{
    public class Enemy : Character
    {
        public int Mana { get; private set; }
        public double ManaRegen { get; private set; }
        public EnemyType EnemyType { get; private set; }

        public Enemy(EnemyParameters parameters) : base(parameters)
        {
            EnemyType = parameters.EnemyType;
        }
    }
}
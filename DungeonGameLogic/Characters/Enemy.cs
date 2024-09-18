using DungeonGameLogic.Characters.CharacterParameters;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters
{
    public class Enemy : Character
    {
        public int Mana { get; set; }
        public int InitialMana { get; set; }
        public double ManaRegen { get; set; }
        public EnemyType EnemyType { get; set; }
        public EnemyParameters enemyParameters { get; set; }

        public Enemy(EnemyParameters enemyParameters) : base(enemyParameters)
        {
            this.enemyParameters = enemyParameters;

            EnemyType = enemyParameters.EnemyType;
            Mana = enemyParameters.Mana;
            InitialMana = enemyParameters.Mana;
            ManaRegen = enemyParameters.ManaRegen;
        }
    }
}
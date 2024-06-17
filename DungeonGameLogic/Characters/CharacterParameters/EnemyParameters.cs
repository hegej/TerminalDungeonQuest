using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;


namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class EnemyParameters : BaseCharacterParameters
    {
        public int Mana { get; private set; }
        public double ManaRegen { get; private set; }
        public EnemyType EnemyType { get; set; }

        public EnemyParameters(string name, EnemyType type)
        {
            Name = name;
            EnemyType = type;
            InitializeDefaultValues(type);
        }

        private void InitializeDefaultValues(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Mage:
                    Level = 1;
                    Health = 60; 
                    Mana = 80;
                    ManaRegen = 1.5;
                    Strength = 8;
                    Defense = 4;
                    ArmorClass = 7;
                    SpecialAbility = new SpecialAbility { Name = "Shadow Bolt" };
                    Speed = 11;
                    THAC0 = 20;
                    break;
                case EnemyType.Hunter:
                    Level = 1;
                    Health = 70;
                    Mana = 0;
                    ManaRegen = 0.0;
                    Strength = 18; 
                    Defense = 13;
                    ArmorClass = 11;
                    SpecialAbility = new SpecialAbility { Name = "Summon Warg" };
                    Speed = 14;
                    THAC0 = 19;
                    break;
                case EnemyType.Warrior:
                    Level = 1;
                    Health = 100;
                    Mana = 0;
                    ManaRegen = 0.0;
                    Strength = 20; 
                    Defense = 18; 
                    ArmorClass = 15;
                    SpecialAbility = new SpecialAbility { Name = "Power Strike" };
                    Speed = 9;
                    THAC0 = 17;
                    break;
                case EnemyType.Rogue:
                    Level = 1;
                    Health = 50;
                    Mana = 0;
                    ManaRegen = 0.0;
                    Strength = 10;
                    Defense = 8;
                    ArmorClass = 10;
                    SpecialAbility = new SpecialAbility { Name = "Stealth Attack" };
                    Speed = 15;
                    THAC0 = 19;
                    break;
                case EnemyType.Paladin:
                    Level = 1;
                    Health = 85;
                    Mana = 80;
                    ManaRegen = 1.0;
                    Strength = 20;
                    Defense = 18;
                    ArmorClass = 18;
                    SpecialAbility = new SpecialAbility { Name = "Tormentor" };
                    Speed = 8;
                    THAC0 = 16;
                    break;
                default:
                    throw new ArgumentException("Invalid enemy type specified.");
            }
        }
    }
}
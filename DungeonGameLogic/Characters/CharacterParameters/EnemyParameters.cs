using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;


namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class EnemyParameters : BaseCharacterParameters
    {
        public int Mana { get; set; }
        public int InitialMana { get; set; }
        public int ManaRegen { get; set; }
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
                    Health = 10; 
                    Mana = 80;
                    InitialMana = Mana;
                    ManaRegen = 2;
                    Strength = 5;
                    Defense = 2;
                    ArmorClass = 7;
                    SpecialAbility = new SpecialAbility { Name = "Shadow Bolt" };
                    Speed = 11;
                    THAC0 = 20;
                    break;
                case EnemyType.Hunter:
                    Level = 1;
                    Health = 10;
                    Strength = 5; 
                    Defense = 2;
                    ArmorClass = 11;
                    SpecialAbility = new SpecialAbility { Name = "Summon Warg" };
                    Speed = 14;
                    THAC0 = 19;
                    break;
                case EnemyType.Warrior:
                    Level = 1;
                    Health = 10;
                    Strength = 5; 
                    Defense = 2; 
                    ArmorClass = 15;
                    SpecialAbility = new SpecialAbility { Name = "Power Strike" };
                    Speed = 9;
                    THAC0 = 17;
                    break;
                case EnemyType.Rogue:
                    Level = 1;
                    Health = 10;
                    Strength = 5;
                    Defense = 2;
                    ArmorClass = 10;
                    SpecialAbility = new SpecialAbility { Name = "Stealth Attack" };
                    Speed = 15;
                    THAC0 = 19;
                    break;
                case EnemyType.Paladin:
                    Level = 1;
                    Health = 10;
                    Mana = 80;
                    InitialMana = Mana;
                    ManaRegen = 1;
                    Strength = 5;
                    Defense = 2;
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
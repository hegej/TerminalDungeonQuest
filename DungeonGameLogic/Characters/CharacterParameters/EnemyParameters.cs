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
        public List<MageSpellPower> Spells { get; set; }

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
                    Health = 8;
                    Mana = 20;
                    InitialMana = Mana;
                    ManaRegen = 2;
                    Strength = 1;
                    ArmorClass = 10;
                    SpecialAbility = new SpecialAbility { Name = "Shadow Bolt" };
                    Initiative = 15;
                    Speed = 11;
                    THAC0 = 20;
                    Spells = InitializeEnemyMageSpells();
                    break;
                case EnemyType.Hunter:
                    Level = 1;
                    Health = 8;
                    Strength = 5;
                    ArmorClass = 8;
                    SpecialAbility = new SpecialAbility { Name = "Summon Warg" };
                    Initiative = 13;
                    Speed = 14;
                    THAC0 = 19;
                    break;
                case EnemyType.Warrior:
                    Level = 1;
                    Health = 10;
                    Strength = 5;
                    ArmorClass = 6;
                    SpecialAbility = new SpecialAbility { Name = "Power Strike" };
                    Initiative = 19;
                    Speed = 9;
                    THAC0 = 17;
                    break;
                case EnemyType.Rogue:
                    Level = 1;
                    Health = 8;
                    Strength = 5;
                    ArmorClass = 7;
                    SpecialAbility = new SpecialAbility { Name = "Stealth Attack" };
                    Initiative = 11;
                    Speed = 15;
                    THAC0 = 19;
                    break;
                case EnemyType.Paladin:
                    Level = 1;
                    Health = 10;
                    Mana = 8;
                    InitialMana = Mana;
                    ManaRegen = 1;
                    Strength = 5;
                    ArmorClass = 5;
                    SpecialAbility = new SpecialAbility { Name = "Tormentor" };
                    Initiative = 17;
                    Speed = 8;
                    THAC0 = 16;
                    break;
                default:
                    throw new ArgumentException("Invalid enemy type specified.");
            }
        }

        private List<MageSpellPower> InitializeEnemyMageSpells()
        {
            return new List<MageSpellPower>
            {
                new MageSpellPower(SpellType.Dark, "Sharp Jolt", spellLevel: 1, effectValue: 4, manaCost: 10),
                new MageSpellPower(SpellType.Dark, "Bleed", spellLevel: 1, effectValue: 4, manaCost:10)
            };
        }

        public MageSpellPower ChooseEnemyMageSpell()
        {
            if (Mana < 10)
            {
                return null;
            }

            return Spells[new Random().Next(Spells.Count)];
        }
    }
}
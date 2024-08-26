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

        private static Random rand = new Random();

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
                    Health = rand.Next(6, 10);
                    Mana = rand.Next(15, 25);
                    InitialMana = Mana;
                    ManaRegen = rand.Next(2, 4);
                    Strength = rand.Next(2, 5);
                    ArmorClass = rand.Next(8, 12);
                    SpecialAbility = new SpecialAbility { Name = "Shadow Bolt" };
                    Initiative = rand.Next(13, 17);
                    Speed = rand.Next(9, 13);
                    THAC0 = 20;
                    Spells = InitializeEnemyMageSpells();
                    break;

                case EnemyType.Hunter:
                    Level = 1;
                    Health = rand.Next(7, 11);
                    Strength = rand.Next(4, 7);
                    ArmorClass = rand.Next(7, 10);
                    SpecialAbility = new SpecialAbility { Name = "Summon Warg" };
                    Initiative = rand.Next(12, 15);
                    Speed = rand.Next(12, 16);
                    THAC0 = 19;
                    break;

                case EnemyType.Warrior:
                    Level = 1;
                    Health = rand.Next(8, 12);
                    Strength = rand.Next(5, 7);
                    ArmorClass = rand.Next(5, 8);
                    SpecialAbility = new SpecialAbility { Name = "Power Strike" };
                    Initiative = rand.Next(16, 20);
                    Speed = rand.Next(7, 11);
                    THAC0 = 17;
                    break;

                case EnemyType.Rogue:
                    Level = 1;
                    Health = rand.Next(6, 9);
                    Strength = rand.Next(4, 6);
                    ArmorClass = rand.Next(6, 9);
                    SpecialAbility = new SpecialAbility { Name = "Stealth Attack" };
                    Initiative = rand.Next(10, 13);
                    Speed = rand.Next(13, 17);
                    THAC0 = 19;
                    break;

                case EnemyType.Paladin:
                    Level = 1;
                    Health = rand.Next(8, 12);
                    Mana = rand.Next(5, 10);
                    InitialMana = Mana;
                    ManaRegen = rand.Next(1, 3);
                    Strength = rand.Next(5, 7);
                    ArmorClass = rand.Next(5, 8);
                    SpecialAbility = new SpecialAbility { Name = "Tormentor" };
                    Initiative = rand.Next(15, 18);
                    Speed = rand.Next(7, 10);
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
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
                    Health = rand.Next(60, 80);
                    Mana = rand.Next(80, 100);
                    InitialMana = Mana;
                    ManaRegen = rand.Next(3, 5);
                    Strength = rand.Next(5, 10);
                    ArmorClass = rand.Next(10, 15);
                    SpecialAbility = new SpecialAbility { Name = "Shadow Bolt" };
                    Speed = rand.Next(8, 12);
                    Experience = 0;
                    THAC0 = 20;
                    Initiative = rand.Next(12, 16);
                    Spells = InitializeEnemyMageSpells();
                    break;

                case EnemyType.Hunter:
                    Level = 1;
                    Health = rand.Next(80, 100);
                    Strength = rand.Next(18, 22);
                    ArmorClass = rand.Next(12, 15);
                    SpecialAbility = new SpecialAbility { Name = "Summon Warg" };
                    Initiative = rand.Next(14, 18);
                    THAC0 = 18;
                    break;

                case EnemyType.Warrior:
                    Level = 1;
                    Health = rand.Next(100, 120);
                    Strength = rand.Next(20, 25);
                    ArmorClass = rand.Next(15, 18);
                    SpecialAbility = new SpecialAbility { Name = "PowerStrikes" };
                    Initiative = rand.Next(10, 14);
                    Speed = rand.Next(10, 15);
                    THAC0 = 17;
                    break;

                case EnemyType.Rogue:
                    Level = 1;
                    Health = rand.Next(70, 90);
                    Strength = rand.Next(15, 20);
                    ArmorClass = rand.Next(12, 16);
                    SpecialAbility = new SpecialAbility { Name = "Stealth Attack" };
                    Initiative = rand.Next(16, 20);
                    Speed = rand.Next(15, 20);
                    THAC0 = 19;
                    break;

                case EnemyType.Paladin:
                    Level = 1;
                    Health = rand.Next(110, 130);
                    Mana = rand.Next(50, 70);
                    InitialMana = Mana;
                    ManaRegen = rand.Next(2, 4);
                    Strength = rand.Next(18, 22);
                    ArmorClass = rand.Next(16, 19);
                    SpecialAbility = new SpecialAbility { Name = "Tormentor" };
                    Initiative = rand.Next(8, 12);
                    Speed = rand.Next(10, 15);
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
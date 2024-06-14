using DungeonGameLogic.Abilities;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class MageParameters : BaseCharacterParameters
    {
        public int Mana { get; set; }
        public double ManaRegen { get; set; }
        public List<MageSpellPower> Spells { get; set; }
        public MageType Type { get; set; }

        //public string Name { get; set; }
        //public string Gender { get; set; }
        //public int Health { get; set; } = 80;
        //public int Mana { get; set; } = 100;  
        //public double ManaRegen { get; set; } = 2.5;
        //public MageType Type { get; set; }
        //public int Level { get; set; } = 1;
        //public int Experience { get; set; } = 0;
        //public int Speed { get; set; } = 60;
        //public int Strength { get; set; } = 5;
        //public int Defense { get; set; } = 20;
        //public string SpecialAbility { get; set; } = "Summon"; //lvl 10 ability
        //public int THAC0 { get; set; } = 20;
        //public List<MageSpellPower> Spells { get; private set; } = new List<MageSpellPower>();

        public MageParameters(string name, string gender, MageType type)
        {
            Name = name;
            Gender = gender;
            Type = type;
            Health = 80;
            Strength = 5;
            Defense = 10;
            SpecialAbility = "Summon"; //lvl 10 ability
            Speed = 10;
            Level = 1;
            Experience = 0;
            THAC0 = 20;
            Mana = 100;
            ManaRegen = 2.5;
            Spells = new List<MageSpellPower>();
            InitializeSpellPower();
        }

        private void InitializeSpellPower()
        {
            switch (Type)
            {
                case MageType.WhiteMage:
                    Spells.Add(new MageSpellPower("Minor Heal", SpellType.Healing, spellLevel: 1, effectValue: 5, manaCost: 10));
                    Spells.Add(new MageSpellPower("Tidal Wave", SpellType.Water, spellLevel: 1, effectValue: 15, manaCost: 20));
                    break;
                case MageType.BlackMage:
                    Spells.Add(new MageSpellPower("Fireball", SpellType.Fire, spellLevel: 1, effectValue: 20, manaCost: 20));
                    Spells.Add(new MageSpellPower("Earth Tremor", SpellType.Earth, spellLevel: 1, effectValue: 15, manaCost: 15));
                    break;
                default:
                    throw new ArgumentException("A valid MageType must be selected.");
            }
        }

        public string PerformSummon()
        {
            if (Level < 10)
            {
                return "Summoning ability not yet available.";
            }

            if (Type == MageType.WhiteMage)
            {
                return "Summoning Shiva Water Goddess";
            }
            else
            {
                return "Summoning Balrog Fire Demon";
            }
        } //Add logic for summoning, Shiva: "Blizzaga" with 100 damage. Balrog: "Firaga" with 100 damage. -Attack only once, 1 minute cooldown.
    }
}


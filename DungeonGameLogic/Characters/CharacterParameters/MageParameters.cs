using DungeonGameLogic.Abilities;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class MageParameters 
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Health { get; set; } = 80;
        public int Mana { get; set; } = 100;  
        public double ManaRegen { get; set; } = 2.5;
        public MageType Type { get; set; }
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public int Speed { get; set; } = 60;
        public int Strength { get; set; } = 5;
        public int Defense { get; set; } = 20;
        public string SpecialAbility { get; set; } = "Summon"; //lvl 10 ability
        public int THAC0 { get; set; } = 20;
        public List<SpellPower> Spells { get; private set; } = new List<SpellPower>();

        public MageParameters(string name, string gender, MageType type)
        {
            Name = name;
            Gender = gender;
            Type = type;
            Spells = new List<SpellPower>();
            InitializeSpellPower();
        }

        private void InitializeSpellPower()
        {
            switch (Type)
            {
                case MageType.WhiteMage:
                    Spells.Add(new SpellPower("Minor Heal", SpellType.Healing, spellLevel: 1, effectValue: 5, manaCost: 10));
                    Spells.Add(new SpellPower("Tidal Wave", SpellType.Water, spellLevel: 1, effectValue: 15, manaCost: 20));
                    break;
                case MageType.BlackMage:
                    Spells.Add(new SpellPower("Fireball", SpellType.Fire, spellLevel: 1, effectValue: 20, manaCost: 20));
                    Spells.Add(new SpellPower("Earth Tremor", SpellType.Earth, spellLevel: 1, effectValue: 15, manaCost: 15));
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


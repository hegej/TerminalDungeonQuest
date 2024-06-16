using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class MageParameters : BaseCharacterParameters
    {
        public int Mana { get; set; }
        public double ManaRegen { get; set; }
        public List<MageSpellPower> Spells { get; set; }
        public MageType Type { get; set; }
        public MageSpecialAbility SpecialAbilitySummon { get; private set; }

        public MageParameters(string name, GenderType gender, MageType type)
        {
            Name = name;
            Gender = gender;
            Type = type;
            Health = 80;
            Strength = 5;
            Defense = 10;
            SpecialAbility = new SpecialAbilty{name = "Summon"}; //lvl 10 ability
            Speed = 10;
            Level = 1;
            Experience = 0;
            THAC0 = 20;
            Mana = 100;
            ManaRegen = 2.5;
            Spells = new List<MageSpellPower>();
            InitializeSpellPower();
            SpecialAbilitySummon = new MageSpecialAbility(type);
        }

        private void InitializeSpellPower()
        {
            switch (Type)
            {
                case MageType.WhiteMage:
                    Spells.Add(new MageSpellPower(SpellType.Healing, "Minor Heal", spellLevel: 1, effectValue: 5, manaCost: 10));
                    Spells.Add(new MageSpellPower(SpellType.Healing, "Tidal Wave", spellLevel: 1, effectValue: 15, manaCost: 20));
                    break;
                case MageType.BlackMage:
                    Spells.Add(new MageSpellPower(SpellType.Healing, "Fireball", spellLevel: 1, effectValue: 20, manaCost: 20));
                    Spells.Add(new MageSpellPower(SpellType.Healing, "Earth Tremor", spellLevel: 1, effectValue: 15, manaCost: 15));
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
        }
    }
}


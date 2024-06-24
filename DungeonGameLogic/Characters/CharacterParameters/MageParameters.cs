using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class MageParameters : BaseCharacterParameters
    {
        public int Mana { get; set; } = 100;
        public int InitialMana { get; set; }
        public int ManaRegen { get; set; } = 3;
        public List<MageSpellPower> Spells { get; set; } = new List<MageSpellPower>();
        public MageSpecialAbility SpecialAbilitySummon { get; set; }
        public MageType Type { get; set; }

        public MageParameters(string name, GenderType gender, MageType type)
        {
            Name = name;
            Gender = gender;
            Type = type;
            Level = 1;
            Health = 10;
            Mana = 20;
            ManaRegen = 4;
            Strength = 2;
            ArmorClass = 10;
            SpecialAbility = new SpecialAbility { Name = "Summon" };
            Speed = 15;
            Experience = 0;
            THAC0 = 20;
            Initiative = 14;
            InitialMana = Mana;
            InitializeSpellPower();
            //SpecialAbilitySummon = new MageSpecialAbility(type);
        }

        private void InitializeSpellPower()
        {
            switch (Type)
            {
                case MageType.WhiteMage:
                    Spells.Add(new MageSpellPower(SpellType.Healing, "Minor Heal", spellLevel: 1, effectValue: 5, manaCost: 10));
                    Spells.Add(new MageSpellPower(SpellType.Water, "Tidal Wave", spellLevel: 1, effectValue: 5, manaCost: 10));
                    break;
                case MageType.BlackMage:
                    Spells.Add(new MageSpellPower(SpellType.Fire, "Fireball", spellLevel: 1, effectValue: 5, manaCost: 10));
                    Spells.Add(new MageSpellPower(SpellType.Earth, "Earth Tremor", spellLevel: 1, effectValue: 5, manaCost: 10));
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


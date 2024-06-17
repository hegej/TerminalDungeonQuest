using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class MageParameters : BaseCharacterParameters
    {
        public new int Level { get; private set; } = 1;
        public new int Health { get; private set; } = 80;
        public new int Strength { get; private set; } = 5;
        public new int Defense { get; private set; } = 10;
        public new int ArmorClass { get; private set; } = 10;
        public SpecialAbility SpecialAbility { get; private set; } = new SpecialAbility { Name = "Summon" };
        public new int Speed { get; private set; } = 15;
        public new int Experience { get; private set; } = 0;
        public new int THAC0 { get; private set; } = 20;
        public int Mana { get; private set; } = 100;
        public double ManaRegen { get; private set; } = 2.5;
        public List<MageSpellPower> Spells { get; set; } = new List<MageSpellPower>();
        public MageSpecialAbility SpecialAbilitySummon { get; private set; }
        public MageType Type { get; set; }

        public MageParameters(string name, GenderType gender, MageType type)
        {
            Name = name;
            Gender = gender;
            Type = type;
            InitializeSpellPower();
            SpecialAbilitySummon = new MageSpecialAbility(type);
        }

        private void InitializeSpellPower()
        {
            switch (Type)
            {
                case MageType.WhiteMage:
                    Spells.Add(new MageSpellPower(SpellType.Healing, "Minor Heal", spellLevel: 1, effectValue: 5, manaCost: 10));
                    Spells.Add(new MageSpellPower(SpellType.Water, "Tidal Wave", spellLevel: 1, effectValue: 15, manaCost: 20));
                    break;
                case MageType.BlackMage:
                    Spells.Add(new MageSpellPower(SpellType.Fire, "Fireball", spellLevel: 1, effectValue: 20, manaCost: 20));
                    Spells.Add(new MageSpellPower(SpellType.Earth, "Earth Tremor", spellLevel: 1, effectValue: 15, manaCost: 15));
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


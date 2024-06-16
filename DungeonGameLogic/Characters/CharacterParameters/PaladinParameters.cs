using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class PaladinParameters : BaseCharacterParameters
    {
        public int Mana { get; set; }
        public double ManaRegen { get; set; }
        public List<PaladinSpellPower> Spells { get; set; }
        public List<PaladinSpecialAbility> SpecialAbilities { get; private set; }

        public PaladinParameters(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;
            InitializeDefaults();
            InitializeSpellPower();
            InitializeSpecialAbilities();
        }

        private void InitializeSpecialAbilities()
        {
            throw new NotImplementedException();
        }

        private void InitializeDefaults()
        {
            Health = 120;
            Mana = 100;
            ManaRegen = 2.0;
            Strength = 20;
            Defense = 30;
            SpecialAbility = "Power of the Gods";
            Speed = 50;
            Level = 1;
            Experience = 0;
            THAC0 = 16;
            //add AC = armorClass on all character types
        }

        private void InitializeSpellPower()
        {
            Spells.Add(new PaladinSpellPower("Minor Heal", PaladinSpellType.MinorHeal, spellLevel: 1, effectValue: 5, manaCost: 10));
            Spells.Add(new PaladinSpellPower("Heal", PaladinSpellType.Heal, spellLevel: 2, effectValue: 10, manaCost: 20));
            Spells.Add(new PaladinSpellPower("Blessing", PaladinSpellType.Blessing, spellLevel: 3, effectValue: 15, manaCost: 30));
            Spells.Add(new PaladinSpellPower("Divine Shield", PaladinSpellType.DivineShield, spellLevel: 4, effectValue: 20, manaCost: 40));
            Spells.Add(new PaladinSpellPower("Smite", PaladinSpellType.Smite, spellLevel: 5, effectValue: 25, manaCost: 50));
        }
    }
}

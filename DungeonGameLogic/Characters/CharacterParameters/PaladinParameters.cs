using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class PaladinParameters : BaseCharacterParameters
    {
        public int Mana { get; set; } = 100;
        public int InitialMana { get; set; }
        public int ManaRegen { get; set; } = 2;
        public List<PaladinSpellPower> Spells { get; set; } = new List<PaladinSpellPower>();
        public List<PaladinSpecialAbility> SpecialAbilities { get; set; } = new List<PaladinSpecialAbility>();


        public PaladinParameters(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;

            Level = 1;
            Health = 12;
            Strength = 6;
            Defense = 4;
            ArmorClass = 18;
            SpecialAbility = new SpecialAbility { Name = "Power of the Gods" };
            Initiative = 41;
            Speed = 12;
            Experience = 0;
            THAC0 = 15;

            InitialMana = Mana;
           // InitializeSpellPower();
            //InitializeSpecialAbilities();
        }

        private void InitializeSpecialAbilities()
        {
            throw new NotImplementedException();
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

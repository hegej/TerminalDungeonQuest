using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class PaladinParameters : BaseCharacterParameters
    {
        public int Level { get; private set; } = 1;
        public int Health { get; private set; } = 120;
        public int Strength { get; private set; } = 20;
        public int Defense { get; private set; } = 30;
        public int ArmorClass { get; private set; } = 18;
        public SpecialAbility SpecialAbility { get; private set; } = new SpecialAbility { Name = "Power of the Gods" };
        public int Speed { get; private set; } = 40;
        public int Experience { get; private set; } = 0;
        public int THAC0 { get; private set; } = 16;
        public int Mana { get; set; } = 100;
        public double ManaRegen { get; set; } = 2.0;
        public List<PaladinSpellPower> Spells { get; set; }
        public List<PaladinSpecialAbility> SpecialAbilities { get; private set; }

        public PaladinParameters(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;
            InitializeSpellPower();
            InitializeSpecialAbilities();
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

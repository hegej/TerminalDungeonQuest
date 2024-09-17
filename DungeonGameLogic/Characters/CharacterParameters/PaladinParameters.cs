using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class PaladinParameters : BaseCharacterParameters
    {
        public int Mana { get; set; }
        public int InitialMana { get; set; }
        public int ManaRegen { get; set; }
        public List<PaladinSpellPower> Spells { get; set; } = new List<PaladinSpellPower>();
        public List<PaladinSpecialAbility> SpecialAbilities { get; set; } = new List<PaladinSpecialAbility>();

        public PaladinParameters(string name, GenderType gender)
        {
            var rand = new Random();
            Name = name;
            Gender = gender;
            Level = 1;
            Health = rand.Next(110, 130);
            Mana = rand.Next(50, 70);
            InitialMana = Mana;
            ManaRegen = rand.Next(2, 4);
            Strength = rand.Next(18, 22);
            ArmorClass = rand.Next(16, 19);
            SpecialAbility = new SpecialAbility { Name = "Power of the Gods" };
            Initiative = rand.Next(8, 12);
            Speed = rand.Next(10, 15);
            Experience = 0;
            THAC0 = 17;

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

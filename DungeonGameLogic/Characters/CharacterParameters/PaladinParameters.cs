using DungeonGameLogic.Abilities;


namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class PaladinParameters : BaseCharacterParameters
    {
        public int Mana { get; set; }
        public double ManaRegen { get; set; }
        public List<PaladinSpellPower> Spells { get; set; }

        public PaladinParameters(string name, string gender)
        {
            Name = name;
            Gender = gender;
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
            Spells = new List<PaladinSpellPower>();
            InitializeSpellPower();
        }

        private void InitializeSpellPower()
        {
            Spells.Add(new PaladinSpellPower("Minor Heal", SpellType.Healing, spellLevel: 1, effectValue: 5, manaCost: 10));
            Spells.Add(new PaladinSpellPower("Heal", SpellType.Healing, spellLevel: 2, effectValue: 10, manaCost: 20));
            Spells.Add(new PaladinSpellPower("Blessing", SpellType.Boost, spellLevel: 3, effectValue: 15, manaCost: 30));
            Spells.Add(new PaladinSpellPower("Divine Shield", SpellType.Boost, spellLevel: 4, effectValue: 20, manaCost: 40));
            Spells.Add(new PaladinSpellPower("Smite", SpellType.Lightning, spellLevel: 5, effectValue: 25, manaCost: 50));
        }

        //public void CheckLevelAndUpdateAbility()
        //{
        //    if (Level >= 10)
        //    {
        //        SpecialAbility = "Mjølnir, Hammer of Thor";  // Unlock special ability
        //    }
        //}
    }
}

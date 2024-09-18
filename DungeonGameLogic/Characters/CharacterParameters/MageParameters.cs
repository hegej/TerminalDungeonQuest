using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;
using DungeonGameLogic.Utilities;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class MageParameters : BaseCharacterParameters
    {
        public int Mana { get; set; }
        public int InitialMana { get; set; }
        public int ManaRegen { get; set; }
        public List<MageSpellPower> Spells { get; set; } = new List<MageSpellPower>();
        public MageSpecialAbility SpecialAbilitySummon { get; set; }
        public MageType Type { get; set; }

        public MageParameters(string name, GenderType gender, MageType type)
        {
            Random rand = RandomStatsProvider.GetRandom();
            Name = name;
            Gender = gender;
            Type = type;
            Level = 1;
            Health = rand.Next(60, 80);
            Mana = rand.Next(80, 100);
            InitialMana = Mana;
            ManaRegen = rand.Next(3, 5);
            Strength = rand.Next(5, 10);
            ArmorClass = rand.Next(10, 15);
            SpecialAbility = new SpecialAbility { Name = "Summon" };
            Speed = rand.Next(8, 12);
            Experience = 0;
            THAC0 = 20;
            Initiative = rand.Next(12, 16);
        }
    }
}


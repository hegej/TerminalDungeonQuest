using DungeonGameLogic.Abilities;
using DungeonGameLogic.Characters.CharacterParameters;

namespace DungeonGameLogic.Characters
{
    public enum MageType
    {
        WhiteMage,
        BlackMage
    }
        public class Mage : Character
        {
        public double ManaRegen { get; private set; }
        public List<SpellPower> Spells { get; private set; }
        public MageParameters MageParam { get; private set; }

        public Mage(MageParameters mageParam)
            : base(mageParam.Name, mageParam.Gender, mageParam.Health, mageParam.Strength, mageParam.Defense, mageParam.SpecialAbility, mageParam.Speed, mageParam.Level, mageParam.Experience, mageParam.THAC0)
        {
            ManaRegen = mageParam.ManaRegen;
            Spells = mageParam.Spells;
        }
    }
}
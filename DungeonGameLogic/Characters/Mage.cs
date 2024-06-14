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
        public int Mana { get; private set; }
        public double ManaRegen { get; private set; }
        public List<MageSpellPower> Spells { get; private set; }
        public MageParameters MageParam { get; private set; }

        public Mage(MageParameters mageParam) : base(mageParam)
        {
            Mana = mageParam.Mana;
            ManaRegen = mageParam.ManaRegen;
            Spells = mageParam.Spells;
            MageParam = mageParam;
        }
    }
}

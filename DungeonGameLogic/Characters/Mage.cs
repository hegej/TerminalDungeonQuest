using DungeonGameLogic.Abilities;
using DungeonGameLogic.Characters.CharacterParameters;

namespace DungeonGameLogic.Characters
{
    public class Mage : Character
    {
        public int Mana { get; set; }
        public int InitialMana { get; set; }
        public int ManaRegen { get; set; }
        public List<MageSpellPower> Spells { get; set; }
        public MageParameters MageParam { get; set; }

        public Mage(MageParameters mageParam) : base(mageParam)
        {
            Mana = mageParam.Mana;
            InitialMana = mageParam.InitialMana;
            ManaRegen = mageParam.ManaRegen;
            Spells = mageParam.Spells;
            MageParam = mageParam;
        }

        public bool CanCastSpell()
        {
            return Spells.Any(spell => Mana >= spell.ManaCost);
        }
    }
}
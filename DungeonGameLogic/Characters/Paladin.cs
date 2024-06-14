using DungeonGameLogic.Abilities;
using DungeonGameLogic.Characters.CharacterParameters;

namespace DungeonGameLogic.Characters
{

    public class Paladin : Character
    {
        public int Mana { get; private set; }
        public double ManaRegen { get; private set; }
        public List<PaladinSpellPower> Spells { get; private set; }
        public PaladinParameters PaladinParam { get; private set; }

        public Paladin(PaladinParameters paladinParam) : base(paladinParam)
        {
            Mana = paladinParam.Mana;
            ManaRegen = paladinParam.ManaRegen;
            Spells = paladinParam.Spells;
            PaladinParam = paladinParam;
        }
    }
}

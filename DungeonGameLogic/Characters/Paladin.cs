using DungeonGameLogic.Abilities;
using DungeonGameLogic.Characters.CharacterParameters;

namespace DungeonGameLogic.Characters
{

    public class Paladin : Character
    {
        public int Mana { get; set; }
        public int InitialMana { get; set; }
        public int ManaRegen { get; set; }
        public List<PaladinSpellPower> Spells { get; set; }
        public PaladinParameters PaladinParam { get; set; }

        public Paladin(PaladinParameters paladinParam) : base(paladinParam)
        {
            Mana = paladinParam.Mana;
            InitialMana = paladinParam.InitialMana;
            ManaRegen = paladinParam.ManaRegen;
            Spells = paladinParam.Spells;
            PaladinParam = paladinParam;
        }
    }
}
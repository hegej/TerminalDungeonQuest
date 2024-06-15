using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Abilities
{
    public class MageSpellPower
    {
        public SpellType Type { get; private set; }
        public string SpellName { get; private set; }
        public int SpellLevel { get; private set; }
        public int EffectValue { get; private set; }
        public int ManaCost { get; private set; }


        public MageSpellPower(SpellType spellType, string spellName, int spellLevel, int effectValue, int manaCost)
        {
            Type = spellType;
            SpellName = spellName;
            SpellLevel = spellLevel;
            EffectValue = effectValue; //damage or heal value
            ManaCost = manaCost;
        }

        //Can add logic for increasing spell power

    }
}

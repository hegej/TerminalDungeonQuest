﻿
namespace DungeonGameLogic.Abilities
{
    public class PaladinSpellPower
    {
        public string SpellName { get; private set; }
        public SpellType Type { get; private set; }
        public int SpellLevel { get; private set; }
        public int EffectValue { get; private set; }
        public int ManaCost { get; private set; }


        public PaladinSpellPower(string spellName, SpellType spellType, int spellLevel, int effectValue, int manaCost)
        {
            SpellName = spellName;
            Type = spellType;
            SpellLevel = spellLevel;
            EffectValue = effectValue; //damage or heal value
            ManaCost = manaCost;
        }
    }
}
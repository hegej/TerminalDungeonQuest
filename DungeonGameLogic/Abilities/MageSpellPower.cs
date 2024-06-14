
namespace DungeonGameLogic.Abilities
{
    public enum SpellType
    {
        Fire,
        Ice,
        Earth,
        Lightning,
        Water,
        Healing,
        Dark,
        Boost
    }

    public class MageSpellPower
    {
        public string SpellName { get; private set; }
        public SpellType Type { get; private set; }
        public int SpellLevel { get; private set; }
        public int EffectValue { get; private set; }
        public int ManaCost { get; private set; }


        public MageSpellPower(string spellName, SpellType spellType, int spellLevel, int effectValue, int manaCost)
        {
            SpellName = spellName;
            Type = spellType;
            SpellLevel = spellLevel;
            EffectValue = effectValue; //damage or heal value
            ManaCost = manaCost;
        }

        //Can add logic for increasing spell power

    }
}

using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Abilities
{
    public class PaladinSpecialAbility
    {
        public PaladinSpecialAbilityType Type { get; private set; }
        public string AbilityName { get; private set; }
        public int EffectValue { get; private set; }
        public int Cooldown { get; private set; }

        public PaladinSpecialAbility(PaladinSpecialAbilityType paladinSpecialAbilityType, string abilityName, int effectValue, int cooldown)
        {
            Type = paladinSpecialAbilityType;
            AbilityName = abilityName;
            EffectValue = effectValue; 
            Cooldown = cooldown; 
        }
    }
}

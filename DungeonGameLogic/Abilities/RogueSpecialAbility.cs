using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Abilities
{
    public class RogueSpecialAbility
    {
        public string AbilityName { get; private set; }
        public AbilityType Type { get; private set; }
        public int AbilityLevel { get; private set; }
        public int EffectValue { get; private set; }
        public int Cooldown { get; private set; }
        public int CurrentCooldown { get; private set; } //Track cooldown 

        public RogueSpecialAbility(string abilityName, AbilityType type, int abilityLevel, int effectValue, int cooldown)
        {
            AbilityName = abilityName;
            Type = type;
            AbilityLevel = abilityLevel;
            EffectValue = effectValue;
            Cooldown = cooldown;
            CurrentCooldown = 0;
        }
    }
}
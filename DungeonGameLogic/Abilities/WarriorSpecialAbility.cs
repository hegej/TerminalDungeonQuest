namespace DungeonGameLogic.Abilities
{
    public enum WarriorAbilityType
    {
        PowerStrike,

    }

    public class WarriorSpecialAbility
    {
        public string AbilityName { get; private set; }
        public WarriorAbilityType Type { get; private set; }
        public int AbilityLevel { get; private set; }
        public int EffectValue { get; private set; }
        public int Cooldown { get; private set; }

        public WarriorSpecialAbility(string abilityName, WarriorAbilityType type, int abilityLevel, int effectValue, int cooldown)
        {
            AbilityName = abilityName;
            Type = type;
            AbilityLevel = abilityLevel;
            EffectValue = effectValue;
            Cooldown = cooldown;
        }

        //public bool CanUse(int currentLevel)
        //{
        //    return currentLevel >= LevelRequired;
        //}
    }
}
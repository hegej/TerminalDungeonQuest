using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class WarriorParameters : BaseCharacterParameters
    {
        public List<WarriorSpecialAbility> Abilities { get; set; } = new List<WarriorSpecialAbility>();

        public WarriorParameters(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;
                       
            Level = 1;
            Health = 12;
            Strength = 6;
            Defense = 4;
            ArmorClass = 16;
            SpecialAbility = new SpecialAbility { Name = "PowerStrikes" };
            Speed = 20;
            Experience = 0;
            THAC0 = 18;

            InitializeAbilities();
        }

        private void InitializeAbilities()
        {
            Abilities = new List<WarriorSpecialAbility>
            {
                new WarriorSpecialAbility("Power Strike", WarriorAbilityType.PowerStrike, abilityLevel: 1, effectValue: 50, cooldown: 30),
                new WarriorSpecialAbility("Defensive Stance", WarriorAbilityType.DefensiveStance, abilityLevel: 1, effectValue: 20, cooldown: 60)
            };
        }
    }
}

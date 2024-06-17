using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class WarriorParameters : BaseCharacterParameters
    {
        public int Level { get; private set; } = 1;
        public int Health { get; private set; } = 150;
        public int Strength { get; private set; } = 30;
        public int Defense { get; private set; } = 25;
        public int ArmorClass { get; private set; } = 16;
        public SpecialAbility SpecialAbility { get; private set; } = new SpecialAbility { Name = "PowerStrikes" };
        public int Speed { get; private set; } = 20;
        public int Experience { get; private set; } = 0;
        public int THAC0 { get; private set; } = 18;
        public List<WarriorSpecialAbility> Abilities { get; set; }

        public WarriorParameters(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;
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

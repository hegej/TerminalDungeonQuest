using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class WarriorParameters : BaseCharacterParameters
    {
        public List<WarriorSpecialAbility> Abilities { get; set; } = new List<WarriorSpecialAbility>();

        public WarriorParameters(string name, GenderType gender)
        {
            Random rand = new Random();
            Name = name;
            Gender = gender;
            Level = 1;
            Health = rand.Next(100, 120);
            Strength = rand.Next(20, 25);
            ArmorClass = rand.Next(15, 18);
            SpecialAbility = new SpecialAbility { Name = "PowerStrikes" };
            Initiative = rand.Next(10, 14);
            Speed = rand.Next(10, 15);
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

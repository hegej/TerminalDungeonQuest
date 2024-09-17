using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class RogueParameters : BaseCharacterParameters
    {
        public List<RogueSpecialAbility> Abilities { get; set; } = new List<RogueSpecialAbility>();

        public RogueParameters(string name, GenderType gender)
        {
            var rand = new Random();
            Name = name;
            Gender = gender;
            Level = 1;
            Health = rand.Next(70, 90);
            Strength = rand.Next(15, 20);
            ArmorClass = rand.Next(12, 16);
            SpecialAbility = new SpecialAbility { Name = "Stealth" };
            Initiative = rand.Next(16, 20);
            Speed = rand.Next(15, 20);
            Experience = 0;
            THAC0 = 19;

            InitializeAbilities();
        }

        private void InitializeAbilities()
        {
            Abilities.Add(new RogueSpecialAbility("Stealth", AbilityType.Stealth, abilityLevel: 1, effectValue: 0, cooldown: 10));
            Abilities.Add(new RogueSpecialAbility("Backstab", AbilityType.Backstab, abilityLevel: 1, effectValue: 30, cooldown: 20));
            Abilities.Add(new RogueSpecialAbility("Poison", AbilityType.Poison, abilityLevel: 1, effectValue: 20, cooldown: 15));
        }
    }
}
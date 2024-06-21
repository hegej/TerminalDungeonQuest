using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class RogueParameters : BaseCharacterParameters
    {
        public List<RogueSpecialAbility> Abilities { get; set; } = new List<RogueSpecialAbility>();

        public RogueParameters(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;
            Level = 1;
            Health = 10;
            Strength = 6;
            Defense = 2;
            ArmorClass = 14;
            SpecialAbility = new SpecialAbility { Name = "Stealth" };
            Initiative = 11;
            Speed = 22;
            Experience = 0;
            THAC0 = 18;

            //InitializeAbilities();
        }

        private void InitializeAbilities()
        {
            Abilities.Add(new RogueSpecialAbility("Stealth", AbilityType.Stealth, abilityLevel: 1, effectValue: 0, cooldown: 10));
            Abilities.Add(new RogueSpecialAbility("Backstab", AbilityType.Backstab, abilityLevel: 1, effectValue: 30, cooldown: 20));
            Abilities.Add(new RogueSpecialAbility("Poison", AbilityType.Poison, abilityLevel: 1, effectValue: 20, cooldown: 15));
        }
    }
}
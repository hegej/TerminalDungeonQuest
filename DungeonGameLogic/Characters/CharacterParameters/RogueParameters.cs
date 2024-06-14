using DungeonGameLogic.Abilities;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class RogueParameters : BaseCharacterParameters
    {
        public int Agility { get; set; }
        public List<RogueSpecialAbility> Abilities { get; set; }

        public RogueParameters(string name, string gender)
        {
            Name = name;
            Gender = gender;
            Health = 90;
            Strength = 25;
            Defense = 10;
            SpecialAbility = "Stealth";
            Speed = 70;
            Agility = 80; 
            Level = 1;
            Experience = 0;
            THAC0 = 18;
            Abilities = new List<RogueSpecialAbility>
            {
                new RogueSpecialAbility("Stealth", AbilityType.Stealth, abilityLevel: 1, effectValue: 0, cooldown: 10),
                new RogueSpecialAbility("Backstab", AbilityType.Backstab,abilityLevel: 1, effectValue: 0, cooldown: 10),
                new RogueSpecialAbility("Poison", AbilityType.Poison, abilityLevel: 1, effectValue: 0, cooldown: 10)
            };
        }
    }
}

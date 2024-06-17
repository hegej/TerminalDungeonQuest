using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class RogueParameters : BaseCharacterParameters
    {
        public new int Level { get; private set; } = 1;
        public new int Health { get; private set; } = 80;
        public new int Strength { get; private set; } = 15;
        public new int Defense { get; private set; } = 10;
        public new int ArmorClass { get; private set; } = 14;
        public SpecialAbility SpecialAbility { get; private set; } = new SpecialAbility { Name = "Stealth" };
        public new int Speed { get; private set; } = 50;
        public int Agility { get; set; } = 80;
        public new int Experience { get; private set; } = 0;
        public new int THAC0 { get; private set; } = 18;
        public List<RogueSpecialAbility> Abilities { get; set; }


        public RogueParameters(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;
            InitializeAbilities();

        }

        private void InitializeAbilities()
        {
            Abilities = new List<RogueSpecialAbility>
            {
                new RogueSpecialAbility("Stealth", AbilityType.Stealth, abilityLevel: 1, effectValue: 0, cooldown: 10),
                new RogueSpecialAbility("Backstab", AbilityType.Backstab,abilityLevel: 1, effectValue: 20, cooldown: 10),
                new RogueSpecialAbility("Poison", AbilityType.Poison, abilityLevel: 1, effectValue: 5, cooldown: 10) //dot
            };
        }
    }
}
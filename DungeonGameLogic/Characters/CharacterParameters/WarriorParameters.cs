﻿using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class WarriorParameters : BaseCharacterParameters
    {
        public List<WarriorSpecialAbility> Abilities { get; set; }

        public WarriorParameters(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;
            Health = 150;
            Strength = 40;
            Defense = 35;
            SpecialAbility = new SpecialAbility { Name = "PowerStrikes" };
            Speed = 50;
            Level = 1;
            Experience = 0;
            THAC0 = 18;
            Abilities = new List<WarriorSpecialAbility>
            {
                new WarriorSpecialAbility("Power Strike", WarriorAbilityType.PowerStrike, abilityLevel: 1, effectValue: 50, cooldown: 30)
            };
        }
    }
}

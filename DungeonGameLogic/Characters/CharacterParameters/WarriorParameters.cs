using DungeonGameLogic.Abilities;

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
            SpecialAbility = "None";
            Speed = 50;
            Level = 1;
            Experience = 0;
            THAC0 = 18;
            Abilities = new List<WarriorSpecialAbility>
            {
                new WarriorSpecialAbility("Power Strike", WarriorAbilityType.PowerStrike, abilityLevel: 1, effectValue: 50, cooldown: 30)
            };
        }

        //public void CheckLevelAndUpdateAbility()
        //{
        //    if (Level >= 10)
        //    {
        //        SpecialAbility = "Power Strike";
        //        // Unlock special ability 
        //    }
        //}
    }
}

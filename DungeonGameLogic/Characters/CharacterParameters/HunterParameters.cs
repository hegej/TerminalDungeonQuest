
using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class HunterParameters : BaseCharacterParameters
    {
        public int Agility { get; private set; }
        public HunterSpecialAbilityPet Pet { get; private set;}
        public List<HunterSpecialAbilityPet> AvailablePets { get; private set; } = new List<HunterSpecialAbilityPet>();

        public HunterParameters(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;
            Level = 1;
            Health = 90;
            Strength = 30;
            Defense = 20;
            SpecialAbility = new SpecialAbility { Name = "Pet" };
            Speed = 70;
            Agility = 80;
            Experience = 0;
            THAC0 = 18;
            AvailablePets = HunterSpecialAbilityPet.InitializeAvailablePets();
        }
    }      
}
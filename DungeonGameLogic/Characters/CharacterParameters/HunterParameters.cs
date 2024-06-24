using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class HunterParameters : BaseCharacterParameters
    {
        public int Agility { get; set; } = 80;
        public HunterSpecialAbilityPet Pet { get; set; } = new HunterSpecialAbilityPet("Default", PetType.Wolf);
        public List<HunterSpecialAbilityPet> AvailablePets { get; set; } = new List<HunterSpecialAbilityPet>();

        public HunterParameters(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;
            Level = 1;
            Health = 10;
            Strength = 6;
            ArmorClass = 8;
            SpecialAbility = new SpecialAbility { Name = "Pet" };
            Initiative = 12;
            Speed = 20;
            Experience = 0;
            THAC0 = 18;

            //AvailablePets = HunterSpecialAbilityPet.InitializeAvailablePets();
        }
    }
}
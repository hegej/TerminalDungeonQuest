using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;
using DungeonGameLogic.Utilities;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class HunterParameters : BaseCharacterParameters
    {
        public int Agility { get; set; }
        public HunterSpecialAbilityPet Pet { get; set; } = new HunterSpecialAbilityPet("Default", PetType.Wolf);
        public List<HunterSpecialAbilityPet> AvailablePets { get; set; } = new List<HunterSpecialAbilityPet>();

        public HunterParameters(string name, GenderType gender)
        {
            Random rand = RandomStatsProvider.GetRandom();
            Name = name;
            Gender = gender;
            Level = 1;
            Health = rand.Next(80, 100);
            Strength = rand.Next(18, 22);
            ArmorClass = rand.Next(12, 15);
            SpecialAbility = new SpecialAbility { Name = "Pet" };
            Initiative = rand.Next(14, 18);
            Speed = rand.Next(12, 18);
            Experience = 0;
            THAC0 = 18;
            Agility = rand.Next(75, 85);

             //AvailablePets = HunterSpecialAbilityPet.InitializeAvailablePets();
        }
    }
}
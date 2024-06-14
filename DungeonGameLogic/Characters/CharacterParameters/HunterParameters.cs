
using DungeonGameLogic.Abilities;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class HunterParameters : BaseCharacterParameters
    {
        public int Agility { get; private set; }
        public HunterSpecialAbilityPet Pet { get; private set;}
        public List<HunterSpecialAbilityPet> AvailablePets { get; private set; } = new List<HunterSpecialAbilityPet>();

        public HunterParameters(string name, GenderType gender, int level, string petType)
        {
            Name = name;
            Gender = gender;
            Level = level;
            Health = 90;
            Strength = 30;
            Defense = 20;
            Speed = 70;
            Agility = 80;
            Experience = 0;
            THAC0 = 18;
            AvailablePets = HunterSpecialAbilityPet.InitializeAvailablePets();
        }

        //private Pet ChoosePet(string petType)
        //{
        //    //logic to choose a pet
        //    throw new ArgumentException(""); //placeholder
        //}
    }
        
}

    


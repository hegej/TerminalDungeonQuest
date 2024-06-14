
namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class HunterParameters : BaseCharacterParameters
    {
        public int Agility { get; private set; }
        public Pet Pet { get; private set;}
        public List<Pet> AvailablePets { get; private set; } = new List<Pet>();

        public HunterParameters(string name, string gender, int level, string petType)
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
            InitializePets();

            if (level >= 10)
            {
                if (string.IsNullOrEmpty(petType))
                {
                    throw new ArgumentException(""); //placeholder handler for no pet selected
                }

                Pet = ChoosePet(petType);
                SpecialAbility = $"Pet Ability: {Pet.Type}";
            }
            else
            {
                Pet = new Pet("None", "No Pet", petHealth: 0, petAttack: 0); //if less then level 10 or no pet selected
                SpecialAbility = "None";
            }
        }

        private void InitializePets()
        {
            AvailablePets.Add(new Pet("Fang", "Wolf"));
            AvailablePets.Add(new Pet("Grizzly", "Bear"));
            AvailablePets.Add(new Pet("Sky", "Eagle"));
            AvailablePets.Add(new Pet("Shadow", "Lynx"));
        }

        private Pet ChoosePet(string petType)
        {
            //logic to choose a pet
            throw new ArgumentException(""); //placeholder
        }
    }
        
}

    


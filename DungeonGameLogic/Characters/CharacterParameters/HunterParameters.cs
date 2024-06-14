using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class HunterParameters
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Health { get; set; } = 90;
        public int Speed { get; set; } = 70;
        public int Agility { get; set; } = 80;
        public int Strength { get; set; } = 30;
        public int Defense { get; set; } = 20;
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public int THAC0 { get; set; } = 18;
        public Pet Pet { get; private set; }
        public string SpecialAbility { get; private set; }
        public List<Pet> AvailablePets { get; private set; } = new List<Pet>();

        public HunterParameters(string name, string gender, int level, string petType)
        {
            Name = name;
            Gender = gender;
            Level = level;
            InitializePets();

            if (level >= 10)
            {
                if (string.IsNullOrEmpty(petType))
                {
                    throw new ArgumentException("A pet type must be selected when the hunter reaches level 10 or higher.");
                }

                Pet = ChoosePet(petType);
                SpecialAbility = $"Pet Ability: {Pet.Type}";
            }
            else
            {
                Pet = new Pet("None", "No Pet", petHealth: 0, petAttack: 0);
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

    


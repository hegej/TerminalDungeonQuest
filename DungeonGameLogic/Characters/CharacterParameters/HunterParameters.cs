
using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class HunterParameters : BaseCharacterParameters
    {
        public int Level { get; private set; } = 1;
        public int Health { get; private set; } = 90;
        public int Strength { get; private set; } = 30;
        public int Defense { get; private set; } = 20;
        public int ArmorClass { get; private set; } = 12;
        public SpecialAbility SpecialAbility { get; private set; } = new SpecialAbility { Name = "Pet" };
        public int Speed { get; private set; } = 70;
        public int Agility { get; private set; } = 80;
        public int Experience { get; private set; } = 0;
        public int THAC0 { get; private set; } = 18; 
        public HunterSpecialAbilityPet Pet { get; private set;}
        public List<HunterSpecialAbilityPet> AvailablePets { get; private set; } = new List<HunterSpecialAbilityPet>();

        public HunterParameters(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;
            AvailablePets = HunterSpecialAbilityPet.InitializeAvailablePets();
        }
    }      
}
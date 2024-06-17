using DungeonGameLogic.Abilities;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class HunterParameters : BaseCharacterParameters
    {
        public new int Level { get; private set; } = 1;
        public new int Health { get; private set; } = 90;
        public new int Strength { get; private set; } = 30;
        public new int Defense { get; private set; } = 20;
        public new int ArmorClass { get; private set; } = 12;
        public SpecialAbility SpecialAbility { get; private set; } = new SpecialAbility { Name = "Pet" };
        public new int Speed { get; private set; } = 70;
        public int Agility { get; private set; } = 80;
        public new int Experience { get; private set; } = 0;
        public new int THAC0 { get; private set; } = 18;
        public HunterSpecialAbilityPet Pet { get; private set; } = new HunterSpecialAbilityPet("Default", PetType.Wolf); // Default value
        public List<HunterSpecialAbilityPet> AvailablePets { get; private set; } = new List<HunterSpecialAbilityPet>();

        public HunterParameters(string name, GenderType gender)
        {
            Name = name;
            Gender = gender;
            AvailablePets = HunterSpecialAbilityPet.InitializeAvailablePets();
        }
    }
}
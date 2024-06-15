using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Abilities
{   
public class HunterSpecialAbilityPet
{
    public string Name { get; set; }
    public PetType Type { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public int Attack { get; set; }

    public HunterSpecialAbilityPet(string petName, PetType petType, int petHealth = 60, int petLevel = 1, int petAttack = 15)
    {
        Name = petName;
        Type = petType;
        Health = petHealth;
        Level = petLevel;
        Attack = petAttack;
    }

    public static List<HunterSpecialAbilityPet> InitializeAvailablePets()
    {
        return new List<HunterSpecialAbilityPet>
            {
                new HunterSpecialAbilityPet("Fang", PetType.Wolf),
                new HunterSpecialAbilityPet("Grizzly", PetType.Bear),
                new HunterSpecialAbilityPet("Sky", PetType.Eagle),
                new HunterSpecialAbilityPet("Shadow", PetType.Lynx)
            };
    }

    public static HunterSpecialAbilityPet ChoosePet(string petName, PetType petType)
    {
        var availablePets = InitializeAvailablePets();
        foreach (var pet in availablePets)
        {
            if (pet.Name == petName && pet.Type == petType)
            {
                return pet;
            }
        }
            throw new ArgumentException("A valid pet type must be selected.");
        }
}
}
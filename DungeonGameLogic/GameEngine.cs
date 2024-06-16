using DungeonGameLogic.Characters;
using DungeonGameLogic.Characters.CharacterParameters;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic
{
    public class GameEngine
    {
        public void StartGame()
        {
            Console.WriteLine("Game started!");
        }

        public Character CreateCharacter(string type, string name, string gender, string specificType = null)
        {
            if (!Enum.TryParse<CharacterType>(type, out var characterType))
            {
                throw new ArgumentException("Invalid character type specified.");
            }

            if (!Enum.TryParse<GenderType>(gender, true, out var genderType))
            {
                throw new ArgumentException("Invalid gender specified.");
            }

            Character character;

            switch (characterType)
            {
                case CharacterType.Mage:
                    if (!Enum.TryParse<MageType>(specificType, out var mageType))
                    {
                        throw new ArgumentException("Invalid mage type specified.");
                    }
                    character = new Mage(new MageParameters(name, genderType, mageType));
                    break;
                case CharacterType.Warrior:
                    character = new Warrior(new WarriorParameters(name, genderType));
                    break;
                case CharacterType.Rogue:
                    character = new Rogue(new RogueParameters(name, genderType));
                    break;
                case CharacterType.Paladin:
                    character = new Paladin(new PaladinParameters(name, genderType));
                    break;
                case CharacterType.Hunter:
                    character = new Hunter(new HunterParameters(name, genderType));
                    break;
                default:
                    throw new ArgumentException("Character not supported.");
            }

            PrintCharacterDetails(character);
            return character;
        }

        private void PrintCharacterDetails(Character character)
        {
            Console.WriteLine($"\nCharacter created:");
            Console.WriteLine($"Type: {character.GetType().Name}");
            Console.WriteLine($"Name: {character.Name}");           
            Console.WriteLine($"Health: {character.Health}");
            Console.WriteLine($"Strength: {character.Strength}");
            Console.WriteLine($"Defense: {character.Defense}");
            Console.WriteLine($"Special Ability: {character.SpecialAbility.Name}");
            Console.WriteLine($"Speed: {character.Speed}");
            Console.WriteLine($"Level: {character.Level}");
            Console.WriteLine($"Experience: {character.Experience}");
            Console.WriteLine($"THAC0: {character.THAC0}");
        }

        public void CreateEnemy()
        {
            Console.WriteLine("\nEnemy created!");
        }
    }
}

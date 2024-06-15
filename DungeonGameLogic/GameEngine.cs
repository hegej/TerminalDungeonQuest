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

        public Character CreateCharacter(string type, string name, string gender)
        {
            if (!Enum.TryParse<CharacterType>(type, out var characterType))
            {
                throw new ArgumentException("Invalid character type specified.");
            }

            if (!Enum.TryParse<GenderType>(gender, true, out var genderType))
            {
                throw new ArgumentException("Invalid gender specified.");
            }

            // Create character based on type
            switch (characterType)
            {
                case CharacterType.Mage:
                    return new Mage(new MageParameters { Name = name, Gender = genderType });
                case CharacterType.Warrior:
                    return new Warrior(new WarriorParameters { Name = name, Gender = genderType });
                case CharacterType.Rogue:
                    return new Rogue(new RogueParameters { Name = name, Gender = genderType });
                case CharacterType.Paladin:
                    return new Paladin(new PaladinParameters { Name = name, Gender = genderType });
                case CharacterType.Hunter:
                    return new Hunter(new HunterParameters { Name = name, Gender = genderType });
                default:
                    throw new ArgumentException("Character type not supported.");
            }
        }

        public void CreateEnemy()
        {
            Console.WriteLine("Enemy created!");
        }


    }
}

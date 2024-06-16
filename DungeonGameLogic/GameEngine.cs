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

            switch (characterType)
            {
                case CharacterType.Mage:
                    if (!Enum.TryParse<MageType>(specificType, out var mageType))
                    {
                        throw new ArgumentException("Invalid mage type specified.");
                    }
                    return new Mage(new MageParameters(name, genderType, mageType));
                case CharacterType.Warrior:
                    return new Warrior(new WarriorParameters(name, genderType));
                case CharacterType.Rogue:
                    return new Rogue(new RogueParameters(name, genderType));
                case CharacterType.Paladin:
                    return new Paladin(new PaladinParameters(name, genderType));
                case CharacterType.Hunter:
                    return new Hunter(new HunterParameters(name, genderType));
                default:
                    throw new ArgumentException("Character not supported.");
            }
        }

        public void CreateEnemy()
        {
            Console.WriteLine("Enemy created!");
        }
    }
}

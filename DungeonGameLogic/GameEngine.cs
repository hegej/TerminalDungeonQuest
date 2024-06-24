using DungeonGameLogic.Characters;
using DungeonGameLogic.Characters.CharacterParameters;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic
{
    public class GameEngine
    {
        private BattleEngine _battleEngine;
        private List<Team> _teams;

        public GameEngine()
        {
            _teams = new List<Team>();
        }

        public void StartGame()
        {
            Console.WriteLine("Game started!");
            CreateTeams();
            InitializeBattleEngine();
            SimulateBattle();
        }

        public Character CreateCharacter(string type, string name, string gender, string specificType = null)
        {
            if (!Enum.TryParse<CharacterType>(type, true, out var characterType))
            {
                Console.WriteLine($"Error: Failed to parse character type from '{type}'.");
                throw new ArgumentException("Invalid character type specified.");
            }

            Console.WriteLine($"Creating character of type {characterType} (Parsed from '{type}')");

            if (!Enum.TryParse<GenderType>(gender, true, out var genderType))
            {
                Console.WriteLine($"Error: Failed to parse gender type from '{gender}'.");
                throw new ArgumentException("Invalid gender specified.");
            }

            Character character;
            switch (characterType)
            {
                case CharacterType.Mage:
                    if (!Enum.TryParse<MageType>(specificType, out var mageType))
                    {
                        Console.WriteLine($"Error: Failed to parse mage type from '{specificType}'.");
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
                    Console.WriteLine($"Error: Unsupported character type '{characterType}'.");
                    throw new ArgumentException("Character type not supported.");
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
            Console.WriteLine($"Special Ability: {character.SpecialAbility?.Name}");
            Console.WriteLine($"Speed: {character.Speed}");
            Console.WriteLine($"Level: {character.Level}");
            Console.WriteLine($"Experience: {character.Experience}");
            Console.WriteLine($"THAC0: {character.THAC0}");
        }

        public Enemy CreateEnemy(string name, EnemyType type)
        {
            return new Enemy(new EnemyParameters(name, type));
        }

        public void CreateTeams()
        {
            Team playerTeam = CreateTeam("Blue Team", false);
            Team enemyTeam = CreateTeam("Red Team", true);

            _teams.Add(playerTeam);
            _teams.Add(enemyTeam);
        }

        public Team CreateTeam(string teamName, bool isEnemy)
        {
            Team team = new Team(teamName);
            team.Priority = isEnemy ? 1 : 0;

            if (isEnemy)
            {
                team.AddMember(CreateEnemy("Enemy Hunter", EnemyType.Hunter));
                team.AddMember(CreateEnemy("Enemy Rogue", EnemyType.Rogue));
                team.AddMember(CreateEnemy("Enemy Warrior", EnemyType.Warrior));
                team.AddMember(CreateEnemy("Enemy Paladin", EnemyType.Paladin));
            }
            else
            {
                team.AddMember(CreateCharacter("Hunter", "Argon", "Male"));
                team.AddMember(CreateCharacter("Mage", "FaLuna", "Female", "WhiteMage"));
                team.AddMember(CreateCharacter("Warrior", "Jarvis", "Male"));
                team.AddMember(CreateCharacter("Paladin", "Raona", "Female"));
            }

            return team;
        }

        public void DisplayTeamMembers(Team team)
        {
            Console.WriteLine($"\n{team.Name} Members:");
            foreach (var member in team.Members)
            {
                Console.WriteLine($"- {member.Name}, Type: {member.GetType().Name}");
                Console.WriteLine($"  Health: {member.Health}");
                Console.WriteLine($"  Strength: {member.Strength}");
                Console.WriteLine($"  Armor Class: {member.ArmorClass}");
                Console.WriteLine($"  Special Ability: {member.SpecialAbility?.Name}");
                Console.WriteLine($"  Speed: {member.Speed}");
                Console.WriteLine($"  Level: {member.Level}");
                Console.WriteLine($"  Experience: {member.Experience}");
                Console.WriteLine($"  THAC0: {member.THAC0}");
            }
        }

        private void InitializeBattleEngine()
        {
            _battleEngine = new BattleEngine(_teams);
        }

        private void SimulateBattle()
        {
            _battleEngine.SimulateBattle(_teams);
        }
    }
}
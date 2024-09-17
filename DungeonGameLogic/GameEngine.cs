using DungeonGameLogic.Characters;
using DungeonGameLogic.Characters.CharacterParameters;
using DungeonGameLogic.Enums;
using Spectre.Console;

namespace DungeonGameLogic
{
    public class GameEngine
    {
        private BattleEngine _battleEngine;
        private List<Team> _teams = new List<Team>();

        public GameEngine()
        {
            CreateTeams();
            BalanceTeams(_teams[0], _teams[1]);
        }

        public static void DisplayStartPage()
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(
                new Panel(
                        @"
                                           ..::.                                              
                                        .....:::...                                           
                                       ......::::::.                                          
                                     ........-------..                                        
                                    .......:++=------..                                       
                                   ......=#%%%%#+====-...                                     
                                  ....-*%%%%%%%%%%#*+=-:...                                   
                                 ..-#%%%%%%%###%#%%%%%%#-::.:                                 
                               ...=#%%##+#**#**#%#%%%%%%%#**+=                                
                               ..-#****+**+==+**%@%%%%%%%%%#*+                                
                              .-*###**++#@#-=+*#%%%#%%%%%%%%%#+                               
                              :*###%#%#==+++=+**####%%%%@@%%%%#                               
                              :####%%@@#-----=+++**#@%%@@@##%##                               
                               +=##%%%@@%#=---++*%@@@@@@@%%+*#*                               
                              =--+*##%%@@@@@%##*%@@@@@%%%%%*##+                               
                             -==*#*#%%@*-:--=+**#%#+#@@@%%%#*#                                
                              =--**#%%+:.:::--=+****++*@%%%%%+-                               
                             --+++*##*:.:=-::-==#%#*++*%%%%%@%#                               
                           -   +++=+=:.:=--:.:=+####+=+*#%%%%%#                               
                            -=+=++-....-=-=--:++*###*++*++*##                                 
                              -==....=+=+***++########*#*+++-:                                
                               ...-=+***%%%#**##%%%%%%#%###**+=-                              
                              ...::===*#%#=:+*######%%*####*****+=                            
                             ...:-:++++#*-:-**##**###%#=####*****+*#*                         
                             ..:===***#*-:-***##+***#%%*=#######%%%%#                         
                            .:==+=+++**-:-**#*##+***#%%#=+= *####%%%#+                        
                       ++***=*====:-*+-::**#####+##*#%%%+++=    %%%%%*                        
                    ==+****       .++-:..+**#%#**#*#*#%%*++++                                 
              ===+*###**         .--:::..-+**##**##**#%##+**++=                               
        ====+*##**             ....:::..:=++++*+*#****#*#****++=                              
      +=######                 ....::...:=++++++******#*******+++                             
       -+###                 .....::....-++**+++******#*******++*+                            
         *                  .....--:...:=+***+++*******#*******++**                           
                           ....:---:...:=+***++********##*******+**+                          
                           ..-==+=:...:-++***+**#%%###%%%#*******+**                          
                           ..-=++==-=++=+******####**##%%%#*******+                           
                             =-:.=+=*####*****##*##+*##%#%%##******                           
                              .+**++*+*########**##+*##%##%###*                               
                                   +**#%@@@%%#######%%%%%*                                    
                                      #%@@@%       %@@@@%                                     
                                      *%%@@%       %@@@@@@%                                   
                                      #*#%%%       %@@@@@@%%         

                        \    / |_  o _|_  _     |\/|  _.  _   _     ._  ._ _   _  _  ._ _|_  _ o
                         \/\/  | | |  |_ (/_    |  | (_| (_| (/_    |_) | (/_ _> (/_ | | |_ _> o
                                                          _|        |              
    "
                )
                .Expand()
                .NoBorder()
            );

            AnsiConsole.WriteLine();

            AnsiConsole.Write(
                new FigletText("Dungeon Quest")
                .LeftJustified()
                .Color(Color.DarkOrange));

            AnsiConsole.WriteLine();
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
            var playerTeam = CreateTeam("Blue Team", false);
            var enemyTeam = CreateTeam("Red Team", true);

            _teams.Add(playerTeam);
            _teams.Add(enemyTeam);
        }

        public Team CreateTeam(string teamName, bool isEnemy)
        {
            var team = new Team(teamName);
            team.Priority = isEnemy ? 1 : 0;

            if (isEnemy)
            {
                team.AddMember(CreateEnemy("Enemy Hunter", EnemyType.Hunter));
                team.AddMember(CreateEnemy("Enemy Rogue", EnemyType.Rogue));
                team.AddMember(CreateEnemy("Enemy Warrior", EnemyType.Warrior));
                team.AddMember(CreateEnemy("Enemy Paladin", EnemyType.Paladin));
                team.AddMember(CreateEnemy("Enemy Mage", EnemyType.Mage));
            }
            else
            {
                team.AddMember(CreateCharacter("Hunter", "Argon", "Male"));
                team.AddMember(CreateCharacter("Mage", "FaLuna", "Female", "WhiteMage"));
                team.AddMember(CreateCharacter("Warrior", "Jarvis", "Male"));
                team.AddMember(CreateCharacter("Rogue", "Shadow", "Female"));
                team.AddMember(CreateCharacter("Paladin", "Raona", "Female"));
            }

            return team;
        }

        private void BalanceTeams(Team team1, Team team2)
        {
            var team1Power = CalculateTeamPower(team1);
            var team2Power = CalculateTeamPower(team2);

            while (Math.Abs(team1Power - team2Power) > 5)
            {
                if (team1Power > team2Power)
                {
                    BuffTeam(team2);
                    team2Power = CalculateTeamPower(team2);
                }
                else
                {
                    BuffTeam(team1);
                    team1Power = CalculateTeamPower(team1);
                }
            }
        }

        private int CalculateTeamPower(Team team)
        {
            return team.Members.Sum(member => member.Health + member.Strength);
        }

        private void BuffTeam(Team team)
        {
            foreach (var member in team.Members)
            {
                member.Health += 1;
                member.Strength += 1;
            }
        }

    }
}
using DungeonGameLogic;
using DungeonGameLogic.Characters;
using DungeonGameLogic.Enums;
using DungeonGameLogic.Interfaces;
using Spectre.Console;
using System.Text;

namespace DungeonGameSimulator.Utilities
{
    public static class GameConsole
    {
        private static readonly Style EnemyStyle = new(Spectre.Console.Color.Red);
        private static readonly Style FriendlyStyle = new(Spectre.Console.Color.Blue);
        private static readonly Style CriticalStyle = new(Spectre.Console.Color.Yellow);
        private static readonly Style HealingStyle = new(Spectre.Console.Color.Green);
        private static readonly Style NormalStyle = new(Spectre.Console.Color.Grey);
        private static bool _useEmoji = true;

        public static void Initialize()
        {
            Console.OutputEncoding = Encoding.UTF8;
            TestEmojiSupport();
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
                .Color(Spectre.Console.Color.DarkOrange));

            AnsiConsole.WriteLine();
        }

        private static readonly Dictionary<string, string> CharacterEmoji = new Dictionary<string, string>
        {
            { "Mage", Emoji.Known.Mage },
            { "Warrior", Emoji.Known.Man },
            { "Rogue", Emoji.Known.Ninja },
            { "Paladin", Emoji.Known.PersonBeard },
            { "Hunter", Emoji.Known.Elf }
        };

        private static readonly Dictionary<string, string> ActionEmoji = new Dictionary<string, string>
        {
            { "Attack", Emoji.Known.CrossedSwords },
            { "Heal", Emoji.Known.SparklingHeart },
            { "Defense", Emoji.Known.Shield },
            { "Death", Emoji.Known.Skull },
            { "Spell", Emoji.Known.Sparkles }
        };

        private static readonly Dictionary<string, string> EmojiFallback = new Dictionary<string, string>
        {
            { Emoji.Known.Mage, "M" },
            { Emoji.Known.Man, "W" },
            { Emoji.Known.Ninja, "R" },
            { Emoji.Known.PersonBeard, "P" },
            { Emoji.Known.Elf, "H" },
            { Emoji.Known.CrossedSwords, "X" },
            { Emoji.Known.SparklingHeart, "+" },
            { Emoji.Known.Shield, "D" },
            { Emoji.Known.Skull, "!" },
            { Emoji.Known.Sparkles, "*" }
        };

        public static void LogAction(string message, LogType type, string action)
        {
            string emoji = GetActionSymbol(action);
            Style borderStyle = type switch
            {
                LogType.Enemy => EnemyStyle,
                LogType.Friendly => FriendlyStyle,
                LogType.Critical => CriticalStyle,
                LogType.Healing => HealingStyle,
                _ => NormalStyle
            };

            BoxBorder borderType = type switch
            {
                LogType.Enemy => BoxBorder.Heavy,
                LogType.Friendly => BoxBorder.Double,
                LogType.Critical => BoxBorder.Rounded,
                LogType.Healing => BoxBorder.Square,
                _ => BoxBorder.Rounded
            };

            if (action == "Heal" || action == "Defense" || action.Contains("Regenerated") || type == LogType.Healing)
            {
                borderStyle = HealingStyle;
                borderType = BoxBorder.Square;
            }

            var panel = new Panel($"{emoji} {message}")
            {
                Border = borderType,
                BorderStyle = borderStyle,
                Expand = false,
                Padding = new Padding(1, 0, 1, 0)
            };

            AnsiConsole.Write(panel);
        }


        private static string GetActionSymbol(string action)
        {
            if (ActionEmoji.TryGetValue(action, out var emoji))
            {
                return _useEmoji ? emoji : GetFallbackSymbol(emoji);
            }
            return "";
        }

        public static string GetCharacterSymbol(string characterType)
        {
            if (CharacterEmoji.TryGetValue(characterType, out var emoji))
            {
                return _useEmoji ? emoji : GetFallbackSymbol(emoji);
            }
            return "";
        }

        private static string GetFallbackSymbol(string emoji)
        {
            return EmojiFallback.TryGetValue(emoji, out var fallback) ? fallback : "";
        }

        public static void TestEmojiSupport()
        {
            try
            {
                var testEmoji = Emoji.Known.CrossedSwords;
                _useEmoji = true;
            }
            catch
            {
                _useEmoji = false;
                Console.WriteLine("Emoji support is not available. Using text fallback.");
            }
        }

        public static void LogBattleStart()
        {
            AnsiConsole.Write(new Rule("[yellow]Battle Begins[/]")
                .DoubleBorder()
                .RuleStyle(Style.Parse("yellow bold"))
                .LeftJustified());
            AnsiConsole.WriteLine();
        }

        public static void LogBattleEnd(string winner)
        {
            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Rule("[yellow]Battle Ends[/]")
                .DoubleBorder()
                .RuleStyle(Style.Parse("yellow bold"))
                .LeftJustified());
            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Markup($"[green]Winner: {winner}[/]").Centered());
            AnsiConsole.WriteLine();
        }

        public static void DisplayCharacterStats(DungeonGameLogic.Characters.Character character)
        {
            string characterSymbol = GetCharacterSymbol(character.GetType().Name);
            var table = new Table()
                .Border(TableBorder.Square)
                .AddColumn(new TableColumn("Attribute").Centered())
                .AddColumn(new TableColumn("Value").Centered());
            table.AddRow($"{characterSymbol} [bold]{character.Name}[/]", $"[bold]{character.GetType().Name}[/]");
            table.AddRow("[red]Health[/]", $"{character.Health}/{character.MaxHealth}");
            table.AddRow("[green]Level[/]", character.Level.ToString());
            if (character is Mage mage)
            {
                table.AddRow("[blue]Mana[/]", $"{mage.Mana}/{mage.InitialMana}");
            }
            table.AddRow("Strength", character.Strength.ToString());
            table.AddRow("Armor Class", character.ArmorClass.ToString());
            table.AddRow("Speed", character.Speed.ToString());
            table.AddRow("THAC0", character.THAC0.ToString());
            AnsiConsole.Write(table);
        }

        public static void DisplayTeamStats(DungeonGameLogic.Team team)
        {
            var table = new Table()
                .Border(TableBorder.Square)
                .AddColumn(new TableColumn("Character").Centered())
                .AddColumn(new TableColumn("Health").Centered())
                .AddColumn(new TableColumn("Level").Centered());
            foreach (var character in team.Members)
            {
                string characterSymbol = GetCharacterSymbol(character.GetType().Name);
                table.AddRow(
                    $"{characterSymbol} {character.Name}",
                    $"[red]{character.Health}/{character.MaxHealth}[/]",
                    $"[green]{character.Level}[/]"
                );
            }
            AnsiConsole.Write(new Rule($"[blue]{team.Name}[/]").RuleStyle(Style.Parse("blue")));
            AnsiConsole.Write(table);
            AnsiConsole.WriteLine();
        }
    }
}

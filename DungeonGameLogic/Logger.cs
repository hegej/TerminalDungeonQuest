using DungeonGameLogic;
using DungeonGameLogic.Characters;
using DungeonGameLogic.Enums;
using Spectre.Console;
using System.Text.Json;

public static class Logger
{
    private static readonly List<LogEntry> _logs = new List<LogEntry>();
    private static readonly string _logDirectory = @"C:/DungeonQuest/BattleLog";
    private static readonly string _logFilePath;
    private static bool _isLoggingEnabled = true;
    private static readonly Style EnemyStyle = new(Spectre.Console.Color.Red);
    private static readonly Style FriendlyStyle = new(Spectre.Console.Color.Blue);
    private static readonly Style CriticalStyle = new(Spectre.Console.Color.Yellow);
    private static readonly Style HealingStyle = new(Spectre.Console.Color.Green);
    private static readonly Style NormalStyle = new(Spectre.Console.Color.Grey);
    private static bool _useEmoji = true;

    static Logger()
    {
        try
        {
            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
                Console.WriteLine($"Directory for Battlelogger dosn't exist, created directory: {_logDirectory}");
            }

        _logFilePath = Path.Combine(_logDirectory, $"BattleLog_{DateTime.Now:yyyyMMdd_HHmmss}.json");

        }
        catch (Exception ex)
        {
            HandleLoggingError(ex, "Error creating battleLog directory");
        }
    }

    private static void HandleLoggingError(Exception ex, string context)
    {
        _isLoggingEnabled = false;
        Console.WriteLine($"{context} : {ex.Message}");
        Console.WriteLine("Logging to file wont work, the logs will only be displayed in the console.");
    }

    public static void Log(string message)
    {
        var logEntry = new LogEntry
        {
            Timestamp = DateTime.Now,
            Type = "LOG",
            Message = message.Replace("\n", Environment.NewLine)
        };

        _logs.Add(logEntry);
        Console.WriteLine($"{logEntry.Timestamp:dd-MM-yyyy HH:mm:ss} [{logEntry.Type}] {logEntry.Message}");
        
        if (_isLoggingEnabled)
        {
            try 
            {
                WriteLogsToFile();
            }
            catch (Exception ex)
            {
                HandleLoggingError(ex, "Error when writing to log file.");
            }
        }
    }

    private static void WriteLogsToFile()
    {
        var jsonFormatOptions = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(_logs, jsonFormatOptions);
        File.WriteAllText(_logFilePath, jsonString);
    }

    public static void LogAction(string actionDetails)
    {
        Log($"Action: {actionDetails}");
    }

    public static void LogBattleOutcome(string outcomeDetails)
    {
        Log($"Outcome: {outcomeDetails}");
    }
    public static void LogBattleRoundStart(int round)
    {
        Log($"Round {round} begins.");
    }

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

}
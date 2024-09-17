using DungeonGameLogic;
using DungeonGameLogic.Enums;
using Spectre.Console;
using System.Text.Json;

public static class Logger
{
    private static readonly List<LogEntry> _logs = new List<LogEntry>();
    private static readonly string _logDirectory = @"C:/DungeonQuest/BattleLog";
    private static readonly string _logFilePath;
    private static bool _isLoggingEnabled = true;
    private static readonly Style EnemyStyle = new(Color.Red);
    private static readonly Style FriendlyStyle = new(Color.Blue);
    private static readonly Style CriticalStyle = new(Color.Yellow);
    private static readonly Style HealingStyle = new(Color.Green);
    private static readonly Style NormalStyle = new(Color.Grey);


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

    public static void LogAction(string message, LogType type, string action)
    {
        var emoji = BattleEngine.GetActionSymbol(action);
        var borderStyle = type switch
        {
            LogType.Enemy => EnemyStyle,
            LogType.Friendly => FriendlyStyle,
            LogType.Critical => CriticalStyle,
            LogType.Healing => HealingStyle,
            _ => NormalStyle
        };

        var borderType = type switch
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
}
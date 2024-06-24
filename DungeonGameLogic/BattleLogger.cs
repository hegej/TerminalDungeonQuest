using DungeonGameLogic;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

public static class BattleLogger
{
    private static readonly List<LogEntry> _logs = new List<LogEntry>();
    private static readonly string _logDirectory = @"C:/DungeonQuest/BattleLog";
    private static readonly string _logFilePath;
    private static bool _isLoggingEnabled = true;

    static BattleLogger()
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
        string jsonString = JsonSerializer.Serialize(_logs, jsonFormatOptions);
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

    public static List<LogEntry> GetBattleLog()
    {
        return _logs;
    }
}
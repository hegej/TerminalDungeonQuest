﻿using System;
using System.IO;

public static class BattleLogger
{
    private static readonly List<string> _logs = new List<string>();
    private static readonly string _logFilePath = $"C:/Users/hejacobsen/Documents/BattleLog/BattleLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

    public static void Log(string message)
    {
        string formattedMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [LOG] {message}";
        Console.WriteLine(formattedMessage);
        _logs.Add(formattedMessage);
        File.AppendAllText(_logFilePath, formattedMessage + Environment.NewLine);
    }

    public static void LogAction(string actionDetails)
    {
        Log($"Action: {actionDetails}");
    }

    public static void LogBattleOutcome(string outcomeDetails)
    {
        Log($"Outcome: {outcomeDetails}");
    }
}
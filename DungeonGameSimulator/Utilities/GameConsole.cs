using Spectre.Console;
using DungeonGameLogic.Enums;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace DungeonGameSimulator.Utilities
{
    public static class GameConsole
    {
        private static readonly Style EnemyStyle = new(Spectre.Console.Color.Red);
        private static readonly Style FriendlyStyle = new(Spectre.Console.Color.Blue);
        private static readonly Style CriticalStyle = new(Spectre.Console.Color.Yellow);
        private static readonly Style HealingStyle = new(Spectre.Console.Color.Green);
        private static readonly Style NarratorStyle = new(Spectre.Console.Color.Grey);
        private static bool _useEmoji = true;

        public static void Initialize()
        {
            AnsiConsole.Write(
                new FigletText("Dungeon Quest")
                .LeftJustified()
                .Color(Spectre.Console.Color.DarkOrange));

            AnsiConsole.WriteLine();
        }

        private static readonly Dictionary<string, string> EmojiFallback = new Dictionary<string, string>
        {
            {Emoji.Known.Dragon, "D" },
            {Emoji.Known.Dagger, "S" },
            {Emoji.Known.Sparkles, "*" },
            {Emoji.Known.CrossedSwords, "X"},
            {Emoji.Known.Collision, "!" },
            {Emoji.Known.Fire, "F" },
            {Emoji.Known.SparklingHeart, "+" }
        };

        public static void LogAction(string message, LogType type, string symbol)
        {
            string displaySymbol = _useEmoji ? symbol : (EmojiFallback.ContainsKey(symbol) ? EmojiFallback[symbol] : "");
            var panel = new Panel($"{displaySymbol} {message}")
            {
                Border = type switch
                {
                    LogType.Enemy => BoxBorder.Heavy,
                    LogType.Friendly => BoxBorder.Double,
                    LogType.Critical => BoxBorder.Rounded,
                    LogType.Healing => BoxBorder.Square,
                    _ => BoxBorder.None
                },
                Expand = false,
                Padding = new Padding(1, 0, 1, 0)
            };


            panel.BorderStyle = type switch
            {
                LogType.Enemy => EnemyStyle,
                LogType.Friendly => FriendlyStyle,
                LogType.Critical => CriticalStyle,
                LogType.Healing => HealingStyle,
                _ => NarratorStyle
            };

            AnsiConsole.Write(panel);
        }

        public static void TestEmojiSupport()
        {
            try
            {
                var testEmoji = Emoji.Known.Dragon;
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

        public static CanvasImage GenerateCharacterImage(string filePath)
        {
            using var image = SixLabors.ImageSharp.Image.Load<Rgba32>(filePath);
            image.Mutate(x => x.Resize(new SixLabors.ImageSharp.Size(20, 10)));

            var canvasImage = new CanvasImage(filePath);
            canvasImage.MaxWidth(20);
            canvasImage.MaxWidth(10);

            return canvasImage;
        }

        public static void DisplayCharacterStats(string name, int level, int health, int mana, string imagePath = null)
        {
            var layout = new Layout("Root")
                .SplitColumns(new Layout("Left"), new Layout("Right").SplitRows(new Layout("Top"), new Layout("Bottom")));

            layout["left"].Update(imagePath != null ? GenerateCharacterImage(imagePath) : new Panel("no image").Expand());

            layout["Right"]["Top"].Update(new Panel(Align.Center(new Markup($"[bold]{name}[/]\n [red]HP: {health}[/] | [green]Level: {level}[/] | [blue]MP: {mana}[/]"))).Expand());

            layout["RIght"]["Bottom"].Update(new Panel(Align.Center(new Markup("[gray]Special Attack[/]"))).Expand());

            AnsiConsole.Write(layout);
        }


        
    }
}

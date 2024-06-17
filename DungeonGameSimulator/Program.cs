using DungeonGameLogic;
using DungeonGameLogic.Characters; 

internal class Program
{
    private static void Main(string[] args)
    {
        GameEngine gameEngine = new GameEngine();

        gameEngine.StartGame();

        var character = gameEngine.CreateCharacter("Mage", "Favella", "Female", "WhiteMage");

        Team redTeam = gameEngine.CreateTeam("Red Team", isEnemy: true);
        Console.WriteLine($"{redTeam.Name} created with {redTeam.Members.Count} members.");

        Team blueTeam = gameEngine.CreateTeam("Blue Team", isEnemy: false);
        Console.WriteLine($"{blueTeam.Name} created with {blueTeam.Members.Count} members.");

        gameEngine.DisplayTeamMembers(redTeam);
        gameEngine.DisplayTeamMembers(blueTeam);
    }
}
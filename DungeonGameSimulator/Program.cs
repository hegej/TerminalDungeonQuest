using DungeonGameLogic;
using DungeonGameLogic.Characters; 

internal class Program
{
    private static void Main(string[] args)
    {
        GameEngine gameEngine = new GameEngine();

        gameEngine.StartGame();

        var character = gameEngine.CreateCharacter("Mage", "Favella", "Female", "WhiteMage");

        gameEngine.CreateEnemy();




    }
}
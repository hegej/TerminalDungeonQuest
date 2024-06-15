using DungeonGameLogic;
using DungeonGameLogic.Characters; 

internal class Program
{
    private static void Main(string[] args)
    {
        GameEngine gameEngine = new GameEngine();

        gameEngine.StartGame();

        var character = gameEngine.createCharacter();
        
        var enemy = gameEngine.CreateEnemy();




    }
}
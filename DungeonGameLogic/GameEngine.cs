using DungeonGameLogic.Characters;

namespace DungeonGameLogic
{
    public class GameEngine
    {
        public void StartGame()
        {
            Console.WriteLine("Game started!");
        }

        public Character CreateCharacter()
        {
            Console.WriteLine("Character created!");
            return new Character("Favella", 100, 15);
        }

        public void CreateEnemy()
        {
            Console.WriteLine("Enemy created!");
        }


    }
}

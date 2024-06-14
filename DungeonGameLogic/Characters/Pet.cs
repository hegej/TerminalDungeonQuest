namespace DungeonGameLogic.Characters
{

    public class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }

        public Pet(string petName, string petType, int petHealth = 60, int petAttack = 15)
        {
            Name = petName;
            Type = petType;
            Health = petHealth;
            Attack = petAttack;
        }
    }
}
}
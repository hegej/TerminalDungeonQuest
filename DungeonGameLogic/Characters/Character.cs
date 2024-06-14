namespace DungeonGameLogic.Characters
{ 

    public class Character
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public string SpecialAbility { get; set; } //pet for hunter, stealth for rouge, heal for white mage, summon for black mage...
        public int Speed { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int THAC0 { get; set; }

        public Character(string name, string gender, int health, int Strength, int defense, string specialAbility, int speed, int level, int experience, int thac0)
        {
            Name = name;
            Gender = gender;
            Health = health;
            SpecialAbility = specialAbility;
            Speed = speed;
            Defense = defense;
            Level = level;
            Experience = experience;
            THAC0 = thac0;
        }

        public void Attack(Character target)
        {
            throw new NotImplementedException();
        }
        public void Defend()
        {
            throw new NotImplementedException();
        }
        public void UseItem()
        {
            throw new NotImplementedException();
        }
        public void Move()
        {
            throw new NotImplementedException();
        }
        public void Jump()
        {
            throw new NotImplementedException();
        }
        public void Rest()
        {
            throw new NotImplementedException();
        }

    }
}



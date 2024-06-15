using DungeonGameLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGameLogic.Characters.Enemy
{
    public class Enemy
    {
        public EnemyType Type { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Level { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }

        public Enemy(EnemyType type, int health, int damage, int level, int defense, int speed)
        {
            Type = type;
            Health = health;
            Damage = damage;
            Level = level;
            Defense = defense;
            Speed = speed;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class PaladinParameters
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Health { get; set; } = 120;
        public int Strength { get; set; } = 20;
        public int Defense { get; set; } = 30;
        public string SpecialAbility { get; set; } = "Power of the Gods";
        public int Speed { get; set; } = 50;
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public int THAC0 { get; set; } = 16;

        public PaladinParameters(string name, string gender)
        {
            Name = name;
            Gender = gender;
        }

        public void CheckLevelAndUpdateAbility()
        {
            if (Level >= 10)
            {
                SpecialAbility = "Mjølnir, Hammer of Thor";  // Unlock special ability
            }
        }
    }
}
    }
}

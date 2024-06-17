using DungeonGameLogic.Enums;
using DungeonGameLogic.Abilities;

namespace DungeonGameLogic.Characters.CharacterParameters
{
    public class BaseCharacterParameters
    {
        public CharacterType Type { get; set; }
        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int ArmorClass { get; set; }
        public SpecialAbility SpecialAbility { get; set; }
        public int Speed { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int THAC0 { get; set; }
    }
}

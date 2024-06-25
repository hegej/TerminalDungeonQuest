using DungeonGameLogic.Characters.CharacterParameters;
using DungeonGameLogic.Abilities;

namespace DungeonGameLogic.Characters
{
    public class Warrior : Character
    {
        public List<WarriorSpecialAbility> Abilities { get; set; }
        public WarriorParameters WarriorParam { get; set; }

        public Warrior(WarriorParameters warriorParam)
            : base(warriorParam)
        {
            Abilities = warriorParam.Abilities;
            WarriorParam = warriorParam;
        }
    }
}
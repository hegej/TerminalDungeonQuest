using DungeonGameLogic.Characters.CharacterParameters;
using DungeonGameLogic.Abilities;

namespace DungeonGameLogic.Characters
{
    public class Warrior : Character
    {
        public List<WarriorSpecialAbility> Abilities { get; private set; }
        public WarriorParameters WarriorParam { get; private set; }

        public Warrior(WarriorParameters warriorParam)
            : base(warriorParam)
        {
            Abilities = warriorParam.Abilities;
            WarriorParam = warriorParam;
        }
    }
}
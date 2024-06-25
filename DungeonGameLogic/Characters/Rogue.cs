using DungeonGameLogic.Abilities;
using DungeonGameLogic.Characters.CharacterParameters;


namespace DungeonGameLogic.Characters
{
    public class Rogue : Character
    {
        public List<RogueSpecialAbility> Abilities { get; set; }
        public RogueParameters RogueParam { get; set; }

        public Rogue(RogueParameters rogueParam)
            : base(rogueParam)
        {
            Abilities = rogueParam.Abilities;
            RogueParam = rogueParam;
        }
    }
}
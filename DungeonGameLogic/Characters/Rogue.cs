using DungeonGameLogic.Abilities;
using DungeonGameLogic.Characters.CharacterParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGameLogic.Characters
{
    public class Rogue : Character
    {
        public List<RogueSpecialAbility> Abilities { get; private set; }
        public RogueParameters RogueParam { get; private set; }

        public Rogue(RogueParameters rogueParam)
            : base(rogueParam)
        {
            Abilities = rogueParam.Abilities;
            RogueParam = rogueParam;
        }
    }
}

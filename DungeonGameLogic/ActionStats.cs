using DungeonGameLogic.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGameLogic
{
    public class ActionStats
    {
        public Character Attacker { get; set; }
        public Character Target { get; set; }
        public int Roll { get; set; }
        public int RequiredRoll { get; set; }
        public int Damage { get; set; }
        public string Result { get; set; }
        public bool IsSpell { get; set; }
        public string SpellName { get; set; }
        public string Message { get; set; }
    }
}

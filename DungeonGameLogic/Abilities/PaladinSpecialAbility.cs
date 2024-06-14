using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGameLogic.Abilities
{
    public enum PaladinSpecialAbilityType
    {
        Mjolnir
    }

    public class PaladinSpecialAbility
    {
        public string AbilityName { get; private set; }
        public PaladinSpecialAbilityType Type { get; private set; }
        public int LevelRequired { get; private set; }
        public int EffectValue { get; private set; }
        public int Cooldown { get; private set; }

        public PaladinSpecialAbility()
        {
            AbilityName = "Mjølnir, Hammer of Thor";
            Type = PaladinSpecialAbilityType.Mjolnir;
            LevelRequired = 10;
            EffectValue = 100; 
            Cooldown = 60; 
        }

        //public bool CanUse(int currentLevel)
        //{
        //    return currentLevel >= LevelRequired;
        //}
    }
}

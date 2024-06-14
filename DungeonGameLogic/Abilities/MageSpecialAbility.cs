using DungeonGameLogic.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGameLogic.Abilities
{
    public enum MageSpecialAbilityType
    {
        SummonShiva,
        SummonBalrog
    }

    public class MageSpecialAbility
    {
        public string AbilityName { get; private set; }
        public MageSpecialAbilityType Type { get; private set; }
        public int LevelRequired { get; private set; }
        public int EffectValue { get; private set; }
        public int Cooldown { get; private set; }

        public MageSpecialAbility(MageType mageType)
        {
            LevelRequired = 10;
            Cooldown = 60; 

            if (mageType == MageType.WhiteMage)
            {
                AbilityName = "Summon Shiva Water Goddess";
                Type = MageSpecialAbilityType.SummonShiva;
                EffectValue = 100;
            }
            else if (mageType == MageType.BlackMage)
            {
                AbilityName = "Summon Balrog Fire Demon";
                Type = MageSpecialAbilityType.SummonBalrog;
                EffectValue = 100;
            }
        }

        //public bool CanUse(int currentLevel)
        //{
        //    return currentLevel >= LevelRequired;
        //}
    }
}
using DungeonGameLogic.Characters.CharacterParameters;

namespace DungeonGameLogic.Characters
{

    public class Paladin : Character
    {
        public Paladin(PaladinParameters parameters)
            : base(parameters.Name, parameters.Gender, parameters.Health, parameters.Strength, parameters.Defense, parameters.SpecialAbility, parameters.Speed, parameters.Level, parameters.Experience, parameters.THAC0)
        {
            parameters.CheckLevelAndUpdateAbility();
            SpecialAbility = parameters.SpecialAbility;
        }
    }
}

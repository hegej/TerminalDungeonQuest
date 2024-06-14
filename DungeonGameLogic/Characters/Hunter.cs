using DungeonGameLogic.Abilities;
using DungeonGameLogic.Characters.CharacterParameters;


namespace DungeonGameLogic.Characters

{
    public class Hunter : Character
    {
        public HunterSpecialAbilityPet Pet { get; private set; }
        public HunterParameters HunterParam { get; private set; }

        public Hunter(HunterParameters hunterParam) : base(hunterParam)
        {
            Pet = hunterParam.Pet;
            HunterParam = hunterParam;
        }
    }
}
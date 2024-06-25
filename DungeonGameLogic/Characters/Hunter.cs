using DungeonGameLogic.Abilities;
using DungeonGameLogic.Characters.CharacterParameters;


namespace DungeonGameLogic.Characters

{
    public class Hunter : Character
    {
        public HunterSpecialAbilityPet Pet { get; set; }
        public HunterParameters HunterParam { get; set; }

        public Hunter(HunterParameters hunterParam) : base(hunterParam)
        {
            Pet = hunterParam.Pet;
            HunterParam = hunterParam;
        }
    }
}
using DungeonGameLogic.Characters.CharacterParameters;


namespace DungeonGameLogic.Characters

{
    public class Hunter : Character
    {
        public Pet Pet { get; private set; }

        public Hunter(HunterParameters parameters)
            : base(parameters.Name, parameters.Gender,parameters.Health, parameters.Strength, parameters.Defense, $"Pet Ability: {parameters.Pet.Type}", parameters.Speed, parameters.Level, parameters.Experience, parameters.THAC0)
        {
            Pet = parameters.Pet;
        }
    }
}
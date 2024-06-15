using DungeonGameLogic.Characters.CharacterParameters;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters
{
    public class Character
    {
        public CharacterType Type { get; set; }
        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public string SpecialAbility { get; set; } //pet for hunter, stealth for rouge, heal for white mage, summon for black mage... TODO: Should this be a list of strings?
        public int Speed { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int THAC0 { get; set; }

        protected Character(BaseCharacterParameters CharacterParam)
        {
            Type = CharacterParam.Type;
            Name = CharacterParam.Name;
            Gender = CharacterParam.Gender;
            Health = CharacterParam.Health;
            Strength = CharacterParam.Strength;
            Defense = CharacterParam.Defense;
            SpecialAbility = CharacterParam.SpecialAbility;
            Speed = CharacterParam.Speed;
            Level = CharacterParam.Level;
            Experience = CharacterParam.Experience;
            THAC0 = CharacterParam.THAC0;
        }

        public void Attack(Character target)
        {
            throw new NotImplementedException();
        }
        public void Defend()
        {
            throw new NotImplementedException();
        }
        public void UseItem()
        {
            throw new NotImplementedException();
        }
        public void Move()
        {
            throw new NotImplementedException();
        }
        public void Jump()
        {
            throw new NotImplementedException();
        }
        public void Rest()
        {
            throw new NotImplementedException();
        }

    }
}



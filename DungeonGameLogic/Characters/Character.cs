using DungeonGameLogic.Abilities;
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
        public int MaxHealth { get; set; }
        public int Strength { get; set; }
        public int ArmorClass { get; set; }
        public SpecialAbility SpecialAbility { get; set; } //pet for hunter, stealth for rouge, heal for white mage, summon for black mage... TODO: Should this be a list of strings?
        public int Speed { get; set; }
        public int Initiative { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int THAC0 { get; set; }
        public bool IsAlive { get; set; }
        public string Team { get; set; }


        protected Character(BaseCharacterParameters CharacterParam)
        {
            Type = CharacterParam.Type;
            Name = CharacterParam.Name;
            Gender = CharacterParam.Gender;
            Health = CharacterParam.Health;
            Strength = CharacterParam.Strength;
            ArmorClass = CharacterParam.ArmorClass;
            SpecialAbility = CharacterParam.SpecialAbility;
            Speed = CharacterParam.Speed;
            Level = CharacterParam.Level;
            Experience = CharacterParam.Experience;
            THAC0 = CharacterParam.THAC0;
            IsAlive = true;
            Team = string.Empty;
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
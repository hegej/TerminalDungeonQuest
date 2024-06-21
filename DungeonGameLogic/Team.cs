using DungeonGameLogic.Characters;

namespace DungeonGameLogic
{
    public class Team
    {
        public string Name { get; private set; }
        public List<Character> Members { get; private set; }

        public Team(string name)
        {
            Name = name;
            Members = new List<Character>();
        }

        public void AddMember(Character character)
        {
            if (character != null)
            {
                Members.Add(character);
            }
        }

        public bool AliveMembers()
        {
            return Members.Any(member => member.IsAlive);
        }

        public Character ChooseRandomTarget()
        {
            var aliveMembers = Members.Where(m => m.IsAlive).ToList();
            if (aliveMembers.Count == 0)
                return null;

            int index = new Random().Next(aliveMembers.Count);
            return aliveMembers[index];
        }

        public void RemoveMember(Character character)
        {
            Members.Remove(character);
        }
    }
}

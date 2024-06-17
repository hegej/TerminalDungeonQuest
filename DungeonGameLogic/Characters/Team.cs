

namespace DungeonGameLogic.Characters
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

        public void AddMember(Character member)
        {
            Members.Add(member);
        }
    }
}

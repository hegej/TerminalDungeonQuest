using DungeonGameLogic.Characters;

namespace DungeonGameLogic
{
    public class Team
    {
        private static Random _random = new Random();
        public string Name { get; private set; }
        public int Priority { get; set; }
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
                character.Team = Name;
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
            var index = new Random().Next(aliveMembers.Count);
            return aliveMembers[index];
        }

        public void RemoveMember(Character character)
        {
            Members.Remove(character);
        }

        public IEnumerable<Character> GetAliveMembers()
        {
            return Members.Where(m => m.IsAlive);
        }

        public void ApplyTeamEffect(Action<Character> effect)
        {
            foreach (var member in GetAliveMembers())
            {
                effect(member);
            }
        }
    }
}

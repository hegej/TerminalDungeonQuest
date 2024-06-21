using DungeonGameLogic.Characters;

namespace DungeonGameLogic
{
    public class BattleEngine
    {
        private List<Team> _teams;
        private Random _random = new Random();
        private List<string> _battleLog = new List<string>();

        public BattleEngine(List<Team> teams)
        {
            if (teams.Count < 2)
            {
                throw new ArgumentException("Battle requires at least two teams.");
            }
            this._teams = teams;
        }

        public void SimulateBattle(List<Team> teams)
        {
            int round = 1;
            while (_teams.Count(t => t.AliveMembers()) > 1)
            {
                LogRoundStart(round);
                ExecuteRound();
                round++;
            }
            LoggBattleEnd();
        }

        
        private Character ChooseRandomTarget(List<Team> teams)
        {
            var availableTargets = teams.SelectMany(t => t.Members.Where(m => m.IsAlive)).ToList();
            if (!availableTargets.Any()) return null;

            int index = _random.Next(availableTargets.Count);
            return availableTargets[index];
        }

        public void ExecuteRound()
        {
            List<Character> allCharacters = _teams.SelectMany(t => t.GetAliveMembers()).ToList();
            allCharacters.Sort((a, b) => base.speed.CompareTo(a.Speed)); 
            var allCharacters = new List<(Character Character, Team Team)>();

            foreach (var team in teams)
            {

                var aliveMembers = team.Members.Where(m => m.IsAlive).ToList();

                foreach (var member in aliveMembers)
                {
                    allCharacters.Add((member, team));
                }
            }

            allCharacters = allCharacters.OrderBy(entry => entry.Character.Initiative).ToList();

            foreach (var entry in allCharacters)
            {
                var opponentTeams = teams.Where(t => t != entry.Team).ToList();
                var target = ChooseRandomTarget(opponentTeams);

                if (target != null)
                {
                    PerformAction(entry.Character, target);
                }
            }

            BattleLogger.Log("Round completed.");
        }


        private void PerformAction(Character attacker, Character target)
        {
            if (attacker is Mage mage && mage.CanCastSpell())
            {
                CastSpell(mage, target);
            }
            else
            {
                Attack(attacker, target);
            }
        }

        private void Attack(Character attacker, Character target)
        {
            int attackRoll = _random.Next(1, 21);
            int requiredRollToHit = attacker.THAC0 - target.ArmorClass;
            int damage = attackRoll >= requiredRollToHit ? Math.Max(0, attacker.Strength - target.Defense) : 0;

            target.Health -= damage;
            BattleLogger.LogAction($"{attacker.Name} attacks {target.Name} for {damage} damage" + (attackRoll >= requiredRollToHit ? "" : ", but missed"));
            if (target.Health <= 0)
            {
                target.IsAlive = false;
                BattleLogger.Log($"{target.Name} has been defeated!");
            }
        }

        private void CastSpell(Mage mage, Character target)
        {
            var spell = mage.Spells.FirstOrDefault(s => s.ManaCost <= mage.Mana);
            if (spell == null)
            {
                Attack(mage, target);
                return;
            }

            mage.Mana -= spell.ManaCost;
            int roll = _random.Next(1, 21);
            int requiredRoll = mage.THAC0 - target.ArmorClass;
            var damage = roll >= requiredRoll ? spell.EffectValue : 0;
            target.Health -= damage;

            BattleLogger.LogAction($"{mage.Name} cast {spell.SpellName} on {target.Name}, dealing {damage} damage" + (roll >= requiredRoll ? "" : ", but missed"));
            if (target.Health <= 0)
            {
                target.IsAlive = false;
                BattleLogger.Log($"{target.Name} has been defeated!");
            }
        }

        private void RegenerateMana(Character character)
        {
            if (character.GetType().GetProperty("ManaRegen") != null)
            {
                dynamic characterWithManaRegen = character;
                if (characterWithManaRegen.Mana < characterWithManaRegen.InitialMana)
                {
                    characterWithManaRegen.Mana = Math.Min(characterWithManaRegen.Mana + (int)characterWithManaRegen.ManaRegen, characterWithManaRegen.InitialMana);
                }
            }
        }
    }
}

using DungeonGameLogic.Abilities;
using DungeonGameLogic.Characters;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic
{
    public class BattleEngine
    {
        private List<Team> _teams;
        private Random _random = new Random();
        private List<string> _battleLog = new List<string>();
        private SimulationSpeed _speed;

        public BattleEngine(List<Team> teams, SimulationSpeed speed)
        {
            if (teams.Count < 2)
            {
                throw new ArgumentException("Battle requires at least two teams.");
            }

           _teams = teams;
           _speed = speed;
        }

        public void SimulateBattle()
        {
            var round = 1;
            while (_teams.Count(t => t.AliveMembers()) > 1)
            {
                BattleLogger.LogBattleRoundStart(round);
                ExecuteRound();
                round++;

                switch (_speed)
                {
                    case SimulationSpeed.Fast:
                        Thread.Sleep(100);
                        break;
                    case SimulationSpeed.Slow:
                        Thread.Sleep(500);
                        break;
                    case SimulationSpeed.Manual:
                        Console.WriteLine("Press Enter...");
                        Console.ReadLine();
                        break;
                }
            }
            LogBattleEnd();
        }


        private Character ChooseRandomTarget(List<Team> teams)
        {
            var availableTargets = teams.SelectMany(t => t.Members.Where(m => m.IsAlive)).ToList();
            if (!availableTargets.Any()) return null;

            var index = _random.Next(availableTargets.Count);
            return availableTargets[index];
        }

        public void ExecuteRound()
        {
            List<Character> allCharacters = _teams.SelectMany(t => t.GetAliveMembers()).ToList();

            allCharacters.Sort((a, b) =>
            {
                var initiativeComparison = a.Initiative.CompareTo(b.Initiative);
                if (initiativeComparison != 0) return initiativeComparison;

                var speedComparison = b.Speed.CompareTo(a.Speed);
                if (speedComparison != 0) return speedComparison;

                Team aTeam = _teams.First(t => t.Name == a.Team);
                Team bTeam = _teams.First(t => t.Name == b.Team);
                return aTeam.Priority.CompareTo(bTeam.Priority);
            });

            foreach (var attacker in allCharacters)
            {
                if (!attacker.IsAlive) continue;

                var opposingTeams = _teams.Where(t => t.Name != attacker.Team).ToList();
                var target = ChooseRandomTarget(opposingTeams);

                if (target == null) continue;

                PerformAction(attacker, target, allCharacters);
            }

            RegenerateMana();
            _battleLog.Add("Round completed.");
        }

        private void Attack(Character attacker, Character target)
        {
            var attackRoll = _random.Next(1, 21);
            var requiredRollToHit = attacker.THAC0 - target.ArmorClass;

            BattleLogger.Log($"{attacker.Name} needs to roll {requiredRollToHit} or higher to hit.\n Rolls: {attackRoll}");

            if (attackRoll >= requiredRollToHit)
            {
                var damage = Math.Max(1, _random.Next(1, attacker.Strength + 1));

                var previousHealth = target.Health;
                target.Health = Math.Max(0, target.Health - damage);

                BattleLogger.LogAction($"{attacker.Name} Hits {target.Name} for {damage} damage.\n {target.Name} has {target.Health} health remaining.");

                if (target.Health <= 0)
                {
                    target.IsAlive = false;
                    BattleLogger.Log($"{target.Name} is defeated!");
                }
            }
            else
            {
                BattleLogger.LogAction($"{attacker.Name} tries to attack {target.Name} bus missed!");
            }
        }

        private void PerformAction(Character attacker, Character randomTarget, List<Character> allCharacters)
        {
            if (attacker is Mage mage)
            {
                var (spell, target) = mage.ChooseSpellAndTarget(allCharacters);
                if (spell != null && target != null)
                {
                    CastSpell(mage, target, spell);
                }
                else
                {
                    Attack(mage, ChooseRandomTarget(_teams.Where(t => t.Name != mage.Team).ToList()));
                }
            }
            else
            {
                Attack(attacker, ChooseRandomTarget(_teams.Where(t => t.Name != attacker.Team).ToList()));
            }
        }

        private void CastSpell(Character caster, Character target, MageSpellPower spell)
        {
            var mana = 0;

            if (caster is Mage playerMage)
            {
                mana = playerMage.Mana;
            }

            else if (caster is Enemy enemyMage && enemyMage.EnemyType == EnemyType.Mage)
            {
                mana = enemyMage.enemyParameters.Mana;
            }

            else
            {
                Attack(caster, target);
                return;
            }

            if (mana < spell.ManaCost)
            {
                Attack(caster, target);
                return;
            }

            if (caster is Mage mage)
            {
                mage.Mana -= spell.ManaCost;
            }
            else if (caster is Enemy enemyCaster && enemyCaster.EnemyType == EnemyType.Mage)
            {
                enemyCaster.enemyParameters.Mana -= spell.ManaCost;
            }

            var roll = _random.Next(1, 21);
            var requiredRoll = caster.THAC0 - target.ArmorClass;

            BattleLogger.Log($"{caster.Name} tries to cast {spell.SpellName}. Need to roll {requiredRoll} or higher to hit.\n Rolls: {roll}");

            if (roll >= requiredRoll)
            {
                if (spell.Type == SpellType.Healing)
                {
                    var healAmount = spell.EffectValue;
                    var oldHealth = target.Health;
                    target.Health = Math.Min(target.MaxHealth, target.Health + healAmount);
                    var actualHeal = target.Health - oldHealth;
                    BattleLogger.LogAction($"{caster.Name} Cast {spell.SpellName} on {target.Name}, healing for {actualHeal}.\n {target.Name} now has {target.Health}/{target.MaxHealth} health.");
                }
                else
                {
                    var damage = spell.EffectValue;
                    target.Health = Math.Max(0, target.Health - damage);
                    BattleLogger.LogAction($"{caster.Name} cast {spell.SpellName} on {target.Name} dealing {damage} damage.\n {target.Name} now has {target.Health}/{target.MaxHealth} health remaining.");

                }

                if (target.Health <= 0)
                {
                    target.IsAlive = false;
                    BattleLogger.Log($"{target.Name} has been defeated!");
                }
            }
            else
            {
                BattleLogger.LogAction($"{caster.Name} tried to cast {spell.SpellName} on {target.Name} but missed!");
            }

            var remainingMana = (caster is Mage mageCaster) ? mageCaster.Mana :
                                (caster is Enemy enemy && enemy.EnemyType == EnemyType.Mage) ? enemy.enemyParameters.Mana : 0;
            BattleLogger.Log($"{caster.Name} has {remainingMana} mana remaining.");
        }

        private void RegenerateMana()
        {
            foreach (var team in _teams)
            {
                foreach (var character in team.Members)
                {
                    if (character is Mage mage)
                    {
                        mage.Mana = Math.Min(mage.Mana + mage.ManaRegen, mage.InitialMana);
                        BattleLogger.Log($"{mage.Name} Regenerated {mage.ManaRegen} mana. Current mana: {mage.Mana}");
                    }
                    else if (character is Enemy enemy && enemy.EnemyType == EnemyType.Mage)
                    {
                        enemy.enemyParameters.Mana = Math.Min(enemy.enemyParameters.Mana + enemy.enemyParameters.ManaRegen, enemy.enemyParameters.InitialMana);
                        BattleLogger.Log($"{enemy.Name} Regenerated {enemy.enemyParameters.ManaRegen} mana. Current mana: {enemy.enemyParameters.Mana}");
                    }
                }
            }
        }

        private void LogBattleEnd()
        {
            var winningTeam = _teams.FirstOrDefault(t => t.AliveMembers());
            BattleLogger.LogBattleOutcome($"Battle has ended! {winningTeam?.Name} is the winner!");
        }
    }
}


using DungeonGameLogic.Abilities;
using DungeonGameLogic.Characters;
using DungeonGameLogic.Enums;
using DungeonGameLogic.Interfaces;

namespace DungeonGameLogic
{
    public class BattleEngine
    {
        private List<Team> _teams;
        private Random _random = new Random();
        private SimulationSpeed _speed;
        private IBattleLogger _logger;

        public BattleEngine(List<Team> teams, SimulationSpeed speed, IBattleLogger logger)
        {
            if (teams.Count < 2)
            {
                throw new ArgumentException("Battle requires at least two teams.");
            }

            _teams = teams;
            _speed = speed;
            _logger = logger;
        }

        public void SimulateBattle()
        {
            _logger.LogBattleStart();

            foreach (var team in _teams)
            {
                foreach (var character in team.Members)
                {
                    _logger.DisplayCharacterStats(character);
                }
            }

            _logger.LogAction("Displaying character stats. Battle will begin in 1 second...", LogType.Normal, "");
            Thread.Sleep(1000);

            var round = 1;
            while (_teams.Count(t => t.AliveMembers()) > 1)
            {
                _logger.LogAction($"Round {round} begins", LogType.Normal, "");
                ExecuteRound();
                round++;

                switch (_speed)
                {
                    case SimulationSpeed.Fast:
                        Thread.Sleep(100);
                        break;
                    case SimulationSpeed.Slow:
                        Thread.Sleep(1000);
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
            _logger.LogAction("Round completed.", LogType.Normal, "");
        }

        private void Attack(Character attacker, Character target)
        {
            var attackRoll = _random.Next(1, 21);
            var requiredRollToHit = attacker.THAC0 - target.ArmorClass;

            _logger.LogAction($"{attacker.Name} needs to roll {requiredRollToHit} or higher to hit. Rolls: {attackRoll}",
            attacker.Team == _teams[0].Name ? LogType.Enemy : LogType.Friendly, "Attack");

            if (attackRoll >= requiredRollToHit)
            {
                var damage = Math.Max(1, _random.Next(1, attacker.Strength + 1));

                var previousHealth = target.Health;
                target.Health = Math.Max(0, target.Health - damage);

                _logger.LogAction($"{attacker.Name} Hits {target.Name} for {damage} damage. {target.Name} has {target.Health} health remaining.",
                attacker.Team == _teams[0].Name ? LogType.Enemy : LogType.Friendly, "Attack");

                if (target.Health <= 0)
                {
                    target.IsAlive = false;
                    _logger.LogAction($"{target.Name} is defeated!", LogType.Critical, "Death");
                }
            }
            else
            {
                _logger.LogAction($"{attacker.Name} tries to attack {target.Name} but missed!",
                attacker.Team == _teams[0].Name ? LogType.Enemy : LogType.Friendly, "Attack");
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

            _logger.LogAction($"{caster.Name} tries to cast {spell.SpellName}. Need to roll {requiredRoll} or higher to hit. Rolls: {roll}",
            caster.Team == _teams[0].Name ? LogType.Enemy : LogType.Friendly, "Spell");

            if (roll >= requiredRoll)
            {
                if (spell.Type == SpellType.Healing)
                {
                    var healAmount = spell.EffectValue;
                    var oldHealth = target.Health;
                    target.Health = Math.Min(target.MaxHealth, target.Health + healAmount);
                    var actualHeal = target.Health - oldHealth;
                    _logger.LogAction($"{caster.Name} Cast {spell.SpellName} on {target.Name}, healing for {actualHeal}. {target.Name} now has {target.Health}/{target.MaxHealth} health.",
                    LogType.Healing, "Heal");
                }
                else
                {
                    var damage = spell.EffectValue;
                    target.Health = Math.Max(0, target.Health - damage);
                    _logger.LogAction($"{caster.Name} cast {spell.SpellName} on {target.Name} dealing {damage} damage. {target.Name} now has {target.Health}/{target.MaxHealth} health remaining.",
                    caster.Team == _teams[0].Name ? LogType.Enemy : LogType.Friendly, "Spell");
                }

                if (target.Health <= 0)
                {
                    target.IsAlive = false;
                    _logger.LogAction($"{target.Name} has been defeated!", LogType.Critical, "Death");
                }
            }
            else
            {
                _logger.LogAction($"{caster.Name} tried to cast {spell.SpellName} on {target.Name} but missed!",
                caster.Team == _teams[0].Name ? LogType.Enemy : LogType.Friendly, "Spell");
            }

            var remainingMana = (caster is Mage mageCaster) ? mageCaster.Mana :
                                (caster is Enemy enemy && enemy.EnemyType == EnemyType.Mage) ? enemy.enemyParameters.Mana : 0;
            _logger.LogAction($"{caster.Name} has {remainingMana} mana remaining.", LogType.Normal, "");
        }

        private void RegenerateMana()
        {
            foreach (var team in _teams)
            {
                foreach (var character in team.Members)
                {
                    if (!character.IsAlive) continue;

                    if (character is Mage mage)
                    {
                        mage.Mana = Math.Min(mage.Mana + mage.ManaRegen, mage.InitialMana);
                        _logger.LogAction($"{mage.Name} Regenerated {mage.ManaRegen} mana. Current mana: {mage.Mana}", LogType.Normal, "ManaRegen");
                    }
                    else if (character is Enemy enemy && enemy.EnemyType == EnemyType.Mage)
                    {
                        enemy.enemyParameters.Mana = Math.Min(enemy.enemyParameters.Mana + enemy.enemyParameters.ManaRegen, enemy.enemyParameters.InitialMana);
                        _logger.LogAction($"{enemy.Name} Regenerated {enemy.enemyParameters.ManaRegen} mana. Current mana: {enemy.enemyParameters.Mana}", LogType.Normal, "ManaRegen");
                    }
                }
            }
        }

        private void LogBattleEnd()
        {
            var winningTeam = _teams.FirstOrDefault(t => t.AliveMembers());
            _logger.LogBattleEnd(winningTeam?.Name ?? "No winner (Draw)");
        }
    }
}
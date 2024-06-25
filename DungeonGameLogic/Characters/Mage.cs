using DungeonGameLogic.Abilities;
using DungeonGameLogic.Characters.CharacterParameters;
using DungeonGameLogic.Enums;

namespace DungeonGameLogic.Characters
{
    public class Mage : Character
    {
        public int Mana { get; set; }
        public int InitialMana { get; set; }
        public int ManaRegen { get; set; }
        public List<MageSpellPower> Spells { get; set; }
        public MageParameters MageParam { get; set; }
        public MageType Type { get; }

        public Mage(MageParameters mageParam) : base(mageParam)
        {
            Mana = mageParam.Mana;
            InitialMana = mageParam.InitialMana;
            ManaRegen = mageParam.ManaRegen;
            MageParam = mageParam;
            Type = mageParam.Type;
            Spells = new List<MageSpellPower>();
            InitializeSpellPower();
        }

        public bool CanCastSpell()
        {
            return Spells.Any(spell => Mana >= spell.ManaCost);
        }

        private void InitializeSpellPower()
        {
            switch (Type)
            {
                case MageType.WhiteMage:
                    Spells.Add(new MageSpellPower(SpellType.Healing, "Minor Heal", spellLevel: 1, effectValue: 5, manaCost: 10));
                    Spells.Add(new MageSpellPower(SpellType.Water, "Tidal Wave", spellLevel: 1, effectValue: 5, manaCost: 10));
                    break;
                case MageType.BlackMage:
                    Spells.Add(new MageSpellPower(SpellType.Fire, "Fireball", spellLevel: 1, effectValue: 5, manaCost: 10));
                    Spells.Add(new MageSpellPower(SpellType.Earth, "Earth Tremor", spellLevel: 1, effectValue: 5, manaCost: 10));
                    break;
                default:
                    throw new ArgumentException("A valid MageType must be selected.");
            }
        }

        public (MageSpellPower Spell, Character Target) ChooseSpellAndTarget(List<Character> allCharacters)
        {
            if (Mana < Spells.Min(s => s.ManaCost))
            {
                return (null, null);
            }

            var healSpell = Spells.FirstOrDefault(s => s.Type == SpellType.Healing);
            var damageSpell = Spells.FirstOrDefault(s => s.Type != SpellType.Healing);

            if (healSpell != null && Mana >= healSpell.ManaCost)
            {
                var healTarget = ChooseHealTarget(allCharacters);

                if (healTarget != null)
                {
                    return (healSpell, healTarget);
                }
            }

            if (damageSpell != null && Mana >= damageSpell.ManaCost)
            {
                var enemyTargets = allCharacters.Where(c => c.Team != this.Team && c.IsAlive).ToList();
                if (enemyTargets.Any())
                {
                    return (damageSpell, enemyTargets[new Random().Next(enemyTargets.Count)]);
                }
            }

            return (null, null);
        }

        private Character ChooseHealTarget(List<Character> allCharacters)
        {
            var alliesNeedHealing = allCharacters.Where(c => c.Team == this.Team && c.IsAlive && c.Health < c.MaxHealth * 0.5).ToList();

            if (!alliesNeedHealing.Any())
            {
                return null;
            }

            int lowestHealth = alliesNeedHealing.Min(c => c.Health);
            var mostInjuredAllies = alliesNeedHealing.Where(c => c.Health == lowestHealth).ToList();

            if (mostInjuredAllies.Count == 1)
            {
                return mostInjuredAllies[0];
            }

            var injuredMages = mostInjuredAllies.Where(c => c is Mage).ToList();

            if (injuredMages.Any())
            {
                return injuredMages.OrderByDescending(c => c.ArmorClass).First();
            }

            return mostInjuredAllies.OrderByDescending(c => c.ArmorClass).First();
        }


        public string PerformSummon()
        {
            if (Level < 10)
            {
                return "Summoning ability not yet available.";
            }

            if (Type == MageType.WhiteMage)
            {
                return "Summoning Shiva Water Goddess";
            }
            else
            {
                return "Summoning Balrog Fire Demon";
            }
        }
    }
}
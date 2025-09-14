using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Abilities;
using TestovoeLesta.Weapons;

namespace TestovoeLesta.Characters.Heroes
{
    public abstract class Hero : Character
    {
        private List<Hero> _additionalClasses = new();

        public IEnumerable<Hero> Classes => _additionalClasses;

        protected Hero(Weapon weapon, int agility, int strength, int stamina, float maxHealth, float damage, List<IAbility> abilities) : base(weapon, agility, strength, stamina, maxHealth, damage, abilities)
        {
        }

        public override void LevelUp()
        {
            base.LevelUp();

            CharacterAbilities[Level - 1].IsOpened = true;

            foreach (var extraAbility in CharacterAbilities)
            {
                if (extraAbility is ISpecificationAbility ability && extraAbility.IsOpened)
                {
                    var damage = Damage;
                    ability.Activate(this);
                }
            }

            foreach (var additionalClass in _additionalClasses)
            {
                foreach (var extraAbility in additionalClass.CharacterAbilities)
                {
                    if (extraAbility is ISpecificationAbility ability  && extraAbility.IsOpened)
                    {
                        var damage = Damage;
                        ability.Activate(this);
                    }
                }
            }
        }


        public override void TakeDamage(float Damage, Character attacker)
        {
            foreach (var ability in CharacterAbilities)
            {
                if (ability is DefenceAbility && ability.IsOpened)
                {
                        ability.Activate(this, attacker, Game.CurrentFightTurn, ref Damage);
                }
            }

            foreach (var additionalClass in _additionalClasses)
            {
                foreach(var ability in additionalClass.CharacterAbilities)
                {
                    if (ability is DefenceAbility && ability.IsOpened)
                    {
                        ability.Activate(this, attacker, Game.CurrentFightTurn, ref Damage);
                    }
                }
            }

            base.TakeDamage(Damage, attacker);
        }

        public override void Attack(IDamagable target)
        {
            var targetDamage = Damage + Weapon.Damage;

            foreach (var ability in CharacterAbilities)
            {
                if (ability is AttackAbility)
                {
                    if (ability.IsOpened)
                        ability.Activate(this, (Character)target, Game.CurrentFightTurn, ref targetDamage);
                }
            }

            foreach (var additionalClass in _additionalClasses)
            {
                foreach (var ability in additionalClass.CharacterAbilities)
                {
                    if (ability is AttackAbility && ability.IsOpened)
                    {
                        ability.Activate(this, (Character)target, Game.CurrentFightTurn, ref targetDamage);
                    }
                }
            }

            target.TakeDamage(targetDamage, this);
        }

        public void TakeWeapon(Weapon weapon)
        {
            Weapon = weapon;
        }


        public void AddNewClass(Hero newClass)
        {
            _additionalClasses.Add(newClass);
        }

        public int SummaryLevel()
        {
            var sum = Level;

            foreach (var extraClass in _additionalClasses)
                sum += extraClass.Level;

            return sum;
        }
    }
}

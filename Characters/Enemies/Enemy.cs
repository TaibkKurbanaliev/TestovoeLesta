using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Abilities;
using TestovoeLesta.Weapons;

namespace TestovoeLesta.Characters.Enemies
{
    public abstract class Enemy : Character
    {
        public Enemy(Weapon weapon, int agility, int strength, int stamina, float maxHealth, float damage, List<IAbility> abilities) : base(weapon, agility, strength, stamina, maxHealth, damage, abilities)
        {
            foreach(var ability in CharacterAbilities)
            {
                ability.IsOpened = true;
            }
        }

        public override void TakeDamage(float Damage, Character attacker)
        {
            foreach (var ability in CharacterAbilities)
            {
                if (ability is DefenceAbility)
                {
                    if (ability.IsOpened)
                        ability.Activate(this, attacker, Game.CurrentFightTurn, ref Damage);
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
                        ability.Activate(this, (Character) target, Game.CurrentFightTurn, ref targetDamage);
                }
            }

            target.TakeDamage(targetDamage, this);
        }

        public Weapon DropItem()
        {
            return WeaponFactory.Get(Enum.Parse<WeaponType>(Weapon.GetType().Name));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Abilities;
using TestovoeLesta.Weapons;

namespace TestovoeLesta.Characters.Enemies
{
    public class Dragon : Enemy
    {
        public Dragon(Weapon weapon, int agility, int strength, int stamina, float maxHealth, float damage, List<IAbility> abilities) : base(weapon, agility, strength, stamina, maxHealth, damage, abilities)
        {
        }

        public override void Attack(IDamagable target)
        {
            var targetDamage = Damage + Weapon.Damage;

            if (Game.CurrentFightTurn % 3 == 0)
                targetDamage += 3;

            foreach (var ability in CharacterAbilities)
            {
                if (ability is AttackAbility)
                {
                    if (ability.IsOpened)
                        ability.Activate(this, (Character)target, Game.CurrentFightTurn, ref targetDamage);
                }
            }

            target.TakeDamage(targetDamage, this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Abilities;
using TestovoeLesta.Weapons;

namespace TestovoeLesta.Characters.Enemies
{
    public class Skeleton : Enemy
    {
        public Skeleton(Weapon weapon, int agility, int strength, int stamina, float maxHealth, float damage, List<IAbility> abilities) : base(weapon, agility, strength, stamina, maxHealth, damage, abilities)
        {
        }

        public override void TakeDamage(float Damage, Character attacker)
        {
            var crushingDamageMultiplier = 2;

            if (attacker.Weapon.DamageType == DamageType.Crushing && attacker != null)
                base.TakeDamage(Damage * crushingDamageMultiplier, attacker);
            else
                base.TakeDamage(Damage, attacker);
        }
    }
}

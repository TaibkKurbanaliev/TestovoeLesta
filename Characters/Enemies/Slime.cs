using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Abilities;
using TestovoeLesta.Weapons;

namespace TestovoeLesta.Characters.Enemies
{
    public class Slime : Enemy
    {
        public Slime(Weapon weapon, int agility, int strength, int stamina, float maxHealth, float damage, List<IAbility> abilities) : base(weapon, agility, strength, stamina, maxHealth, damage, abilities)
        {
        }

        public override void TakeDamage(float Damage, Character attacker)
        {
            if (attacker.Weapon.DamageType == DamageType.Slashing)
                base.TakeDamage(Damage - attacker.Weapon.Damage, attacker);
            else
                base.TakeDamage(Damage, attacker);
        }
    }
}

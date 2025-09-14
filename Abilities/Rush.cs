using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Characters;

namespace TestovoeLesta.Abilities
{
    public class Rush : AttackAbility
    {
        public int DamageMultiplier {  get; private set; }

        public Rush(int damageMultiplier = 2)
        {
            DamageMultiplier = damageMultiplier;
        }

        public override void Activate(Character owner, Character target, int turn, ref float damage)
        {
            damage += owner.Weapon.Damage;
        }
    }
}

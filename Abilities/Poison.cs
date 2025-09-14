using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Characters;

namespace TestovoeLesta.Abilities
{
    public class Poison : AttackAbility
    {
        public int Damage { get; private set; }

        public Poison(int damage = 1)
        {
            Damage = damage;
        }

        public override void Activate(Character owner, Character target, int turn, ref float damage)
        {
            target.TakeDamage(Damage + turn - 1, null);
        }
    }
}

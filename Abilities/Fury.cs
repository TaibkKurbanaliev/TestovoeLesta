using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Characters;

namespace TestovoeLesta.Abilities
{
    public class Fury : AttackAbility
    {
        public float Damage { get; private set; }

        public Fury(float damage = 2)
        {
            Damage = damage;
        }

        public override void Activate(Character owner, Character target, int turn, ref float damage)
        {
            if (turn <= 3)
                damage += 2;
        }
    }
}

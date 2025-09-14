using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Characters;

namespace TestovoeLesta.Abilities
{
    public abstract class AttackAbility : IAbility
    {
        public bool IsOpened { get ; set; }

        public virtual void Activate(Character owner, Character target, int turn, ref float damage)
        {
        }
    }
}

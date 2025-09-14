using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Characters;

namespace TestovoeLesta.Abilities
{
    public class Shield : DefenceAbility
    {
        public float DefenceValue { get; private set; }

        public Shield(float defenceValue = 3)
        {
            DefenceValue = defenceValue;
        }

        public override void Activate(Character owner, Character target, int turn, ref float damage)
        {
            if (owner.Strength > target.Strength)
            {
                damage -= DefenceValue;
            }
        }
    }
}

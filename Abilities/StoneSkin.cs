using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Characters;

namespace TestovoeLesta.Abilities
{
    public class StoneSkin : DefenceAbility
    {
        public override void Activate(Character owner, Character target, int turn, ref float damage)
        {
            damage -= owner.Agility;
        }
    }
}

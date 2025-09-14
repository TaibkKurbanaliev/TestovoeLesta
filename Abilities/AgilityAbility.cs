using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Characters;

namespace TestovoeLesta.Abilities
{
    public class AgilityAbility : ISpecificationAbility
    {
        public bool IsOpened { get; set; }  

        public void Activate(Character owner)
        {
            owner.AddAgility();
        }

        public void Activate(Character owner, Character target, int turn, ref float damage)
        {
        }
    }
}

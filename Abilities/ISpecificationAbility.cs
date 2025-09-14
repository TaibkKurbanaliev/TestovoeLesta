using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Characters;

namespace TestovoeLesta.Abilities
{
    public interface ISpecificationAbility : IAbility
    {
        void Activate(Character owner);
    }
}

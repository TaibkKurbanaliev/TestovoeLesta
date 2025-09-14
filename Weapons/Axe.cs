using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeLesta.Weapons
{
    public class Axe : Weapon
    {
        public Axe(int damage = 4) : base(damage, DamageType.Slashing, nameof(Axe))
        {
        }
    }
}

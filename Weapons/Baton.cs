using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeLesta.Weapons
{
    public class Baton : Weapon
    {
        public Baton(int damage = 4, DamageType damageType = DamageType.Crushing) : base(damage, damageType, nameof(Axe))
        {
        }
    }
}

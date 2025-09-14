using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeLesta.Weapons
{
    public class Dagger : Weapon
    {
        public Dagger(int damage = 2, DamageType damageType = DamageType.Piercing) : base(damage, damageType, nameof(Dagger))
        {
        }
    }
}

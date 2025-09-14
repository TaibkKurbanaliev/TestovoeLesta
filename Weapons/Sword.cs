using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeLesta.Weapons
{
    public class Sword : Weapon
    {
        public Sword(int damage = 3, DamageType damageType = DamageType.Slashing) : base(damage, damageType, nameof(Sword))
        {
        }
    }
}

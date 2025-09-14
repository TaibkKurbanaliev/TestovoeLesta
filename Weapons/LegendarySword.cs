using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeLesta.Weapons
{
    public class LegendarySword : Weapon
    {
        public LegendarySword(int damage = 10, DamageType damageType = DamageType.Slashing) : base(damage, damageType, nameof(LegendarySword))
        {
        }
    }
}

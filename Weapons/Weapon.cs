using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeLesta.Weapons
{
    public abstract class Weapon
    {
        public int Damage { get; private set; }
        public DamageType DamageType { get; private set; }
        public string Name { get; private set; }

        public Weapon(int damage, DamageType type, string name)
        {
            Damage = damage;
            DamageType = type;
            Name = name;
        }
    }

    public enum DamageType
    {
        Slashing,
        Crushing,
        Piercing
    }
}

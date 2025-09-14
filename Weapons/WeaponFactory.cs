using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeLesta.Weapons
{
    public static class WeaponFactory
    {
        public static Weapon Get(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Axe:
                    return new Axe();
                case WeaponType.Baton:
                    return new Baton();
                case WeaponType.Dagger:
                    return new Dagger();
                case WeaponType.Spear:
                    return new Spear();
                case WeaponType.Sword:
                    return new Sword();
                case WeaponType.LegendarySword:
                    return new LegendarySword();
                default:
                    throw new NotImplementedException(nameof(type));
            }
        }
    }

    public enum WeaponType
    {
        Axe,
        Baton, 
        Dagger,
        Spear,
        Sword,
        LegendarySword
    }
}

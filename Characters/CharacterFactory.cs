using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Abilities;
using TestovoeLesta.Characters.Enemies;
using TestovoeLesta.Characters.Heroes;
using TestovoeLesta.Weapons;

namespace TestovoeLesta.Characters
{
    public class CharacterFactory
    {

        public Enemy GetEnemy(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Godbiln:
                    return new Goblin(new Dagger(2), 1, 1, 1, 5, 0, new List<IAbility> { });
                case EnemyType.Skeleton:
                    return new Skeleton(new Baton(2), 2, 2, 1, 10, 0, new List<IAbility> { });
                case EnemyType.Slime:
                    return new Slime(new Spear(1), 1, 3, 2, 8, 0, new List<IAbility> { }); 
                case EnemyType.Ghost:
                    return new Ghost(new Sword(3), 3, 1, 1, 6, 0, new List<IAbility> { new HiddenAttack() });
                case EnemyType.Golem:
                    return new Golem(new Axe(1), 1, 3, 3, 10, 0, new List<IAbility> { new StoneSkin() });
                case EnemyType.Dragon:
                    return new Dragon(new LegendarySword(4), 3,3,3, 20, 0, new List<IAbility> { });
                default:
                    throw new NotImplementedException(nameof(type));
            }
        }

        public Hero GetHero(HeroType type)
        {
            var minValue = 1;
            var maxValue = 3;
            var random = new Random();
            var agility = random.Next(minValue, maxValue + 1);
            var strength = random.Next(minValue, maxValue + 1);
            var stamina = random.Next(minValue, maxValue + 1);

            switch (type)
            {
                case HeroType.Robber:
                    return new Robber(new Dagger(), agility, strength, stamina, 4, 0, new List<IAbility> { new HiddenAttack(), new AgilityAbility(), new Poison() });
                case HeroType.Barbarian:
                    return new Barbarian(new Baton(), agility, strength, stamina, 6, 0, new List<IAbility> { new Fury(), new StoneSkin(), new StrenghtAbility() });
                case HeroType.Warrior:
                    return new Warrior(new Sword(), agility, strength, stamina, 5, 0, new List<IAbility> { new Rush(), new Shield(), new StaminaAbility() });
                default:
                    throw new NotImplementedException(nameof(type));
            }
        }
    }

    public enum EnemyType
    {
        Godbiln = 1,
        Skeleton,
        Slime,
        Ghost,
        Golem,
        Dragon
    }

    public enum HeroType
    {
        Warrior = 1,
        Robber,
        Barbarian
    }
}

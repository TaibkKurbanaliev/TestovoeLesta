using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Abilities;
using TestovoeLesta.Weapons;

namespace TestovoeLesta.Characters
{
    public abstract class Character : IDamagable
    {
        private float _damage;
        private float _maxHealth;
        private float _healthPerLevel;

        public Weapon Weapon { get; protected set; }
        public int Level { get; protected set; }
        public int Agility { get; protected set; }
        public int Strength { get; protected set; }
        public int Stamina { get; protected set; }
        public float Health { get; protected set; }
        public bool IsDead => Health <= 0;

        protected readonly List<IAbility> CharacterAbilities;

        public float Damage 
        { 
            get => _damage + Strength;
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _damage = value;
            }
        }

        public Character(Weapon weapon, int agility, int strength, int stamina, float healthPerLevel, float damage, List<IAbility> abilities)
        {
            Level = 0;
            Weapon = weapon;
            Agility = agility;
            Strength = strength;
            Stamina = stamina;
            _healthPerLevel = healthPerLevel;
            Damage = damage;
            CharacterAbilities = abilities;
            LevelUp();
            ResetHealth();
        }
        public virtual void Attack(IDamagable target)
        {

        }

        public virtual void LevelUp()
        {
            Level++;
            _maxHealth += _healthPerLevel + Stamina;
        }

        public void ResetHealth()
        {
            Health = _maxHealth;
        }

        public virtual void TakeDamage(float Damage, Character attacker)
        {

            if (Damage < 0)
                Damage = 0;

            Health -= Damage;
        }

        public void AddAgility() => Agility++;
        public void AddStrenght() => Strength++;
        public void AddStamina() => Stamina++;

    }
}

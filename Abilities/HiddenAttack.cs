using TestovoeLesta.Characters;

namespace TestovoeLesta.Abilities
{
    public class HiddenAttack : AttackAbility
    {
        public int Damage {  get; private set; }
        public HiddenAttack(int damage = 1)
        {
            Damage = damage;
        }

        public override void Activate(Character owner, Character target, int turn, ref float damage)
        {
            if (owner.Agility > target.Agility)
                damage++;
        }
    }
}

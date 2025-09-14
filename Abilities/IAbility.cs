using TestovoeLesta.Characters;

namespace TestovoeLesta.Abilities
{
    public interface IAbility
    {
        public bool IsOpened { get; set; }
        void Activate(Character owner, Character target, int turn, ref float damage);
    }
}

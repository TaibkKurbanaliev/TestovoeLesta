using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeLesta.Abilities
{
    public class Modifier
    {

        public event Action<int> Modified;

        public void Modify(ref int modifyValue, int amount)
        {
            modifyValue += amount;
            Modified?.Invoke(modifyValue);
        }
    }
}

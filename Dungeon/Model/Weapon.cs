using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_and_D_demo.Model
{
    public class Weapon
    {
        public string WeaponName { get; set; }
        public DemageDice Demage { get; set; }
        public int DemageMod { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_and_D_demo.Model
{
    public class Creature
    {
        public string CreatureName { get; set; }
        public Weapon CreatureWeapon { get; set; }
        public int CreatureArmor { get; set; }
        public int CreatureAttackMod { get; set; }
        public int CreatureHitPoints { get; set; }
        public int CreatureLevel { get; set; } 
        public int Initiative { get; set; }
    }
}

using D_and_D_demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    class Hero
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public string HeroName{ get; set; }
        public int HeroHitPoints { get; set; }
        public int HeroLevel { get; set; }
        public Weapon HeroWeapon { get; set; }
        public int HeroArmor { get; set; }
        public int HeroAttackMod { get; set; }
        public bool KeyAvailability { get; set; }
    }
}

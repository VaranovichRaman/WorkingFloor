using D_and_D_demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    class CreateHero
    {
        Hero newHero = new Hero();
        public void HeroCreation()
        {
            newHero.HeroWeapon.WeaponName = "sword";
            newHero.HeroWeapon.Demage.NumberOfDices = 1;
            newHero.HeroWeapon.Demage.SizeOfDice = (DiceSize)int.Parse(8.ToString());
            newHero.HeroName = Console.ReadLine();
            newHero.HeroHitPoints = 20;
        }
        
        
    }
}

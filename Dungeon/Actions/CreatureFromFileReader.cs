using D_and_D_demo.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_and_D_demo.Actions
{
    class CreatureFromFileReader
    {
        public List<Creature> CreateCreatureList()
        {
            List<Creature> creatureList = new List<Creature>();
            string[] separators = { "***" };
            var creaturesZip = File.ReadAllLines("CreatureList.txt", Encoding.Default);
            foreach (var creaturePick in creaturesZip)
            {
                Creature creature = new Creature();
                creature.CreatureWeapon = new Weapon();
                creature.CreatureWeapon.Demage = new DemageDice();
                creature.CreatureWeapon.Demage.SizeOfDice = new DiceSize();
                string[] splitedStats = creaturePick.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                creature.CreatureName = splitedStats[0];
                creature.CreatureArmor = int.Parse(splitedStats[1]);
                creature.CreatureAttackMod = int.Parse(splitedStats[2]);
                creature.CreatureHitPoints = int.Parse(splitedStats[3]);
                creature.CreatureLevel = int.Parse(splitedStats[4]);
                creature.CreatureWeapon.WeaponName = splitedStats[5];
                creature.CreatureWeapon.DemageMod = int.Parse(splitedStats[6]);
                creature.CreatureWeapon.Demage.NumberOfDices = int.Parse(splitedStats[7]);
                creature.CreatureWeapon.Demage.SizeOfDice = (DiceSize)int.Parse(splitedStats[8]);
                creatureList.Add(creature);
            }
            return creatureList;
        }    
    }
}

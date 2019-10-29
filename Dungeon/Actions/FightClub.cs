using D_and_D_demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_and_D_demo.Actions
{
    class FightClub
    {
        CreatureFromFileReader creature = new CreatureFromFileReader();
        Random diceRandom = new Random();
        public void RandomFight()
        {
            Creature firstFighter = creature.CreateCreatureList().ElementAt(
                diceRandom.Next(0, creature.CreateCreatureList().Count));
            Creature secondFighter = creature.CreateCreatureList().ElementAt(
                diceRandom.Next(0, creature.CreateCreatureList().Count));
            firstFighter.Initiative = diceRandom.Next(1, 20);
            secondFighter.Initiative = diceRandom.Next(1, 20);
            Console.WriteLine($"\nIniciative of {firstFighter.CreatureName}: {firstFighter.Initiative}." +
                $"Iniciative of {secondFighter.CreatureName}: {secondFighter.Initiative}.\n");
            Console.WriteLine($"\nHP1: {firstFighter.CreatureHitPoints}, HP2: {secondFighter.CreatureHitPoints}.\n");
            while (firstFighter.CreatureHitPoints >= 0 && secondFighter.CreatureHitPoints >= 0)
            {
                if (firstFighter.Initiative > secondFighter.Initiative)
                {
                    var attackOfFirstFighter = (int)(diceRandom.Next(1, 20) + firstFighter.CreatureAttackMod);
                    if (attackOfFirstFighter >= (int)secondFighter.CreatureArmor)
                    {
                        secondFighter.CreatureHitPoints = secondFighter.CreatureHitPoints -
                            ((int)firstFighter.CreatureWeapon.Demage.NumberOfDices *
                             diceRandom.Next(1, (int)firstFighter.CreatureWeapon.Demage.SizeOfDice) +
                             firstFighter.CreatureWeapon.DemageMod);
                    }
                    else
                    {
                        Console.WriteLine($"\n{firstFighter.CreatureName} MISS!!!\n");
                    }
                    var attackOfSecondFighter = (int)(diceRandom.Next(1, 20) + secondFighter.CreatureAttackMod);
                    if (attackOfSecondFighter >= (int)firstFighter.CreatureArmor)
                    {
                        firstFighter.CreatureHitPoints = firstFighter.CreatureHitPoints -
                            ((int)secondFighter.CreatureWeapon.Demage.NumberOfDices *
                             diceRandom.Next(1, (int)secondFighter.CreatureWeapon.Demage.SizeOfDice) +
                             secondFighter.CreatureWeapon.DemageMod);
                    }
                    else
                    {
                        Console.WriteLine($"\n{secondFighter.CreatureName} MISS!!!\n");
                    }
                }
                else if (firstFighter.Initiative < secondFighter.Initiative)
                {
                    var attackOfSecondFighter = (int)(diceRandom.Next(1, 20) + secondFighter.CreatureAttackMod);
                    if (attackOfSecondFighter >= (int)firstFighter.CreatureArmor)
                    {
                        firstFighter.CreatureHitPoints = firstFighter.CreatureHitPoints -
                            ((int)secondFighter.CreatureWeapon.Demage.NumberOfDices *
                             diceRandom.Next(1, (int)secondFighter.CreatureWeapon.Demage.SizeOfDice) +
                             secondFighter.CreatureWeapon.DemageMod);
                    }
                    else
                    {
                        Console.WriteLine($"\n{secondFighter.CreatureName} MISS!!!\n");
                    }
                    var attackOfFirstFighter = (int)(diceRandom.Next(1, 20) + firstFighter.CreatureAttackMod);
                    if (attackOfFirstFighter >= (int)secondFighter.CreatureArmor)
                    {
                        secondFighter.CreatureHitPoints = secondFighter.CreatureHitPoints -
                            ((int)firstFighter.CreatureWeapon.Demage.NumberOfDices *
                             diceRandom.Next(1, (int)firstFighter.CreatureWeapon.Demage.SizeOfDice) +
                             firstFighter.CreatureWeapon.DemageMod);
                    }
                    else
                    {
                        Console.WriteLine($"\n{firstFighter.CreatureName} MISS!!!\n");
                    }
                }
                else
                {
                    firstFighter.Initiative = diceRandom.Next(1, 20);
                    secondFighter.Initiative = diceRandom.Next(1, 20);
                }
                Console.WriteLine($"\nAfter this round: {firstFighter.CreatureName} has {firstFighter.CreatureHitPoints} HP | " +
                    $"{secondFighter.CreatureName} has {secondFighter.CreatureHitPoints} HP.\n");
                //Console.ReadLine();
            }        
        }
        public void ChoosenCreturesFight()
        {
            int index = 0;
            Console.WriteLine($"\nGreetings in Fight Club!!! What fight you want to see?\n\nThis is list of cretures:\n");
            foreach (var creatureChoose in creature.CreateCreatureList())
            {
                Console.WriteLine($"{index++} --- {creatureChoose.CreatureName}");
            }
            Console.WriteLine($"\n--------------------------\n\nChoose first creature:(type number of creature)" +
                $"\"Please don't use other keys, I didn't manage to write a check for incorrect input.\"\n");
            int firstCreatureChoose = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nChoose second creature:(type number of creature)\"Please don't use other keys, I didn't manage to write a check for incorrect input.\"\n") ;
            int secondCreatureChoose = int.Parse(Console.ReadLine());
            Creature firstFighter = creature.CreateCreatureList().ElementAt(firstCreatureChoose);
            Creature secondFighter = creature.CreateCreatureList().ElementAt(secondCreatureChoose);
            firstFighter.Initiative = diceRandom.Next(1, 20);
            secondFighter.Initiative = diceRandom.Next(1, 20);
            Console.WriteLine($"\nThe greatest battle {firstFighter.CreatureName} VS {secondFighter.CreatureName} begins now!\n\nIniciative of {firstFighter.CreatureName}: {firstFighter.Initiative}. " +
                $"Iniciative of {secondFighter.CreatureName}: {secondFighter.Initiative}.\n");
            Console.WriteLine($"\n{firstFighter.CreatureName} has {firstFighter.CreatureHitPoints} HP," +
                $"{secondFighter.CreatureName} has {secondFighter.CreatureHitPoints} HP.\n");
            while (firstFighter.CreatureHitPoints > 0 && secondFighter.CreatureHitPoints > 0)
            {
                if (firstFighter.Initiative > secondFighter.Initiative)
                {
                    var attackOfFirstFighter = (int)(diceRandom.Next(1, 20) + firstFighter.CreatureAttackMod);
                    Console.WriteLine($"\n{firstFighter.CreatureName} attack: {attackOfFirstFighter}, " +
                        $"{secondFighter.CreatureName} armore: {(int)secondFighter.CreatureArmor}.\n");
                    if (attackOfFirstFighter >= int.Parse(secondFighter.CreatureArmor.ToString()))
                    {
                        var firstFighterDemage = ((int)firstFighter.CreatureWeapon.Demage.NumberOfDices *
                             diceRandom.Next(1, (int)firstFighter.CreatureWeapon.Demage.SizeOfDice) +
                             firstFighter.CreatureWeapon.DemageMod);
                        secondFighter.CreatureHitPoints -= firstFighterDemage;
                        Console.WriteLine($"\n{firstFighter.CreatureName} dealt {firstFighterDemage} points of damage.\n");
                    }
                    else
                    {
                        Console.WriteLine($"\n{firstFighter.CreatureName} MISS!!!\n");
                    }
                    var attackOfSecondFighter = (int)(diceRandom.Next(1, 20) + secondFighter.CreatureAttackMod);
                    Console.WriteLine($"\n{secondFighter.CreatureName} attack: {attackOfSecondFighter}, " +
                       $"{firstFighter.CreatureName} armore: {(int)firstFighter.CreatureArmor}.\n");
                    if (attackOfSecondFighter >= int.Parse(firstFighter.CreatureArmor.ToString()))
                    {
                        var secondFighterDemage = ((int)secondFighter.CreatureWeapon.Demage.NumberOfDices *
                             diceRandom.Next(1, (int)secondFighter.CreatureWeapon.Demage.SizeOfDice) +
                             secondFighter.CreatureWeapon.DemageMod);
                        firstFighter.CreatureHitPoints -= secondFighterDemage;
                        Console.WriteLine($"\n{secondFighter.CreatureName} dealt {secondFighterDemage} points of damage.\n");
                    }
                    else
                    {
                        Console.WriteLine($"\n{secondFighter.CreatureName} MISS!!!\n");
                    }
                }
                else if (firstFighter.Initiative < secondFighter.Initiative)
                {
                    var attackOfSecondFighter = (int)(diceRandom.Next(1, 20) + secondFighter.CreatureAttackMod);
                    Console.WriteLine($"\n{secondFighter.CreatureName} attack: {attackOfSecondFighter}, " +
                      $"{firstFighter.CreatureName} armore: {(int)firstFighter.CreatureArmor}.\n");
                    if (attackOfSecondFighter >= int.Parse(firstFighter.CreatureArmor.ToString()))
                    {
                        var secondFighterDemage = ((int)secondFighter.CreatureWeapon.Demage.NumberOfDices *
                              diceRandom.Next(1, (int)secondFighter.CreatureWeapon.Demage.SizeOfDice) +
                              secondFighter.CreatureWeapon.DemageMod);
                        firstFighter.CreatureHitPoints -= secondFighterDemage;
                        Console.WriteLine($"\n{secondFighter.CreatureName} dealt {secondFighterDemage} points of damage.\n");
                    }
                    else
                    {
                        Console.WriteLine($"\n{secondFighter.CreatureName} MISS!!!\n");
                    }
                    var attackOfFirstFighter = (int)(diceRandom.Next(1, 20) + firstFighter.CreatureAttackMod);
                    Console.WriteLine($"\n{firstFighter.CreatureName} attack: {attackOfFirstFighter}, " +
                        $"{secondFighter.CreatureName} armore: {(int)secondFighter.CreatureArmor}.\n");
                    if (attackOfFirstFighter >= int.Parse(secondFighter.CreatureArmor.ToString()))
                    {
                        var firstFighterDemage = ((int)firstFighter.CreatureWeapon.Demage.NumberOfDices *
                              diceRandom.Next(1, (int)firstFighter.CreatureWeapon.Demage.SizeOfDice) +
                              firstFighter.CreatureWeapon.DemageMod);
                        secondFighter.CreatureHitPoints -= firstFighterDemage;
                        Console.WriteLine($"\n{firstFighter.CreatureName} dealt {firstFighterDemage} points of damage.\n");
                    }
                    else
                    {
                        Console.WriteLine($"\n{firstFighter.CreatureName} MISS!!!\n");
                    }
                }
                else
                {
                    Console.WriteLine($"\nDraw iniciative! {firstFighter.Initiative} VS {secondFighter.Initiative}.\n" +
                        $"Reroll!!! Now iniciative of {firstFighter.CreatureName}: {firstFighter.Initiative}. " +
                $"Iniciative of {secondFighter.CreatureName}: {secondFighter.Initiative}.\n");
                    firstFighter.Initiative = diceRandom.Next(1, 20);
                    secondFighter.Initiative = diceRandom.Next(1, 20);
                }
                Console.WriteLine($"\nAfter this round: {firstFighter.CreatureName} has {firstFighter.CreatureHitPoints} HP | " +
                    $"{secondFighter.CreatureName} has {secondFighter.CreatureHitPoints} HP.\n\n--------------------------\n");
                Console.ReadLine();
            }
            if (firstFighter.CreatureHitPoints <= 0)
            {
                Console.WriteLine($"\n{secondFighter.CreatureName} WIN!!!\n");
            }
            else if (secondFighter.CreatureHitPoints <= 0)
            {
                Console.WriteLine($"\n{firstFighter.CreatureName} WIN!!!\n");
            }
            RepeatChoosenCreturesFight();
        }  
        public void RepeatChoosenCreturesFight()
        {
            var flag = true;
            Console.WriteLine($"\nChoose your destiny! Wanna try again?(type \"y\" if yes, \"n\" if no)\n");
            while (flag)
            {
                var repeatAnswer = Console.ReadLine().ToLower();
                if (repeatAnswer == "y")
                {
                    ChoosenCreturesFight();
                    flag = false;
                }
                else if (repeatAnswer == "n")
                {
                    Console.WriteLine($"Your desteny chosen! Come again for more blood and suffer!!! Bye!");
                    flag = false;
                }
                else
                {
                    Console.WriteLine($"Wrong answer!(type \"y\" if yes, \"n\" if no)");
                }
            }
        }
    }
}

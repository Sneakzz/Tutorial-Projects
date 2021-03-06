﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut8
{
    class Program
    {
        /*
        Bob Attacks Maximus and Deals 74 Damage
        Maximus Has 69 Health
 
        Maximus Attacks Bob and Deals 6 Damage
        Bob Has 6 Health
 
        Bob Attacks Maximus and Deals 48 Damage
        Maximus Has 21 Health
 
        Maximus Attacks Bob and Deals 48 Damage
        Bob Has -42 Health
 
        Bob has Died and Maximus is Victorious
 
        Game Over
        */

        static void Main(string[] args)
        {
            Warrior maximus = new Warrior("Playable Character", 150, 55, 50);
            Warrior bob = new Warrior("JAD", 150, 55, 50);

            Battle.StartFight(maximus, bob);

            Console.ReadLine();
        }
    }
}

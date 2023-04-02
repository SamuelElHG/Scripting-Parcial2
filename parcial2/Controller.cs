using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace parcial2
{
    internal class Controller
    {
        public enum race { Human, Beast, Hybrid}
             public class Character
           {
            public string name;
            public int lifePoints;
            public int baseAtk;
            public int baseDf;
            public race race;
            public Weapon weapon;
            public Armor armor;

            //constuctor
            public Character(string name, int lifePoints, int baseAtk, int baseDf, race race)
            {
                this.name = name;
                this.lifePoints = lifePoints;
                this.baseAtk = baseAtk;
                this.baseDf = baseDf;
                this.race = race;
            }
           
            public virtual int attack()
            {
                int totalAtk = baseAtk + weapon.weaponAtk;
                weapon.weaponDurability--;
                return totalAtk;
            }
            public virtual int damage(int damage) {

                int totalDF = baseDf + armor.armorDf;
                int damageTaken = Math.Max(1, (damage - totalDF)/2);
                armor.armorDurability -= Math.Max(1, damageTaken);
                lifePoints -= damageTaken;
                return damageTaken;
            }
        
             }
        public class Weapon
        {
            public string Wname;
            public int weaponAtk;
            public int weaponDurability;
            public Weapon(string wname, int weaponAtk, int weaponDurability)
            {
                Wname = wname;
                this.weaponAtk = weaponAtk;
                this.weaponDurability = weaponDurability;
            }
        }
        public class Armor
        {
            public string Aname;
            public int armorDf;
            public int armorDurability;
            public Armor(string aname, int armorDf, int armorDurability)
            {
                Aname = aname;
                this.armorDf = armorDf;
                this.armorDurability = armorDurability;
            }
        }




    }
}

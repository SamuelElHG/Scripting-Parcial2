using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace parcial2
{
    public class Character : WeaponAndArmor
    {
        public string Name;
        public int lifePoints;
        public int baseAtk;
        public int baseDf;

        public enum race {human, beast, hybrid }
        public race CharacterRace { get; set; }

        public enum wType { human, beast, hybrid, any }
        public enum aType { human, beast, hybrid, any }
        public aType armorType { get; set; }
        public wType weaponType { get; set; }



        public Character(string Name, int lifePoints, int baseAtk, int baseDf,
              int armorDf, int weaponAtk, int armorDurability,
              int weaponDurability, bool aEquiped, bool wEquiped, string armorName, string weaponName, race Crace)
              : base(armorDf, weaponAtk, armorDurability, weaponDurability, aEquiped, wEquiped, armorName, weaponName)
        {
            this.Name = Name;
            this.lifePoints =Math.Max(1, lifePoints);
            this.baseAtk = baseAtk;
            this.baseDf = baseDf;
            Crace = Crace;

            
        }
        public bool equipArmor(int durability, string aName, int aPower, race Crace, aType type, Character player)
        {
            if ( durability > 0 ) //if type is the same and durability is not 0, can equip
            {
                return true;
            }
            else return false;
            player.armorDf = aPower; player.armorDurability = durability; player.armorName = aName;


        }
        public bool equipWeapon(int durability, string wName, int wPower, race race, wType type, Character player)
        {
            if (durability > 0 )//if type is the same and durability is not 0, can equip
            {
                return true;
            }
            else return false;
            player.weaponAtk = wPower ; player.weaponDurability = durability; player.weaponName = wName; 
        }




        public void attack(Character atacante, Character defensor)
        {
            int atkDamage;

            if (atacante.wEquiped==true)
            {atkDamage = atacante.baseAtk + atacante.weaponAtk;}
            else
            {atkDamage = atacante.baseAtk;}

            if (defensor.aEquiped==true)
            {defensor.armorDurability = Math.Max(0, defensor.armorDurability - atkDamage / 2);}
            else
            {defensor.lifePoints = Math.Max(0, defensor.lifePoints- atkDamage);}


            if (atacante.wEquiped == true)
            {atacante.weaponDurability= Math.Max(0, atacante.weaponDurability-1);}


            if (atacante.weaponDurability < 1)
            {
                atacante.wEquiped = false;
            }

            if(defensor.armorDurability < 1)
            {
                defensor.aEquiped = false;
            }

        }


    }
}

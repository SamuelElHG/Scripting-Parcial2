using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial2
{
    public class WeaponAndArmor
    {


        public int armorDf = 10;
        public int weaponAtk = 20;

        public string weaponName ="a";
        public string armorName ="b";

        public int armorDurability = 5;
        public int weaponDurability = 10;

        public bool aEquiped = true;
        public bool wEquiped = true;




        public WeaponAndArmor(int armorDf, int weaponAtk, int armorDurability, int weaponDurability, bool aEquiped, bool wEquiped, string weaponName, string armorName)
        {

            this.armorDf = armorDf;
            this.weaponAtk = weaponAtk;
            this.armorDurability = Math.Max(1, armorDurability);
            this.weaponDurability = Math.Max(1, weaponDurability);
            this.aEquiped = aEquiped;
            this.wEquiped = wEquiped;
            this.weaponName = weaponName;
            this.armorName = armorName;

        }
    }
}

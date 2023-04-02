namespace parcial2
{
    public class Tests
    {
        public Character Player;
        public Character Enemy;
        [SetUp]
        public void Setup()
        {
            Player = new Character("Sam", 100, 10, 5, 10, 20, 12, 20, true, true, "espada del cielo", "Armadura de la tierra", Character.race.human);
            Enemy = new Character("Sephiroth", 100, 10, 5, 10, 20, 18, 25, true, true, "Masamune", "mata Aeris", Character.race.human);

        }

        [Test]
        public void TestA() //player is not null nor empty
        {

            Assert.Greater(Player.lifePoints, 0);
            Assert.Greater(Player.baseAtk,0);
            Assert.Greater(Player.baseDf, 0);
            Assert.Greater(Player.armorDf, 0);
            Assert.Greater(Player.weaponAtk, 0);
            Assert.Greater(Player.armorDurability, 0);
            Assert.Greater(Player.weaponDurability, 0);

            Assert.IsNotNull(Player);
        }

        [Test]
        public void TestB() //atributes cant be 0
        {
            Assert.IsNotNull(Player.armorDf);
            Assert.IsNotNull(Player.weaponAtk);

            Assert.IsNotNull(Player.armorDurability);
            Assert.IsNotNull(Player.weaponDurability);

        }

        [Test]
        public void testC() //lifepoints must be at least 1
        {
            Player = new Character("Sam", 0, 10, 5, 10, 20, 12, 20, true, true, "espada del cielo", "Armadura de la tierra", Character.race.human);
            Assert.Greater(Player.lifePoints,0);
        }

        [Test]
        public void testD() //weapon and armor durability must be at least 1
        {
            Player = new Character("Sam", 100, 10, 5, 10, 20, 0, 0, true, true, "espada del cielo", "Armadura de la tierra", Character.race.human);
            Assert.Greater(Player.weaponDurability, 0);
            Assert.Greater(Player.armorDurability, 0);
        }

        [Test]
        public void testE()//weapons and armors must be same type or race to be equiped, failure
        {




        }

        [Test]
        public void testF()//can only have one armor and weapon at the same time
        {
            string originalArmorName = Player.armorName;
            string originalWeaponName = Player.weaponName;
            Player.equipArmor(123,"rey de plumas", 123, Character.race.human, Character.aType.human, Player); //we can assure this by checking the stats are the same

            Player.equipWeapon(123, "rey de plumas", 123, Character.race.human, Character.wType.human, Player);
        Assert.AreEqual(originalArmorName, Player.armorName);
            Assert.AreEqual(originalWeaponName, Player.weaponName);
        }

        [Test]
        public void testA2()//decrease durability of weapons and armors
        {
            Player = new Character("Sam", 100, 10, 5, 10, 20, 15, 8, true, true, "espada del cielo", "Armadura de la tierra", Character.race.human);
            Enemy = new Character("Sephiroth", 100, 10, 5, 10, 20, 12, 20, true, true, "Masamune", "Túnica de Aeris", Character.race.human);
            int WeaponinitialDurability = Player.weaponDurability;
            int armorinitialDurability = Enemy.armorDurability;
            Player.attack(Player, Enemy);
            Assert.AreNotEqual(Player.weaponDurability,WeaponinitialDurability );
            Assert.AreNotEqual(Enemy.armorDurability, armorinitialDurability );
        }

        [Test]
        public void testB2()//weapon attacking no armor
        {
            Player = new Character("Sam", 100, 10, 5, 10, 20, 15, 8, true, true, "espada del cielo", "Armadura de la tierra", Character.race.human);
            Enemy = new Character("Sephiroth", 100, 10, 5, 10, 20, 12, 20, false, false, "Masamune", "Túnica de Aeris", Character.race.human);
            int initialLifePoints = Enemy.lifePoints;
            int playerAtk = Player.baseAtk+Player.weaponAtk;
            Player.attack(Player, Enemy);
            Assert.AreEqual(Enemy.lifePoints, initialLifePoints - playerAtk);
        }

        [Test] public void testC2() //weapon attacking armor
        {
            int initialLifePoints = Enemy.lifePoints;
            Player.attack(Player, Enemy);
            Assert.AreEqual(initialLifePoints, Enemy.lifePoints);
        }

        [Test] public void testD2()//no weapon attacks armor
        {
            Player = new Character("Sam", 100, 10, 5, 10, 20, 15, 8, false, false, "espada del cielo", "Armadura de la tierra", Character.race.human);

            int intialDurability = Enemy.armorDurability;

            Player.attack(Player, Enemy);
            Assert.That(intialDurability - Math.Max(1, (Player.baseAtk / 2)), Is.EqualTo(Enemy.armorDurability));
        }

        [Test] public void testE2() //no weapon attacks no armor
        {
            Player = new Character("Sam", 100, 10, 5, 10, 20, 12, 20, false, false, "espada del cielo", "Armadura de la tierra", Character.race.human);
            Enemy = new Character("Sephiroth", 100, 10, 5, 10, 20, 18, 25, false, false, "Masamune", "mata Aeris", Character.race.human);
            int finalLp = Enemy.lifePoints-Player.baseAtk;
             
            Player.attack(Player, Enemy);
            Assert.AreEqual(Enemy.lifePoints, finalLp);
        }

        [Test]
        public void testF2() //Destroy weapon on durability 0
        {
            Player = new Character("Sam", 100, 10, 5, 10, 20, 1, 20, true, false, "espada del cielo", "Armadura de la tierra", Character.race.human);

            Player.attack(Player, Enemy); //luego del ataque debe decir que el arma es false
            Assert.IsFalse(Player.wEquiped);

            Player.attack(Player, Enemy); //Podemos intentar otra vez
            Assert.IsFalse(Player.wEquiped);
        }

        [Test] public void testG() //destroy armor on durability 0
        {
            Enemy = new Character("Sephiroth", 100, 10, 5, 10, 20, 2, 2, true, true, "Masamune", "mata Aeris", Character.race.human);

            Player.attack(Player, Enemy); //luego del ataque debe decir que la armor es false
            Assert.IsFalse(Enemy.aEquiped);
        }

        [Test] public void testH()//lifepoints cant be negative
        {
            Enemy = new Character("Sephiroth", 1, 10, 5, 10, 20, 2, 2, false, false, "Masamune", "mata Aeris", Character.race.human);
            Player.attack(Player, Enemy);
            Assert.GreaterOrEqual(Enemy.lifePoints, 0); //los puntos de vida pueden ser 0, no menos
        }

        [Test] public void testI() //durability cant be lower than 0 on armor
        {
            Enemy = new Character("Sephiroth", 1, 10, 5, 10, 20, 1, 1, true, true, "Masamune", "mata Aeris", Character.race.human);
            Player.attack(Player, Enemy);
            Assert.GreaterOrEqual(Enemy.armorDurability, 0); //la durabilidad puede ser 0, no menos
        }

        [Test] public void testJ() //durability cant be lower than 0 on armor
        {
            Player = new Character("Sam", 100, 10, 5, 10, 20, 1, 20, true, false, "espada del cielo", "Armadura de la tierra", Character.race.human);
            Player.attack(Player, Enemy);
            Assert.GreaterOrEqual(Player.weaponDurability, 0); //la durabilidad puede ser 0, no menos
            Player.attack(Player, Enemy);
            Assert.GreaterOrEqual(Player.weaponDurability, 0); //repetimos por el que dirán
        }

        [Test] public void testK() //can always equip a weapon or armor
        {
            bool armorEquiped = Player.equipArmor(12, "alas rotas", 12, Character.race.human, Character.aType.human, Player); //should be true
            bool weaponEquiped = Player.equipWeapon(12, "pluma rota", 12, Character.race.human, Character.wType.human, Player); //should be true
            Assert.IsTrue(armorEquiped);
            Assert.IsTrue(weaponEquiped);
        }

        [Test] public void testL() //can only equip weapons or armors with durability greater than 0
        {

            bool armorEquiped = Player.equipArmor(0, "alas rotas", 0, Character.race.human, Character.aType.human, Player); //should be false
           bool weaponEquiped = Player.equipWeapon(0, "pluma rota", 0, Character.race.human, Character.wType.human, Player); //should be false
            Assert.IsFalse(armorEquiped);
            Assert.IsFalse(weaponEquiped);

             armorEquiped = Player.equipArmor(12, "alas rotas", 12, Character.race.human, Character.aType.human, Player); //should be true
             weaponEquiped = Player.equipWeapon(12, "pluma rota", 12, Character.race.human, Character.wType.human, Player); //should be true
            Assert.IsTrue(armorEquiped);
            Assert.IsTrue(weaponEquiped);


        }

        [Test]
        public void testM() //Race or weapon class cannot be changed "in game", failure
        { }

        [Test] public void testN() //weapons and armors atributes cannot be changed "in game", failure
        { }

        [TearDown]
        public void TearDown() {
            Player = null;
            Enemy = null;
        }

}
}
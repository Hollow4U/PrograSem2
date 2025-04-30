using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static List<Characters> character = new List<Characters>();

        public static List<EnemyMelee> enemyM = new List<EnemyMelee>();
        public static int meleeCount = enemyM.Count;

        public static List<EnemyRange> enemyR = new List<EnemyRange>();
        public static int rangeCount = enemyR.Count;


        public static List<player> player = new List<player>();
        static void Main(string[] args)
        {
            bool exit = false;

            Console.WriteLine("=== CREADOR DE PERSONAJE ===");

            Console.Write("Nombre del jugador: ");
            string name = Console.ReadLine();

            Console.Write("Vida: ");
            int vida = int.Parse(Console.ReadLine());

            Console.Write("Daño base: ");
            int daño = int.Parse(Console.ReadLine());

            Console.Write("Clase de armadura (AC): ");
            int ac = int.Parse(Console.ReadLine());

            Console.Write("Bono de daño: ");
            int dmgBonus = int.Parse(Console.ReadLine());

            player newplayer = new player(name, vida, daño, ac, dmgBonus);
            player.Add(newplayer);

            while (!exit)
            {
                EnemyRange enemigo1r = new EnemyRange("Arquero Orco", 100, 15, 12, true, 30);
                EnemyRange enemigo2r = new EnemyRange("Ballestero Goblin", 80, 10, 10, true, 20);
                EnemyMelee enemigo1m = new EnemyMelee("Orco Guerrero", 120, 20, 14, true);
                EnemyMelee enemigo2m = new EnemyMelee("Trol Salvaje", 150, 25, 13, true);

                enemyR.Add(enemigo1r);
                enemyR.Add(enemigo2r);

                enemyM.Add(enemigo1m);
                enemyM.Add(enemigo2m);

                Program.player[0].rowCheck();
                Program.enemyM[0].attack(0);
                Program.enemyM[1].attack(0);
                Program.enemyR[0].attack(0);
                Program.enemyR[1].attack(0);

                Program.enemyM[0].Alive(0);
                Program.enemyM[1].Alive(1);
                Program.enemyR[0].Alive(0);
                Program.enemyR[1].Alive(1);

                if(Program.player[0].vida == 0)
                {
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine("Presiona ENTER para salir...");
                    Console.ReadLine();
                    exit = true;
                }
                else if(TodosLosEnemigosMuertos())
                {
                    Console.WriteLine("GANASTE");
                    Console.WriteLine("Presiona ENTER para salir...");
                    Console.ReadLine();
                    exit = true;
                }
            }
        }

        static bool TodosLosEnemigosMuertos()
        {
            bool meleeMuertos = enemyM.All(e => e.alive == false);
            bool rangeMuertos = enemyR.All(e => e.alive == false);
            return meleeMuertos && rangeMuertos;
        }
    }
}
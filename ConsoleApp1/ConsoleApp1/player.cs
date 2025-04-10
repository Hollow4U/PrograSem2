using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class player : Characters
    {

        protected int dmgBonus;
        public player(string name, int vida, int daño, int ac, int dmgBonus) : base(name, vida, daño, ac)
        {
            this.name = name;
            this.vida = vida;
            this.daño = daño;
            this.ac = ac;
            this.dmgBonus = dmgBonus;
        }
        public void attackMelee(int i)
        {
            Console.WriteLine($"{name} ataca a {Program.enemyM[i].name}");
            Random random = new Random();
            int ranNum = random.Next(1, 21);
            if (ranNum + dmgBonus >= Program.enemyM[i].ac)
            {
                Console.WriteLine($"{name} impacta a {Program.enemyM[i].name}");
                Program.enemyM[i].lostLife(damageCheck());
            }
            else
            {
                Console.WriteLine($"{name} falla al atacar a {Program.enemyM[i].name}");
            }
        }
        public void attackRange(int i)
        {
            Console.WriteLine($"{name} ataca a {Program.enemyR[i].name}");
            Random random = new Random();
            int ranNum = random.Next(1, 21);
            if (ranNum + dmgBonus >= Program.enemyR[i].ac)
            {
                Console.WriteLine($"{name} impacta a {Program.enemyR[i].name}");
                Program.enemyR[i].lostLife(damageCheck());
            }
            else
            {
                Console.WriteLine($"{name} falla al atacar a {Program.enemyR[i].name}");
            }
        }


        public virtual void rowCheck()
        {
            if (Program.meleeCount > 0 && Program.rangeCount > 0)
            {
                bool salir = false;

                while (!salir)
                {
                    Console.WriteLine("¿Que grupo de enemigos quieres atacar");
                    Console.WriteLine("1. Guerreros");
                    Console.WriteLine("2. Arqueros");

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            Console.WriteLine("¿A quien quieres atacar?");
                            for (int i = 0; i < Program.enemyM.Count; i++)
                            {
                                Console.WriteLine($"{i}. {Program.enemyM[i].name}");
                            }

                            int enemyMtarget = int.Parse(Console.ReadLine());
                            bool meleeout = false;

                            while(!meleeout)
                            {
                                if (enemyMtarget >= 0 && enemyMtarget < Program.enemyR.Count)
                                {
                                    Program.player[0].attackMelee(enemyMtarget);
                                    meleeout = true;
                                }
                                else
                                {
                                    Console.WriteLine("No existe ese enemigo");
                                }
                            }
                            break;

                        case "2":
                            Console.WriteLine("¿A quien quieres atacar?");
                            for (int i = 0; i < Program.enemyR.Count; i++)
                            {
                                Console.WriteLine($"{i}. {Program.enemyR[i].name}");
                            }

                            int enemyRtarget = int.Parse(Console.ReadLine());
                            bool rangeout = false;

                            while (!rangeout)
                            {
                                if (enemyRtarget >= 0 && enemyRtarget < Program.enemyR.Count)
                                {
                                    Program.player[0].attackRange(enemyRtarget);
                                    rangeout = true;
                                }
                                else
                                {
                                    Console.WriteLine("No existe ese enemigo");
                                }
                            }
                            break;

                        default:
                            Console.WriteLine("Opcion no valida");
                            break;
                    }

                }
            }
        }
    }
}



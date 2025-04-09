using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class EnemyRange : Enemies
    {
        public int ammo;
        public EnemyRange(string name, int vida, int daño, int ac, bool alive, int ammo) : base(name, vida, daño, ac, alive)
        {
            this.name = name;
            this.vida = vida;
            this.daño = daño;
            this.ac = ac;
            this.alive = alive;
            this.ammo = ammo;   
        }
        public override void Alive()
        {
            if (vida <= 0)
            {
                alive = false;
                Console.WriteLine($"{name} esta muerto");
            }
        }

        public override void attack(int i)
        {
            if (ammo > 0)
            {
                Console.WriteLine($"{name} ataca a {Program.player[i].name}");
                Random random = new Random();
                int ranNum = random.Next(1, 21);

                if (ranNum >= Program.player[i].ac)
                {
                    Console.WriteLine($"{name} impacta a {Program.player[i].name}");
                    Program.player[i].lostLife(damageCheck());
                }
                else
                {
                    Console.WriteLine($"{name} falla al atacar a {Program.player[i].name}");
                }
            }
            else
            {
                Console.WriteLine($"{name} no le queda municion y no puede atacar");
            }
        }
    }
}

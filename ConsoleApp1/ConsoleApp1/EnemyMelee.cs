using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class EnemyMelee : Enemies
    {
        public EnemyMelee(string name, int vida, int daño, int ac, bool alive) : base(name, vida, daño, ac, alive)
        {
            this.name = name;
            this.vida = vida;
            this.daño = daño;
            this.ac = ac;
            this.alive = alive;

        }

        public override void Alive()
        {
            if(vida <= 0)
            {
                alive = false;
                Console.WriteLine($"{name} esta muerto");
            }
        }
    }
}

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
        public player (string name, int vida, int daño, int ac, int dmgBonus) : base(name, vida, daño, ac)
        {
            this.name = name;
            this.vida = vida;
            this.daño = daño;
            this.ac = ac;
            this.dmgBonus = dmgBonus;
        }
        public override void attack(int i)
        {
            Console.WriteLine($"{name} ataca a {Program.character[i].name}");
            Random random = new Random();
            int ranNum = random.Next(1, 21);

            if (ranNum + dmgBonus >= Program.character[i].ac)
            {
                Console.WriteLine($"{name} impacta a {Program.character[i].name}");
                Program.character[i].lostLife(damageCheck());
            }
            else
            {
                Console.WriteLine($"{name} falla al atacar a {Program.character[i].name}");
            }
        }


    }
}

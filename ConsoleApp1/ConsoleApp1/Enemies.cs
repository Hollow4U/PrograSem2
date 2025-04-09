using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal abstract class Enemies : Characters
    {
        public bool alive = true;
        public Enemies(string name, int vida, int daño, int ac, bool alive) : base(name, vida, daño, ac)
        {
            this.name = name;
            this.vida = vida;
            this.daño = daño;
            this.ac = ac;
            this.alive = alive;
        }
        public abstract void Alive();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_lab___C_
{
    abstract class Animal: MainInterface
    {
        protected string name;
        protected string type;
        protected string habitat;
        public virtual string ShowInfo()
        {
            return "Название: " + name + ", вид: " + type + ", местообитание: " + habitat + ShowMovement();
        }
        public virtual string ShowMovement()
        {
            return "Оно что-то делает";
        }
        public abstract object Clone();
        public abstract int CompareTo(object? o);
    }
}

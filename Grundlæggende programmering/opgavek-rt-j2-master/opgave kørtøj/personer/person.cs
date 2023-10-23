using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace opgave_kørtøj.Personer
{
    using System;
    public abstract class Person
    {
        internal string name;

        protected string Name { get; }

        protected Person(string name)
        {
            Name = name;
        }

        public virtual string SayHello(string role)
        {
            return $"Hej, jeg er en {role}.";
        }

        public virtual string SayHello(string role, string name)
        {
            return $"Hej, jeg er en {role} og jeg hedder {name}.";
        }

        public abstract void ShowMyIdentity();
    }


}

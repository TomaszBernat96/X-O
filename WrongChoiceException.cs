using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gra
{
    class WrongChoiceException : Exception
    {
        public WrongChoiceException() {
            this.Source = "Wybrales liczbe spoza zakresu opcji.";
        }
        //public WrongChoiceException(string message) : base(message) { }
    }
}

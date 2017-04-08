using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gra
{
    class BadAssignmentException : FormatException
    {
        public BadAssignmentException() {
            this.Source = "Proba przypisania nieprawidlowego typu";
        }
    }
}

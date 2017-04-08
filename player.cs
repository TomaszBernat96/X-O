using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gra
{
    class player
    {

        private string name;
        private int score;
        public string frst;

        public player()
        {
            name = "DOMYSLNY";
            score = 0; 
        }

        public void setname(string a)
        {
            try
            {
            name = a;
            }
            catch(BadAssignmentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
            }
        }
        public void showname()
        {
            Console.Write(name);
        }

        public void setscore(int a)
        {
            try
            {
                score = a;
            }
            catch (BadAssignmentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
            }
        }

        public string setwinner(string a)
        {
            try
            {
                a = name;
            }
            catch (BadAssignmentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
            }
            return a;
        }

    }
}

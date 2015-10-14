using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motherload
{
    class Program
    {
        static void Main(string[] args)
        {   
            Manager m = new Manager();
            while(m.esc == true)
            { 
                m = new Manager();
            }
        }
    }
}

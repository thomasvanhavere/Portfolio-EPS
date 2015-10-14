using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TijdOmzetter
{
    class Program
    {
        static void Main(string[] args)
        {
            double uur = 0, min = 0, sec = 0;
            int lengte,i,count=0;
            string tijd;
            char[] c = new char[3];
            int[] array = new int[3];
            System.Console.WriteLine("Dit programma zal de ingegeven tijd omzetten naar seconden :-) \n Geef de tijd i geschijde door \".\"of \",\" ");
            tijd = Console.ReadLine();
            lengte = tijd.Length;
            for (i = 0; i < lengte-1; i++)
            {
                if (tijd.Substring(i, 1) == "," || tijd.Substring(i, 1) == "." )
                {
                    array[count] = i;
                    count += 1;
                }
            }
            uur = Convert.ToDouble(tijd.Substring(0, array[0]));
            min = Convert.ToDouble(tijd.Substring(array[0]+1,array[1]-array[0]));
            sec = Convert.ToDouble(tijd.Substring(array[1]+1,lengte-array[1]-1));

            sec = sec + (min * 60) + (uur * 3600);
            System.Console.WriteLine("De tijd is seconden is :"+sec);
          
            System.Console.ReadLine();
        }
    }
}

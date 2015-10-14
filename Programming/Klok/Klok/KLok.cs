using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klok
{
    class KLok
    {
        static void Main(string[] args)
        {
            int sec=0, min=0, uur = 0;
            do
            {
                do
                {

                    do
                    {
                      
                           Console.WriteLine(uur + " : " + min + " : " + sec);
                           sec = Sec(sec);
                    } while (sec != 60);

                    sec = 0;
                    min = Min(min);


                } while (min != 60);

                min = 0;
                sec = 0;
                uur = Uur(uur);

            } while (uur != 60);
            System.Console.ReadLine();
        }
        static int Sec(int sec)
        {
            
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            sec = sec + 1;
           
            return sec;
        }
        static int Min(int min)
        {
            min = min + 1;
            return min;
        }
        static int Uur(int uur)
        {
            uur = uur + 1;
            return uur;
        }
    }
}

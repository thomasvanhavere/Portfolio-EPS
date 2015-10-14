using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klok_met_alarm
{
    class AlarmKlok
    {
        static void Main(string[] args)
        {
            double[] Alarm = new double[3];
            Alarm = setAlarm();           
            int sec = 0, min = 0, uur = 0;
            do
            {
                do
                {

                    do
                    {
                        sec = Sec(sec);
                        if (uur == Alarm[0] && min == Alarm[1] && sec == Alarm[2])
                        {
                         
                            for (int i = 0; i < 60; i++)
                            {
                                if (sec == 60)
                                {
                                    sec = 0;
                                    min = min + 1;

                                }
                                else if (min == 60)
                                {
                                    sec = 0;
                                    min = 0;
                                    uur = uur + 1;
                                }
                                Console.WriteLine(uur + " : " + min + " : " + sec + " ALARM !!!!");
                                sec = Sec(sec);
                            } 
                        }
                        Console.WriteLine(uur + " : " + min + " : " + sec);
                    } while (sec != 60 );

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
        static double[] setAlarm()
        {
            int[] array = new int[3];
            double[] Alarm =new double [3];
            int count = 0, i = 0;
            Console.WriteLine("Geef op wanneer je Alarm moet afgaan");
            String alarm = Console.ReadLine();
            for (i = 0; i < alarm.Length - 1; i++)
            {
                if (alarm.Substring(i, 1) == "," || alarm.Substring(i, 1) == ".")
                {
                    array[count] = i;
                    count += 1;
                }
            }
            Alarm[0] = Convert.ToDouble(alarm.Substring(0, array[0]));
            Alarm[1] = Convert.ToDouble(alarm.Substring(array[0] + 1, array[1] - array[0]));
            Alarm[2] = Convert.ToDouble(alarm.Substring(array[1] + 1, alarm.Length - array[1] - 1));
            return Alarm;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klok_met_extra
{
    class extraKlok
    {
        static void Main(string[] args)
        {
            string Loop = "",Dat="";
            int sec = 0, min = 0, uur = 0, mili = 0;
            double[] huidige = new double[3];
            string[] huidigedatum = new string[3];
            System.Console.WriteLine("Huidige datum instellen ?(ja / nee ) ");
            Dat = Console.ReadLine();
            if (Dat == "ja" || Dat == "Ja"|| Dat=="JA")
            huidigedatum = getDatum();

            System.Console.WriteLine("Huidige tijd instellen ?(ja / nee ) ");
            string tijd = Console.ReadLine();
            if (tijd == "ja" || tijd == "Ja")
            {
                huidige = HuidigeTijd();
                
                uur = Convert.ToInt32(huidige[0]);
                min =  Convert.ToInt32(huidige[1]);
                sec = Convert.ToInt32(huidige[2]);

            }
            string[] enable = new string[10];
            double[] Alarm = new double[3];
            enable = Enable(Dat);
            if (Convert.ToInt32(enable[0]) != 24 || Convert.ToInt32(enable[0]) != 12)
                enable[0] = Convert.ToString(24);

            if (uur >= 12 || uur>=24)
                uur = 0;
            if (min >= 59)
                min = 0;
            string String = weergave(enable[3], enable[1],uur,min,sec,mili);
            string Al = "nee";
            int x = Convert.ToInt32(enable[5]);
            int y = Convert.ToInt32(enable[6]);
            if (enable[2] == "ja")
            {
                Alarm = setAlarm();
            }
          
            do
            {
            do
            {
                do
                {

                    do
                    {
                        if (enable[1] == "ja" || enable[1] == "JA" || enable[1] == "Ja")
                        {

                            do
                            {

                                if (uur == Alarm[0] && min == Alarm[1] && sec == Alarm[2] && sec != 0)
                                {
                                    Al = "ja";
                                    if (enable[7] == "ja")
                                        weegevendatum(huidigedatum, x, (y + 1));
                                    String = weergave(enable[3], enable[1], uur, min, sec, mili);
                                    knipperen(sec, min, uur, mili, String, enable[4], Al, enable[1], x, y);
                                    mili = Mili(mili);
                                    if (Alarm[1] + 1 == min && Alarm[2] ==sec)
                                        Al = "nee";
                                   }
                                else
                                {
                                    if (enable[7] == "ja")
                                        weegevendatum(huidigedatum, x, (y + 1));
                                    String = weergave(enable[3], enable[1], uur, min, sec, mili);
                                    knipperen(sec, min, uur, mili, String, enable[4], Al, enable[1],x,y);
                                   mili = Mili(mili);
                                }
                                                       

                                
                            } while (mili != 59);
                            mili = 0;
                            sec = sec + 1;
                        }
                        else if (enable[1] == "Nee" || enable[1] == "nee" || enable[1] == "")
                        {
                            if (uur == Alarm[0] && min == Alarm[1] && sec == Alarm[2] && sec != 0)
                            {

                                Al = "ja";
                                sec = Sec(sec);
                                if (enable[7] == "ja")
                                    weegevendatum(huidigedatum, x, (y + 1));
                                String = weergave(enable[3], enable[1], uur, min, sec, mili);
                                knipperen(sec, min, uur, mili, String, enable[4], Al, enable[1], x, y);

                            }
                            else
                            {
                                sec = Sec(sec);
                                String = weergave(enable[3], enable[1], uur, min, sec, mili);
                                if (enable[7] == "ja")
                                    weegevendatum(huidigedatum, x, (y+1));

                                knipperen(sec, min, uur, mili, String, enable[4], Al, enable[1], x, y);
                            }
                            if (Alarm[1] + 1 == min && sec == Alarm[2])
                            {
                                Al = "nee";
                            }
                        }
                        if (sec > 59)
                            sec = 59;
                    } while (sec != 59);
                    sec = 0;
                    min = Min(min);
                    if (min >= 59)
                        min = 0;
                } while (min != 59);
                min = 0;
                sec = 0;
                uur = Uur(uur);
               
                
               
            } while (uur != Convert.ToInt32(enable[0])-1);
            
            uur = 0;

            }while (Loop =="");

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
            double[] Alarm = new double[3];
            int count = 0, i = 0;
            string alarm;
            do
            {
                Console.WriteLine("Geef op wanneer je Alarm moet afgaan  (geschijden door . of ,");
                alarm = Console.ReadLine();
            } while (alarm == "");
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
        static string[] Enable(string datum)
        {
            string[] en = new string[10];
            string exit = "ja";
            do
            {
                if (datum == "ja" || datum == "JA" || datum == "Ja")
                {
                    System.Console.WriteLine("Wil je de datum weergeven ? ");
                    en[7] = System.Console.ReadLine();
                }
                System.Console.WriteLine("Wil je een 12 of 24 uurs klok ? ");
                en[0] = System.Console.ReadLine();
                if (en[0] =="")
                    en[0] = Convert.ToString(24);
                System.Console.WriteLine("Wil je Miliseconden zien ?");
                en[1] = System.Console.ReadLine();
                System.Console.WriteLine("Wil je een alarm ?");
                en[2] = System.Console.ReadLine();
                System.Console.WriteLine("Weergave in tekst of cijfers ?");
                en[3] = System.Console.ReadLine();
                System.Console.WriteLine("Om de hoeveel sec wil je kniperen 0 om niet te knipperen?");
                en[4] = System.Console.ReadLine();
                if (en[4] == "")
                    en[4] = "0";
                System.Console.WriteLine("Geef de de x en y positie waar je de klok wilt : \n Geef X :");
                en[5] = System.Console.ReadLine();
                if (en[5] == "")
                    en[5] = "0";
                System.Console.WriteLine(" Geef Y :");
                en[6] = System.Console.ReadLine();
                if (en[6] == "")
                    en[6] = "0";
                Console.Clear();

                System.Console.WriteLine("Overzicht van je instellingen : \n");
                System.Console.WriteLine("-----------------------------------------------------");
                System.Console.WriteLine("Je hebt gekozen voor {0} uurs klok \n Millisec : {1} \n En alarm : {2} \n Je wilt de weergave in : {3} \n Je knippert om de {4} seconden \n Je klok zal op positie : ({5} , {6}) staan\n ", en[0], en[1], en[2],en[3],en[4],en[5],en[6]);
                System.Console.WriteLine("-----------------------------------------------------");
                System.Console.WriteLine("Zijn de instellingen in orde ? ja /nee ");
                exit = System.Console.ReadLine();
            } while (exit == "nee");
         
            return en;
        }
        static int Mili(int mili)
        {
            System.Threading.Thread.Sleep(10);
            Console.Clear();
            mili = mili + 1;
            return mili;
        }
        static string weergave(string keuze, string mili,int uur , int min, int sec,int milisec)
        {
            string u="", m="", s="", ml="";
            
            if (uur < 10)
                u = "0";
            else if (uur >= 10)
                u = "";
            if (min <10)
                m="0";
            else if (min>=10)
                m="";
            if (sec < 10)
                s = "0";
            else if (sec >= 10)
                s = "";
            if (milisec < 10)
                ml = "0";
            else if (milisec >= 10)
                ml = "";

            if (keuze == "cijfers" && mili == "ja")
            {
               return u+"{0} : "+m+"{1} : "+s+"{2} : "+ml+"{3}";
            }
            else if (keuze == "cijfers")
            {
                return u+"{0} : "+m+"{1} : "+s+"{2}";
            }
            else if (keuze == "tekst" && mili == "ja")
            {
                return u+"{0} uur  "+m+"{1} min "+s+"{2} sec "+ml+"{3} mili sec ";
            }
            else if (keuze == "tekst")
            {
                return u + "{0} uur  " + m + "{1} min " + s + "{2} sec ";
            }
            return u + "{0} uur  " + m + "{1} min " + s + "{2} sec ";
        }
        static void knipperen(int sec, int min, int uur, int mili, string String, string weergave, string alarm, string millisec, int x, int y)
        {
            if (Convert.ToInt32(weergave) != 0)
            {
                if (sec % Convert.ToInt32(weergave) == 0)
                {
                    if (alarm == "ja" && millisec == "ja")
                    {
                        Console.SetCursorPosition(x, y);
                        System.Console.WriteLine(String + " alarm!!!", uur, min, sec, mili);
                    }
                    else if (alarm == "ja")
                    {
                        Console.SetCursorPosition(x, y);
                        System.Console.WriteLine(String + " alarm!!!", uur, min, sec);
                    }
                    else if (millisec == "ja" && alarm == "nee")
                    {
                        Console.SetCursorPosition(x, y);
                        System.Console.WriteLine(String, uur, min, sec, mili);
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);
                        System.Console.WriteLine(String, uur, min, sec);
                    }
                }
            }
            else
            {
                if (alarm == "ja" && millisec == "ja")
                {
                    Console.SetCursorPosition(x, y);
                    System.Console.WriteLine(String + " alarm!!!", uur, min, sec, mili);
                }

                else if (alarm == "ja")
                {
                    Console.SetCursorPosition(x, y);
                    System.Console.WriteLine(String + "alarm!!!", uur, min, sec);
                }

                else if (millisec == "ja" && alarm == "nee")
                {
                    Console.SetCursorPosition(x, y);
                    System.Console.WriteLine(String, uur, min, sec, mili);
                }

                else
                {
                    Console.SetCursorPosition(x, y);
                    System.Console.WriteLine(String, uur, min, sec);
                }
            }
        }
        static double[] HuidigeTijd()
        {
           
            int[] array = new int[3];
            double[] Alarm = new double[3];
            int count = 0, i = 0;
            string alarm;
            do
            {
                Console.WriteLine("Geef de houdige tijd op : (geschijden door . of ,");
                alarm = Console.ReadLine();
            } while (alarm == "");
            for (i = 0; i < alarm.Length - 1; i++)
            {
                if (alarm.Substring(i, 1) == "," || alarm.Substring(i, 1) == ".")
                {
                    array[count] = i;
                    count += 1;
                }
            }
            if (array.Length <= 4)
            {
                Alarm[0] = Convert.ToDouble(alarm.Substring(0, array[0]));
                Alarm[1] = Convert.ToDouble(alarm.Substring(array[0] + 1, alarm.Length - array[0]-1));

            }
            else
            {
                Alarm[0] = Convert.ToDouble(alarm.Substring(0, array[0]));
                Alarm[1] = Convert.ToDouble(alarm.Substring(array[0] + 1, array[1] - array[0]));
                Alarm[2] = Convert.ToDouble(alarm.Substring(array[1] + 1, alarm.Length - array[1] - 1));
            }
            return Alarm;
        }
        static void datum(string jaar , string maand , string dag)
        {

        }
        static string[] getDatum()
        {
            string[] datum = new string[3];
            Console.WriteLine("Geef het jaar in : ");
            datum[0] = Console.ReadLine();
            Console.WriteLine("Geef de maand in : ");
            datum[1] = Console.ReadLine();
            try
            {
                     while(Convert.ToInt32(datum[1]) > 12)
                     {
                    Console.WriteLine("Geef de maand in : ");
                    datum[1] = Console.ReadLine();
                }
            }
            catch
            {
                datum[1]=Convert.ToString(catchmaand(datum[1]));
            }
            Console.WriteLine("Geef de dag in in : ");
            datum[2] = Console.ReadLine();
            Console.Clear();
            return datum;
        }
        static string catchmaand(string maand)
        {

            if (maand == "januarie")
                return "1";
            else if (maand == "februarie")
                return "2";
            else if (maand == "maart")
                return "3";
            else if (maand == "april")
                return "4";
            else if (maand == "mei")
                return "5";
            else if (maand == "juni")
                return "6";
            else if (maand == "juli")
                return "7";
            else if (maand == "augustus")
                return "8";
            else if (maand == "september")
                return "9";
            else if (maand == "oktober")
                return "10";
            else if (maand == "november")
                return "11";
            else if (maand == "december")
                return "12";
            else
                return "1";


            
        }
        static void weegevendatum(string[] datum , int x ,int y)
        {
            Console.SetCursorPosition(x, y);
            System.Console.WriteLine("{0} - {1} - {2}", datum[2], datum[1], datum[0]);
        }
    }
}
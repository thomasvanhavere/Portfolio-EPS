using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testform
{
    class Berekenen
    {
        public string StringVerdelen(string complexstring)
        {
            int[] plaatsbewerking = new int[complexstring.Length];
            string[] bewerking = new string[complexstring.Length];
            //string[] getallenarray = new string[complexstring.Length];
          
            string newstring ="",resartstring="";
            int count = 0, i = 0;
           

            for (i = 0; i < complexstring.Length; i++)
            {
                if (complexstring.Substring(i, 1) == "(")
                {
                    plaatsbewerking[count] = i;
                    bewerking[count] = "(";
                    count++;
               }
                if (complexstring.Substring(i,1)==")")
                {
                    plaatsbewerking[count] = i;
                    bewerking[count] = ")";
                    count++;
                }
              
            }
            if (bewerking[0] == null)
            {
                return stringBewerking(complexstring);
            }
            
            
             for (i = 0; i < bewerking.Length - 1; i++)
                {
                    
                 if (bewerking[i] == "(" && bewerking[i + 1] == ")")
                    {
                        if (plaatsbewerking[i] == 0)
                        {
                            newstring = complexstring.Substring(1, (plaatsbewerking[i + 1] - 1));
                            newstring = stringBewerking(newstring);
                            resartstring = newstring + complexstring.Substring(plaatsbewerking[i + 1] + 1, complexstring.Length - plaatsbewerking[i + 1] - 1);
                            complexstring = resartstring;
                           return resartstring;
                            //StringVerdelen(resartstring);
                           
                        }
                        else if (plaatsbewerking[i] ==complexstring.Length)
                        {
                            newstring = complexstring.Substring(plaatsbewerking[i] + 1, complexstring.Length);
                            newstring = stringBewerking(newstring);
                            resartstring = complexstring.Substring(0, plaatsbewerking[i] - 1) + " " + newstring + complexstring.Substring(plaatsbewerking[i + 1] + 1, complexstring.Length - plaatsbewerking[i + 1] - 1);
                            complexstring = resartstring;
                            StringVerdelen(resartstring);
                        }
                        else
                        {
                            newstring = complexstring.Substring(plaatsbewerking[i] + 1, (plaatsbewerking[i + 1] - plaatsbewerking[i] - 1));
                            newstring = stringBewerking(newstring);
                            resartstring = complexstring.Substring(0, plaatsbewerking[i] - 1) + " " + newstring + complexstring.Substring(plaatsbewerking[i + 1] + 1, complexstring.Length - plaatsbewerking[i + 1] - 1);
                            complexstring = resartstring;
                            StringVerdelen(resartstring);
                        }
                }
            }

            return stringBewerking(complexstring);
        }
        public string stringBewerking(string bewerking)
        {

            int[] plaatsbewerking = new int[bewerking.Length];
            string[] soortbewerking = new string[bewerking.Length];
            string[] getallenarray = new string[bewerking.Length];
            int productcounter = 0, deelcounter = 0, somcounter = 0, verschilcounter = 0;
            int count = 0, i = 0;


            for (i = 0; i < bewerking.Length; i++)
            {
                if (bewerking.Substring(i, 1) == "+" || bewerking.Substring(i, 1) == "-" || bewerking.Substring(i, 1) == "/" || bewerking.Substring(i, 1) == "X" || i == bewerking.Length - 1)
                {

                    plaatsbewerking[count] = i + 1;
                   


                    if (count == 0)
                    {
                        getallenarray[count] = bewerking.Substring(0, i - 1);

                    }
                    else if (i == bewerking.Length - 1)
                    {
                        getallenarray[count] = bewerking.Substring(plaatsbewerking[count - 1] + 1, ((bewerking.Length) - (plaatsbewerking[count - 1] + 1)));
                    }
                    else if (count != 0)
                    {
                        getallenarray[count] = bewerking.Substring(plaatsbewerking[count - 1] + 1, ((plaatsbewerking[count] - 1) - (plaatsbewerking[count - 1] + 1)));
                    }



                    if (bewerking.Substring(i, 1) == "+")
                    {
                        soortbewerking[count] = "+";
                        somcounter += 1;
                    }
                    else if (bewerking.Substring(i, 1) == "-")
                    {
                        soortbewerking[count] = "-";
                        verschilcounter += 1;
                    }
                    else if (bewerking.Substring(i, 1) == "X")
                    {
                        soortbewerking[count] = "*";
                        productcounter += 1;
                    }
                    else if (bewerking.Substring(i, 1) == "/")
                    {
                        soortbewerking[count] = "/";
                        deelcounter += 1;
                    }
                    count += 1;
                }
            }
            return (berekening(soortbewerking, getallenarray, productcounter, deelcounter, somcounter, verschilcounter));
            
        }
      
        static string berekening(string[] soortbewerking, string[] getallenarray,int productcounter,int deelcounter,int somcounter,int verschilcounter)
        {

            int Pcounter = 0,Vcounter=0,Dcounter=0,Scounter=0;

               for (int i = 0; i < soortbewerking.Length-1; i++)
                {
                   
                    if (soortbewerking[i] == "*" )
                    {
                        getallenarray[i] = Convert.ToString(Convert.ToDouble(getallenarray[i]) * Convert.ToDouble(getallenarray[i + 1]));
                        getallenarray=schuifgetallen(getallenarray, i);
                        soortbewerking = schuifbewerkingen(soortbewerking, i);
                        Pcounter++;
                        i = i - 1;
                    }
                }

               if (Pcounter == productcounter)
               {
                   for (int i = 0; i < soortbewerking.Length - 1; i++)
                   {

                       if (soortbewerking[i] == "/")
                       {
                           getallenarray[i] = Convert.ToString(Convert.ToDouble(getallenarray[i]) / Convert.ToDouble(getallenarray[i + 1]));
                           getallenarray = schuifgetallen(getallenarray, i);
                           soortbewerking = schuifbewerkingen(soortbewerking, i);
                           Dcounter++;
                           i = i - 1;
                       }
                   }
                   if (Dcounter == deelcounter)
                   {
                       for (int i = 0; i < soortbewerking.Length - 1; i++)
                       {

                           if (soortbewerking[i] == "-")
                           {
                               getallenarray[i] = Convert.ToString(Convert.ToDouble(getallenarray[i]) - Convert.ToDouble(getallenarray[i + 1]));
                               getallenarray = schuifgetallen(getallenarray, i);
                               soortbewerking = schuifbewerkingen(soortbewerking, i);
                               Vcounter++;
                               i = i - 1;
                           }
                       }
                       if (verschilcounter == Vcounter)
                       {
                           for (int i = 0; i < soortbewerking.Length - 1; i++)
                           {

                               if (soortbewerking[i] == "+")
                               {
                                   getallenarray[i] = Convert.ToString(Convert.ToDouble(getallenarray[i]) + Convert.ToDouble(getallenarray[i + 1]));
                                   getallenarray = schuifgetallen(getallenarray, i);
                                   soortbewerking = schuifbewerkingen(soortbewerking, i);
                                   Scounter++;
                                   i = i - 1;
                               }
                           }
                       }

                   }
               }

           


            return getallenarray[0];
        }
        static string[] schuifgetallen(string[] getallenarray,int plaats)
        {
            for (int i = 0; i < getallenarray.Length - 1; i++)
            {
                if (i > plaats)
                    getallenarray[i] = getallenarray[i + 1];
            }
            return getallenarray;
        }
        static string[] schuifbewerkingen(string[] soortbewerkingen ,int plaats)
        {
            for (int i = 0; i < soortbewerkingen.Length - 1; i++)
            {
                if (i == plaats)
                    soortbewerkingen[i] = soortbewerkingen[i + 1];
                else if (i>plaats)
                    soortbewerkingen[i] = soortbewerkingen[i + 1];
            }
            return soortbewerkingen;
        }

       
       
    }
   }


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testform
{
    public partial class Callculator_V1 : Form
    {
        string bewerking = "";

        public Callculator_V1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + "1";
            txt1.Text = bewerking;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + "2";
            txt1.Text = bewerking;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + "3";
            txt1.Text = bewerking;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + "4";
            txt1.Text = bewerking;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + "5";
            txt1.Text = bewerking;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + "6";
            txt1.Text = bewerking;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + "7";
            txt1.Text = bewerking;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + "8";
            txt1.Text = bewerking;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + "9";
            txt1.Text = bewerking;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + "0";
            txt1.Text = bewerking;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + " + ";
            txt1.Text = bewerking;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + " - ";
            txt1.Text = bewerking;
        }

        private void btnMaal_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + " X ";
            txt1.Text = bewerking;
        }

        private void btndeel_Click(object sender, EventArgs e)
        {
            bewerking = bewerking + " / ";
            txt1.Text = bewerking;
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            txt1.Clear();
            bewerking = "";
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int[] plaatsbewerking = new int[100];
            string[] soortbewerking = new string[100];
            string[] getallenarray = new string[100];
             int productcounter  = 0,deelcounter=0,somcounter=0,verschilcounter=0;
           int count = 0, i = 0;
          
            
            for (i = 0; i < bewerking.Length ; i++)
            {
                if (bewerking.Substring(i, 1) == "+" || bewerking.Substring(i, 1) == "-" || bewerking.Substring(i, 1) == "/" || bewerking.Substring(i, 1) == "X" || i==bewerking.Length-1)
                {
                    plaatsbewerking[count] = i;
                  
                        plaatsbewerking[count] = i + 1;

                    
                    if (count == 0)
                    {
                        getallenarray[count] = bewerking.Substring(0, i -1 );
                       
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
                        verschilcounter+=1;
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
            txt1.Clear();
            txt1.Text = (berekening(soortbewerking, getallenarray,productcounter,deelcounter,somcounter,verschilcounter));
            bewerking = txt1.Text;



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

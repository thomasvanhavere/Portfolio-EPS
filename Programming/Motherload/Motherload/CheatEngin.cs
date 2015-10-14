using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motherload
{
    class CheatEngin
    {
        public CheatEngin()
        {

        }
        private bool Cheatbaar = false;
        public bool CheatBaar
        {
            get { return Cheatbaar; }
            set { Cheatbaar = value; }
        }
        private bool InfLifes;
        public bool inflifes
        {
            get { return InfLifes; }
        }
        private bool timemaster;
        public bool TimeMaster
        {
            get { return timemaster; }
        }
        private bool enough;
        public bool Enough
      {
          get { return enough; }
      }
        private bool ultiscore;
        public bool UltiScore
        {
            get { return ultiscore; }
            set { ultiscore = value; }
        }
        private bool fly;
        public bool Fly
        {
            get { return fly; }
        }
    
        private string[,] Cheats=new string[,]
        {
        {"0", "Be a Gaming God"},
        {"1", "Become a master of TIME"},
        {"2", "When you just hade enough"},
        {"3" , "Because your not good enough to do it yourself"},
        {"4", "I believe i can fly"}
        };
        public void ShowSheartEngin()
        {
            if(Cheatbaar)
            {
                try
                {
                    Console.Clear();

                    Console.Title = "CheatEngin 1.2.8.01.5.15 Beta 7";
                    Console.WriteLine("Welcome to CheatEngin 1.2.8.01.5.15 Beta 7 +\n");
                    Console.WriteLine("Choose a standart cheat or type one :");
                    Console.WriteLine("----------------------------------------------------------");
                    for (int x = 0; x < 5; x++)
                    {
                        Console.WriteLine(Cheats[x, 0] + "\t" + Cheats[x, 1]);

                    }
                    Console.WriteLine("----------------------------------------------------------\n");
                    string selected = Console.ReadLine().ToString();
                    if (selected == "0")
                    {
                        InfLifes = true;
                        ResetConsole();
                        Console.WriteLine("You gaint infinite Lifes way to go");
                    }

                    if (selected == "1")
                    {
                        timemaster = true;
                        ResetConsole();
                        Console.WriteLine("You became a master of time congrats");
                    }

                    if (selected == "2")
                    {
                        enough = true;
                        ResetConsole();
                        Console.WriteLine("Your right this game sucks play candy Crush instead");
                    }
                    if (selected == "3")
                    {
                        ultiscore = true;
                        ResetConsole();
                        Console.WriteLine("Go tell your friends how you got this score.\n Oo wait friends ??");
                    }
                    if (selected == "4")
                    {
                        fly = true;
                        ResetConsole();
                        Console.WriteLine("Fly away my little Bro");
                    }
                    else if(Convert.ToInt32(selected) >4)
                        Console.WriteLine("Can you even type Bro ?");

                    Cheatbaar = false;

                }
                catch 
                {

                    Console.WriteLine("Can you even type Bro ?");
                }
              
              

            }
            
           
        }
        private void ResetConsole()
        {
            Console.Clear();
            Console.Title = "MotherLoad";
          
        }
    }
}

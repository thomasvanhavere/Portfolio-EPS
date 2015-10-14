using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motherload
{
    class LoadLevel
    {
     
        private int[,] matrix = new int[24, 100];
        public int [,] GetMatrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        public string levelfile;
        public string LevelFile
        {
            get { return levelfile; }
            set { levelfile = value; }
        }
        List<string> testlist = new List<string>();
        public LoadLevel()
        { 
            string StringMatrix;
            Random rand = new Random();
            //schrijven Naar textfile
            StreamWriter info = new StreamWriter("Level.txt");
            for (int x = 0; x < 100; x++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (x > 5)
                    {
                        matrix[j, x] = rand.Next(0, 4);
                    }
                    else if (x == 5)
                    {
                        matrix[j, x] = 1;
                    }

                    else
                    {
                        matrix[j, x] = 0;
                    }
                    if (x == 99)
                    {
                        matrix[j, x] = 5;
                    }
                    if (x == 98)
                    {
                        matrix[j, x] = 5;
                    }  
                    
                    StringMatrix = matrix[j,x].ToString();
                    info.Write(StringMatrix);
                }
                info.WriteLine();
            }

            info.Close(); 
        }
        //lezen van file
        public void ReadLevel()
        {
            //lezen van file
            StreamReader file = new StreamReader(LevelFile);
            for (int x = 0; x < 100; x++)
            {
                testlist.Add(file.ReadLine());
            }
            file.Close();
            //convert terug naar 2d matrix

            for (int x = 0; x < 100; x++)
            {
                for (int j = 0; j < 23; j++)
                {
                    matrix[j, x] = Convert.ToInt32(testlist[x].Substring(j, 1));
                 
                }
               
            }
        }
    
              
    }
      
}

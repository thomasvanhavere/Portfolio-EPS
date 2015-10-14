using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beejuweld
{
    public partial class Form1 : Form
    {
        Graphics drawArea;
        GenereerClasse[,] Matrix = new GenereerClasse[10, 20];
        GenereerClasse vul = new GenereerClasse();
        Click[,] clickMatrix = new Click[2, 2];
        int[,] click = new int[2,2];
        int gevonden =1;
        public Form1()
        {
            InitializeComponent();
            drawArea = drawingArea.CreateGraphics();
            drawgrid();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            vulmatrix();
            drawIcons();
            textBox1.Clear();
            Check();
            textBox1.Clear();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    textBox1.Text = textBox1.Text + Convert.ToString(Matrix[i, j].GetmatrixTile);
                }
            }
          
        }
        public void vulmatrix()
        {
            int j = 0;
            for (int i = 0; i < 10; i++)
            {
                for (j = 0; j < 20; j++)
                {
                    Matrix[i, j] = new GenereerClasse();
                 
                }
                j = 0;
            }
            for (int k = 0; k < 2; k++)
            {
                for (int h = 0; h < 2; h++)
                {
                    clickMatrix[k, h] = new Click();
                }
            }
        }
        public void regenereermatrix()
        {
            int j = 0;
            for (int i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    Matrix[i, j] = new GenereerClasse();

                }
                j = 0;
            }
        }
        private void drawIcons()
        {
            int x = 40 , y = 40;
            drawgrid();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 10; j < 20; j++)
                {
                    Matrix[i,j].X = x;
                    Matrix[i, j].Y = y;

                    if (Matrix[i, j].vulMatrix == 1)
                    {
                        drawRect(x, y);
                    }
                    else if (Matrix[i, j].vulMatrix == 2)
                    {
                        drawDriehoek(x, y);
                    }
                    else if (Matrix[i, j].vulMatrix == 3)
                    {
                        drawButter(x, y);
                    }
                    else if (Matrix[i, j].vulMatrix == 4)
                    {
                        drawRuit(x, y);
                    }
                    else if (Matrix[i, j].vulMatrix == 5)
                    {
                        drawParallel(x, y);
                    }
                    else if (Matrix[i, j].vulMatrix == 6)
                    {
                        drawVijfhoek(x, y);
                    }
                    if (x == 400)
                    {
                        x = 0;
                        y = y + 40;
                    }
                 
                    x = x + 40;

                }
            }
            
        }
        public void Check()
        {

          
           
            checkOpVier();
           
            checkOpDrie();
            regenereermatrix();
            drawIcons();
          
           
         
        }
        public void checkOpDrie()
        {
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                for (j = 10; j < 20; j++)
                {
                    if (Matrix[i, j].GetMatrixValue == Matrix[i + 1, j].GetMatrixValue && Matrix[i, j].GetMatrixValue == Matrix[i + 2, j].GetMatrixValue && Matrix[i + 1, j].GetMatrixValue == Matrix[i + 2, j].GetMatrixValue)
                    {
                        gevonden++;
                        for (int k = i; k + 1 > 10; k--)
                        {
                            clearRectX(i, j, 3);
                            Matrix[k + 2, j] = Matrix[k - 1, j];    
                        }
                    }
                }
                j = 0;
            }
            for (int i = 0; i < 10; i++)
            {
                for (j = 10; j < 18; j++)
                {
                    if (Matrix[i, j].GetMatrixValue == Matrix[i, j + 1].GetMatrixValue && Matrix[i, j + 1].GetMatrixValue == Matrix[i, j + 2].GetMatrixValue && Matrix[i, j].GetMatrixValue == Matrix[i, j + 2].GetMatrixValue)
                    {
                        gevonden++;
                        for (int k = i; k + 1 > 10; k--)
                        {
                            clearRecty(i, j, 3);
                            Matrix[k, j] = Matrix[k- 1, j];
                            Matrix[k, j + 1] = Matrix[k - 1, j + 1];
                            Matrix[k, j + 2] = Matrix[k - 1, j + 2];
                        }
                     
                    }
                   
                }
                j = 0;
            }
        }
        
        public void checkOpVier()
        {
             int j = 0;
            for (int i = 0; i < 7; i++)
            {
                for ( j = 10; j<20;j++)
                {
                    if (Matrix[i, j].GetMatrixValue == Matrix[i + 1, j].GetMatrixValue && Matrix[i, j].GetMatrixValue == Matrix[i + 2, j].GetMatrixValue && Matrix[i , j].GetMatrixValue == Matrix[i + 3, j].GetMatrixValue)
                    {

                        gevonden++;
                        for (int k = i; k + 1 > 10; k--)
                        {
                            clearRectX(i, j, 4);
                            Matrix[k + 3, j] = Matrix[k - 1, j];


                        }
                    }
                }
                j = 0;
            }
            for (int i = 0; i < 10; i++)
            {
                for (j = 10; j < 17; j++)
                {
                    if (Matrix[i, j].GetMatrixValue == Matrix[i, j+1].GetMatrixValue && Matrix[i, j].GetMatrixValue == Matrix[i, j+2].GetMatrixValue && Matrix[i , j].GetMatrixValue == Matrix[i , j+3].GetMatrixValue)
                    {
                        gevonden++;
                        for (int k = i; k + 1 > 10; k--)
                        {
                            clearRecty(i, j, 4);
                            Matrix[k, j] = Matrix[k - 1, j];
                            Matrix[k, j + 1] = Matrix[k - 1, j + 1];
                            Matrix[k, j + 2] = Matrix[k - 1, j + 2];
                            Matrix[k, j + 3] = Matrix[k - 1, j + 3];
                        }
                      
                    }
                }
                j = 0;
            }
        }
     
        public void clearRectX(int x, int y ,int lengte)
        {
            DrawClearRect(Matrix[x, y].X, Matrix[x, y].Y);
            DrawClearRect(Matrix[x + 1, y].X, Matrix[x + 1, y].Y);
            DrawClearRect(Matrix[x + 2, y].X, Matrix[x + 2, y].Y);
            if (lengte == 4)
            {
                DrawClearRect(Matrix[x + 3, y].X, Matrix[x + 3, y].Y);
            }
        }
        public void clearRecty(int x, int y, int lengte)
        {
            DrawClearRect(Matrix[x, y].X, Matrix[x, y].Y);
            DrawClearRect(Matrix[x, y + 1].X, Matrix[x, y + 1].Y);
            DrawClearRect(Matrix[x, y + 2].X, Matrix[x, y + 2].Y);
           
            if (lengte == 4)
            {
                DrawClearRect(Matrix[x, y + 3].X, Matrix[x, y + 3].Y);
            }
        }
        public void clearcanvas()
        {
            SolidBrush Brush = new SolidBrush(Color.White);
            Rectangle rect = new Rectangle(0, 0, 400, 400);
            drawArea.FillRectangle(Brush, rect);
        }
        private void drawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            
          
            if (clickMatrix[0, 0].X == 0 && clickMatrix[0, 0].Y == 0)
            {
                clickMatrix[0, 0].X = e.X;
                clickMatrix[0,0].Y= e.Y;
            }
            else
            {
                clickMatrix[1, 0] = clickMatrix[0, 0];
                clickMatrix[0, 0].X = e.X;
                clickMatrix[0, 0].Y = e.Y;
            }
            if (clickMatrix[0, 0].X != 0 && clickMatrix[1, 0].X != 0 && clickMatrix[0, 0].Y != 0 && clickMatrix[1, 0].X != 0)
            {

                verplaatsen();
            }

            
        }
        public void verplaatsen()
        {
                for (int h = 1; h > 0; h--)
                {

                    for (int i = 1; i < 10; i++)
                    {
                        for (int j = 10; j < 20; j++)

                        {
                            //txtxy.Text = (txtxy.Text + "[" + Matrix[i, j].X.ToString() + "," + Matrix[i, j].Y.ToString() + "]");
                          // MessageBox.Show("clickMatrix[ " + h + "," + 0 + "]" +clickMatrix[h,0].X+" matrix[ " + i + "," + j + "] " + Matrix[i, j].X);
                            MessageBox.Show("cx "+clickMatrix[h, 0].X + " MX-1 " + Matrix[i - 1, j].X +" cy "+ clickMatrix[h, 0].Y +" MY-1 "+ Matrix[i, j - 1].Y +" CX "+ clickMatrix[h, 0].X +" MX "+ Matrix[i, j].X +" CY "+ clickMatrix[h, 0].Y +" MY "+ Matrix[i, j].Y);
                           if (clickMatrix[h, 0].X > Matrix[i - 1, j].X && clickMatrix[h, 0].Y > Matrix[i, j - 1].Y && clickMatrix[h, 0].X < Matrix[i , j].X && clickMatrix[h, 0].Y < Matrix[i, j ].Y)
                            {
                                MessageBox.Show("Verplaatsen die handel  " + Matrix[i,j].X);

                            }
                        }
                    }
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearcanvas();
            drawgrid();
            drawIcons();
            for (int i = 10; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    txtxy.Text = (txtxy.Text+"[" + Matrix[i, j].X.ToString() + "," + Matrix[i, j].Y.ToString() + "]");
                }
            }
        }

        public void drawRect(int x, int y)
        {
            SolidBrush Brush = new SolidBrush(Color.Green);
            Rectangle rect = new Rectangle(x - 39, y - 39, 39, 39);
            drawArea.FillRectangle(Brush, rect);
        }
        public void drawDriehoek(int x, int y)
        {
            SolidBrush Brush = new SolidBrush(Color.Red);
            Point punt1 = new Point(x - 20, y - 40);
            Point punt2 = new Point(x - 40, y);
            Point punt3 = new Point(x, y);
            Point[] collectie = { punt1, punt2, punt3 };
            drawArea.FillPolygon(Brush, collectie);
        }
        public void drawButter(int x, int y)
        {
            SolidBrush Brush = new SolidBrush(Color.Blue);
            Point punt1 = new Point(x - 39, y - 39);
            Point punt2 = new Point(x - 39, y);
            Point punt3 = new Point(x, y - 39);
            Point punt4 = new Point(x, y);
            Point[] collectie = { punt1, punt2, punt3, punt4 };
            drawArea.FillPolygon(Brush, collectie);
        }
        public void drawRuit(int x, int y)
        {
            SolidBrush Brush = new SolidBrush(Color.Yellow);
            Point punt1 = new Point(x - 39, y - 20);
            Point punt2 = new Point(x - 20, y - 39);
            Point punt3 = new Point(x, y - 20);
            Point punt4 = new Point(x - 20, y);
            Point[] collectie = { punt1, punt2, punt3, punt4 };
            drawArea.FillPolygon(Brush, collectie);
        }
        public void drawParallel(int x, int y)
        {
            SolidBrush Brush = new SolidBrush(Color.Orange);
            Point punt1 = new Point(x - 10, y - 39);
            Point punt2 = new Point(x, y - 30);
            Point punt3 = new Point(x - 30, y);
            Point punt4 = new Point(x - 39, y - 10);
            Point[] collectie = { punt1, punt2, punt3, punt4 };
            drawArea.FillPolygon(Brush, collectie);
        }
        public void drawVijfhoek(int x, int y)
        {
            SolidBrush Brush = new SolidBrush(Color.Black);
            Point punt1 = new Point(x - 39, y);
            Point punt2 = new Point(x - 39, y - 20);
            Point punt3 = new Point(x - 20, y - 39);
            Point punt4 = new Point(x, y - 20);
            Point punt5 = new Point(x, y);
            Point[] collectie = { punt1, punt2, punt3, punt4, punt5 };
            drawArea.FillPolygon(Brush, collectie);
        }
        public void DrawClearRect(int x, int y)
        {
            SolidBrush Brush = new SolidBrush(Color.White);
            Rectangle rect = new Rectangle(x - 39, y - 39, 39, 39);
            drawArea.FillRectangle(Brush, rect);
        }
        public void drawgrid()
        {

            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.White);
            Rectangle rect = new Rectangle(0, 0, 400, 400);
            drawArea.FillRectangle(brush, rect);
            int y1 = 40;
            for (int i = 0; i < 10; i++)
            {
                drawArea.DrawLine(pen, 0, y1, 400, y1);
                drawArea.DrawLine(pen, y1, 0, y1, 400);
                y1 = y1 + 40;
            }
        }
    }
}

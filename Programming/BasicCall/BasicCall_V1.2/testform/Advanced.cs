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
    public partial class Advanced : Form
    {
        string bewerking = "";
        Knoppen bew = new Knoppen();
        public Advanced()
        {
            InitializeComponent();
        }
        
        private void btn1_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.een();
            
        }
 
        private void overToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bew.over());
        }

        private void versieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bew.versie());
        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void calToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Callculator_V11 showForm = new Callculator_V11();
            showForm.ShowDialog();

        }

        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn2_Click_1(object sender, EventArgs e)
        {
            txt1.Text = bew.twee();
            
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.drie();
           
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.vier();
        
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.vijf();

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.zes();
         
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.zeven();
           
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.acht();
         
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.negen();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.nul();
          
        }

        private void komma_Click(object sender, EventArgs e)
        {
             txt1.Text = bew.komma();
            
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
           txt1.Text = bew.plus();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            
            txt1.Text = bew.min();
        }

        private void btnMaal_Click(object sender, EventArgs e)
        {
            
            txt1.Text = bew.maal(); 
        }

        private void btndeel_Click(object sender, EventArgs e)
        {
            
            txt1.Text = bew.deel();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Berekenen opString = new Berekenen();
            bewerking = txt1.Text;
            txt1.Clear();
            txt1.Text = opString.StringVerdelen(bewerking);
            bewerking = txt1.Text;
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            txt1.Clear();
            bew.clear();
        }

        private void btnvierkants_Click(object sender, EventArgs e)
        {
            
            txt1.Text = bew.sqrtx();
        }

        private void btntan_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.tan();
        }

        private void btnhaakr_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.haaklinks();
        }

        private void btncos_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.cos();

        }

        private void btnsin_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.sin();
        }

        private void btnkwadraat_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.kwadraat();
        }

        private void btnmacht_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.machten();
        }

        private void btnhaall_Click(object sender, EventArgs e)
        {
            txt1.Text = bew.haakrechts();
        }




    }
}

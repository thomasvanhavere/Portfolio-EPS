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
    public partial class Callculator_V11 : Form
    {
        string bewerking = "";
        Knoppen bew = new Knoppen();
        public Callculator_V11()
        {
            InitializeComponent();
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            bewerking = bew.een();
            txt1.Text = bewerking;
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            bewerking = bew.twee();
            txt1.Text = bewerking;
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            bewerking = bew.drie();
            txt1.Text = bewerking;
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            bewerking = bew.vier();
            txt1.Text = bewerking;
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            bewerking = bew.vijf();
            txt1.Text = bewerking;
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            bewerking = bew.zes();
            txt1.Text = bewerking;
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            bewerking = bew.zeven();
            txt1.Text = bewerking;
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            bewerking = bew.acht();
            txt1.Text = bewerking;
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            bewerking = bew.negen();
            txt1.Text = bewerking;
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            bewerking = bew.nul();
            txt1.Text = bewerking;
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            bewerking = bew.plus();
            txt1.Text = bewerking;
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            bewerking = bew.min();
            txt1.Text = bewerking;
        }
        private void btnMaal_Click(object sender, EventArgs e)
        {
            bewerking = bew.maal();
            txt1.Text = bewerking;
        }
        private void btndeel_Click(object sender, EventArgs e)
        {
            bewerking = bew.deel();
            txt1.Text = bewerking;
        }
        private void btnc_Click(object sender, EventArgs e)
        {
            txt1.Clear();
            bew.clear();
        }
        private void komma_Click(object sender, EventArgs e)
        {
            bewerking = bew.komma();
            txt1.Text = bewerking;
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            Berekenen opString = new Berekenen();
            txt1.Clear();
            txt1.Text = opString.stringBewerking(bewerking);
            bewerking = txt1.Text;
           
        }

        private void calToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
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
            this.Hide();
            Advanced showForm = new Advanced();
            showForm.ShowDialog();
        }

        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
        
}

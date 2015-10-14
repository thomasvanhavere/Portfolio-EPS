namespace Beejuweld
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.drawingArea = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblx1 = new System.Windows.Forms.Label();
            this.lblx2 = new System.Windows.Forms.Label();
            this.lbly1 = new System.Windows.Forms.Label();
            this.lbly2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtxy = new System.Windows.Forms.TextBox();
            this.lblxy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingArea
            // 
            this.drawingArea.BackColor = System.Drawing.SystemColors.Window;
            this.drawingArea.Location = new System.Drawing.Point(39, 12);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(400, 400);
            this.drawingArea.TabIndex = 0;
            this.drawingArea.TabStop = false;
            this.drawingArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(605, 39);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(97, 194);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(605, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "BeeldWaarde";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblx1
            // 
            this.lblx1.AutoSize = true;
            this.lblx1.Location = new System.Drawing.Point(489, 59);
            this.lblx1.Name = "lblx1";
            this.lblx1.Size = new System.Drawing.Size(20, 13);
            this.lblx1.TabIndex = 8;
            this.lblx1.Text = "X1";
            this.lblx1.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblx2
            // 
            this.lblx2.AutoSize = true;
            this.lblx2.Location = new System.Drawing.Point(489, 98);
            this.lblx2.Name = "lblx2";
            this.lblx2.Size = new System.Drawing.Size(20, 13);
            this.lblx2.TabIndex = 9;
            this.lblx2.Text = "X2";
            // 
            // lbly1
            // 
            this.lbly1.AutoSize = true;
            this.lbly1.Location = new System.Drawing.Point(532, 59);
            this.lbly1.Name = "lbly1";
            this.lbly1.Size = new System.Drawing.Size(20, 13);
            this.lbly1.TabIndex = 10;
            this.lbly1.Text = "Y1";
            // 
            // lbly2
            // 
            this.lbly2.AutoSize = true;
            this.lbly2.Location = new System.Drawing.Point(532, 98);
            this.lbly2.Name = "lbly2";
            this.lbly2.Size = new System.Drawing.Size(20, 13);
            this.lbly2.TabIndex = 11;
            this.lbly2.Text = "Y2";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(474, 427);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(228, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Draw";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtxy
            // 
            this.txtxy.Location = new System.Drawing.Point(724, 39);
            this.txtxy.Multiline = true;
            this.txtxy.Name = "txtxy";
            this.txtxy.ReadOnly = true;
            this.txtxy.Size = new System.Drawing.Size(97, 194);
            this.txtxy.TabIndex = 17;
            // 
            // lblxy
            // 
            this.lblxy.AutoSize = true;
            this.lblxy.Location = new System.Drawing.Point(734, 20);
            this.lblxy.Name = "lblxy";
            this.lblxy.Size = new System.Drawing.Size(58, 13);
            this.lblxy.TabIndex = 18;
            this.lblxy.Text = "x,y waarde";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 462);
            this.Controls.Add(this.lblxy);
            this.Controls.Add(this.txtxy);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbly2);
            this.Controls.Add(this.lbly1);
            this.Controls.Add(this.lblx2);
            this.Controls.Add(this.lblx1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.drawingArea);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox drawingArea;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblx1;
        private System.Windows.Forms.Label lblx2;
        private System.Windows.Forms.Label lbly1;
        private System.Windows.Forms.Label lbly2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtxy;
        private System.Windows.Forms.Label lblxy;
    }
}


using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace gamon
{
	/// <summary>
	/// Descrizione di riepilogo per frmAbout.
	/// </summary>
	public class frmAbout : Form
	{
        public System.Windows.Forms.Label lblData;
		public System.Windows.Forms.ToolTip ToolTip1;
		public System.Windows.Forms.Label lblVersione;
        public System.Windows.Forms.Timer Timer1;
		public System.Windows.Forms.Label lblAssemblyTitle;
		public System.Windows.Forms.Label lblAssemblyDescription;
        public Label label1;
        private Panel panel1;
        public Label label2;
        public Label label4;
        public Label label5;
        public Label label7;
        private PictureBox pictureBox1;
        public Label label8;
        public Label label3;
        public Label label6;
        private PictureBox pictureBox3;
        public Label label9;
        private PictureBox pictureBox4;
        public Label label12;
        public Label label11;
        public Label label10;
        private PictureBox pictureBox5;
        private System.ComponentModel.IContainer components;

		public frmAbout()
		{
			//
			// Necessario per il supporto di Progettazione Windows Form
			//
			InitializeComponent();

			// costruttore
		}

		/// <summary>
		/// Pulire le risorse in uso.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Codice generato da Progettazione Windows Form
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lblData = new System.Windows.Forms.Label();
            this.lblAssemblyTitle = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblVersione = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblAssemblyDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblData
            // 
            this.lblData.BackColor = System.Drawing.Color.White;
            this.lblData.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblData.ForeColor = System.Drawing.Color.Black;
            this.lblData.Location = new System.Drawing.Point(153, 103);
            this.lblData.Name = "lblData";
            this.lblData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblData.Size = new System.Drawing.Size(320, 24);
            this.lblData.TabIndex = 16;
            this.lblData.Text = "lblData";
            this.lblData.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAssemblyTitle
            // 
            this.lblAssemblyTitle.BackColor = System.Drawing.Color.White;
            this.lblAssemblyTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblAssemblyTitle.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAssemblyTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAssemblyTitle.Location = new System.Drawing.Point(156, 15);
            this.lblAssemblyTitle.Name = "lblAssemblyTitle";
            this.lblAssemblyTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAssemblyTitle.Size = new System.Drawing.Size(315, 47);
            this.lblAssemblyTitle.TabIndex = 17;
            this.lblAssemblyTitle.Text = "lblAssemblyTitle";
            this.lblAssemblyTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblVersione
            // 
            this.lblVersione.BackColor = System.Drawing.Color.White;
            this.lblVersione.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblVersione.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVersione.ForeColor = System.Drawing.Color.Black;
            this.lblVersione.Location = new System.Drawing.Point(153, 83);
            this.lblVersione.Name = "lblVersione";
            this.lblVersione.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVersione.Size = new System.Drawing.Size(320, 20);
            this.lblVersione.TabIndex = 11;
            this.lblVersione.Text = "Versione ";
            this.lblVersione.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 5000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // lblAssemblyDescription
            // 
            this.lblAssemblyDescription.BackColor = System.Drawing.Color.White;
            this.lblAssemblyDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblAssemblyDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAssemblyDescription.ForeColor = System.Drawing.Color.Black;
            this.lblAssemblyDescription.Location = new System.Drawing.Point(153, 62);
            this.lblAssemblyDescription.Name = "lblAssemblyDescription";
            this.lblAssemblyDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAssemblyDescription.Size = new System.Drawing.Size(320, 21);
            this.lblAssemblyDescription.TabIndex = 10;
            this.lblAssemblyDescription.Text = "lblAssemblyDescription";
            this.lblAssemblyDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(126, 166);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(209, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Gabriele MONTI, Forlì, ITALIA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblData);
            this.panel1.Controls.Add(this.lblAssemblyTitle);
            this.panel1.Controls.Add(this.lblVersione);
            this.panel1.Controls.Add(this.lblAssemblyDescription);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 454);
            this.panel1.TabIndex = 24;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::ForeignWords.Properties.Resources.ALA_logo_172x121;
            this.pictureBox5.Location = new System.Drawing.Point(3, 289);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(142, 100);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 41;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ForeignWords.Properties.Resources.gamon_LegoLogo_decentrato_sfondo_bianco_256x256;
            this.pictureBox3.Location = new System.Drawing.Point(25, 124);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(120, 120);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Cursor = System.Windows.Forms.Cursors.Default;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(528, 342);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(125, 21);
            this.label12.TabIndex = 40;
            this.label12.Text = "for this software";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Cursor = System.Windows.Forms.Cursors.Default;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(531, 323);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(118, 21);
            this.label11.TabIndex = 39;
            this.label11.Text = "EU Commission";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(531, 302);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(119, 21);
            this.label10.TabIndex = 38;
            this.label10.Text = "No fund from the";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ForeignWords.Properties.Resources.ErasmusPlus;
            this.pictureBox4.Location = new System.Drawing.Point(384, 289);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(141, 100);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 37;
            this.pictureBox4.TabStop = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(494, 166);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(179, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "ITT \"Blaise Pascal\"";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(7, 432);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(642, 21);
            this.label9.TabIndex = 36;
            this.label9.Text = "Find the source code at https://github.com/gamondue/ForeignWords";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(518, 194);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(131, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Cesena, ITALIA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(134, 194);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(192, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "prof@ingmonti.it";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(103, 359);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(239, 16);
            this.label8.TabIndex = 33;
            this.label8.Text = "An Erasmus+ Project of the E.U.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(103, 328);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(239, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "Active Learning Academy";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(111, 301);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(223, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "ALA";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(7, 410);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(642, 21);
            this.label2.TabIndex = 25;
            this.label2.Text = "ForeignWords is free software, regulated by the GPL licence v.2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ForeignWords.Properties.Resources.logo_blaise_pascal_300x212;
            this.pictureBox1.Location = new System.Drawing.Point(361, 124);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // frmAbout
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(679, 478);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Activated += new System.EventHandler(this.frmAbout_Activated);
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmAbout_Load(object sender, System.EventArgs e)
		{
            lblAssemblyTitle.Text = System.Diagnostics.FileVersionInfo.GetVersionInfo
                    (System.Reflection.Assembly.GetExecutingAssembly().Location)
                    .FileDescription;
            lblAssemblyDescription.Text = System.Diagnostics.FileVersionInfo.GetVersionInfo
                    (System.Reflection.Assembly.GetExecutingAssembly().Location)
                    .Comments;


            lblVersione.Text += System.Diagnostics.FileVersionInfo.GetVersionInfo
                    (System.Reflection.Assembly.GetExecutingAssembly().Location)
                    .ProductVersion;
            DateTime CreationDate = System.IO.File.GetCreationTime(Assembly.GetExecutingAssembly().Location);
            lblData.Text = CreationDate.ToString("yyyy-MM-dd");
            // lblData.Text = DateCompiled().ToString();
        }

        private void frmAbout_Activated(object sender, System.EventArgs e)
		{
			Timer1.Enabled = false;
			Timer1.Interval = 4000;
			Timer1.Enabled = true;
		}

		private void Timer1_Tick(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private DateTime DateCompiled()

        // Assumes that in AssemblyInfo.cs,
        // the version is specified as 1.0.* or the like,
        // with only 2 numbers specified;
        // the next two are generated from the date.
        // This routine decodes them.
        {

            System.Version v =
            System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            // v.Build is days since Jan. 1, 2000
            // v.Revision*2 is seconds since local midnight
            // (NEVER daylight saving time)

            //DateTime t = new DateTime(
            //    v.Build * TimeSpan.TicksPerDay +
            //    v.Revision * TimeSpan.TicksPerSecond * 2
            //).AddYears(1999);
            
            DateTime t = new DateTime(
                v.Build * TimeSpan.TicksPerDay).AddYears(1999);

            return t;
        }
	}
}

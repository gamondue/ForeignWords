namespace gamon.ForeignWords
{
    partial class frmNuovoRandom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuovoRandom));
            this.rdNulla = new System.Windows.Forms.RadioButton();
            this.rdRandom = new System.Windows.Forms.RadioButton();
            this.rdDeterminata = new System.Windows.Forms.RadioButton();
            this.txtSeme = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdNulla
            // 
            this.rdNulla.AutoSize = true;
            this.rdNulla.Location = new System.Drawing.Point(12, 60);
            this.rdNulla.Name = "rdNulla";
            this.rdNulla.Size = new System.Drawing.Size(105, 17);
            this.rdNulla.TabIndex = 0;
            this.rdNulla.TabStop = true;
            this.rdNulla.Text = "Ordine alfabetico";
            this.rdNulla.UseVisualStyleBackColor = true;
            this.rdNulla.CheckedChanged += new System.EventHandler(this.rdNulla_CheckedChanged);
            // 
            // rdRandom
            // 
            this.rdRandom.AutoSize = true;
            this.rdRandom.Checked = true;
            this.rdRandom.Location = new System.Drawing.Point(12, 12);
            this.rdRandom.Name = "rdRandom";
            this.rdRandom.Size = new System.Drawing.Size(146, 17);
            this.rdRandom.TabIndex = 1;
            this.rdRandom.TabStop = true;
            this.rdRandom.Text = "Nuova sequenza casuale";
            this.rdRandom.UseVisualStyleBackColor = true;
            this.rdRandom.CheckedChanged += new System.EventHandler(this.rdRandom_CheckedChanged);
            // 
            // rdDeterminata
            // 
            this.rdDeterminata.AutoSize = true;
            this.rdDeterminata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rdDeterminata.Location = new System.Drawing.Point(12, 36);
            this.rdDeterminata.Name = "rdDeterminata";
            this.rdDeterminata.Size = new System.Drawing.Size(178, 17);
            this.rdDeterminata.TabIndex = 2;
            this.rdDeterminata.TabStop = true;
            this.rdDeterminata.Text = "Sequenza determinata, numero: ";
            this.rdDeterminata.UseVisualStyleBackColor = false;
            this.rdDeterminata.CheckedChanged += new System.EventHandler(this.rdDeterminata_CheckedChanged);
            // 
            // txtSeme
            // 
            this.txtSeme.Enabled = false;
            this.txtSeme.Location = new System.Drawing.Point(187, 35);
            this.txtSeme.Name = "txtSeme";
            this.txtSeme.Size = new System.Drawing.Size(100, 20);
            this.txtSeme.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(232, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(54, 24);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmNuovoRandom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(294, 87);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtSeme);
            this.Controls.Add(this.rdDeterminata);
            this.Controls.Add(this.rdRandom);
            this.Controls.Add(this.rdNulla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmNuovoRandom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuova sequenza di domande";
            this.Load += new System.EventHandler(this.frmNuovoRandom_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmNuovoRandom_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdNulla;
        private System.Windows.Forms.RadioButton rdRandom;
        private System.Windows.Forms.RadioButton rdDeterminata;
        private System.Windows.Forms.TextBox txtSeme;
        private System.Windows.Forms.Button btnOK;
    }
}
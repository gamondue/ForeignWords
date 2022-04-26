
namespace gamon.ForeignWords
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnEditUICaptions = new System.Windows.Forms.Button();
            this.btnInfinitives = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEditUICaptions
            // 
            this.btnEditUICaptions.Location = new System.Drawing.Point(12, 12);
            this.btnEditUICaptions.Name = "btnEditUICaptions";
            this.btnEditUICaptions.Size = new System.Drawing.Size(136, 65);
            this.btnEditUICaptions.TabIndex = 0;
            this.btnEditUICaptions.Text = "Edit User Interface\'s texts";
            this.btnEditUICaptions.UseVisualStyleBackColor = true;
            this.btnEditUICaptions.Click += new System.EventHandler(this.btnEditUICaptions_Click);
            // 
            // btnInfinitives
            // 
            this.btnInfinitives.Location = new System.Drawing.Point(155, 12);
            this.btnInfinitives.Name = "btnInfinitives";
            this.btnInfinitives.Size = new System.Drawing.Size(136, 65);
            this.btnInfinitives.TabIndex = 1;
            this.btnInfinitives.Text = "Edit Languages\' infinitive tenses";
            this.btnInfinitives.UseVisualStyleBackColor = true;
            this.btnInfinitives.Click += new System.EventHandler(this.btnInfinitives_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(310, 89);
            this.Controls.Add(this.btnInfinitives);
            this.Controls.Add(this.btnEditUICaptions);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "ForeignWords Language Editor";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEditUICaptions;
        private System.Windows.Forms.Button btnInfinitives;
    }
}

namespace gamon.ForeignWords
{
    partial class frmInfinitives
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfinitives));
            this.grdDati = new System.Windows.Forms.DataGridView();
            this.btnLeggiDatabase = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCopyDatabaseFile = new System.Windows.Forms.Button();
            this.btnNuova = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.boundInfinitives = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdDati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boundInfinitives)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDati
            // 
            this.grdDati.AllowDrop = true;
            this.grdDati.AllowUserToOrderColumns = true;
            this.grdDati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDati.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.grdDati.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDati.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDati.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdDati.Location = new System.Drawing.Point(144, 1);
            this.grdDati.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grdDati.Name = "grdDati";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDati.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdDati.Size = new System.Drawing.Size(683, 396);
            this.grdDati.TabIndex = 6;
            // 
            // btnLeggiDatabase
            // 
            this.btnLeggiDatabase.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLeggiDatabase.Location = new System.Drawing.Point(282, 403);
            this.btnLeggiDatabase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLeggiDatabase.Name = "btnLeggiDatabase";
            this.btnLeggiDatabase.Size = new System.Drawing.Size(131, 40);
            this.btnLeggiDatabase.TabIndex = 17;
            this.btnLeggiDatabase.Text = "Read Database File";
            this.btnLeggiDatabase.UseVisualStyleBackColor = true;
            this.btnLeggiDatabase.Visible = false;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSend.Location = new System.Drawing.Point(558, 403);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(131, 40);
            this.btnSend.TabIndex = 16;
            this.btnSend.Text = "Send database file to the author";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Visible = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCopyDatabaseFile
            // 
            this.btnCopyDatabaseFile.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCopyDatabaseFile.Location = new System.Drawing.Point(420, 403);
            this.btnCopyDatabaseFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCopyDatabaseFile.Name = "btnCopyDatabaseFile";
            this.btnCopyDatabaseFile.Size = new System.Drawing.Size(131, 40);
            this.btnCopyDatabaseFile.TabIndex = 15;
            this.btnCopyDatabaseFile.Text = "Take Database File";
            this.btnCopyDatabaseFile.UseVisualStyleBackColor = true;
            this.btnCopyDatabaseFile.Visible = false;
            // 
            // btnNuova
            // 
            this.btnNuova.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNuova.Location = new System.Drawing.Point(144, 403);
            this.btnNuova.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNuova.Name = "btnNuova";
            this.btnNuova.Size = new System.Drawing.Size(131, 40);
            this.btnNuova.TabIndex = 14;
            this.btnNuova.Text = "New language";
            this.btnNuova.UseVisualStyleBackColor = true;
            this.btnNuova.Visible = false;
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAbort.Location = new System.Drawing.Point(696, 403);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(131, 40);
            this.btnAbort.TabIndex = 13;
            this.btnAbort.Text = "Close";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.BackColor = System.Drawing.Color.Red;
            this.btnSave.ForeColor = System.Drawing.Color.Yellow;
            this.btnSave.Location = new System.Drawing.Point(6, 403);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 40);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmInfinitives
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(834, 446);
            this.Controls.Add(this.btnLeggiDatabase);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCopyDatabaseFile);
            this.Controls.Add(this.btnNuova);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdDati);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInfinitives";
            this.Text = "Infinitive tenses in program\'s languages";
            this.Load += new System.EventHandler(this.frmInfinitives_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boundInfinitives)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDati;
        private System.Windows.Forms.Button btnLeggiDatabase;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCopyDatabaseFile;
        private System.Windows.Forms.Button btnNuova;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource boundInfinitives;
    }
}
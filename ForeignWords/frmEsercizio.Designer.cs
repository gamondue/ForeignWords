namespace gamon.ForeignWords
{
    partial class frmEsercizio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEsercizio));
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.grdEsercizio = new System.Windows.Forms.DataGridView();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.btnDestra = new System.Windows.Forms.Button();
            this.btnDestra2 = new System.Windows.Forms.Button();
            this.btnSinistra = new System.Windows.Forms.Button();
            this.btnSinistra2 = new System.Windows.Forms.Button();
            this.bindSVerbiTutti = new System.Windows.Forms.BindingSource(this.components);
            this.bindSVerbiEsercizio = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdTutti = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdEsercizio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindSVerbiTutti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindSVerbiEsercizio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTutti)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(82, 12);
            this.txtEsercizio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(677, 23);
            this.txtEsercizio.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(14, 332);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 31);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAbort.Location = new System.Drawing.Point(637, 332);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(122, 31);
            this.btnAbort.TabIndex = 4;
            this.btnAbort.Text = "Esci senza salvare";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // grdEsercizio
            // 
            this.grdEsercizio.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.grdEsercizio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEsercizio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEsercizio.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdEsercizio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEsercizio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdEsercizio.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdEsercizio.Location = new System.Drawing.Point(4, 0);
            this.grdEsercizio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grdEsercizio.Name = "grdEsercizio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdEsercizio.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdEsercizio.Size = new System.Drawing.Size(375, 285);
            this.grdEsercizio.TabIndex = 5;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(14, 12);
            this.txtCodice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.ReadOnly = true;
            this.txtCodice.Size = new System.Drawing.Size(60, 23);
            this.txtCodice.TabIndex = 6;
            // 
            // btnDestra
            // 
            this.btnDestra.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDestra.Location = new System.Drawing.Point(332, 331);
            this.btnDestra.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDestra.Name = "btnDestra";
            this.btnDestra.Size = new System.Drawing.Size(37, 39);
            this.btnDestra.TabIndex = 7;
            this.btnDestra.Text = ">";
            this.btnDestra.UseVisualStyleBackColor = true;
            this.btnDestra.Click += new System.EventHandler(this.btnDestra_Click);
            // 
            // btnDestra2
            // 
            this.btnDestra2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDestra2.Location = new System.Drawing.Point(288, 330);
            this.btnDestra2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDestra2.Name = "btnDestra2";
            this.btnDestra2.Size = new System.Drawing.Size(37, 39);
            this.btnDestra2.TabIndex = 8;
            this.btnDestra2.Text = ">>";
            this.btnDestra2.UseVisualStyleBackColor = true;
            this.btnDestra2.Click += new System.EventHandler(this.btnDestra2_Click);
            // 
            // btnSinistra
            // 
            this.btnSinistra.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSinistra.Location = new System.Drawing.Point(377, 331);
            this.btnSinistra.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSinistra.Name = "btnSinistra";
            this.btnSinistra.Size = new System.Drawing.Size(37, 39);
            this.btnSinistra.TabIndex = 9;
            this.btnSinistra.Text = "<";
            this.btnSinistra.UseVisualStyleBackColor = true;
            this.btnSinistra.Click += new System.EventHandler(this.btnSinistra_Click);
            // 
            // btnSinistra2
            // 
            this.btnSinistra2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSinistra2.Location = new System.Drawing.Point(421, 331);
            this.btnSinistra2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSinistra2.Name = "btnSinistra2";
            this.btnSinistra2.Size = new System.Drawing.Size(37, 39);
            this.btnSinistra2.TabIndex = 10;
            this.btnSinistra2.Text = "<<";
            this.btnSinistra2.UseVisualStyleBackColor = true;
            this.btnSinistra2.Click += new System.EventHandler(this.btnSinistra2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(14, 42);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdTutti);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdEsercizio);
            this.splitContainer1.Size = new System.Drawing.Size(746, 288);
            this.splitContainer1.SplitterDistance = 358;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 11;
            // 
            // grdTutti
            // 
            this.grdTutti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTutti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdTutti.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTutti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdTutti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTutti.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdTutti.Location = new System.Drawing.Point(0, 0);
            this.grdTutti.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grdTutti.Name = "grdTutti";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTutti.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdTutti.Size = new System.Drawing.Size(356, 285);
            this.grdTutti.TabIndex = 0;
            // 
            // frmEsercizio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(774, 373);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnSinistra2);
            this.Controls.Add(this.btnSinistra);
            this.Controls.Add(this.btnDestra2);
            this.Controls.Add(this.btnDestra);
            this.Controls.Add(this.txtCodice);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtEsercizio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmEsercizio";
            this.Text = "Configurazioni esercizio";
            this.Load += new System.EventHandler(this.frmEsercizio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdEsercizio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindSVerbiTutti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindSVerbiEsercizio)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTutti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.DataGridView grdEsercizio;
        private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.Button btnDestra;
        private System.Windows.Forms.Button btnDestra2;
        private System.Windows.Forms.Button btnSinistra;
        private System.Windows.Forms.Button btnSinistra2;
        private System.Windows.Forms.BindingSource bindSVerbiTutti;
        private System.Windows.Forms.BindingSource bindSVerbiEsercizio;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grdTutti;
    }
}
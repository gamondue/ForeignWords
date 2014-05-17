namespace gamon.ForeignWords
{
    partial class frmTuttiEsercizi
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTuttiEsercizi));
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grdDati = new System.Windows.Forms.DataGridView();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.bindEsercizi = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancella = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindEsercizi)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAbort.Location = new System.Drawing.Point(542, 281);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(112, 28);
            this.btnAbort.TabIndex = 7;
            this.btnAbort.Text = "Scegli";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(14, 281);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Salva modifiche";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // grdDati
            // 
            this.grdDati.AllowUserToDeleteRows = false;
            this.grdDati.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdDati.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDati.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDati.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdDati.Location = new System.Drawing.Point(14, 38);
            this.grdDati.Name = "grdDati";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDati.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdDati.Size = new System.Drawing.Size(641, 237);
            this.grdDati.TabIndex = 5;
            this.grdDati.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDati_CellValueChanged);
            this.grdDati.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDati_CellClick);
            this.grdDati.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdDati_RowHeaderMouseDoubleClick);
            this.grdDati.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdDati_KeyPress);
            this.grdDati.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDati_CellContentClick);
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(14, 12);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.ReadOnly = true;
            this.txtCodice.Size = new System.Drawing.Size(52, 20);
            this.txtCodice.TabIndex = 9;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(74, 12);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(581, 20);
            this.txtEsercizio.TabIndex = 8;
            // 
            // btnCancella
            // 
            this.btnCancella.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancella.Location = new System.Drawing.Point(278, 281);
            this.btnCancella.Name = "btnCancella";
            this.btnCancella.Size = new System.Drawing.Size(112, 28);
            this.btnCancella.TabIndex = 10;
            this.btnCancella.Text = "Cancella esercizio";
            this.btnCancella.UseVisualStyleBackColor = true;
            this.btnCancella.Click += new System.EventHandler(this.btnCancella_Click);
            // 
            // frmTuttiEsercizi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(665, 321);
            this.Controls.Add(this.btnCancella);
            this.Controls.Add(this.txtCodice);
            this.Controls.Add(this.txtEsercizio);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdDati);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTuttiEsercizi";
            this.Text = "Scelta dell\' esercizio da svolgere";
            ((System.ComponentModel.ISupportInitialize)(this.grdDati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindEsercizi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView grdDati;
        public System.Windows.Forms.TextBox txtCodice;
        public System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.BindingSource bindEsercizi;
        private System.Windows.Forms.Button btnCancella;
    }
}
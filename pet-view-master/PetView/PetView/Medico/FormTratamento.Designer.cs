namespace PetView
{
    partial class FormTratamento
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label17 = new System.Windows.Forms.Label();
            this.flpBotoes = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDono = new System.Windows.Forms.ComboBox();
            this.cboTratamento = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rtxtObservacoes = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtxtDadosAnimal = new System.Windows.Forms.RichTextBox();
            this.rtxtDadosDono = new System.Windows.Forms.RichTextBox();
            this.rtxtDadosTratamento = new System.Windows.Forms.RichTextBox();
            this.flpBotoes.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Top;
            this.label17.Font = new System.Drawing.Font("Calibri", 14F);
            this.label17.Location = new System.Drawing.Point(0, 0);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.label17.Size = new System.Drawing.Size(1560, 66);
            this.label17.TabIndex = 8;
            this.label17.Text = "Tratamento";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpBotoes
            // 
            this.flpBotoes.Controls.Add(this.btnCadastrar);
            this.flpBotoes.Controls.Add(this.btnCancelar);
            this.flpBotoes.Controls.Add(this.btnLimpar);
            this.flpBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpBotoes.Location = new System.Drawing.Point(0, 751);
            this.flpBotoes.Margin = new System.Windows.Forms.Padding(4);
            this.flpBotoes.Name = "flpBotoes";
            this.flpBotoes.Padding = new System.Windows.Forms.Padding(0, 0, 27, 0);
            this.flpBotoes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flpBotoes.Size = new System.Drawing.Size(1560, 123);
            this.flpBotoes.TabIndex = 13;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.Location = new System.Drawing.Point(1287, 12);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(233, 62);
            this.btnCadastrar.TabIndex = 17;
            this.btnCadastrar.Text = "Finalizar tratamento";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(1028, 12);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(233, 62);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLimpar.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(769, 12);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(233, 62);
            this.btnLimpar.TabIndex = 18;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.63732F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.61103F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.50592F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.24573F));
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboDono, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboTratamento, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rtxtObservacoes, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.rtxtDadosAnimal, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rtxtDadosDono, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.rtxtDadosTratamento, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 66);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.372093F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.72868F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.78295F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1560, 685);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 13F);
            this.label7.Location = new System.Drawing.Point(801, 33);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label7.Size = new System.Drawing.Size(176, 27);
            this.label7.TabIndex = 10;
            this.label7.Text = "Filtrar por dono";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13F);
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(152, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecionar tratamento *";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13F);
            this.label3.Location = new System.Drawing.Point(23, 172);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(186, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dados do animal";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 13F);
            this.label4.Location = new System.Drawing.Point(801, 172);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(172, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dados do dono";
            // 
            // cboDono
            // 
            this.cboDono.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboDono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDono.Font = new System.Drawing.Font("Calibri", 13F);
            this.cboDono.FormattingEnabled = true;
            this.cboDono.Location = new System.Drawing.Point(1051, 29);
            this.cboDono.Name = "cboDono";
            this.cboDono.Size = new System.Drawing.Size(471, 35);
            this.cboDono.TabIndex = 11;
            this.cboDono.TextChanged += new System.EventHandler(this.cboDono_TextChanged);
            // 
            // cboTratamento
            // 
            this.cboTratamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboTratamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTratamento.Font = new System.Drawing.Font("Calibri", 13F);
            this.cboTratamento.FormattingEnabled = true;
            this.cboTratamento.Location = new System.Drawing.Point(281, 29);
            this.cboTratamento.Name = "cboTratamento";
            this.cboTratamento.Size = new System.Drawing.Size(492, 35);
            this.cboTratamento.TabIndex = 4;
            this.cboTratamento.SelectedValueChanged += new System.EventHandler(this.cboTratamento_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 13F);
            this.label6.Location = new System.Drawing.Point(23, 387);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label6.Size = new System.Drawing.Size(165, 27);
            this.label6.TabIndex = 9;
            this.label6.Text = "Observações *";
            // 
            // rtxtObservacoes
            // 
            this.rtxtObservacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtObservacoes.Font = new System.Drawing.Font("Calibri", 13F);
            this.rtxtObservacoes.Location = new System.Drawing.Point(272, 313);
            this.rtxtObservacoes.Margin = new System.Windows.Forms.Padding(15);
            this.rtxtObservacoes.MaxLength = 300;
            this.rtxtObservacoes.Name = "rtxtObservacoes";
            this.rtxtObservacoes.Size = new System.Drawing.Size(511, 175);
            this.rtxtObservacoes.TabIndex = 14;
            this.rtxtObservacoes.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13F);
            this.label2.Location = new System.Drawing.Point(801, 387);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(228, 27);
            this.label2.TabIndex = 18;
            this.label2.Text = "Dados do tratamento";
            // 
            // rtxtDadosAnimal
            // 
            this.rtxtDadosAnimal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtDadosAnimal.Font = new System.Drawing.Font("Calibri", 13F);
            this.rtxtDadosAnimal.Location = new System.Drawing.Point(272, 89);
            this.rtxtDadosAnimal.Margin = new System.Windows.Forms.Padding(15);
            this.rtxtDadosAnimal.Name = "rtxtDadosAnimal";
            this.rtxtDadosAnimal.ReadOnly = true;
            this.rtxtDadosAnimal.Size = new System.Drawing.Size(511, 194);
            this.rtxtDadosAnimal.TabIndex = 22;
            this.rtxtDadosAnimal.Text = "";
            // 
            // rtxtDadosDono
            // 
            this.rtxtDadosDono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtDadosDono.Font = new System.Drawing.Font("Calibri", 13F);
            this.rtxtDadosDono.Location = new System.Drawing.Point(1048, 89);
            this.rtxtDadosDono.Margin = new System.Windows.Forms.Padding(15);
            this.rtxtDadosDono.Name = "rtxtDadosDono";
            this.rtxtDadosDono.ReadOnly = true;
            this.rtxtDadosDono.Size = new System.Drawing.Size(477, 194);
            this.rtxtDadosDono.TabIndex = 23;
            this.rtxtDadosDono.Text = "";
            // 
            // rtxtDadosTratamento
            // 
            this.rtxtDadosTratamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtDadosTratamento.Font = new System.Drawing.Font("Calibri", 13F);
            this.rtxtDadosTratamento.Location = new System.Drawing.Point(1048, 313);
            this.rtxtDadosTratamento.Margin = new System.Windows.Forms.Padding(15);
            this.rtxtDadosTratamento.Name = "rtxtDadosTratamento";
            this.rtxtDadosTratamento.ReadOnly = true;
            this.rtxtDadosTratamento.Size = new System.Drawing.Size(477, 175);
            this.rtxtDadosTratamento.TabIndex = 24;
            this.rtxtDadosTratamento.Text = "";
            // 
            // FormTratamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flpBotoes);
            this.Controls.Add(this.label17);
            this.Name = "FormTratamento";
            this.Size = new System.Drawing.Size(1560, 874);
            this.flpBotoes.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.FlowLayoutPanel flpBotoes;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDono;
        private System.Windows.Forms.ComboBox cboTratamento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtxtObservacoes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtxtDadosAnimal;
        private System.Windows.Forms.RichTextBox rtxtDadosDono;
        private System.Windows.Forms.RichTextBox rtxtDadosTratamento;
    }
}

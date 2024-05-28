namespace PetView
{
    partial class Estrutura
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlSeguidora = new System.Windows.Forms.Panel();
            this.lblBemVindo = new System.Windows.Forms.Label();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnExame = new System.Windows.Forms.Button();
            this.btnTratamento = new System.Windows.Forms.Button();
            this.btnAgendamento = new System.Windows.Forms.Button();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnAnimal = new System.Windows.Forms.Button();
            this.btnDono = new System.Windows.Forms.Button();
            this.btnFuncionario = new System.Windows.Forms.Button();
            this.btnMedico = new System.Windows.Forms.Button();
            this.btnRegistros = new System.Windows.Forms.Button();
            this.btnAgenda = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.formAgenda1 = new PetView.FormAgenda();
            this.formDono1 = new PetView.FormDono();
            this.registros1 = new PetView.Registros();
            this.formMedico1 = new PetView.FormMedico();
            this.formFuncionario1 = new PetView.FormFuncionario();
            this.formAnimal1 = new PetView.FormAnimal();
            this.agendamento1 = new PetView.Agendamento();
            this.formConsulta1 = new PetView.FormConsulta();
            this.formExame1 = new PetView.FormExame();
            this.formTratamento1 = new PetView.FormTratamento();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.pnlSeguidora);
            this.panel1.Controls.Add(this.lblBemVindo);
            this.panel1.Controls.Add(this.btnConsulta);
            this.panel1.Controls.Add(this.btnExame);
            this.panel1.Controls.Add(this.btnTratamento);
            this.panel1.Controls.Add(this.btnAgendamento);
            this.panel1.Controls.Add(this.btnCadastro);
            this.panel1.Controls.Add(this.btnAnimal);
            this.panel1.Controls.Add(this.btnDono);
            this.panel1.Controls.Add(this.btnFuncionario);
            this.panel1.Controls.Add(this.btnMedico);
            this.panel1.Controls.Add(this.btnRegistros);
            this.panel1.Controls.Add(this.btnAgenda);
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 894);
            this.panel1.TabIndex = 0;
            // 
            // pnlSeguidora
            // 
            this.pnlSeguidora.BackColor = System.Drawing.Color.AntiqueWhite;
            this.pnlSeguidora.Location = new System.Drawing.Point(2, 150);
            this.pnlSeguidora.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlSeguidora.Name = "pnlSeguidora";
            this.pnlSeguidora.Size = new System.Drawing.Size(6, 57);
            this.pnlSeguidora.TabIndex = 9;
            this.pnlSeguidora.Visible = false;
            // 
            // lblBemVindo
            // 
            this.lblBemVindo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBemVindo.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.lblBemVindo.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.lblBemVindo.Location = new System.Drawing.Point(0, 0);
            this.lblBemVindo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBemVindo.Name = "lblBemVindo";
            this.lblBemVindo.Padding = new System.Windows.Forms.Padding(4, 16, 4, 4);
            this.lblBemVindo.Size = new System.Drawing.Size(196, 131);
            this.lblBemVindo.TabIndex = 8;
            this.lblBemVindo.Text = "Bem vindo(a)!";
            this.lblBemVindo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBemVindo.Click += new System.EventHandler(this.lblBemVindo_Click);
            // 
            // btnConsulta
            // 
            this.btnConsulta.BackColor = System.Drawing.Color.Transparent;
            this.btnConsulta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConsulta.FlatAppearance.BorderSize = 0;
            this.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsulta.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnConsulta.Location = new System.Drawing.Point(0, 210);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnConsulta.Size = new System.Drawing.Size(196, 57);
            this.btnConsulta.TabIndex = 14;
            this.btnConsulta.Text = "Consulta";
            this.btnConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsulta.UseVisualStyleBackColor = false;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnExame
            // 
            this.btnExame.BackColor = System.Drawing.Color.Transparent;
            this.btnExame.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExame.FlatAppearance.BorderSize = 0;
            this.btnExame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnExame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExame.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExame.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnExame.Location = new System.Drawing.Point(0, 267);
            this.btnExame.Name = "btnExame";
            this.btnExame.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnExame.Size = new System.Drawing.Size(196, 57);
            this.btnExame.TabIndex = 14;
            this.btnExame.Text = "Exame";
            this.btnExame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExame.UseVisualStyleBackColor = false;
            this.btnExame.Click += new System.EventHandler(this.btnExame_Click);
            // 
            // btnTratamento
            // 
            this.btnTratamento.BackColor = System.Drawing.Color.Transparent;
            this.btnTratamento.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTratamento.FlatAppearance.BorderSize = 0;
            this.btnTratamento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTratamento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnTratamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTratamento.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTratamento.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnTratamento.Location = new System.Drawing.Point(0, 324);
            this.btnTratamento.Name = "btnTratamento";
            this.btnTratamento.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnTratamento.Size = new System.Drawing.Size(196, 57);
            this.btnTratamento.TabIndex = 13;
            this.btnTratamento.Text = "Tratamento";
            this.btnTratamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTratamento.UseVisualStyleBackColor = false;
            this.btnTratamento.Click += new System.EventHandler(this.btnTratamento_Click);
            // 
            // btnAgendamento
            // 
            this.btnAgendamento.BackColor = System.Drawing.Color.Transparent;
            this.btnAgendamento.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAgendamento.FlatAppearance.BorderSize = 0;
            this.btnAgendamento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAgendamento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnAgendamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgendamento.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgendamento.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnAgendamento.Location = new System.Drawing.Point(0, 381);
            this.btnAgendamento.Name = "btnAgendamento";
            this.btnAgendamento.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnAgendamento.Size = new System.Drawing.Size(196, 57);
            this.btnAgendamento.TabIndex = 10;
            this.btnAgendamento.Text = "Novo agendamento";
            this.btnAgendamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgendamento.UseVisualStyleBackColor = false;
            this.btnAgendamento.Click += new System.EventHandler(this.btnAgendamento_Click);
            // 
            // btnCadastro
            // 
            this.btnCadastro.BackColor = System.Drawing.Color.Transparent;
            this.btnCadastro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCadastro.FlatAppearance.BorderSize = 0;
            this.btnCadastro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCadastro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastro.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastro.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnCadastro.Location = new System.Drawing.Point(0, 438);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnCadastro.Size = new System.Drawing.Size(196, 57);
            this.btnCadastro.TabIndex = 9;
            this.btnCadastro.Text = "Novo cadastro";
            this.btnCadastro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCadastro.UseVisualStyleBackColor = false;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // btnAnimal
            // 
            this.btnAnimal.BackColor = System.Drawing.Color.Transparent;
            this.btnAnimal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAnimal.FlatAppearance.BorderSize = 0;
            this.btnAnimal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAnimal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnimal.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnAnimal.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnAnimal.Location = new System.Drawing.Point(0, 495);
            this.btnAnimal.Name = "btnAnimal";
            this.btnAnimal.Padding = new System.Windows.Forms.Padding(30, 10, 10, 10);
            this.btnAnimal.Size = new System.Drawing.Size(196, 57);
            this.btnAnimal.TabIndex = 8;
            this.btnAnimal.Text = "Animal";
            this.btnAnimal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnimal.UseVisualStyleBackColor = false;
            this.btnAnimal.Visible = false;
            this.btnAnimal.Click += new System.EventHandler(this.btnAnimal_Click);
            // 
            // btnDono
            // 
            this.btnDono.BackColor = System.Drawing.Color.Transparent;
            this.btnDono.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDono.FlatAppearance.BorderSize = 0;
            this.btnDono.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDono.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnDono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDono.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnDono.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnDono.Location = new System.Drawing.Point(0, 552);
            this.btnDono.Name = "btnDono";
            this.btnDono.Padding = new System.Windows.Forms.Padding(30, 10, 10, 10);
            this.btnDono.Size = new System.Drawing.Size(196, 57);
            this.btnDono.TabIndex = 7;
            this.btnDono.Text = "Dono";
            this.btnDono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDono.UseVisualStyleBackColor = false;
            this.btnDono.Visible = false;
            this.btnDono.Click += new System.EventHandler(this.btnDono_Click);
            // 
            // btnFuncionario
            // 
            this.btnFuncionario.BackColor = System.Drawing.Color.Transparent;
            this.btnFuncionario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFuncionario.FlatAppearance.BorderSize = 0;
            this.btnFuncionario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFuncionario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFuncionario.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnFuncionario.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnFuncionario.Location = new System.Drawing.Point(0, 609);
            this.btnFuncionario.Name = "btnFuncionario";
            this.btnFuncionario.Padding = new System.Windows.Forms.Padding(30, 10, 10, 10);
            this.btnFuncionario.Size = new System.Drawing.Size(196, 57);
            this.btnFuncionario.TabIndex = 6;
            this.btnFuncionario.Text = "Funcionário";
            this.btnFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFuncionario.UseVisualStyleBackColor = false;
            this.btnFuncionario.Visible = false;
            this.btnFuncionario.Click += new System.EventHandler(this.btnFuncionario_Click);
            // 
            // btnMedico
            // 
            this.btnMedico.BackColor = System.Drawing.Color.Transparent;
            this.btnMedico.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMedico.FlatAppearance.BorderSize = 0;
            this.btnMedico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMedico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnMedico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedico.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnMedico.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnMedico.Location = new System.Drawing.Point(0, 666);
            this.btnMedico.Name = "btnMedico";
            this.btnMedico.Padding = new System.Windows.Forms.Padding(30, 10, 10, 10);
            this.btnMedico.Size = new System.Drawing.Size(196, 57);
            this.btnMedico.TabIndex = 5;
            this.btnMedico.Text = "Médico";
            this.btnMedico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedico.UseVisualStyleBackColor = false;
            this.btnMedico.Visible = false;
            this.btnMedico.Click += new System.EventHandler(this.btnMedico_Click);
            // 
            // btnRegistros
            // 
            this.btnRegistros.BackColor = System.Drawing.Color.Transparent;
            this.btnRegistros.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRegistros.FlatAppearance.BorderSize = 0;
            this.btnRegistros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRegistros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnRegistros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistros.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistros.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnRegistros.Location = new System.Drawing.Point(0, 723);
            this.btnRegistros.Name = "btnRegistros";
            this.btnRegistros.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnRegistros.Size = new System.Drawing.Size(196, 57);
            this.btnRegistros.TabIndex = 4;
            this.btnRegistros.Text = "Registros";
            this.btnRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistros.UseVisualStyleBackColor = false;
            this.btnRegistros.Click += new System.EventHandler(this.btnRegistros_Click);
            // 
            // btnAgenda
            // 
            this.btnAgenda.BackColor = System.Drawing.Color.Transparent;
            this.btnAgenda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAgenda.FlatAppearance.BorderSize = 0;
            this.btnAgenda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAgenda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnAgenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgenda.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgenda.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnAgenda.Location = new System.Drawing.Point(0, 780);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnAgenda.Size = new System.Drawing.Size(196, 57);
            this.btnAgenda.TabIndex = 3;
            this.btnAgenda.Text = "Agenda";
            this.btnAgenda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgenda.UseVisualStyleBackColor = false;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnLogOut.Location = new System.Drawing.Point(0, 837);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnLogOut.Size = new System.Drawing.Size(196, 57);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Sair";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Snow;
            this.panel2.Controls.Add(this.btnSair);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(196, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1259, 58);
            this.panel2.TabIndex = 1;
            // 
            // btnSair
            // 
            this.btnSair.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Calibri", 13F);
            this.btnSair.Location = new System.Drawing.Point(1184, 0);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 58);
            this.btnSair.TabIndex = 0;
            this.btnSair.Text = "X";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // formAgenda1
            // 
            this.formAgenda1.Location = new System.Drawing.Point(240, 756);
            this.formAgenda1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.formAgenda1.Name = "formAgenda1";
            this.formAgenda1.Size = new System.Drawing.Size(277, 106);
            this.formAgenda1.TabIndex = 8;
            this.formAgenda1.Visible = false;
            // 
            // formDono1
            // 
            this.formDono1.Location = new System.Drawing.Point(228, 626);
            this.formDono1.Name = "formDono1";
            this.formDono1.Size = new System.Drawing.Size(289, 108);
            this.formDono1.TabIndex = 7;
            this.formDono1.Visible = false;
            // 
            // registros1
            // 
            this.registros1.Location = new System.Drawing.Point(228, 506);
            this.registros1.Name = "registros1";
            this.registros1.Size = new System.Drawing.Size(289, 92);
            this.registros1.TabIndex = 6;
            this.registros1.Visible = false;
            // 
            // formMedico1
            // 
            this.formMedico1.Location = new System.Drawing.Point(227, 384);
            this.formMedico1.Name = "formMedico1";
            this.formMedico1.Size = new System.Drawing.Size(290, 80);
            this.formMedico1.TabIndex = 5;
            this.formMedico1.Visible = false;
            // 
            // formFuncionario1
            // 
            this.formFuncionario1.Location = new System.Drawing.Point(228, 280);
            this.formFuncionario1.Name = "formFuncionario1";
            this.formFuncionario1.Size = new System.Drawing.Size(289, 74);
            this.formFuncionario1.TabIndex = 4;
            this.formFuncionario1.Visible = false;
            // 
            // formAnimal1
            // 
            this.formAnimal1.Location = new System.Drawing.Point(228, 171);
            this.formAnimal1.Name = "formAnimal1";
            this.formAnimal1.Size = new System.Drawing.Size(289, 72);
            this.formAnimal1.TabIndex = 3;
            this.formAnimal1.Visible = false;
            // 
            // agendamento1
            // 
            this.agendamento1.Location = new System.Drawing.Point(228, 73);
            this.agendamento1.Name = "agendamento1";
            this.agendamento1.Size = new System.Drawing.Size(289, 58);
            this.agendamento1.TabIndex = 2;
            this.agendamento1.Visible = false;
            // 
            // formConsulta1
            // 
            this.formConsulta1.Location = new System.Drawing.Point(677, 73);
            this.formConsulta1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.formConsulta1.Name = "formConsulta1";
            this.formConsulta1.Size = new System.Drawing.Size(224, 93);
            this.formConsulta1.TabIndex = 9;
            this.formConsulta1.Visible = false;
            // 
            // formExame1
            // 
            this.formExame1.Location = new System.Drawing.Point(677, 213);
            this.formExame1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.formExame1.Name = "formExame1";
            this.formExame1.Size = new System.Drawing.Size(224, 106);
            this.formExame1.TabIndex = 10;
            this.formExame1.Visible = false;
            // 
            // formTratamento1
            // 
            this.formTratamento1.Location = new System.Drawing.Point(677, 368);
            this.formTratamento1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.formTratamento1.Name = "formTratamento1";
            this.formTratamento1.Size = new System.Drawing.Size(224, 106);
            this.formTratamento1.TabIndex = 11;
            this.formTratamento1.Visible = false;
            // 
            // Estrutura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1455, 894);
            this.Controls.Add(this.formTratamento1);
            this.Controls.Add(this.formExame1);
            this.Controls.Add(this.formConsulta1);
            this.Controls.Add(this.formAgenda1);
            this.Controls.Add(this.formDono1);
            this.Controls.Add(this.registros1);
            this.Controls.Add(this.formMedico1);
            this.Controls.Add(this.formFuncionario1);
            this.Controls.Add(this.formAnimal1);
            this.Controls.Add(this.agendamento1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Estrutura";
            this.Text = "Estrutura";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Estrutura_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMedico;
        private System.Windows.Forms.Button btnRegistros;
        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnFuncionario;
        private System.Windows.Forms.Button btnAgendamento;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Button btnAnimal;
        private System.Windows.Forms.Button btnDono;
        private Agendamento agendamento1;
        private FormAnimal formAnimal1;
        private FormFuncionario formFuncionario1;
        private FormMedico formMedico1;
        private Registros registros1;
        private FormDono formDono1;
        private System.Windows.Forms.Button btnTratamento;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Button btnExame;
        private System.Windows.Forms.Label lblBemVindo;
        private FormAgenda formAgenda1;
        private System.Windows.Forms.Panel pnlSeguidora;
        private FormConsulta formConsulta1;
        private FormExame formExame1;
        private FormTratamento formTratamento1;
    }
}
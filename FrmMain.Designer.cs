namespace Projeto_SistemadeChamadosCMR
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnAberturaChamados = new System.Windows.Forms.Button();
            this.BtnAutoriza = new System.Windows.Forms.Button();
            this.btnMeusChamados = new System.Windows.Forms.Button();
            this.BtnAdministrador = new System.Windows.Forms.Button();
            this.BtnCadastros = new System.Windows.Forms.Button();
            this.BtnFila = new System.Windows.Forms.Button();
            this.btnRelatórios = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUsuarioLogado = new System.Windows.Forms.Label();
            this.lbladmin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(129)))), ((int)(((byte)(26)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1014, 30);
            this.panel3.TabIndex = 4;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // BtnAberturaChamados
            // 
            this.BtnAberturaChamados.BackColor = System.Drawing.Color.SkyBlue;
            this.BtnAberturaChamados.FlatAppearance.BorderSize = 0;
            this.BtnAberturaChamados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAberturaChamados.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAberturaChamados.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnAberturaChamados.Image = ((System.Drawing.Image)(resources.GetObject("BtnAberturaChamados.Image")));
            this.BtnAberturaChamados.Location = new System.Drawing.Point(20, 175);
            this.BtnAberturaChamados.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAberturaChamados.Name = "BtnAberturaChamados";
            this.BtnAberturaChamados.Size = new System.Drawing.Size(276, 158);
            this.BtnAberturaChamados.TabIndex = 5;
            this.BtnAberturaChamados.Text = "Abrir Chamado";
            this.BtnAberturaChamados.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BtnAberturaChamados.UseVisualStyleBackColor = false;
            this.BtnAberturaChamados.Click += new System.EventHandler(this.BtnAberturaChamados_Click);
            // 
            // BtnAutoriza
            // 
            this.BtnAutoriza.BackColor = System.Drawing.Color.Khaki;
            this.BtnAutoriza.FlatAppearance.BorderSize = 0;
            this.BtnAutoriza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAutoriza.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAutoriza.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnAutoriza.Image = ((System.Drawing.Image)(resources.GetObject("BtnAutoriza.Image")));
            this.BtnAutoriza.Location = new System.Drawing.Point(20, 332);
            this.BtnAutoriza.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAutoriza.Name = "BtnAutoriza";
            this.BtnAutoriza.Size = new System.Drawing.Size(276, 152);
            this.BtnAutoriza.TabIndex = 6;
            this.BtnAutoriza.Text = "Autorizações de Chamados";
            this.BtnAutoriza.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BtnAutoriza.UseVisualStyleBackColor = false;
            this.BtnAutoriza.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnMeusChamados
            // 
            this.btnMeusChamados.BackColor = System.Drawing.Color.Pink;
            this.btnMeusChamados.FlatAppearance.BorderSize = 0;
            this.btnMeusChamados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeusChamados.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeusChamados.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMeusChamados.Image = ((System.Drawing.Image)(resources.GetObject("btnMeusChamados.Image")));
            this.btnMeusChamados.Location = new System.Drawing.Point(295, 175);
            this.btnMeusChamados.Margin = new System.Windows.Forms.Padding(2);
            this.btnMeusChamados.Name = "btnMeusChamados";
            this.btnMeusChamados.Size = new System.Drawing.Size(425, 158);
            this.btnMeusChamados.TabIndex = 7;
            this.btnMeusChamados.Text = "Meus Chamados";
            this.btnMeusChamados.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnMeusChamados.UseVisualStyleBackColor = false;
            this.btnMeusChamados.Click += new System.EventHandler(this.btnMeusChamados_Click);
            // 
            // BtnAdministrador
            // 
            this.BtnAdministrador.BackColor = System.Drawing.Color.DarkSalmon;
            this.BtnAdministrador.FlatAppearance.BorderSize = 0;
            this.BtnAdministrador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdministrador.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdministrador.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnAdministrador.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdministrador.Image")));
            this.BtnAdministrador.Location = new System.Drawing.Point(718, 332);
            this.BtnAdministrador.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAdministrador.Name = "BtnAdministrador";
            this.BtnAdministrador.Size = new System.Drawing.Size(273, 152);
            this.BtnAdministrador.TabIndex = 8;
            this.BtnAdministrador.Text = "Administrador";
            this.BtnAdministrador.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BtnAdministrador.UseVisualStyleBackColor = false;
            this.BtnAdministrador.Click += new System.EventHandler(this.BtnAdministrador_Click);
            // 
            // BtnCadastros
            // 
            this.BtnCadastros.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BtnCadastros.FlatAppearance.BorderSize = 0;
            this.BtnCadastros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCadastros.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCadastros.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnCadastros.Image = ((System.Drawing.Image)(resources.GetObject("BtnCadastros.Image")));
            this.BtnCadastros.Location = new System.Drawing.Point(720, 175);
            this.BtnCadastros.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCadastros.Name = "BtnCadastros";
            this.BtnCadastros.Size = new System.Drawing.Size(272, 158);
            this.BtnCadastros.TabIndex = 9;
            this.BtnCadastros.Text = "Cadastros";
            this.BtnCadastros.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BtnCadastros.UseVisualStyleBackColor = false;
            this.BtnCadastros.Click += new System.EventHandler(this.BtnCadastros_Click);
            // 
            // BtnFila
            // 
            this.BtnFila.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BtnFila.FlatAppearance.BorderSize = 0;
            this.BtnFila.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFila.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFila.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnFila.Image = ((System.Drawing.Image)(resources.GetObject("BtnFila.Image")));
            this.BtnFila.Location = new System.Drawing.Point(295, 332);
            this.BtnFila.Margin = new System.Windows.Forms.Padding(2);
            this.BtnFila.Name = "BtnFila";
            this.BtnFila.Size = new System.Drawing.Size(218, 152);
            this.BtnFila.TabIndex = 10;
            this.BtnFila.Text = "Fila de Atendimento ";
            this.BtnFila.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BtnFila.UseVisualStyleBackColor = false;
            this.BtnFila.Click += new System.EventHandler(this.BtnFila_Click);
            // 
            // btnRelatórios
            // 
            this.btnRelatórios.BackColor = System.Drawing.Color.Violet;
            this.btnRelatórios.FlatAppearance.BorderSize = 0;
            this.btnRelatórios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatórios.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatórios.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRelatórios.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatórios.Image")));
            this.btnRelatórios.Location = new System.Drawing.Point(513, 332);
            this.btnRelatórios.Margin = new System.Windows.Forms.Padding(2);
            this.btnRelatórios.Name = "btnRelatórios";
            this.btnRelatórios.Size = new System.Drawing.Size(207, 152);
            this.btnRelatórios.TabIndex = 11;
            this.btnRelatórios.Text = "Relatórios";
            this.btnRelatórios.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnRelatórios.UseVisualStyleBackColor = false;
            this.btnRelatórios.Click += new System.EventHandler(this.btnRelatórios_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(38, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 115);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(135, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sistema de Chamados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(909, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Versão: 4.3.3";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(137, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Bem vindo: ";
            // 
            // lblUsuarioLogado
            // 
            this.lblUsuarioLogado.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioLogado.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblUsuarioLogado.Location = new System.Drawing.Point(212, 102);
            this.lblUsuarioLogado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuarioLogado.Name = "lblUsuarioLogado";
            this.lblUsuarioLogado.Size = new System.Drawing.Size(245, 15);
            this.lblUsuarioLogado.TabIndex = 16;
            // 
            // lbladmin
            // 
            this.lbladmin.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladmin.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbladmin.Location = new System.Drawing.Point(892, 92);
            this.lbladmin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbladmin.Name = "lbladmin";
            this.lbladmin.Size = new System.Drawing.Size(113, 15);
            this.lbladmin.TabIndex = 17;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(1014, 575);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbladmin);
            this.Controls.Add(this.lblUsuarioLogado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRelatórios);
            this.Controls.Add(this.BtnFila);
            this.Controls.Add(this.BtnCadastros);
            this.Controls.Add(this.BtnAdministrador);
            this.Controls.Add(this.btnMeusChamados);
            this.Controls.Add(this.BtnAutoriza);
            this.Controls.Add(this.BtnAberturaChamados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUsuarioLogado;
        public System.Windows.Forms.Button BtnAberturaChamados;
        public System.Windows.Forms.Button BtnAutoriza;
        public System.Windows.Forms.Button btnMeusChamados;
        public System.Windows.Forms.Button BtnAdministrador;
        public System.Windows.Forms.Button BtnCadastros;
        public System.Windows.Forms.Button BtnFila;
        public System.Windows.Forms.Button btnRelatórios;
        public System.Windows.Forms.Label lbladmin;
    }
}
namespace Projeto_SistemadeChamadosCMR
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chamadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aberturaDeChamadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meusChamadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filaDeAtendimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pêndenciasDeAutorizaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarSubCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarDepartamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarGestorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarUsuárioPermissõesEspeciaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarPermissõesEspeciaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buscarHistóricoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairDoSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairDoSistemaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuarioLogado = new System.Windows.Forms.Label();
            this.timer1Horario = new System.Windows.Forms.Timer(this.components);
            this.lblAdmin = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkOrange;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chamadosToolStripMenuItem,
            this.cadastrosToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.administradorToolStripMenuItem,
            this.sairDoSistemaToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chamadosToolStripMenuItem
            // 
            this.chamadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aberturaDeChamadoToolStripMenuItem,
            this.meusChamadosToolStripMenuItem,
            this.filaDeAtendimentoToolStripMenuItem,
            this.pêndenciasDeAutorizaçãoToolStripMenuItem});
            this.chamadosToolStripMenuItem.Name = "chamadosToolStripMenuItem";
            this.chamadosToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.chamadosToolStripMenuItem.Text = "Chamados";
            // 
            // aberturaDeChamadoToolStripMenuItem
            // 
            this.aberturaDeChamadoToolStripMenuItem.Name = "aberturaDeChamadoToolStripMenuItem";
            this.aberturaDeChamadoToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.aberturaDeChamadoToolStripMenuItem.Text = "Abertura de Chamado";
            this.aberturaDeChamadoToolStripMenuItem.Click += new System.EventHandler(this.aberturaDeChamadoToolStripMenuItem_Click);
            // 
            // meusChamadosToolStripMenuItem
            // 
            this.meusChamadosToolStripMenuItem.Name = "meusChamadosToolStripMenuItem";
            this.meusChamadosToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.meusChamadosToolStripMenuItem.Text = "Meus Chamados";
            this.meusChamadosToolStripMenuItem.Click += new System.EventHandler(this.meusChamadosToolStripMenuItem_Click);
            // 
            // filaDeAtendimentoToolStripMenuItem
            // 
            this.filaDeAtendimentoToolStripMenuItem.Name = "filaDeAtendimentoToolStripMenuItem";
            this.filaDeAtendimentoToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.filaDeAtendimentoToolStripMenuItem.Text = "Fila de Atendimento";
            this.filaDeAtendimentoToolStripMenuItem.Click += new System.EventHandler(this.filaDeAtendimentoToolStripMenuItem_Click);
            // 
            // pêndenciasDeAutorizaçãoToolStripMenuItem
            // 
            this.pêndenciasDeAutorizaçãoToolStripMenuItem.Name = "pêndenciasDeAutorizaçãoToolStripMenuItem";
            this.pêndenciasDeAutorizaçãoToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.pêndenciasDeAutorizaçãoToolStripMenuItem.Text = "Pêndencias de Autorização";
            this.pêndenciasDeAutorizaçãoToolStripMenuItem.Click += new System.EventHandler(this.pêndenciasDeAutorizaçãoToolStripMenuItem_Click);
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarCategoriaToolStripMenuItem,
            this.cadastrarSubCategoriaToolStripMenuItem,
            this.cadastrarDepartamentoToolStripMenuItem,
            this.cadastrarGestorToolStripMenuItem,
            this.cadastrarUsuárioPermissõesEspeciaisToolStripMenuItem,
            this.cadastrarPermissõesEspeciaisToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            this.cadastrosToolStripMenuItem.Click += new System.EventHandler(this.cadastrosToolStripMenuItem_Click);
            // 
            // cadastrarCategoriaToolStripMenuItem
            // 
            this.cadastrarCategoriaToolStripMenuItem.Name = "cadastrarCategoriaToolStripMenuItem";
            this.cadastrarCategoriaToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.cadastrarCategoriaToolStripMenuItem.Text = "Cadastrar Categoria";
            this.cadastrarCategoriaToolStripMenuItem.Click += new System.EventHandler(this.cadastrarCategoriaToolStripMenuItem_Click);
            // 
            // cadastrarSubCategoriaToolStripMenuItem
            // 
            this.cadastrarSubCategoriaToolStripMenuItem.Name = "cadastrarSubCategoriaToolStripMenuItem";
            this.cadastrarSubCategoriaToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.cadastrarSubCategoriaToolStripMenuItem.Text = "Cadastrar Sub Categoria";
            this.cadastrarSubCategoriaToolStripMenuItem.Click += new System.EventHandler(this.cadastrarSubCategoriaToolStripMenuItem_Click);
            // 
            // cadastrarDepartamentoToolStripMenuItem
            // 
            this.cadastrarDepartamentoToolStripMenuItem.Name = "cadastrarDepartamentoToolStripMenuItem";
            this.cadastrarDepartamentoToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.cadastrarDepartamentoToolStripMenuItem.Text = "Cadastrar Departamento";
            this.cadastrarDepartamentoToolStripMenuItem.Click += new System.EventHandler(this.cadastrarDepartamentoToolStripMenuItem_Click);
            // 
            // cadastrarGestorToolStripMenuItem
            // 
            this.cadastrarGestorToolStripMenuItem.Name = "cadastrarGestorToolStripMenuItem";
            this.cadastrarGestorToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.cadastrarGestorToolStripMenuItem.Text = "Cadastrar Gestor";
            this.cadastrarGestorToolStripMenuItem.Click += new System.EventHandler(this.cadastrarGestorToolStripMenuItem_Click);
            // 
            // cadastrarUsuárioPermissõesEspeciaisToolStripMenuItem
            // 
            this.cadastrarUsuárioPermissõesEspeciaisToolStripMenuItem.Name = "cadastrarUsuárioPermissõesEspeciaisToolStripMenuItem";
            this.cadastrarUsuárioPermissõesEspeciaisToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.cadastrarUsuárioPermissõesEspeciaisToolStripMenuItem.Text = "Cadastrar Usuário Permissões especiais";
            this.cadastrarUsuárioPermissõesEspeciaisToolStripMenuItem.Click += new System.EventHandler(this.cadastrarUsuárioPermissoesEspeciaisToolStripMenuItem_Click);
            // 
            // cadastrarPermissõesEspeciaisToolStripMenuItem
            // 
            this.cadastrarPermissõesEspeciaisToolStripMenuItem.Name = "cadastrarPermissõesEspeciaisToolStripMenuItem";
            this.cadastrarPermissõesEspeciaisToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.cadastrarPermissõesEspeciaisToolStripMenuItem.Text = "Cadastrar Permissões Especiais";
            this.cadastrarPermissõesEspeciaisToolStripMenuItem.Click += new System.EventHandler(this.cadastrarPermissõesEspeciaisToolStripMenuItem_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.buscarHistóricoToolStripMenuItem});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // buscarHistóricoToolStripMenuItem
            // 
            this.buscarHistóricoToolStripMenuItem.Name = "buscarHistóricoToolStripMenuItem";
            this.buscarHistóricoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.buscarHistóricoToolStripMenuItem.Text = "Buscar Histórico";
            this.buscarHistóricoToolStripMenuItem.Click += new System.EventHandler(this.buscarHistóricoToolStripMenuItem_Click);
            // 
            // administradorToolStripMenuItem
            // 
            this.administradorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem});
            this.administradorToolStripMenuItem.Name = "administradorToolStripMenuItem";
            this.administradorToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.administradorToolStripMenuItem.Text = "Administrador";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // sairDoSistemaToolStripMenuItem
            // 
            this.sairDoSistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informaçãoToolStripMenuItem});
            this.sairDoSistemaToolStripMenuItem.Name = "sairDoSistemaToolStripMenuItem";
            this.sairDoSistemaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sairDoSistemaToolStripMenuItem.Text = "Sistema";
            // 
            // informaçãoToolStripMenuItem
            // 
            this.informaçãoToolStripMenuItem.Name = "informaçãoToolStripMenuItem";
            this.informaçãoToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.informaçãoToolStripMenuItem.Text = "Informação";
            this.informaçãoToolStripMenuItem.Click += new System.EventHandler(this.informaçãoToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairDoSistemaToolStripMenuItem1});
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // sairDoSistemaToolStripMenuItem1
            // 
            this.sairDoSistemaToolStripMenuItem1.Name = "sairDoSistemaToolStripMenuItem1";
            this.sairDoSistemaToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.sairDoSistemaToolStripMenuItem1.Text = "Sair do Sistema";
            this.sairDoSistemaToolStripMenuItem1.Click += new System.EventHandler(this.sairDoSistemaToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Online";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 634);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Você esta logado como :";
            // 
            // lblUsuarioLogado
            // 
            this.lblUsuarioLogado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioLogado.Location = new System.Drawing.Point(163, 636);
            this.lblUsuarioLogado.Name = "lblUsuarioLogado";
            this.lblUsuarioLogado.Size = new System.Drawing.Size(424, 16);
            this.lblUsuarioLogado.TabIndex = 3;
            this.lblUsuarioLogado.Text = "Usuário:";
            // 
            // timer1Horario
            // 
            this.timer1Horario.Enabled = true;
            this.timer1Horario.Interval = 1000;
            this.timer1Horario.Tick += new System.EventHandler(this.timer1Horario_Tick);
            // 
            // lblAdmin
            // 
            this.lblAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdmin.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAdmin.Location = new System.Drawing.Point(872, 634);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(129, 16);
            this.lblAdmin.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(92, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(822, 591);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.lblUsuarioLogado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Chamados CMR";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chamadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sairDoSistemaToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem administradorToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuarioLogado;
        private System.Windows.Forms.ToolStripMenuItem aberturaDeChamadoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem filaDeAtendimentoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cadastrarCategoriaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cadastrarSubCategoriaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cadastrarDepartamentoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem buscarHistóricoToolStripMenuItem;
        private System.Windows.Forms.Timer timer1Horario;
        public System.Windows.Forms.ToolStripMenuItem meusChamadosToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        public System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem informaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pêndenciasDeAutorizaçãoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cadastrarGestorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairDoSistemaToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem cadastrarUsuárioPermissõesEspeciaisToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cadastrarPermissõesEspeciaisToolStripMenuItem;
    }
}
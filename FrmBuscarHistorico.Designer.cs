namespace Projeto_SistemadeChamadosCMR
{
    partial class FrmBuscarHistorico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuscarHistorico));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboGestor = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboIndevido = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtResp = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mskData2 = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mskData1 = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSolicitante = new System.Windows.Forms.TextBox();
            this.comboDepar = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboSubcat = new System.Windows.Forms.ComboBox();
            this.comboCate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dataGridBuscar = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblQtdChamados = new System.Windows.Forms.Label();
            this.lblTexto = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataAbertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prioridade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subcategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solucao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indevido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datafechamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codcategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigosubcat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coddepar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBuscar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboGestor);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.comboIndevido);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtResp);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.mskData2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.mskData1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtSolicitante);
            this.groupBox1.Controls.Add(this.comboDepar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboSubcat);
            this.groupBox1.Controls.Add(this.comboCate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Location = new System.Drawing.Point(6, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1152, 186);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // comboGestor
            // 
            this.comboGestor.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.comboGestor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.comboGestor.FormattingEnabled = true;
            this.comboGestor.Location = new System.Drawing.Point(821, 89);
            this.comboGestor.Name = "comboGestor";
            this.comboGestor.Size = new System.Drawing.Size(267, 25);
            this.comboGestor.TabIndex = 19;
            this.comboGestor.Click += new System.EventHandler(this.comboGestor_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label12.Location = new System.Drawing.Point(823, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Gestor:";
            // 
            // comboIndevido
            // 
            this.comboIndevido.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.comboIndevido.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.comboIndevido.FormattingEnabled = true;
            this.comboIndevido.Items.AddRange(new object[] {
            "Sim "});
            this.comboIndevido.Location = new System.Drawing.Point(215, 140);
            this.comboIndevido.Name = "comboIndevido";
            this.comboIndevido.Size = new System.Drawing.Size(121, 25);
            this.comboIndevido.TabIndex = 17;
            this.comboIndevido.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboIndevido_MouseClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label11.Location = new System.Drawing.Point(212, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 15);
            this.label11.TabIndex = 16;
            this.label11.Text = "Indevido:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1089, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 22);
            this.button1.TabIndex = 15;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtResp
            // 
            this.txtResp.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtResp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtResp.Location = new System.Drawing.Point(479, 89);
            this.txtResp.Multiline = true;
            this.txtResp.Name = "txtResp";
            this.txtResp.Size = new System.Drawing.Size(315, 25);
            this.txtResp.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label10.Location = new System.Drawing.Point(476, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "Responsável:";
            // 
            // mskData2
            // 
            this.mskData2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.mskData2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mskData2.Location = new System.Drawing.Point(110, 140);
            this.mskData2.Mask = "00/00/0000";
            this.mskData2.Name = "mskData2";
            this.mskData2.Size = new System.Drawing.Size(78, 22);
            this.mskData2.TabIndex = 6;
            this.mskData2.ValidatingType = typeof(System.DateTime);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(107, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "até:";
            // 
            // mskData1
            // 
            this.mskData1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.mskData1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mskData1.Location = new System.Drawing.Point(14, 140);
            this.mskData1.Mask = "00/00/0000";
            this.mskData1.Name = "mskData1";
            this.mskData1.Size = new System.Drawing.Size(82, 22);
            this.mskData1.TabIndex = 5;
            this.mskData1.ValidatingType = typeof(System.DateTime);
            this.mskData1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mskData1_MaskInputRejected);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Location = new System.Drawing.Point(11, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "De:";
            // 
            // txtSolicitante
            // 
            this.txtSolicitante.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtSolicitante.Location = new System.Drawing.Point(821, 42);
            this.txtSolicitante.Name = "txtSolicitante";
            this.txtSolicitante.Size = new System.Drawing.Size(262, 22);
            this.txtSolicitante.TabIndex = 4;
            // 
            // comboDepar
            // 
            this.comboDepar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.comboDepar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.comboDepar.FormattingEnabled = true;
            this.comboDepar.Location = new System.Drawing.Point(14, 89);
            this.comboDepar.Name = "comboDepar";
            this.comboDepar.Size = new System.Drawing.Size(436, 25);
            this.comboDepar.TabIndex = 3;
            this.comboDepar.Click += new System.EventHandler(this.comboDepar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(823, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Solicitante:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.Location = new System.Drawing.Point(11, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Departamento:";
            // 
            // comboSubcat
            // 
            this.comboSubcat.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.comboSubcat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.comboSubcat.FormattingEnabled = true;
            this.comboSubcat.Location = new System.Drawing.Point(479, 39);
            this.comboSubcat.Name = "comboSubcat";
            this.comboSubcat.Size = new System.Drawing.Size(315, 25);
            this.comboSubcat.TabIndex = 2;
            this.comboSubcat.SelectedIndexChanged += new System.EventHandler(this.comboSubcat_SelectedIndexChanged);
            // 
            // comboCate
            // 
            this.comboCate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.comboCate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.comboCate.FormattingEnabled = true;
            this.comboCate.Location = new System.Drawing.Point(215, 39);
            this.comboCate.Name = "comboCate";
            this.comboCate.Size = new System.Drawing.Size(235, 25);
            this.comboCate.TabIndex = 1;
            this.comboCate.SelectedIndexChanged += new System.EventHandler(this.comboCate_SelectedIndexChanged);
            this.comboCate.Click += new System.EventHandler(this.comboCate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(476, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Subcategoria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(212, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Categoria:";
            // 
            // comboStatus
            // 
            this.comboStatus.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.comboStatus.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "TODOS",
            "ABERTO",
            "EM ATENDIMENTO",
            "ENCERRADO"});
            this.comboStatus.Location = new System.Drawing.Point(13, 39);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(175, 25);
            this.comboStatus.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(392, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "Histórico de Chamados";
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportar.Location = new System.Drawing.Point(1010, 7);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(57, 56);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.Location = new System.Drawing.Point(945, 7);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(59, 56);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dataGridBuscar
            // 
            this.dataGridBuscar.AllowUserToAddRows = false;
            this.dataGridBuscar.AllowUserToDeleteRows = false;
            this.dataGridBuscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBuscar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.status,
            this.dataAbertura,
            this.descricao,
            this.solicitante,
            this.responsavel,
            this.prioridade,
            this.departamento,
            this.categoria,
            this.subcategoria,
            this.solucao,
            this.indevido,
            this.observacoes,
            this.datafechamento,
            this.codcategoria,
            this.codigosubcat,
            this.coddepar});
            this.dataGridBuscar.Location = new System.Drawing.Point(10, 69);
            this.dataGridBuscar.Name = "dataGridBuscar";
            this.dataGridBuscar.ReadOnly = true;
            this.dataGridBuscar.Size = new System.Drawing.Size(1138, 274);
            this.dataGridBuscar.TabIndex = 3;
            this.dataGridBuscar.DoubleClick += new System.EventHandler(this.dataGridBuscar_DoubleClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVoltar.Location = new System.Drawing.Point(1076, 7);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(57, 56);
            this.btnVoltar.TabIndex = 4;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblQtdChamados
            // 
            this.lblQtdChamados.AutoSize = true;
            this.lblQtdChamados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblQtdChamados.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblQtdChamados.Location = new System.Drawing.Point(10, 48);
            this.lblQtdChamados.Name = "lblQtdChamados";
            this.lblQtdChamados.Size = new System.Drawing.Size(15, 15);
            this.lblQtdChamados.TabIndex = 5;
            this.lblQtdChamados.Text = "0";
            this.lblQtdChamados.Click += new System.EventHandler(this.lblQtdChamados_Click);
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTexto.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTexto.Location = new System.Drawing.Point(56, 48);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(158, 15);
            this.lblTexto.TabIndex = 6;
            this.lblTexto.Text = "Chamados encontrados";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTexto);
            this.panel1.Controls.Add(this.lblQtdChamados);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.dataGridBuscar);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.btnExportar);
            this.panel1.Location = new System.Drawing.Point(6, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1152, 317);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(129)))), ((int)(((byte)(26)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1164, 35);
            this.panel3.TabIndex = 46;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(129)))), ((int)(((byte)(26)))));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(51, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 110);
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "Codigo";
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "Status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // dataAbertura
            // 
            this.dataAbertura.DataPropertyName = "dataAbertura";
            this.dataAbertura.HeaderText = "Data de Abertura";
            this.dataAbertura.Name = "dataAbertura";
            this.dataAbertura.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "Descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // solicitante
            // 
            this.solicitante.DataPropertyName = "Usuario";
            this.solicitante.HeaderText = "Solicitante";
            this.solicitante.Name = "solicitante";
            this.solicitante.ReadOnly = true;
            // 
            // responsavel
            // 
            this.responsavel.DataPropertyName = "Responsavel";
            this.responsavel.HeaderText = "Responsável";
            this.responsavel.Name = "responsavel";
            this.responsavel.ReadOnly = true;
            // 
            // prioridade
            // 
            this.prioridade.DataPropertyName = "Prioridade";
            this.prioridade.HeaderText = "Prioridade";
            this.prioridade.Name = "prioridade";
            this.prioridade.ReadOnly = true;
            // 
            // departamento
            // 
            this.departamento.DataPropertyName = "Departamento";
            this.departamento.HeaderText = "Departamento";
            this.departamento.Name = "departamento";
            this.departamento.ReadOnly = true;
            // 
            // categoria
            // 
            this.categoria.DataPropertyName = "Categoria";
            this.categoria.HeaderText = "Categoria";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            // 
            // subcategoria
            // 
            this.subcategoria.DataPropertyName = "Subcategoria";
            this.subcategoria.HeaderText = "Subcategoria";
            this.subcategoria.Name = "subcategoria";
            this.subcategoria.ReadOnly = true;
            // 
            // solucao
            // 
            this.solucao.DataPropertyName = "Solucao";
            this.solucao.HeaderText = "Solução";
            this.solucao.Name = "solucao";
            this.solucao.ReadOnly = true;
            // 
            // indevido
            // 
            this.indevido.DataPropertyName = "Indevido";
            this.indevido.HeaderText = "Indevido";
            this.indevido.Name = "indevido";
            this.indevido.ReadOnly = true;
            // 
            // observacoes
            // 
            this.observacoes.DataPropertyName = "ObservacoesResponsavel";
            this.observacoes.HeaderText = "Observações do Responsável";
            this.observacoes.Name = "observacoes";
            this.observacoes.ReadOnly = true;
            // 
            // datafechamento
            // 
            this.datafechamento.DataPropertyName = "DataFechamento";
            this.datafechamento.HeaderText = "Data de fechamento";
            this.datafechamento.Name = "datafechamento";
            this.datafechamento.ReadOnly = true;
            // 
            // codcategoria
            // 
            this.codcategoria.DataPropertyName = "CodigoCategoria";
            this.codcategoria.HeaderText = "Codigo Categoria";
            this.codcategoria.Name = "codcategoria";
            this.codcategoria.ReadOnly = true;
            // 
            // codigosubcat
            // 
            this.codigosubcat.DataPropertyName = "CodigoSubcategoria";
            this.codigosubcat.HeaderText = "Codigo Subcategoria";
            this.codigosubcat.Name = "codigosubcat";
            this.codigosubcat.ReadOnly = true;
            // 
            // coddepar
            // 
            this.coddepar.DataPropertyName = "CodigoDepartamento";
            this.coddepar.HeaderText = "Codigo Departamento";
            this.coddepar.Name = "coddepar";
            this.coddepar.ReadOnly = true;
            // 
            // FrmBuscarHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(1164, 668);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmBuscarHistorico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histórico de Chamados";
            this.Load += new System.EventHandler(this.FrmBuscarHistorico_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBuscar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboDepar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboCate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskData2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mskData1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtResp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txtSolicitante;
        private System.Windows.Forms.ComboBox comboSubcat;
        private System.Windows.Forms.ComboBox comboIndevido;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboGestor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dataGridBuscar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblQtdChamados;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataAbertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn solicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsavel;
        private System.Windows.Forms.DataGridViewTextBoxColumn prioridade;
        private System.Windows.Forms.DataGridViewTextBoxColumn departamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn subcategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn solucao;
        private System.Windows.Forms.DataGridViewTextBoxColumn indevido;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn datafechamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn codcategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigosubcat;
        private System.Windows.Forms.DataGridViewTextBoxColumn coddepar;
    }
}
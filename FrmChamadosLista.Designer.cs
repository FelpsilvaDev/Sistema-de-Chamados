namespace Projeto_SistemadeChamadosCMR
{
    partial class FrmChamadosLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChamadosLista));
            this.dataGridChamados = new System.Windows.Forms.DataGridView();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnVoltar = new FontAwesome.Sharp.IconButton();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataAbertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Autorização = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridChamados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridChamados
            // 
            this.dataGridChamados.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGridChamados.AllowUserToAddRows = false;
            this.dataGridChamados.AllowUserToDeleteRows = false;
            this.dataGridChamados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridChamados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridChamados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridChamados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridChamados.ColumnHeadersHeight = 49;
            this.dataGridChamados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.status,
            this.dataAbertura,
            this.solicitante,
            this.Autorização,
            this.descricao,
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridChamados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridChamados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridChamados.EnableHeadersVisualStyles = false;
            this.dataGridChamados.Location = new System.Drawing.Point(26, 187);
            this.dataGridChamados.Name = "dataGridChamados";
            this.dataGridChamados.ReadOnly = true;
            this.dataGridChamados.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridChamados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridChamados.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.dataGridChamados.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridChamados.Size = new System.Drawing.Size(1863, 775);
            this.dataGridChamados.TabIndex = 2;
            this.dataGridChamados.DoubleClick += new System.EventHandler(this.dataGridChamados_DoubleClick);
            // 
            // comboStatus
            // 
            this.comboStatus.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboStatus.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "Aberto/Em atendimento",
            "Encerrado"});
            this.comboStatus.Location = new System.Drawing.Point(109, 159);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(278, 25);
            this.comboStatus.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(23, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pesquisar:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(764, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "Meus Chamados";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(129)))), ((int)(((byte)(26)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1837, 28);
            this.panel3.TabIndex = 46;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(129)))), ((int)(((byte)(26)))));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(43, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 110);
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 22;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnBuscar.Location = new System.Drawing.Point(403, 159);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(69, 28);
            this.btnBuscar.TabIndex = 47;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.IconChar = FontAwesome.Sharp.IconChar.Reply;
            this.btnVoltar.IconColor = System.Drawing.Color.Black;
            this.btnVoltar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVoltar.IconSize = 22;
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnVoltar.Location = new System.Drawing.Point(1749, 153);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(63, 28);
            this.btnVoltar.TabIndex = 22;
            this.btnVoltar.Text = "Voltar\r\n";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "Status";
            this.status.HeaderText = "Status";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // dataAbertura
            // 
            this.dataAbertura.DataPropertyName = "dataAbertura";
            this.dataAbertura.HeaderText = "Data de Abertura";
            this.dataAbertura.MinimumWidth = 6;
            this.dataAbertura.Name = "dataAbertura";
            this.dataAbertura.ReadOnly = true;
            this.dataAbertura.Width = 125;
            // 
            // solicitante
            // 
            this.solicitante.DataPropertyName = "Usuario";
            this.solicitante.HeaderText = "Solicitante";
            this.solicitante.MinimumWidth = 6;
            this.solicitante.Name = "solicitante";
            this.solicitante.ReadOnly = true;
            this.solicitante.Width = 125;
            // 
            // Autorização
            // 
            this.Autorização.DataPropertyName = "Autorizacao";
            this.Autorização.HeaderText = "Pendente";
            this.Autorização.Name = "Autorização";
            this.Autorização.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.descricao.DataPropertyName = "Descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.MinimumWidth = 6;
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // responsavel
            // 
            this.responsavel.DataPropertyName = "Responsavel";
            this.responsavel.HeaderText = "Responsável";
            this.responsavel.MinimumWidth = 6;
            this.responsavel.Name = "responsavel";
            this.responsavel.ReadOnly = true;
            this.responsavel.Width = 125;
            // 
            // prioridade
            // 
            this.prioridade.DataPropertyName = "Prioridade";
            this.prioridade.HeaderText = "Prioridade";
            this.prioridade.MinimumWidth = 6;
            this.prioridade.Name = "prioridade";
            this.prioridade.ReadOnly = true;
            this.prioridade.Width = 125;
            // 
            // departamento
            // 
            this.departamento.DataPropertyName = "Departamento";
            this.departamento.HeaderText = "Departamento";
            this.departamento.MinimumWidth = 6;
            this.departamento.Name = "departamento";
            this.departamento.ReadOnly = true;
            this.departamento.Width = 125;
            // 
            // categoria
            // 
            this.categoria.DataPropertyName = "Categoria";
            this.categoria.HeaderText = "Categoria";
            this.categoria.MinimumWidth = 6;
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            this.categoria.Width = 125;
            // 
            // subcategoria
            // 
            this.subcategoria.DataPropertyName = "Subcategoria";
            this.subcategoria.HeaderText = "Subcategoria";
            this.subcategoria.MinimumWidth = 6;
            this.subcategoria.Name = "subcategoria";
            this.subcategoria.ReadOnly = true;
            this.subcategoria.Width = 125;
            // 
            // solucao
            // 
            this.solucao.DataPropertyName = "Solucao";
            this.solucao.HeaderText = "Solução";
            this.solucao.MinimumWidth = 6;
            this.solucao.Name = "solucao";
            this.solucao.ReadOnly = true;
            this.solucao.Width = 125;
            // 
            // indevido
            // 
            this.indevido.DataPropertyName = "Indevido";
            this.indevido.HeaderText = "Indevido";
            this.indevido.MinimumWidth = 6;
            this.indevido.Name = "indevido";
            this.indevido.ReadOnly = true;
            this.indevido.Width = 125;
            // 
            // observacoes
            // 
            this.observacoes.DataPropertyName = "ObservacoesResponsavel";
            this.observacoes.HeaderText = "Observações do Responsável";
            this.observacoes.MinimumWidth = 6;
            this.observacoes.Name = "observacoes";
            this.observacoes.ReadOnly = true;
            this.observacoes.Width = 125;
            // 
            // datafechamento
            // 
            this.datafechamento.DataPropertyName = "DataFechamento";
            this.datafechamento.HeaderText = "Data de fechamento";
            this.datafechamento.MinimumWidth = 6;
            this.datafechamento.Name = "datafechamento";
            this.datafechamento.ReadOnly = true;
            this.datafechamento.Width = 125;
            // 
            // codcategoria
            // 
            this.codcategoria.DataPropertyName = "CodigoCategoria";
            this.codcategoria.HeaderText = "Codigo Categoria";
            this.codcategoria.MinimumWidth = 6;
            this.codcategoria.Name = "codcategoria";
            this.codcategoria.ReadOnly = true;
            this.codcategoria.Width = 125;
            // 
            // codigosubcat
            // 
            this.codigosubcat.DataPropertyName = "CodigoSubcategoria";
            this.codigosubcat.HeaderText = "Codigo Subcategoria";
            this.codigosubcat.MinimumWidth = 6;
            this.codigosubcat.Name = "codigosubcat";
            this.codigosubcat.ReadOnly = true;
            this.codigosubcat.Width = 125;
            // 
            // coddepar
            // 
            this.coddepar.DataPropertyName = "CodigoDepartamento";
            this.coddepar.HeaderText = "Codigo Departamento";
            this.coddepar.MinimumWidth = 6;
            this.coddepar.Name = "coddepar";
            this.coddepar.ReadOnly = true;
            this.coddepar.Width = 125;
            // 
            // FrmChamadosLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(1837, 857);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.dataGridChamados);
            this.Controls.Add(this.label2);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmChamadosLista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Chamados do Solicitante";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmChamadosLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridChamados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridChamados;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnVoltar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataAbertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn solicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Autorização;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
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
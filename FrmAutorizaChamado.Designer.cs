namespace Projeto_SistemadeChamadosCMR
{
    partial class FrmAutorizaChamado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAutorizaChamado));
            this.dataGridChamados = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAnexarArq = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.coddepar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigosubcat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codcategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datafechamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indevido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solucao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subcategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prioridade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataAbertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridChamados)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridChamados
            // 
            this.dataGridChamados.AllowUserToAddRows = false;
            this.dataGridChamados.AllowUserToDeleteRows = false;
            this.dataGridChamados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridChamados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.status,
            this.dataAbertura,
            this.solicitante,
            this.responsavel,
            this.prioridade,
            this.departamento,
            this.categoria,
            this.subcategoria,
            this.descricao,
            this.solucao,
            this.indevido,
            this.observacoes,
            this.datafechamento,
            this.codcategoria,
            this.codigosubcat,
            this.coddepar});
            this.dataGridChamados.Location = new System.Drawing.Point(6, 177);
            this.dataGridChamados.Name = "dataGridChamados";
            this.dataGridChamados.ReadOnly = true;
            this.dataGridChamados.Size = new System.Drawing.Size(1124, 337);
            this.dataGridChamados.TabIndex = 3;
            this.dataGridChamados.DoubleClick += new System.EventHandler(this.dataGridChamados_DoubleClick);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisar.Location = new System.Drawing.Point(5, 136);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(203, 38);
            this.btnPesquisar.TabIndex = 6;
            this.btnPesquisar.Text = "Pesquisar Chamados Anteriores";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(129)))), ((int)(((byte)(26)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1137, 26);
            this.panel3.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.btnAnexarArq);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.panelInferior);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 551);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1137, 76);
            this.panel2.TabIndex = 43;
            // 
            // btnAnexarArq
            // 
            this.btnAnexarArq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.btnAnexarArq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnexarArq.FlatAppearance.BorderSize = 0;
            this.btnAnexarArq.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnexarArq.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnexarArq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAnexarArq.Image = ((System.Drawing.Image)(resources.GetObject("btnAnexarArq.Image")));
            this.btnAnexarArq.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAnexarArq.Location = new System.Drawing.Point(449, 3);
            this.btnAnexarArq.Name = "btnAnexarArq";
            this.btnAnexarArq.Size = new System.Drawing.Size(96, 63);
            this.btnAnexarArq.TabIndex = 28;
            this.btnAnexarArq.Tag = "BtnAtualizarTela";
            this.btnAnexarArq.Text = "Atualizar Tela ";
            this.btnAnexarArq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnexarArq.UseVisualStyleBackColor = false;
            this.btnAnexarArq.Click += new System.EventHandler(this.btnAnexarArq_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(562, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 63);
            this.button2.TabIndex = 3;
            this.button2.Text = "Sair";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelInferior
            // 
            this.panelInferior.BackColor = System.Drawing.Color.Black;
            this.panelInferior.Location = new System.Drawing.Point(449, 66);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(96, 10);
            this.panelInferior.TabIndex = 27;
            this.panelInferior.Paint += new System.Windows.Forms.PaintEventHandler(this.panelInferior_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(307, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(572, 38);
            this.label1.TabIndex = 44;
            this.label1.Text = "Lista de Chamados par Autorização";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(36, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 111);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // coddepar
            // 
            this.coddepar.DataPropertyName = "CodigoDepartamento";
            this.coddepar.HeaderText = "Codigo Departamento";
            this.coddepar.Name = "coddepar";
            this.coddepar.ReadOnly = true;
            // 
            // codigosubcat
            // 
            this.codigosubcat.DataPropertyName = "CodigoSubcategoria";
            this.codigosubcat.HeaderText = "Codigo Subcategoria";
            this.codigosubcat.Name = "codigosubcat";
            this.codigosubcat.ReadOnly = true;
            // 
            // codcategoria
            // 
            this.codcategoria.DataPropertyName = "CodigoCategoria";
            this.codcategoria.HeaderText = "Codigo Categoria";
            this.codcategoria.Name = "codcategoria";
            this.codcategoria.ReadOnly = true;
            // 
            // datafechamento
            // 
            this.datafechamento.DataPropertyName = "DataFechamento";
            this.datafechamento.HeaderText = "Data de fechamento";
            this.datafechamento.Name = "datafechamento";
            this.datafechamento.ReadOnly = true;
            // 
            // observacoes
            // 
            this.observacoes.DataPropertyName = "ObservacoesResponsavel";
            this.observacoes.HeaderText = "Observações do Responsável";
            this.observacoes.Name = "observacoes";
            this.observacoes.ReadOnly = true;
            // 
            // indevido
            // 
            this.indevido.DataPropertyName = "Indevido";
            this.indevido.HeaderText = "Indevido";
            this.indevido.Name = "indevido";
            this.indevido.ReadOnly = true;
            // 
            // solucao
            // 
            this.solucao.DataPropertyName = "Solucao";
            this.solucao.HeaderText = "Solução";
            this.solucao.Name = "solucao";
            this.solucao.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "Descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // subcategoria
            // 
            this.subcategoria.DataPropertyName = "Subcategoria";
            this.subcategoria.HeaderText = "Subcategoria";
            this.subcategoria.Name = "subcategoria";
            this.subcategoria.ReadOnly = true;
            // 
            // categoria
            // 
            this.categoria.DataPropertyName = "Categoria";
            this.categoria.HeaderText = "Categoria";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            // 
            // departamento
            // 
            this.departamento.DataPropertyName = "Departamento";
            this.departamento.HeaderText = "Departamento";
            this.departamento.Name = "departamento";
            this.departamento.ReadOnly = true;
            // 
            // prioridade
            // 
            this.prioridade.DataPropertyName = "Prioridade";
            this.prioridade.HeaderText = "Prioridade";
            this.prioridade.Name = "prioridade";
            this.prioridade.ReadOnly = true;
            // 
            // responsavel
            // 
            this.responsavel.DataPropertyName = "Responsavel";
            this.responsavel.HeaderText = "Responsável";
            this.responsavel.Name = "responsavel";
            this.responsavel.ReadOnly = true;
            // 
            // solicitante
            // 
            this.solicitante.DataPropertyName = "Usuario";
            this.solicitante.HeaderText = "Solicitante";
            this.solicitante.Name = "solicitante";
            this.solicitante.ReadOnly = true;
            // 
            // dataAbertura
            // 
            this.dataAbertura.DataPropertyName = "dataAbertura";
            this.dataAbertura.HeaderText = "Data de Abertura";
            this.dataAbertura.Name = "dataAbertura";
            this.dataAbertura.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "Status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "Codigo";
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // FrmAutorizaChamado
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(1137, 627);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dataGridChamados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAutorizaChamado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorizações de Chamados";
            this.Load += new System.EventHandler(this.FrmAutorizaChamado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridChamados)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridChamados;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAnexarArq;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataAbertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn solicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsavel;
        private System.Windows.Forms.DataGridViewTextBoxColumn prioridade;
        private System.Windows.Forms.DataGridViewTextBoxColumn departamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn subcategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn solucao;
        private System.Windows.Forms.DataGridViewTextBoxColumn indevido;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn datafechamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn codcategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigosubcat;
        private System.Windows.Forms.DataGridViewTextBoxColumn coddepar;
    }
}
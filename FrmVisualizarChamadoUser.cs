using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Persistencia;
using System.Runtime.InteropServices;
using System.IO;

namespace Projeto_SistemadeChamadosCMR
{
    public partial class FrmVisualizarChamadoUser : Form
    {
        public FrmVisualizarChamadoUser(ChamadosE chamado,string perfil,string tipo)
        {
            InitializeComponent();

            lblNumero.Text = chamado.Codigo.ToString();
            lblStatus.Text = chamado.Status;
            lblDataAbertura.Text = chamado.DataAbertura.ToString();
            lblDepart.Text = chamado.Departamento;
            lblSubcat.Text = chamado.Subcategoria;
            lblTipo.Text = chamado.Prioridade;
            lblSolicitante.Text = chamado.Usuario;
            lblResponsavel.Text = chamado.Responsavel;
            lblCategoria.Text = chamado.Categoria;
            lblDataFecha.Text = chamado.DataFechamento.ToString();
            lblDescricao.Text = chamado.Descricao;
            lblSolucao.Text = chamado.Solucao;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            if (chamado.Autorizacao == "S")
            {
                lblAuto.Text = "Sim";                
            }
            else if (chamado.Autorizacao == "N")
            {
                lblAuto.Text = "Não"; 
            }

            perfiluser = perfil;

            if (perfiluser != "GESTOR" )
            {
                comboBox1.Visible = false;
              
            }
            else
            {
                if (tipo == "V")
                {
                    comboBox1.Visible = false;
                }
                else
                {
                    comboBox1.Visible = true;
                    btnSair.Text = "Confirmar";
                } 

             }
                

            dataGridVchamados.AutoGenerateColumns = false;
        }
        //Para desabilitar X do form
        const int MF_BYPOSITION = 0x400;


        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        AcompanhamentoP acomP = new AcompanhamentoP();
        int auxiliar=0;
        string nomearq;
        string perfiluser;
        private void btnInserir_Click(object sender, EventArgs e)
        {
            InserirAcomp();
        }
        public void InserirAcomp(string corpo)
        {
            if (txtAcomp.Text != "" || auxiliar !=0)
            {
                try
                {
                    AcompanhamentoE aco = new AcompanhamentoE();
                    aco.UsuarioComent = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;
                    aco.CodigoChamado = Convert.ToInt32(lblNumero.Text);
                    aco.DataModificacao = DateTime.Now;
                    aco.Descricao = "Arquivo "+nomearq + " anexado";

                    acomP.InserirAcompanhamento(aco);

                    CarregarDataGrid();
                    btnCancelar.PerformClick();

                    EnviaEmail mailDelivery = new EnviaEmail();

                    ChamadosP chap = new ChamadosP();
                    ChamadosE chamado = chap.PesquisarPorCodigo(aco.CodigoChamado);
                    string mail = mailDelivery.buscarEmailUser(chamado.Usuario);
       
                    mailDelivery.EnviarEmail(mail, "CMR Service Desk - Novo Acompanhamento - Chamado: " + aco.CodigoChamado, corpo);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro:" + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void InserirAcomp()
        {
            if (txtAcomp.Text != "")
            {
                try
                {
                    AcompanhamentoE aco = new AcompanhamentoE();
                    aco.UsuarioComent = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;
                    aco.CodigoChamado = Convert.ToInt32(lblNumero.Text);
                    aco.DataModificacao = DateTime.Now;
                    aco.Descricao = txtAcomp.Text;

                    acomP.InserirAcompanhamento(aco);

                    MessageBox.Show("Acompanhento incluído", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarDataGrid();
                    btnCancelar.PerformClick();

                    EnviaEmail mailDelivery = new EnviaEmail();

                    ChamadosP chap = new ChamadosP();
                    ChamadosE chamado = chap.PesquisarPorCodigo(aco.CodigoChamado);
                    string mail = mailDelivery.buscarEmailUser(chamado.Usuario);
                    string corpoEmail = "(*) Este é um email automático , por favor não responda\n\n\nSeu Chamado com a descrição abaixo possui um novo acompanhamento\n\n\nDescrição: " + chamado.Descricao;
                    mailDelivery.EnviarEmail(mail, "CMR Service Desk - Novo Acompanhamento - Chamado: " + aco.CodigoChamado, corpoEmail);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro:" + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CarregarDataGrid()
        {
            dataGridVchamados.DataSource=null;

            try
            {
                dataGridVchamados.DataSource = acomP.listarAcompanhamentos(Convert.ToInt32(lblNumero.Text));
                dataGridVchamados.AutoResizeColumns();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro:" + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void FrmVisualizarChamadoUser_Load(object sender, EventArgs e)
        {
            CarregarDataGrid();
            //Desabilita o botão Fechar (X)
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);


            ListarArquivos();
            lblNumero.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void SelecionarArquivo()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "All files (*.*)|*.*";
            dialog.Title = "Selecione o arquivo";
            dialog.ShowDialog();

            if (!String.IsNullOrEmpty(dialog.FileName))
            {
                if (!System.IO.Directory.Exists(@"\\srvjdifs01\AnexosChamados\" + lblNumero.Text)) // verifica se o diretorio existe
                {
                    System.IO.Directory.CreateDirectory(@"\\srvjdifs01\AnexosChamados\" + lblNumero.Text); //cria o diretório caso nao exista
                }
                try
                {
                    System.IO.File.Copy(dialog.FileName, @"\\srvjdifs01\AnexosChamados\" + lblNumero.Text + "\\" + dialog.SafeFileName); //copia arquivo selecionado para o diretório
                    nomearq = dialog.SafeFileName;
                    MessageBox.Show("Arquivo anexado com sucesso ", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    auxiliar = 1;
                    anexos.Items.Clear();//limpando listbox.
                    ListarArquivos();//listando arquivos na listbox
                    InserirAcomp("(*)Este é um email automático por favor não responda\n\n\nO chamado: " + lblNumero.Text + " possui um novo anexo");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ListarArquivos()
        {
            try
            {
                if (System.IO.Directory.Exists(@"\\srvjdifs01\AnexosChamados\" + lblNumero.Text)) // verifica se o diretorio existe
                {
                    DirectoryInfo Dir = new DirectoryInfo(@"\\srvjdifs01\AnexosChamados\" + lblNumero.Text);
                    // Busca automaticamente todos os arquivos em todos os subdiretórios
                    FileInfo[] Files = Dir.GetFiles("*", SearchOption.AllDirectories);
                    foreach (FileInfo File in Files)
                    {
                        if (File.Name != "Thumbs.db")
                            anexos.Items.Add(File.Name);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void anexos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"\\srvjdifs01\AnexosChamados\" + lblNumero.Text + @"\" + anexos.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não existe anexo selecionado\n Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void radioNao_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioSim_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioSim_Click(object sender, EventArgs e)
        {
           
        }

        private void radioNao_Click(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            FrmSenhaGestor obj = new FrmSenhaGestor(this);
            obj.ShowDialog();
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();

            panelInferior.Height = btnSair.Height;
            panelInferior.Left = btnSair.Left;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelInferior.Height = btnCancelar.Height;
            panelInferior.Left = btnCancelar.Left;
            txtAcomp.Clear();
        }

        private void btnAnexarArq_Click(object sender, EventArgs e)
        {       
            panelInferior.Height = btnAnexarArq.Height;
            panelInferior.Left = btnAnexarArq.Left;

            SelecionarArquivo();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

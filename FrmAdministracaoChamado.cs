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
using System.Data.SqlTypes;
using System.IO;

namespace Projeto_SistemadeChamadosCMR
{
    public partial class FrmAdministracaoChamado : Form
    {

        public FrmAdministracaoChamado(ChamadosE chamado, FrmChamadosLista form)
        {
            InitializeComponent();
            oUsuarioAnterior = chamado;
            // setando paramentros trazidos do form lista de chamados 
            lblNumero.Text = chamado.Codigo.ToString();
            //lblStatus.Text = chamado.Status;
            lblDataAbertura.Text = chamado.DataAbertura.ToString();
            lblSubcat.Text = chamado.Subcategoria;
            lblTipo.Text = chamado.Prioridade;
            lblSolicitante.Text = chamado.Usuario;
            txtSolucao.Text = chamado.Solucao;
            lblResponsavel.Text = chamado.Responsavel;
            lblCategoria.Text = chamado.Categoria;
            lblDataFecha.Text = chamado.DataFechamento.ToString();
            lblDescricao.Text = chamado.Descricao;
            lblDepart.Text = chamado.Departamento;
            txtautorizacao.Enabled = false;

            if (chamado.Autorizacao == "S")
            {
                txtautorizacao.Text = "SIM";
            }
            else if (chamado.Autorizacao == "N")
            {
                txtautorizacao.Text = "NÃO";
            }
            else
            {
                txtautorizacao.Text = "PENDENTE";

            }

            dataGridVchamados.AutoGenerateColumns = false;
            comboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboIndevido.DropDownStyle = ComboBoxStyle.DropDownList;

            if (chamado.Indevido != "")
            {
                comboIndevido.SelectedIndex = comboIndevido.FindStringExact(chamado.Indevido);
            }

            foreach (string item in comboStatus.Items)//setando o status na combobox
            {
                if (item == chamado.Status)
                {
                    comboStatus.SelectedIndex = comboStatus.FindStringExact(chamado.Status);
                }
            }

            frm = form;


           
        }
        private ChamadosE oUsuarioAnterior;

        FrmChamadosLista frm;
        ////Para desabilitar X do form
        //const int MF_BYPOSITION = 0x400;


        //[DllImport("User32")]
        //private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        //[DllImport("User32")]
        //private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        //[DllImport("User32")]
        //private static extern int GetMenuItemCount(IntPtr hWnd);

        string descritivoEmail;
        private void FrmAdministracaoChamado_Load(object sender, EventArgs e)
        {
            CarregarDataGrid();
            //Desabilita o botão Fechar (X)
            //IntPtr hMenu = GetSystemMenu(this.Handle, false);
            //int MenuItemCount = GetMenuItemCount(hMenu);
            //RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);
            descritivoEmail = lblDescricao.Text;
            ListarArquivos();

            if (lblSubcat.Text == "SAP - TRANSAÇÕES" || lblSubcat.Text == "SAP - REQUESTS CONSULTORIA" || lblSubcat.Text == "CONCESSÕES DE ACESSO" || lblSubcat.Text == "REVOGAÇÕES DE ACESSO")
            {
                if (txtautorizacao.Text == "PENDENTE")
                {
                    comboStatus.Enabled = false;
                }

            }
            else
            {
                txtautorizacao.Text = "";
            }
        }
        AcompanhamentoP acomp = new AcompanhamentoP();
        ChamadosP chap = new ChamadosP();
        DateTime? datafecha;
        string nomearq;
        int auxiliar;
        private void CarregarDataGrid()
        {
            dataGridVchamados.DataSource = null;

            try
            {
                dataGridVchamados.DataSource = acomp.listarAcompanhamentos(Convert.ToInt32(lblNumero.Text));
                dataGridVchamados.AutoResizeColumns();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            //alterando status do chamado na implementação abaixo ja deixei pronto para demais campos serem alterados.
            if (comboStatus.Text != "")
            {
                ChamadosE chamado = new ChamadosE();

                chamado.Codigo = Convert.ToInt32(lblNumero.Text);
                chamado.Status = comboStatus.Text;
                chamado.DataAbertura = Convert.ToDateTime(lblDataAbertura.Text);
                chamado.Solucao = txtSolucao.Text;
                if (comboIndevido.Text != "") ///caso o chamado seja indevido
                    chamado.Indevido = comboIndevido.Text;
                else
                    chamado.Indevido = "";
                chamado.ObservacoesResponsavel = txtObs.Text;
                chamado.Prioridade = lblTipo.Text;
                chamado.Usuario = lblSolicitante.Text;

                chamado.Responsavel = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;

                if (comboStatus.Text == "ENCERRADO")
                {
                    // chamado.DataFechamento = DateTime.Now.ToString();

                    datafecha = DateTime.Now;

                    try
                    {
                        EnviaEmail mailDelivery = new EnviaEmail();
                        string mail = mailDelivery.buscarEmailUser(chamado.Usuario);

                        mailDelivery.EnviarEmail(mail, "Encerramento de chamado  - chamado: " + chamado.Codigo, "(*) Este é um email automático , por favor não responda\n\n\nSeu Chamado com a descrição abaixo foi encerrado\n\nDescrição: " + descritivoEmail + "\n\n" + "Solução: " + chamado.Solucao + "\n\n");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao conectar-se ao AD ou SMTP do Office 365 , favor reportar o T.I", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                }
                else if (comboStatus.Text == "ENCAMINHADO")
                {
                    datafecha = DateTime.Now;
                    chamado.Responsavel = lblResponsavel.Text;
                    chamado.Status = comboStatus.Text;

                    try
                    {
                        EnviaEmail mailDeliveryAtual = new EnviaEmail();
                        string mailResponsavelAtual = mailDeliveryAtual.buscarEmailUser(chamado.Responsavel);
                        mailDeliveryAtual.EnviarEmail(mailResponsavelAtual, $"Encaminhamento de chamado - chamado: {chamado.Codigo}", $"Você é o novo responsável pelo chamado {chamado.Codigo}.\n\nResponsável anterior: {oUsuarioAnterior.Responsavel}\n\n\n(*) Este é um email automático , por favor não responda!");

                        if (!oUsuarioAnterior.Responsavel.Equals(""))
                        {
                            EnviaEmail mailDeliveryAnterior = new EnviaEmail();
                            string mailResponsavelAnterior = mailDeliveryAnterior.buscarEmailUser(oUsuarioAnterior.Responsavel);
                            mailDeliveryAnterior.EnviarEmail(mailResponsavelAnterior, $"Encaminhamento de chamado - chamado: {chamado.Codigo}", $"Você não é mais o responsável pelo chamado {chamado.Codigo}.\n\nNovo Responsável: {chamado.Responsavel}\n\n\n(*) Este é um email automático , por favor não responda!");
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Erro ao conectar-se ao AD ou SMTP do Office 365 , favor reportar o T.I", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {

                    datafecha = null;
                }

                try
                {

                    chap.AlterarChamado(chamado, datafecha); // passando variavel data fechamento adicional , pois na conversao de dados nao é possivel o Datetime ficar nulo ,
                                                             //desta forma crie um data fechamento na classe chamadoE como string para receber datas em branco de chamados que nao foram fechados
                                                             // e criei a variavel datafecha com Datetime para ser a alteraçao quando o chamdo for fechado (converter corretamente da maneira que o BD espera)
                    MessageBox.Show("Chamado Alterado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    frm.CarregarDataGrid("Aberto", "Em atendimento", "ENCAMINHADO");//forçando o carregando do form chamados lista
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            InserirAcomp();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtAcomp.Text = "";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboIndevido_MouseClick(object sender, MouseEventArgs e)
        {
            comboIndevido.SelectedIndex = -1;
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

        private void InserirAcomp(string corpo)
        {
            if (txtAcomp.Text != "" || auxiliar != 0)
            {
                try
                {
                    AcompanhamentoE aco = new AcompanhamentoE();
                    aco.UsuarioComent = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;
                    aco.CodigoChamado = Convert.ToInt32(lblNumero.Text);
                    aco.DataModificacao = DateTime.Now;
                    aco.Descricao = "Arquivo " + nomearq + " anexado";

                    acomp.InserirAcompanhamento(aco);

                    CarregarDataGrid();
                    btnLimpar.PerformClick();

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

                    acomp.InserirAcompanhamento(aco);

                    MessageBox.Show("Acompanhento incluído", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarDataGrid();
                    btnLimpar.PerformClick();

                    EnviaEmail mailDelivery = new EnviaEmail();

                    ChamadosP chap = new ChamadosP();
                    ChamadosE chamado = chap.PesquisarPorCodigo(aco.CodigoChamado);

                    string mail = mailDelivery.buscarEmailUser(chamado.Usuario);
                    string corpoEmail = "(*) Este é um email automático , por favor não responda\n\n\nSeu Chamado com a descrição abaixo possui um novo acompanhamento\n\n\nDescrição: " + chamado.Descricao;
                    mailDelivery.EnviarEmail(mail, "CMR Service Desk - Novo Acompanhamento - Chamado: " + aco.CodigoChamado, corpoEmail + aco.Descricao + "\n\n" + "Acompanhamento: " + aco.Descricao);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro:" + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAnexar_Click(object sender, EventArgs e)
        {
            SelecionarArquivo();
        }

        private void anexos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"\\srvjdifs01\AnexosChamados\" + lblNumero.Text + @"\" + anexos.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não existe anexo selecionado\n Erro:  " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAcomp_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

            FrmUsuariosAD obj = new FrmUsuariosAD(this);

            obj.ShowDialog();

        }

        public void DefinirResponsavel(string responsavel)
        {
            lblResponsavel.Text = responsavel;
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string responsavelAtual = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;

            if (comboStatus.Text == "ENCAMINHADO" && oUsuarioAnterior.Responsavel.Equals(responsavelAtual))
                btnNovo.Enabled = true;
            else
                btnNovo.Enabled = false;
        }

        private void anexos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

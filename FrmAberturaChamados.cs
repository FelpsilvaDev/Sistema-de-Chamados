using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistencia;
using Entidades;
using System.DirectoryServices.AccountManagement;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;

namespace Projeto_SistemadeChamadosCMR
{
    public partial class FrmAberturaChamados : Form
    {
        public FrmAberturaChamados()
        {
            InitializeComponent();

            combocat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSubcat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDepart.DropDownStyle = ComboBoxStyle.DropDownList;

            lblUsuario.Text = DisplayNameUsuarioLogado();
        }
        CategoriaP cat = new CategoriaP();
        SubcategoriaP subca = new SubcategoriaP();
        DepartamentoP depto = new DepartamentoP();
        ChamadosP chap = new ChamadosP();
        int controle = 1;

        ////Para desabilitar X do form
        //const int MF_BYPOSITION = 0x400;


        //[DllImport("User32")]
        //private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        //[DllImport("User32")]
        //private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        //[DllImport("User32")]
        //private static extern int GetMenuItemCount(IntPtr hWnd);
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmAberturaChamados_Load(object sender, EventArgs e)
        {

            ////Desabilita o botão Fechar (X)
            //IntPtr hMenu = GetSystemMenu(this.Handle, false);
            //int MenuItemCount = GetMenuItemCount(hMenu);
            //RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);


        }

        private void combocat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CarregarComboBox();

            }
            catch (Exception)
            {

            }

        }

        private void combocat_DisplayMemberChanged(object sender, EventArgs e)
        {
            //int codigo = Convert.ToInt32(combocat.SelectedValue.ToString());


        }

        private void combocat_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void CarregarComboBox()
        {
            if (combocat.Text != "")
            {
                comboSubcat.DataSource = subca.PesquisarPorCategoria(combocat.SelectedValue.ToString());
                comboSubcat.DisplayMember = "NomeSubcat";
                comboSubcat.ValueMember = "Codigo";
                comboSubcat.SelectedIndex = -1;
            }
        }

        private string DisplayNameUsuarioLogado()
        {
            try
            {

                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "cmr.com.br");

                string displayname = UserPrincipal.Current.DisplayName;
                return displayname;
            }
            catch (Exception ex)
            {
                MessageBox.Show("O computador deve estar ingressado no dominio CMR : " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw;


            }


        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            panelInferior.Height = btnAdicionar.Height;
            panelInferior.Left = btnAdicionar.Left;

            combocat.ValueMember = "Codigo";



            if (txtDescricao.Text != "" && combocat.Text != "" && comboSubcat.Text != "" && comboTipo.Text != "" && comboDepart.Text != "" && lblUsuario.Text != "")
            {

                try
                {

                    ChamadosE chamado = new ChamadosE();
                    string emailgestor = "";
                    chamado.CodigoCategoria = Convert.ToInt32(combocat.SelectedValue.ToString());
                    chamado.CodigoDepartamento = Convert.ToInt32(comboDepart.SelectedValue.ToString());
                    chamado.CodigoSubcategoria = Convert.ToInt32(comboSubcat.SelectedValue.ToString());
                    chamado.DataAbertura = DateTime.Now;
                    chamado.Descricao = txtDescricao.Text;
                    chamado.Prioridade = comboTipo.Text;
                    chamado.Usuario = lblUsuario.Text;
                    chamado.Autorizacao = "";
                    chamado.Responsavel = UserPrincipal.Current.Name;                   


                    int ultimoCodigo = RetornaUltimoChamado();
                    string email = System.DirectoryServices.AccountManagement.UserPrincipal.Current.EmailAddress;
                    string corpoDeEmail = " (*)Este é um e-mail automático por favor não responda \n\n\nSeu chamado foi aberto com sucesso\n\n\nNúmero do Chamado: " + ultimoCodigo + "\n\nSolicitante: " + DisplayNameUsuarioLogado();

                    if (comboSubcat.Text == "SAP - TRANSAÇÕES" || comboSubcat.Text == "SAP - REQUESTS CONSULTORIA" || comboSubcat.Text == "CONCESSÕES DE ACESSO")
                    {
                        GestorP gt = new GestorP();
                        int coddep;
                        emailgestor = gt.BuscarSetor(coddep = Convert.ToInt32(comboDepart.SelectedValue.ToString()));
                        chamado.Autorizacao = "P";
                        corpoDeEmail = " (*)Este é um e-mail automático por favor não responda \n\n\nChamado aberto com sucesso\n\n\nNúmero do Chamado: " + ultimoCodigo + "\n\nSolicitante: " + DisplayNameUsuarioLogado() + "\n\nEste chamado deve ser autorizado pelo gestor da área";
                        EnviaEmail enviaMail = new EnviaEmail();
                        enviaMail.EnviarEmail(emailgestor, email, "Abertura de Chamado Interno CMR", corpoDeEmail);
                    }
                    else
                    {
                        EnviaEmail enviaMail = new EnviaEmail();
                        enviaMail.EnviarEmail(email, "Abertura de Chamado Interno CMR", corpoDeEmail);
                    }


                    chap.InserirChamado(chamado);


                    MessageBox.Show("CHAMADO CRIADO COM SUCESSO !\n", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();



                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS !", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ChecarPermissaoRH()
        {
            string email = System.DirectoryServices.AccountManagement.UserPrincipal.Current.EmailAddress;

            PermissaoP perp = new PermissaoP();
            bool retorno = false;
            try
            {
                retorno = perp.ValidarPermissao(email, 1);

            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao consultar banco de dados", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retorno;
        }

        private void combocat_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                combocat.DataSource = cat.Listar();
                combocat.DisplayMember = "Nomecategoria";
                combocat.ValueMember = "Nomecategoria";
                combocat.SelectedIndex = -1;

            }
            catch (Exception)
            {


            }

        }

        private void comboDepart_Click(object sender, EventArgs e)
        {
            try
            {
                comboDepart.DataSource = depto.ListarDepartamentos();
                comboDepart.DisplayMember = "NomeDepto";
                comboDepart.ValueMember = "Codigo";
                comboDepart.SelectedIndex = -1;
            }
            catch (Exception)
            {


            }
        }

        private int RetornaUltimoChamado()
        {
            try
            {
                ChamadosE chamado = new ChamadosE();
                chamado.Usuario = DisplayNameUsuarioLogado();
                int codigo = chap.BuscarUltimoChamadoAberto(chamado);
                return codigo;
            }
            catch (Exception)
            {

                throw;
            }
        }




        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDescricao.Text = "";

            panelInferior.Height = btnCancelar.Height;
            panelInferior.Left = btnCancelar.Left;

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            panelInferior.Height = btnVoltar.Height;
            panelInferior.Left = btnVoltar.Left;
            this.Close();
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboSubcat_Click(object sender, EventArgs e)
        {
            if (combocat.Text == "")
            {
                MessageBox.Show("Selecione primeiro a categoria ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void combocat_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void combocat_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboSubcat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboSubcat_MouseClick(object sender, MouseEventArgs e)
        {
            bool retorno = ChecarPermissaoRH();

            if (!retorno)
            {
                if (combocat.Text == "ADM PESSOAL RH")
                {
                    MessageBox.Show("Você não tem permissão para abrir chamado para esta categoria", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    combocat.SelectedIndex = -1;
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

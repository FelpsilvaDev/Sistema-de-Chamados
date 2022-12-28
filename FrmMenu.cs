using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;
using System.IO;
using Entidades;
using Persistencia;

namespace Projeto_SistemadeChamadosCMR
{

    public partial class FrmMenu : Form
    {

        public FrmMenu()
        {
            InitializeComponent();
        
        }
        public int auxiliar = 0;
        //Para desabilitar X do form
        const int MF_BYPOSITION = 0x400;


        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            //VerificaAtualizacao();
            //VerificaGestor();
            //toolStripStatusLabel1.Text = DateTime.Now.ToString();
            //// cadastrosToolStripMenuItem.Enabled = false;
            //cadastrarCategoriaToolStripMenuItem.Enabled = false;
            //cadastrarDepartamentoToolStripMenuItem.Enabled = false;
            //cadastrarSubCategoriaToolStripMenuItem.Enabled = false;
            //cadastrarGestorToolStripMenuItem.Enabled = false;
            //buscarHistóricoToolStripMenuItem.Enabled = false;
            //filaDeAtendimentoToolStripMenuItem.Enabled = false;
            //pêndenciasDeAutorizaçãoToolStripMenuItem.Enabled = false;
            //cadastrarPermissõesEspeciaisToolStripMenuItem.Enabled = false;
            //cadastrarUsuárioPermissõesEspeciaisToolStripMenuItem.Enabled = false;

            //lblUsuarioLogado.Text = DisplayNameUsuarioLogado();

            ////Desabilita o botão Fechar (X)
            //IntPtr hMenu = GetSystemMenu(this.Handle, false);
            //int MenuItemCount = GetMenuItemCount(hMenu);
            //RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);

            //string email = System.DirectoryServices.AccountManagement.UserPrincipal.Current.EmailAddress;

            //GestorP gp = new GestorP();

            //bool validado = gp.ValidarGestor(email);

            //if (validado)
            //{
            //    pêndenciasDeAutorizaçãoToolStripMenuItem.Enabled = true;
            //    lblAdmin.Text = "Perfil de Gestor";
            //}
                    

        }

        private void VerificaGestor()
        {
        //    string email = System.DirectoryServices.AccountManagement.UserPrincipal.Current.EmailAddress;

        }
        string nome, controleversao = "instaladorV3.1.1.exe";
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmLogin obj = new FrmLogin(this);
            //obj.ShowDialog();

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

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult resp = MessageBox.Show("Deseja realmente sair do sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (resp == DialogResult.Yes)
            //{

            //    this.Close();
            //}
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1Horario_Tick(object sender, EventArgs e)
        {
            //toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void cadastrarDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmDepartamento obj = new FrmDepartamento();
            //obj.Show();
        }

        private void cadastrarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmCategoria obj = new FrmCategoria();
            //obj.Show();
        }

        private void cadastrarSubCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmSubCategoria obj = new FrmSubCategoria();
            //obj.Show();
        }

        private void aberturaDeChamadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmAberturaChamados obj = new FrmAberturaChamados();
            //obj.Show();
        }

        private void meusChamadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmChamadosLista obj = new FrmChamadosLista(auxiliar);
            //obj.Show();
        }

        private void filaDeAtendimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmChamadosLista obj = new FrmChamadosLista(auxiliar);
            //obj.Show();
        }

        private void buscarHistóricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmBuscarHistorico obj = new FrmBuscarHistorico();
            //obj.Show();
        }

        private void informaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmInformation obj = new FrmInformation();
            //obj.ShowDialog();
        }

        string caminhoDeAtualizacao = @"\\srvjdifs01\atualizacao\";
        private void VerificaAtualizacao()
        {
            if (!Directory.GetDirectories(caminhoDeAtualizacao).Equals(0)) // verifica se tem algo no diretorio de atualizacao 
            {
                //if (!System.IO.Directory.Exists(@"c:\Atualiza_Sistema")) // verifica se o diretorio local existe
                //{
                //    System.IO.Directory.CreateDirectory(@"c:\Atualiza_Sistema");
                //}
                string[] files = System.IO.Directory.GetFiles(caminhoDeAtualizacao, "*.exe"); // pega o que tem de .exe dentro do diretorio
                                                                                              // string[] files2 = System.IO.Directory.GetFiles(@"c:\Atualiza_Sistema", "*.exe"); //pega o que tem de .exe dentro do diretorio

                foreach (string item in files) //loop para varrer os arquivos no diretorio do srvjdifs01
                {
                    System.IO.FileInfo f = null;
                    try
                    {
                        f = new FileInfo(item);
                        nome = f.Name;
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }

                if (nome != controleversao)
                {
                    DialogResult resp = MessageBox.Show("Existe uma atualização disponível , deseja atualizar agora ?\n\nObs: após a atualização abra o sistema novamente!", "Informação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    try
                    {
                        if (resp == DialogResult.Yes)
                        {
                            //File.Copy(Path.Combine(@"\\srvjdifs01\atualizacao", nome), Path.Combine(@"c:\Atualiza_Sistema", nome), true); // transferindo arquivo para o c
                            System.Diagnostics.Process.Start(caminhoDeAtualizacao + nome);// startando a instalação da atualização
                            this.Close();
                            System.Diagnostics.Process.GetCurrentProcess().Kill();

                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Ocorreu um erro na cópia: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
        }

        private void liToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void pêndenciasDeAutorizaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmAutorizaChamado obj = new FrmAutorizaChamado(System.DirectoryServices.AccountManagement.UserPrincipal.Current.EmailAddress);
            //obj.Show();
        }

        private void cadastrarGestorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmCadastraGestor obj = new FrmCadastraGestor();
            //obj.Show();
        }

        private void sairDoSistemaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //DialogResult resp = MessageBox.Show("Deseja realmente sair do sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (resp == DialogResult.Yes)
            //{

            //    this.Close();
            //}
        }

        private void cadastrarUsuárioPermissoesEspeciaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmCadastroUsuario obj = new FrmCadastroUsuario();
            //obj.Show();
        }

        private void cadastrarPermissõesEspeciaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmPermissoes obj = new FrmPermissoes();
            //obj.Show();
        }
    }
}

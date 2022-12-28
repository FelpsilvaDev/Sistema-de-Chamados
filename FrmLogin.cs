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


namespace Projeto_SistemadeChamadosCMR
{

    public partial class FrmLogin : Form
    {
        public FrmLogin( FrmMain form)
        {
            InitializeComponent();

            formRecebeInstancia = form;
        }
        bool resultado;
        FrmMain formRecebeInstancia;
        //Para desabilitar X do form
        const int MF_BYPOSITION = 0x400;


        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //Desabilita o botão Fechar (X)
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool AcessarActiveDirectory(string nome, string senha) //metodo para acessar o active directory
        {
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "cmr.com.br"))// enviando paramentros para busca no ad 
                {
              
                    resultado = pc.ValidateCredentials(nome,senha);//recebendo resultado da consult

                    if(nome.IndexOf("adm_")!= -1 && resultado==true)  // se caso  seja adm e  exista o usuario 
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                    }
                   
                }
            }
            catch (Exception ex)// em caso de erro 
            {

                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return resultado; // retornando o resultado para quem chamar.
            
        }

        private void button1_Click(object sender, EventArgs e) //botao confirma
        {
            bool valida=false;
            //validando formulario
            if (txtLogin.Text!=string.Empty)
            {
                valida = AcessarActiveDirectory(txtLogin.Text, txtSenha.Text); // recebendo resposta do Metodo AcessarActiveDirectory

                if (valida == true)//Tratando resposta no caso de existir o usuario.
                {
                    //MessageBox.Show("Usuario existe ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ////Habilitando os cadastros para o administrador após a autenticação
                    //formRecebeInstancia.buscarHistóricoToolStripMenuItem.Enabled= true;
                    //formRecebeInstancia.cadastrarCategoriaToolStripMenuItem.Enabled = true;
                    //formRecebeInstancia.cadastrarSubCategoriaToolStripMenuItem.Enabled = true;
                    //formRecebeInstancia.cadastrarDepartamentoToolStripMenuItem.Enabled = true;
                    //formRecebeInstancia.filaDeAtendimentoToolStripMenuItem.Enabled = true;
                    //formRecebeInstancia.cadastrarGestorToolStripMenuItem.Enabled = true;
                    //formRecebeInstancia.meusChamadosToolStripMenuItem.Enabled = false;
                    //formRecebeInstancia.loginToolStripMenuItem.Enabled = false;
                    //formRecebeInstancia.cadastrarPermissõesEspeciaisToolStripMenuItem.Enabled = true;
                    //formRecebeInstancia.cadastrarUsuárioPermissõesEspeciaisToolStripMenuItem.Enabled = true;
                    
                    formRecebeInstancia.auxiliar = 1;
                    formRecebeInstancia.lbladmin.Text = "Administrador";

                    formRecebeInstancia.BtnCadastros.Enabled = true;
                    formRecebeInstancia.btnRelatórios.Enabled = true;
                    formRecebeInstancia.BtnFila.Enabled = true;
                    formRecebeInstancia.BtnAdministrador.Enabled = false;
                    formRecebeInstancia.btnMeusChamados.Enabled = false;

                    this.Close();
                }

                else
                {
                    MessageBox.Show("Usuário ou senha incorretos ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSenha.Text = "";
                }
            }
            else // caso nao seja digitado um Login no textbox
            {

                MessageBox.Show("Digite um login", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

            
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(e.KeyChar == 13)
            {
                txtSenha.Focus();
            }
                
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                btnConfirmar.PerformClick();
            }
        }
    }
}

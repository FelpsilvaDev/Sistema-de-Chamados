using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using ActiveDs;
using System.Runtime.InteropServices;

namespace Projeto_SistemadeChamadosCMR
{
    public partial class FrmUsuariosAD : Form
    {
        public FrmUsuariosAD(object form)
        {
            InitializeComponent();
            recebInstacia = form;
        }

        //public FrmUsuariosAD(FrmAdministracaoChamado form)
        //{
        //    InitializeComponent();
        //    recebInstacia = form;
        //}


        object recebInstacia;
        List<String> registrosList; // sendo carregado no metodo load.

        //Para desabilitar X do form
        const int MF_BYPOSITION = 0x400;


        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listagem.BeginUpdate(); // iniciando alteracao na listbox
            listagem.Items.Clear(); // limpando listbox

            foreach (string item in registrosList) // percorrendo lista de string com itens da listbox
            {
                if (item.Contains(textBox1.Text)) // comparando o que foi digitado na textbox com os itens da List<string>
                {
                    listagem.Items.Add(item); // adicionando itens encontrados da lista na list box
                }
            }
            listagem.EndUpdate();//finalizando alteracao na list box
        }

        private void BuscarUsuariosAD()
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "cmr.com.br", "administrator", "(#L1&20==)");

            PrincipalSearcher buscarUsers = new PrincipalSearcher();
            UserPrincipal userPrin = new UserPrincipal(ctx);
            userPrin.Name = "*";
            buscarUsers.QueryFilter = userPrin;
            PrincipalSearchResult<Principal> result = buscarUsers.FindAll();

            foreach (Principal item in result)
            {
                try
                {
                    listagem.Items.Add(item.DisplayName);
                }
                catch (Exception)
                {


                }

            }


        }

        private void FrmUsuariosAD_Load(object sender, EventArgs e)
        {
            BuscarUsuariosAD();
            registrosList = listagem.Items.Cast<String>().ToList(); // Transferindo dados da listbox para a list<string>

            //Desabilita o botão Fechar (X)
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (recebInstacia.GetType() == typeof(FrmBuscarHistorico))
            {
                var teste = recebInstacia as FrmBuscarHistorico;
                teste.txtSolicitante.Text = textBox1.Text;
            }
            if (recebInstacia.GetType() == typeof(FrmAdministracaoChamado))
            {
                var teste = recebInstacia as FrmAdministracaoChamado;
                teste.DefinirResponsavel(textBox1.Text);
            }

            this.Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {


        }

        private void btnCarregarUsers_Click(object sender, EventArgs e)
        {
            BuscarUsuariosAD();
            registrosList = listagem.Items.Cast<String>().ToList();

        }

        private void listagem_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = listagem.SelectedItem.ToString();
            }
            catch (Exception)
            {

                //MessageBox.Show("Erro: " + ex.Message, "Erro: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

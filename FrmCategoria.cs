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

namespace Projeto_SistemadeChamadosCMR
{
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
            DesabilitarBotoes();
        }
        CategoriaP catp = new CategoriaP();
        const int MF_BYPOSITION = 0x400;


        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        private void btnAdicionar_Click(object sender, EventArgs e)
        {      
            if(txtNome.Text != "")
            {
                try
                {
                    CategoriaE cat = new CategoriaE();
                    cat.Nomecategoria = txtNome.Text.ToUpper();
                    catp.InserirCategoria(cat);

                    MessageBox.Show("Categoria inserida com sucesso","Mensagem",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    CarregarDataGridView();
                    DesabilitarBotoes();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Atribua um nome para a nova categoria", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     

            
        }

        private void CarregarDataGridView()
        {

            List<CategoriaE> listaVerifacao = new List<CategoriaE>();
            listaVerifacao = catp.Listar();

            if(listaVerifacao.Count != 0)
            {
                datagridCategoria.DataSource = "";
                datagridCategoria.DataSource = catp.Listar();
                datagridCategoria.AutoResizeColumns();
            }
            else
            {
                MessageBox.Show("Não existem categorias cadastradas", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            lblcodigo.Text = "";
            txtNome.Text = "";
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            CarregarDataGridView();
            //Desabilita o botão Fechar (X)
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);
        }

        private void HabilitarBotoes()
        {
            btnAdicionar.Enabled = false;
            btnAlterar.Enabled = true;
            btnDeletar.Enabled = true;
        }
        private void DesabilitarBotoes()
        {
            btnAdicionar.Enabled = true;
            btnAlterar.Enabled = false;
            btnDeletar.Enabled = false;
        }

        private void datagridCategoria_DoubleClick(object sender, EventArgs e)
        {
            int posicao = datagridCategoria.SelectedCells[0].RowIndex;
            DataGridViewRow linha = datagridCategoria.Rows[posicao];

            int codigo = Convert.ToInt32(linha.Cells[0].Value);

            try
            {
                CategoriaE categ = catp.PesquisarPorCodigo(codigo);

                txtNome.Text = categ.Nomecategoria;
                lblcodigo.Text = categ.Codigo.ToString();
                HabilitarBotoes();
            }
            catch (Exception)
            {

                throw;
            }
         
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            lblcodigo.Text = "";
            DesabilitarBotoes();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && lblcodigo.Text != "")
            {
                try
                {
                    CategoriaE cat = new CategoriaE();
                    cat.Nomecategoria = txtNome.Text.ToUpper();
                    cat.Codigo = Convert.ToInt32(lblcodigo.Text);
                    catp.AlterarCategoria(cat);
                    DesabilitarBotoes();

                    MessageBox.Show("Categoria alterada com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarDataGridView();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Selecione uma categoria para ser alterada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if(lblcodigo.Text != "")
            {
                try
                {
                    catp.DeletarCategoria(Convert.ToInt32(lblcodigo.Text));
                    MessageBox.Show("Categoria deletada com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarDataGridView();
                    DesabilitarBotoes();
                   
                }
                catch (Exception)
                {

                    MessageBox.Show("Administrador , acesse o banco de dados e altere a categoria das subcategorias pertencentes a esta", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

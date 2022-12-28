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
using System.Runtime.InteropServices;

namespace Projeto_SistemadeChamadosCMR
{
    public partial class FrmSubCategoria : Form
    {
        public FrmSubCategoria()
        {
            InitializeComponent();
            datagridSubCategoria.AutoGenerateColumns = false;//nao montar colunas automaticamente
            //Ocultando uma coluna no data grid view que se refere ao codigo da categoria da subcategoria.
            datagridSubCategoria.Columns[3].Visible = false;

            comboCat.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        SubcategoriaP sup = new SubcategoriaP();
        CategoriaP cat = new CategoriaP();
        //Para desabilitar X do form
        const int MF_BYPOSITION = 0x400;


        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        private void FrmSubCategoria_Load(object sender, EventArgs e)
        {
         
            comboCat.DataSource = cat.Listar();
            comboCat.DisplayMember = "Nomecategoria";          
            comboCat.ValueMember = "Codigo"; // Estou fazendo isso por conta da pesquisa no banco , pois com o valuemember (tipo de dados inteiro) estava dando pau no método selectindexchange 
                                                    // alterei a pesquisa para o nome da categoria e nao pela chave primaria 
                                                    // porém no método de adicionar volto o value member para Codigo , para utilizar a chave primaria para insercao do registro
            CarregarDataGrid();
            DesabilitarBotoes();

            //Desabilita o botão Fechar (X)
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitarBotoes();
            CarregarDataGrid();
           
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if(txtNome.Text != "" && comboCat.Text!= "")
            {
                try
                {

                    comboCat.ValueMember = "Codigo";
                    SubcategoriaE cat = new SubcategoriaE();
                    cat.NomeSubcat = txtNome.Text.ToUpper();
                    cat.codigoCate = Convert.ToInt32(comboCat.SelectedValue);
                    sup.InserirCategoria(cat);
                    CarregarDataGrid();
                    LimparCampos();

                    MessageBox.Show("Subcategoria inserida com sucesso !", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,"Erro ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Descreva um nome e a categoria ! ","Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CarregarDataGrid()
        {
            try
            {
                datagridSubCategoria.DataSource = null;
                datagridSubCategoria.DataSource = sup.Listar(Convert.ToInt32(comboCat.SelectedValue.ToString()));
                datagridSubCategoria.AutoResizeColumns();
            }
            catch (Exception)
            {
                
            
            }
          
        }

        private void datagridSubCategoria_DoubleClick(object sender, EventArgs e)
        {
            int posicao = datagridSubCategoria.SelectedCells[0].RowIndex;
            DataGridViewRow linha = datagridSubCategoria.Rows[posicao];
            int codigo = Convert.ToInt32(linha.Cells[0].Value);

            SubcategoriaE sub = sup.PesquisarPorCodigo(codigo);

            txtNome.Text = sub.NomeSubcat;
            lblcodigo.Text = sub.Codigo.ToString();
            HabilitarBotoes();

            foreach( CategoriaE item in comboCat.Items)//varrendo a combobox para comparaçao com os dados extraidos do banco
            {
                if(sub.NomeCategoria == item.Nomecategoria)
                {
                    comboCat.SelectedIndex = comboCat.FindStringExact(sub.NomeCategoria);//se o nome for igual seleciona o index do nome
                    break;
                   
                }
            }

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
        private void LimparCampos()
        {
            txtNome.Text = "";
            lblcodigo.Text = "";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && comboCat.Text != ""&& lblcodigo.Text != "")
            {
                try
                {
                    SubcategoriaE cat = new SubcategoriaE();
                    cat.NomeSubcat = txtNome.Text.ToUpper();
                    cat.Codigo = Convert.ToInt32(lblcodigo.Text);
                    cat.codigoCate = Convert.ToInt32(comboCat.SelectedValue);
                    sup.AlterarCategoria(cat);
                    CarregarDataGrid();
                    LimparCampos();
                    DesabilitarBotoes();

                    MessageBox.Show("Subcategoria alterada com sucesso !", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Erro ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma categoria para ser alterada e preencha o nome da subcategoria e a categoria! ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (lblcodigo.Text!= "")
            {
                try
                {
                    SubcategoriaE cat = new SubcategoriaE();
                    sup.DeletarCategoria(Convert.ToInt32(lblcodigo.Text));
                    CarregarDataGrid();
                    LimparCampos();
                    DesabilitarBotoes();

                    MessageBox.Show("Subcategoria excluída  com sucesso !", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Erro ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Descreva um nome e a categoria ! ", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboCat_SelectedIndexChanged(object sender, EventArgs e)
        {

            CarregarDataGrid();

        }

        private void comboCat_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboCat_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }
    }
    }



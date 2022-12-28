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
    public partial class FrmDepartamento : Form
    {
        public FrmDepartamento()
        {
            InitializeComponent();
            dataGridDepartamento.AutoGenerateColumns = false;
        }
        DepartamentoP deptP = new DepartamentoP();
        //Para desabilitar X do form
        const int MF_BYPOSITION = 0x400;


        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        private void FrmDepartamento_Load(object sender, EventArgs e)
        {
            CarregarDataGrid();

            DesabilitarBotoes();

            //Desabilita o botão Fechar (X)
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);

            comboGestor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "")
            {

                try
                {
                    DepartamentoE dep = new DepartamentoE(); //Instanciando DepartamentE 
                    dep.NomeDepto = txtNome.Text.ToUpper(); //Passando parametro
                    deptP.Inserir(dep);//Invocando metodo Inserir da classe departamentoP
                    MessageBox.Show("Departamento inserido com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);// enviando mensagem caso esteja correto.
                    CarregarDataGrid();
                    DesabilitarBotoes();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);//enviando mensagem de erro de caso houver.
                }

            }
            else
            {
                MessageBox.Show("Digite um nome para o departamento ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);//enviando mensagem de erro de caso houver.
            }


        }

        private void CarregarDataGrid()
        {
            dataGridDepartamento.DataSource = null;
            dataGridDepartamento.DataSource = deptP.ListarDepartamentos();
            dataGridDepartamento.AutoResizeColumns();

            txtNome.Text = "";
            lblcodigo.Text = "";
        }

        private void dataGridDepartamento_DoubleClick(object sender, EventArgs e)
        {
            int posicao = dataGridDepartamento.SelectedCells[0].RowIndex;
            DataGridViewRow linha = dataGridDepartamento.Rows[posicao];

            int codigo = Convert.ToInt32(linha.Cells[0].Value);

            GestorP gesp = new GestorP();

            comboGestor.DataSource = gesp.ListaTodoGestores();
            comboGestor.DisplayMember = "Nome";
            comboGestor.ValueMember = "Cod";

            DepartamentoE dept = deptP.PesquisarPorCodigo(codigo);

            if (dept.NomeGestor == "")
            {
                comboGestor.SelectedIndex = -1;
            }

            foreach (GestorE item in comboGestor.Items)
            {
                if (dept.NomeGestor== item.Nome)
                {
                    comboGestor.SelectedIndex = comboGestor.FindStringExact(dept.NomeGestor.ToString());
                    break;
                }
            }

            txtNome.Text = dept.NomeDepto;
            lblcodigo.Text = dept.Codigo.ToString();

            HabilitarBotoes();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            CarregarDataGrid();
            DesabilitarBotoes();

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
                    DepartamentoE dept = new DepartamentoE();
                    dept.Codigo = int.Parse(lblcodigo.Text);
                    dept.NomeDepto = txtNome.Text.ToUpper();
                    dept.Codgestor = Convert.ToInt32(comboGestor.SelectedValue);
                    deptP.AlterarDepartamento(dept);

                    MessageBox.Show("Departamento alterado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);// enviando mensagem caso esteja correto.
                    CarregarDataGrid();
                    DesabilitarBotoes();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);//enviando mensagem de erro de caso houver.
                }


            }


        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && lblcodigo.Text != "")
            {
                try
                {
                
                    deptP.ExcluirDepartamento(int.Parse(lblcodigo.Text));

                    MessageBox.Show("Departamento excluído com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);// enviando mensagem caso esteja correto.
                    CarregarDataGrid();
                    DesabilitarBotoes();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);//enviando mensagem de erro de caso houver.
                }

            }
        }

        private void comboGestor_Click(object sender, EventArgs e)
        {
            GestorP gesp = new GestorP();

            comboGestor.DataSource = gesp.ListaTodoGestores();
            comboGestor.DisplayMember = "Nome";
            comboGestor.ValueMember = "Cod";
        }
    }
}

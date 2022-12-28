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

namespace Projeto_SistemadeChamadosCMR
{
    public partial class FrmAutorizaChamado : Form
    {
        public FrmAutorizaChamado(string email)
        {
            InitializeComponent();

            emailgestor = email;

            dataGridChamados.AutoGenerateColumns = false;
            dataGridChamados.Columns[11].Visible = false;
            dataGridChamados.Columns[12].Visible = false;
            dataGridChamados.Columns[14].Visible = false;
            dataGridChamados.Columns[15].Visible = false;
            dataGridChamados.Columns[16].Visible = false;
        }
        string emailgestor;
        int coddepartamento;
        string acesso = "";
        private void FrmAutorizaChamado_Load(object sender, EventArgs e)
        {
            acesso = "A"; // Autorização
            ConsultaDepartamento(emailgestor);
            CarregarDataGrid();
        }

        private void ConsultaDepartamento(string emailgestor)
        {

            try
            {
                GestorP gp = new GestorP();
                coddepartamento = gp.BuscarGestorSetor(emailgestor);
            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao Consultar Dados","Erro",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
           
        }


        private void CarregarDataGrid()
        {
            ChamadosP chp = new ChamadosP();

            try
            {
                dataGridChamados.DataSource = null;
               GestorP gep = new GestorP();
                dataGridChamados.DataSource = chp.ListarParaAutorizações(gep.RetornaCodigoGestor(coddepartamento),33,34,36, "ABERTO"); // Passando codigos das subcategoria que necessitam de autorização
            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao Consultar Chamados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
        }

        private void dataGridChamados_DoubleClick(object sender, EventArgs e)
        {
            int posicao = dataGridChamados.SelectedCells[0].RowIndex;
            DataGridViewRow linha = dataGridChamados.Rows[posicao];
            int codigo = Convert.ToInt32(linha.Cells[0].Value);
            ChamadosP chp = new ChamadosP();
            ChamadosE chamado = chp.PesquisarPorCodigo(codigo);

            FrmVisualizarChamadoUser obj = new FrmVisualizarChamadoUser(chamado, "GESTOR",acesso);
            obj.ShowDialog();

        }

        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            acesso = "A"; // Autorização
            CarregarDataGrid();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ChamadosP chamap = new ChamadosP();
            GestorP gep = new GestorP();
            dataGridChamados.DataSource = null;
            dataGridChamados.DataSource = chamap.BuscaHistoricoGestor(gep.RetornaCodigoGestor(coddepartamento));
            acesso = "V"; // V de Visualização
        }

        private void btnAnexarArq_Click(object sender, EventArgs e)
        {
            acesso = "A"; // Autorização
            CarregarDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             this.WindowState = FormWindowState.Minimized;
        }

        private void panelInferior_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

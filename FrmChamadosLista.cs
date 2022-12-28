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
    public partial class FrmChamadosLista : Form
    {
        public FrmChamadosLista(int aux)//variavel para servir como parametro entre comparaçao de useradm e usuariocomum
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Normal;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            dataGridChamados.AutoGenerateColumns = false;
            dataGridChamados.Columns[11].Visible = false;
            dataGridChamados.Columns[12].Visible = false;
            dataGridChamados.Columns[14].Visible = false;
            dataGridChamados.Columns[15].Visible = false;
            dataGridChamados.Columns[16].Visible = false;

            comboStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            auxiliar = aux; // passando valor para a variavel auxiliar

            displayname = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;
        }

        ChamadosP chamap = new ChamadosP();
        int auxiliar;
        string displayname;
        ////Para desabilitar X do form
        //const int MF_BYPOSITION = 0x400;


        //[DllImport("User32")]
        //private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        //[DllImport("User32")]
        //private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        //[DllImport("User32")]
        //private static extern int GetMenuItemCount(IntPtr hWnd);
        private void FrmChamadosLista_Load(object sender, EventArgs e)
        {
            comboStatus.SelectedIndex = 0;
            if(auxiliar == 1) // condicao para se for adm ser zerado o displayname para mudar o comportamento do metodo que recebe este parametro
            {
                displayname = "";
                label1.Text = "CHAMADOS CMR";
            }
            
            try
            {
                CarregarDataGrid("Aberto", "Em atendimento", "ENCAMINHADO");//Passando três status para o metodo de carregar o data grid view 
                //Desabilita o botão Fechar (X)
                //IntPtr hMenu = GetSystemMenu(this.Handle, false);
                //int MenuItemCount = GetMenuItemCount(hMenu);
                //RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(comboStatus.Text == @"Aberto/Em atendimento")
            {
                CarregarDataGrid("Aberto","Em atendimento", "ENCAMINHADO");
            }
            else
            {
                CarregarDataGrid("Encerrado");
            }
        }

        public void CarregarDataGrid (string st01, string st02, string st03)
        {
            try
            {
                dataGridChamados.DataSource = null;
                dataGridChamados.DataSource = chamap.ListarChamadosUsuario(displayname, st01, st02, st03);
                dataGridChamados.AutoResizeColumns();

                dataGridChamados.RowsDefaultCellStyle.BackColor = Color.Orange;
                dataGridChamados.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;

                
                //dataGridChamados
                foreach (DataGridViewRow data in dataGridChamados.Rows)
                {
                    TimeSpan date = DateTime.Now - Convert.ToDateTime(data.Cells["dataAbertura"].Value);
                    int days = date.Days;


                    if (days >= 3)
                    {
                        //dataGridChamados.Rows[data.Index].DefaultCellStyle.BackColor = Color.Yellow;
                        data.DefaultCellStyle.BackColor = Color.FromArgb(194,108,21);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao consultar tabela do banco de dados: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public void CarregarDataGrid(string st01)
        {
            foreach (DataGridViewRow data in dataGridChamados.Rows)
            {
                TimeSpan date = Convert.ToDateTime(data.Cells["dataAbertura"].Value) - DateTime.Now;
                int days = date.Days;


                if (days >= 1)
                {
                    dataGridChamados.Rows[data.Index].DefaultCellStyle.BackColor = Color.Red;
                }
            }
            try
            {
                dataGridChamados.DataSource = null;
                dataGridChamados.DataSource = chamap.ListarChamadosUsuario(displayname, st01);
                dataGridChamados.AutoResizeColumns();

                dataGridChamados.RowsDefaultCellStyle.BackColor = Color.Orange;
                dataGridChamados.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao consultar tabela do banco de dados: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void dataGridChamados_DoubleClick(object sender, EventArgs e)
        {
            int posicao = dataGridChamados.SelectedCells[0].RowIndex;
            DataGridViewRow linha = dataGridChamados.Rows[posicao];
            int codigo = Convert.ToInt32(linha.Cells[0].Value);

            ChamadosE chamado = chamap.PesquisarPorCodigo(codigo);

            if (auxiliar == 1)
            {
                FrmAdministracaoChamado obj = new FrmAdministracaoChamado(chamado, this);
                obj.ShowDialog();
            }
            else
            {

                FrmVisualizarChamadoUser obj = new FrmVisualizarChamadoUser(chamado, "usuario", "V");
                obj.ShowDialog();
            }
            
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboStatus.Text == @"Aberto/Em atendimento")
            {
                CarregarDataGrid("Aberto", "Em atendimento", "ENCAMINHADO");
            }
            else
            {
                CarregarDataGrid("Encerrado");
            }
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
       
    }
}

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
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;

namespace Projeto_SistemadeChamadosCMR
{
    public partial class FrmBuscarHistorico : Form
    {
        public FrmBuscarHistorico()
        {
            InitializeComponent();

            dataGridBuscar.AutoGenerateColumns = false;
            //dataGridBuscar.Columns[11].Visible = false;
            //dataGridBuscar.Columns[12].Visible = false;
            dataGridBuscar.Columns[14].Visible = false;
            dataGridBuscar.Columns[15].Visible = false;
            dataGridBuscar.Columns[16].Visible = false;

            comboCate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDepar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSubcat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboIndevido.DropDownStyle = ComboBoxStyle.DropDownList;
            comboGestor.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        //Para desabilitar X do form
        const int MF_BYPOSITION = 0x400;


        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        private void FrmBuscarHistorico_Load(object sender, EventArgs e)
        {
            //Desabilita o botão Fechar (X)
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, MenuItemCount - 1, MF_BYPOSITION);
            comboIndevido.SelectedIndex = -1;
        }

        private void comboCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CarregarComboBox();
            }
            catch (Exception)
            {


            }

        }
        SubcategoriaP subca = new SubcategoriaP();
        ChamadosP chamap = new ChamadosP();
        DateTime data2;
        string data1;
        string data3;
        private void CarregarComboBox()
        {
            if (comboCate.Text != "")
            {
                comboSubcat.DataSource = subca.PesquisarPorCategoria(comboCate.SelectedValue.ToString());
                comboSubcat.DisplayMember = "NomeSubcat";
                comboSubcat.ValueMember = "Codigo";
                comboSubcat.SelectedIndex = -1;

            }

            if (true)
            {

            }
        }

        private void comboCate_Click(object sender, EventArgs e)
        {
            CategoriaP catp = new CategoriaP();

            comboCate.DataSource = catp.Listar();
            comboCate.DisplayMember = "Nomecategoria";
            comboCate.ValueMember = "Nomecategoria";
            comboCate.SelectedIndex = -1;
        }

        private void comboDepar_Click(object sender, EventArgs e)
        {
            DepartamentoP depart = new DepartamentoP(); // carregando combo box departamento

            comboDepar.DataSource = depart.ListarDepartamentos();
            comboDepar.DisplayMember = "NomeDepto";
            comboDepar.ValueMember = "Codigo";
            comboDepar.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            comboCate.ValueMember = "Codigo"; // valor da combobox ao selecionar
            ChamadosE chamado = new ChamadosE();

            //convertendo valor das combos para int
            chamado.CodigoCategoria = Convert.ToInt32(comboCate.SelectedValue);
            chamado.CodigoSubcategoria = Convert.ToInt32(comboSubcat.SelectedValue);
            chamado.CodigoDepartamento = Convert.ToInt32(comboDepar.SelectedValue);
            try
            {
                data1 = mskData1.Text;
                data1 += " 00:00";

                data3 = mskData2.Text;
                data3 += " 23:59";

                chamado.DataAbertura = Convert.ToDateTime(data1);
                data2 = Convert.ToDateTime(data3);
            }
            catch (Exception)
            {
                MessageBox.Show("Insira uma data e hora correta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            chamado.Usuario = txtSolicitante.Text;
            chamado.Responsavel = txtResp.Text;
            chamado.Status = comboStatus.Text;
            chamado.Indevido = comboIndevido.Text;


            try
            {
                if (comboGestor.Text != "")
                {
                    comboIndevido.SelectedIndex = -1;
                    comboCate.SelectedIndex = -1;
                    comboSubcat.SelectedIndex = -1;
                    comboStatus.SelectedIndex = -1;
                    txtResp.Text = "";
                    txtSolicitante.Text = "";

                    GestorP gep = new GestorP();



                    bool retornoferias = gep.ConsultaFerias(Convert.ToInt32(comboGestor.SelectedValue), Convert.ToDateTime(data1), data2);

                    if (retornoferias)
                    {
                        if (comboDepar.Text == "")
                        {
                            MessageBox.Show("Nesse período de busca o gestor estava de férias , gentileza escolher um depto especifico", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (chamap.BuscaHistoricoGestor(Convert.ToDateTime(data1), data2, Convert.ToInt32(comboDepar.SelectedValue)).Count != 0) // validando se existe registros na busca
                            {

                                dataGridBuscar.DataSource = null;
                                dataGridBuscar.DataSource = chamap.BuscaHistoricoGestor(Convert.ToDateTime(data1), data2, Convert.ToInt32(comboDepar.SelectedValue));
                                dataGridBuscar.AutoResizeColumns();
                                lblQtdChamados.Text = dataGridBuscar.RowCount.ToString(); //Quantidade de registros encontrados no select(memoria).
                            }

                            else
                            {
                                MessageBox.Show(" Não existe nenhum registro para os critérios de seleção definidos ! ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dataGridBuscar.DataSource = null;
                            }

                        }


                    }
                    else
                    {
                        if (chamap.BuscaHistoricoGestor(Convert.ToInt32(comboGestor.SelectedValue), Convert.ToDateTime(data1), data2).Count != 0) // validando se existe registros na busca
                        {
                            dataGridBuscar.DataSource = null;
                            dataGridBuscar.DataSource = chamap.BuscaHistoricoGestor(Convert.ToInt32(comboGestor.SelectedValue), Convert.ToDateTime(data1), data2);
                            dataGridBuscar.AutoResizeColumns();
                            lblQtdChamados.Text = dataGridBuscar.RowCount.ToString(); //Quantidade de registros encontrados no select(memoria).
                        }

                        else
                        {
                            MessageBox.Show(" Não existe nenhum registro para os critérios de seleção definidos ! ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dataGridBuscar.DataSource = null;
                        }

                    }



                }
                else
                {

                    if (chamap.BuscarHistorico(chamado, data2).Count != 0) // validando se existe registros na busca
                    {
                        dataGridBuscar.DataSource = null;
                        dataGridBuscar.DataSource = chamap.BuscarHistorico(chamado, data2);
                        dataGridBuscar.AutoResizeColumns();
                        lblQtdChamados.Text = dataGridBuscar.RowCount.ToString(); //Quantidade de registros encontrados no select(memoria).
                    }

                    else
                    {
                        MessageBox.Show(" Não existe nenhum registro para os critérios de seleção definidos ! ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dataGridBuscar.DataSource = null;
                    }

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            comboCate.ValueMember = "Codigo";
            ChamadosE chamado = new ChamadosE();

            chamado.CodigoCategoria = Convert.ToInt32(comboCate.SelectedValue);
            chamado.CodigoSubcategoria = Convert.ToInt32(comboSubcat.SelectedValue);
            chamado.CodigoDepartamento = Convert.ToInt32(comboDepar.SelectedValue);
            chamado.DataAbertura = Convert.ToDateTime(mskData1.Text);
            chamado.Usuario = txtSolicitante.Text;
            chamado.Responsavel = txtResp.Text;
            chamado.Status = comboStatus.Text;
            chamado.Indevido = comboIndevido.Text;

            data1 = mskData1.Text;
            data1 += " 00:00";

            data3 = mskData2.Text;
            data3 += " 23:59";

            chamado.DataAbertura = Convert.ToDateTime(data1);
            data2 = Convert.ToDateTime(data3);

            try
            {
                List<ChamadosE> receb = chamap.BuscarHistorico(chamado, data2);

                FrmReport obj = new FrmReport(receb);
                obj.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void comboSubcat_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmUsuariosAD obj = new FrmUsuariosAD(this);

            obj.ShowDialog();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboIndevido_MouseClick(object sender, MouseEventArgs e)
        {
            comboIndevido.SelectedIndex = -1;
        }

        private void dataGridBuscar_DoubleClick(object sender, EventArgs e)
        {
            int posicao = dataGridBuscar.SelectedCells[0].RowIndex;
            DataGridViewRow linha = dataGridBuscar.Rows[posicao];
            int codigo = Convert.ToInt32(linha.Cells[0].Value);

            ChamadosE chamado = chamap.PesquisarPorCodigo(codigo);

            FrmVisualizarChamadoUser obj = new FrmVisualizarChamadoUser(chamado, "adm", "V");
            obj.ShowDialog();
        }

        private void lblQtdChamados_Click(object sender, EventArgs e)
        {

        }

        private void comboGestor_Click(object sender, EventArgs e)
        {
            GestorP gp = new GestorP();

            comboGestor.DataSource = null;
            comboGestor.DataSource = gp.ListaTodoGestores();
            comboGestor.DisplayMember = "Nome";
            comboGestor.ValueMember = "Cod";
            comboGestor.SelectedIndex = -1;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void comboSubcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCate.Text == "")
            {
                CarregarComboBox();
                //MessageBox.Show("Selecione primeiro a categoria ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mskData1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}

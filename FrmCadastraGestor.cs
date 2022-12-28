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

namespace Projeto_SistemadeChamadosCMR
{
    public partial class FrmCadastraGestor : Form
    {
        public FrmCadastraGestor()
        {
            InitializeComponent();
        }

        GestorP gerp = new GestorP();
        int controle = 0;
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            GestorE gestor = new GestorE();

            if (txtNome.Text != "" && txtEmail.Text != "" )
            {
                gestor.Nome = txtNome.Text.ToUpper();
                gestor.Email = txtEmail.Text;
                //gestor.CodDepartamento = Convert.ToInt32(cmbDepar.SelectedValue);

                try
                {
                    if (btnSalvar.Text == "Salvar")
                    {
                        gerp.CadastrarGestor(gestor);
                        MessageBox.Show("Cadastro realizado ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarDataGrid();
                      
                    }
                    else
                    {
                        gestor.Cod = Convert.ToInt32(txtCodigo.Text);

                        if (mskdata.Text == "  /  /" && mskdata2.Text == "  /  /")
                        {
                            if (controle == 1)
                            {
                                Nullable<DateTime> dt1 = null;
                                Nullable<DateTime> dt2 = null;
                                gerp.AlterarGestor(gestor, dt1, dt2);

                                controle = 0;
                            }
                            else
                            {
                                gerp.AlterarGestor(gestor);
                            }
                            

                        }
                        else
                        {
                           
                            gerp.AlterarGestor(gestor,Convert.ToDateTime(mskdata.Text),Convert.ToDateTime(mskdata2.Text));

                            gerp.InsereRegistroFerias(Convert.ToDateTime(mskdata.Text), Convert.ToDateTime(mskdata2.Text), gestor.Cod);
                        }

                        MessageBox.Show("Cadastro alterado ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarDataGrid();
                        lblferiasate.Visible = false;
                        lbldatade.Visible = false;
                        mskdata.Visible = false;
                        mskdata2.Visible = false;                  
                    }
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro na manutenção do  gestor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos" ,"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtCodigo.Text = "";
            //cmbDepar.SelectedIndex = -1;

        }

        private void cmbDepar_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbDepar_Click(object sender, EventArgs e)
        {

          
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadastraGestor_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            lblferiasate.Visible = false;
            lbldatade.Visible = false;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarDataGrid();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int posicao = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow linha = dataGridView1.Rows[posicao];
            int codigo = Convert.ToInt32(linha.Cells[0].Value);
            DepartamentoP depto = new DepartamentoP();
            GestorE gest = new GestorE();
            try
            {
                //cmbDepar.DataSource = null;
                //cmbDepar.DataSource = depto.ListarDepartamentos();
                //cmbDepar.DisplayMember = "NomeDepto";
                //cmbDepar.ValueMember = "Codigo";
                gest = gerp.BuscarGestor(codigo);

                txtNome.Text = gest.Nome;
                txtEmail.Text = gest.Email;
                txtCodigo.Text = gest.Cod.ToString();
                lblferiasate.Visible = true;
                lbldatade.Visible = true;
                mskdata.Visible = true;
                mskdata2.Visible = true;

                if (gest.data1 != "")
                {
                    mskdata.Text  = gest.data1.ToString();
                    mskdata2.Text = gest.data2.ToString();
                    controle = 1;

                }

                //foreach (DepartamentoE item in cmbDepar.Items)
                //{
                //    if (gest.Departamento == item.NomeDepto)
                //    {
                //        cmbDepar.SelectedIndex = cmbDepar.FindStringExact(gest.Departamento.ToString());
                //        break;
                //    }
                //}

                btnSalvar.Text = "Alterar";
              
            }
            catch (Exception)
            {
                
               
            }
            



        }

        private void CarregarDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gerp.ListaGestor(txtPesquisa.Text);
            dataGridView1.AutoResizeColumns();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

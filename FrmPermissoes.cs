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
    public partial class FrmPermissoes : Form
    {
        public FrmPermissoes()
        {
            InitializeComponent();
        }

        PermissaoP permp = new PermissaoP();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            PermissaoE per = new PermissaoE();

            per.Descricao = txtDesc.Text;

            try
            {
                permp.CadastrarPermissao(per);

                dataGridPermissao.DataSource = null;
                dataGridPermissao.DataSource = permp.ListarPermissoes();

                txtDesc.Text = "";
            }
            catch (Exception)
            {
                
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPermissoes_Load(object sender, EventArgs e)
        {
            dataGridPermissao.AutoGenerateColumns = false;
            dataGridPermissao.DataSource = null;
            dataGridPermissao.DataSource = permp.ListarPermissoes();
            dataGridPermissao.AutoResizeColumns();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_SistemadeChamadosCMR
{
    public partial class FrmCadastroscs : Form
    {
        public FrmCadastroscs()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (rbCategoria.Checked == true)
            {
                FrmCategoria obj = new FrmCategoria();
                obj.ShowDialog();
            }
            else if(rbSubcat.Checked == true)
            {
                FrmSubCategoria obj = new FrmSubCategoria();
                obj.ShowDialog();
            }
            else if (rbDepartamento.Checked == true)
            {
                FrmDepartamento obj = new FrmDepartamento();
                obj.ShowDialog();
            }
            else if (rbGestor.Checked == true)
            {
                FrmCadastraGestor obj = new FrmCadastraGestor();
                obj.ShowDialog();
            }
            else if (rbPermiespec.Checked == true)
            {
                FrmPermissoes obj = new FrmPermissoes();
                obj.ShowDialog();
            }
            else if (rbUserperm.Checked == true)
            {
                FrmCadastroUsuario obj = new FrmCadastroUsuario();
                obj.ShowDialog();
            }
        }
    }
}

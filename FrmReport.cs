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
    public partial class FrmReport : Form
    {
        public FrmReport(List<ChamadosE> lista)
        {
            InitializeComponent();

            listaOficial = lista;
        }
        List<ChamadosE> listaOficial;
        private void FrmReport_Load(object sender, EventArgs e)
        {
            ChamadosEBindingSource.DataSource = listaOficial;
            this.reportViewer1.RefreshReport();
            
        }
    }
}

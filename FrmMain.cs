using Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace Projeto_SistemadeChamadosCMR
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void VerificaGestor()
        {
            string email = UserPrincipal.Current.EmailAddress;

        }

        private string DisplayNameUsuarioLogado()
        {
            try
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "cmr.com.br");


                string displayname = UserPrincipal.Current.DisplayName;
                return displayname;
            }
            catch (Exception ex)
            {
                MessageBox.Show("O computador deve estar ingressado no dominio CMR : " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw;

            }



        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int auxiliar = 0;
        private void BtnAdministrador_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin(this);
            login.Show();
        }

        private void BtnAberturaChamados_Click(object sender, EventArgs e)
        {
            FrmAberturaChamados obj = new FrmAberturaChamados();
            obj.Show();
        }

        private void btnMeusChamados_Click(object sender, EventArgs e)
        {
            FrmChamadosLista obj = new FrmChamadosLista(auxiliar);
            obj.Show();
        }

        private void BtnFila_Click(object sender, EventArgs e)
        {
            FrmChamadosLista obj = new FrmChamadosLista(auxiliar);
            obj.Show();
        }

        private void btnRelatórios_Click(object sender, EventArgs e)
        {
            FrmBuscarHistorico obj = new FrmBuscarHistorico();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmAutorizaChamado obj = new FrmAutorizaChamado(UserPrincipal.Current.EmailAddress);
            obj.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            BtnCadastros.Enabled = false;
            btnRelatórios.Enabled = false;
            BtnFila.Enabled = false;
            BtnAdministrador.Enabled = true;
            btnMeusChamados.Enabled = true;
            BtnAutoriza.Enabled = false;

            string email = UserPrincipal.Current.EmailAddress;

            lblUsuarioLogado.Text = DisplayNameUsuarioLogado();

            GestorP gp = new GestorP();

            bool validado = gp.ValidarGestor(email);

            if (validado)
            {
                lbladmin.Text = "Perfil de Gestor";
                BtnAutoriza.Enabled = true;
            }
        }

        private void BtnCadastros_Click(object sender, EventArgs e)
        {
            FrmCadastroscs obj = new FrmCadastroscs();

            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

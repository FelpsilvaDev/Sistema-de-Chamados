using Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_SistemadeChamadosCMR
{
    public partial class FrmSenhaGestor : Form
    {
        public FrmSenhaGestor(FrmVisualizarChamadoUser telachamado)
        {
            InitializeComponent();
            chamado = telachamado;
        }
        FrmVisualizarChamadoUser chamado;
        private void FrmSenhaGestor_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string nome = System.DirectoryServices.AccountManagement.UserPrincipal.Current.UserPrincipalName;
            string senha = txtSenha.Text;

                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "cmr.com.br"))// enviando paramentros para busca no ad 
                {
                    bool resultado = pc.ValidateCredentials(nome, senha);//recebendo resultado da consult

                    if (resultado == true)  // se caso  o usuario 
                    {
                        GestorP gep = new GestorP();
                        int codigo = gep.ResgataCodEmail(System.DirectoryServices.AccountManagement.UserPrincipal.Current.EmailAddress);

                        if (!gep.ConsultaFeriasCorrente(codigo, DateTime.Now))
                        {
                            if (chamado.comboBox1.Text == "Sim")
                            {
                                try
                                {
                                    ChamadosP chamap = new ChamadosP();
                                    codigo = gep.ResgataCodEmail(System.DirectoryServices.AccountManagement.UserPrincipal.Current.EmailAddress);

                                    chamap.AlteraAutorização(Convert.ToInt32(chamado.lblNumero.Text), "S", codigo);
                                    MessageBox.Show("Chamado Autorizado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show("Erro ao alterar chamado\n Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }


                            }

                            if (chamado.comboBox1.Text == "Não")
                            {
                                try
                                {
                                    ChamadosP chamap = new ChamadosP();

                                    codigo = gep.ResgataCodEmail(System.DirectoryServices.AccountManagement.UserPrincipal.Current.EmailAddress);
                                    chamap.AlteraAutorização(Convert.ToInt32(chamado.lblNumero.Text), "N", codigo);

                                    MessageBox.Show("Chamado Não Autorizado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Erro ao alterar chamado\n Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }


                            }

                        }
                        else
                        {
                            MessageBox.Show("Seu cadastro sinalizando que está em período de férias , favor consultar o T.I", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }



          
                    }
                    else
                    {
                        MessageBox.Show("Senha incorreta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
        
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnConfirmar.PerformClick();

            }
        }
    }
}

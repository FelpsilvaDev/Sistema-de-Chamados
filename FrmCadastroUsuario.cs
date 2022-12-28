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
    public partial class FrmCadastroUsuario : Form
    {
        public FrmCadastroUsuario()
        {
            InitializeComponent();
        }

        UsuarioP userp = new UsuarioP();
        UsuperP usp = new UsuperP();

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtEmail.Text != "" && comboAtivo.Text != "")
            {
                UsuarioE usuario = new UsuarioE();

                usuario.Nome = txtUsuario.Text.ToUpper();
                usuario.Email = txtEmail.Text;

                if (comboAtivo.Text == "Sim")
                {
                    usuario.ativo = "S";
                }
                else
                {
                    usuario.ativo = "N";
                }

                try
                {

                    if (btnCadastrar.Text == "Alterar")
                    {
                        usuario.Codigo = Convert.ToInt32(txtCodigo.Text);
                        userp.AlterarUser(usuario);
                        MessageBox.Show("Usuário Alterado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();

                    }
                    else
                    {
                        userp.CadastrarUser(usuario);
                        MessageBox.Show("Usuário Cadastrado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                 
                    btnCadastrar.Text = "Cadastrar";
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = userp.ListarUsuarios();
                    dataGridView1.AutoResizeColumns();
                }
                catch (Exception)
                {

                    MessageBox.Show("Erro ao realizar cadastro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int posicao = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow linha = dataGridView1.Rows[posicao];

            int codigo = Convert.ToInt32(linha.Cells[0].Value);

            UsuarioE usuario = new UsuarioE();
            try
            {
                usuario = userp.PesquisarPorCodigo(codigo);
                txtUsuario.Text = usuario.Nome;
                txtEmail.Text = usuario.Email;
                txtCodigo.Text = usuario.Codigo.ToString(); ;

                if (usuario.ativo == "S")
                {
                    comboAtivo.Text = "Sim";
                }
                else
                {
                    comboAtivo.Text = "Não";
                }

                btnCadastrar.Text = "Alterar";

            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao realizar cadastro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }

        private void FrmCadastroUsuario_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = userp.ListarUsuarios();
            dataGridView1.AutoResizeColumns();

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.AutoResizeColumns();

            comboAtivo.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox2.DataSource = userp.ListarUsuarios();
            comboBox2.DisplayMember = "Nome";
            comboBox2.ValueMember = "Codigo";
            comboBox2.SelectedIndex = -1;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtEmail.Text = "";
            txtUsuario.Text = "";
            comboAtivo.Text = "";
            btnCadastrar.Text = "Cadastrar";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                UsuperP perusp = new UsuperP();

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = perusp.ListarPermissoes(Convert.ToInt32(comboBox2.SelectedValue));
            }
            catch (Exception)
            {
                
                
            }
           
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                
                comboBox2.DataSource = userp.ListarUsuarios();
                comboBox2.DisplayMember = "Nome";
                comboBox2.ValueMember = "Codigo";
                comboBox2.SelectedIndex = -1;

                try
                {
                    UsuperP perusp = new UsuperP();

                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = perusp.ListarPermissoes(Convert.ToInt32(comboBox2.SelectedValue));
                }
                catch (Exception)
                {
                    
                   
                }
                

               
            }
            catch (Exception)
            {
                
            }
       
        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                PermissaoP perp = new PermissaoP();
                comboBox3.DataSource = perp.ListarPermissoes();
                comboBox3.DisplayMember = "Descricao";
                comboBox3.ValueMember = "Codigo";
            }
            catch (Exception)
            {

            }
       
        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {

            if (comboBox2.Text != "" && comboBox3.Text != "")
            {
                UsuperP usep = new UsuperP();

                UsuperE us = new UsuperE();

                us.CodPermissao = Convert.ToInt32(comboBox3.SelectedValue);
                us.CodUsuario = Convert.ToInt32(comboBox2.SelectedValue);

                try
                {
                    usep.LiberarAcesso(us);
                    MessageBox.Show("Acesso concedido", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = usep.ListarPermissoes(Convert.ToInt32(comboBox2.SelectedValue));

                  
                   
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao realizar liberacao", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            int posicao = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow linha = dataGridView2.Rows[posicao];

            int codigo = Convert.ToInt32(linha.Cells[0].Value);

            PermissaoP permp = new PermissaoP();

            comboBox3.DataSource = permp.ListarPermissoes();
            comboBox3.DisplayMember = "Descricao";
            comboBox3.ValueMember = "Codigo";
            comboBox3.SelectedIndex = -1;

            string descricao = linha.Cells[1].Value.ToString();
            

            lblcodigo.Text = codigo.ToString();

        
            foreach (PermissaoE item in comboBox3.Items)//varrendo a combobox para comparaçao com os dados extraidos do banco
            {
                if (descricao == item.Descricao)
                {
                    comboBox3.SelectedIndex = comboBox3.FindStringExact(descricao);//se o nome for igual seleciona o index do nome
                    break;

                }
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (lblcodigo.Text != "")
            {
                UsuperP up = new UsuperP();

                try
                {
                    up.RevogarAcesso(Convert.ToInt32(lblcodigo.Text));
                    UsuperP perusp = new UsuperP();

                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = perusp.ListarPermissoes(Convert.ToInt32(comboBox2.SelectedValue));

                }
                catch (Exception)
                {

                    MessageBox.Show("Erro ao realizar liberacao", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

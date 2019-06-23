using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using crud_wf_camadas.Model;
using crud_wf_camadas.BLL;

namespace crud_wf_camadas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Listar();
        }


        private void LimparDados()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            mtbTel.Clear();
            mtbCel.Clear();
            cbxSexo.SelectedIndex = -1;
            txtEndereco.Clear();
            cbxUF.SelectedIndex = -1;
            txtCidade.Clear();
            txtBairro.Clear();
        }

        private void Salvar(Funcionario funcionario)
        {
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

            funcionario.Nome = txtNome.Text;
            funcionario.Sexo = cbxSexo.Text;
            funcionario.Telefone = mtbTel.Text;
            funcionario.Celular = mtbCel.Text;
            funcionario.Endereco = txtEndereco.Text;
            funcionario.Bairro = txtBairro.Text;
            funcionario.Cidade = txtCidade.Text;
            funcionario.Estado = cbxUF.Text;

            funcionarioBLL.Salvar(funcionario);

            MessageBox.Show("O Funcionário foi salvo com Sucesso!");
            LimparDados();
            Listar();
        }


        private void Listar()
        {
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

            dataGridView.DataSource = funcionarioBLL.Listar();
        }


        private void Editar(Funcionario funcionario)
        {
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

            funcionario.IdFuncionario = Convert.ToInt32(txtCodigo.Text);
            funcionario.Nome = txtNome.Text;
            funcionario.Sexo = cbxSexo.Text;
            funcionario.Telefone = mtbTel.Text;
            funcionario.Celular = mtbCel.Text;
            funcionario.Endereco = txtEndereco.Text;
            funcionario.Bairro = txtBairro.Text;
            funcionario.Cidade = txtCidade.Text;
            funcionario.Estado = cbxUF.Text;

            funcionarioBLL.Editar(funcionario);

            MessageBox.Show("Dados Atualizados com Sucesso!");
            LimparDados();
            Listar();
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            Salvar(funcionario);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            Editar(funcionario);
        }


        private void Excluir(Funcionario funcionario)
        {
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

            funcionario.IdFuncionario = Convert.ToInt32(txtCodigo.Text);

            funcionarioBLL.Excluir(funcionario);

            MessageBox.Show("Dados Removidos com Sucesso!");
            LimparDados();
            Listar();
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtCodigo.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            cbxSexo.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            mtbTel.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            mtbCel.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();          
            txtEndereco.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            txtBairro.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
            txtCidade.Text = dataGridView.CurrentRow.Cells[7].Value.ToString();
            cbxUF.Text = dataGridView.CurrentRow.Cells[8].Value.ToString();         
                    
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();

            Excluir(funcionario);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparDados();
        }
    }
}

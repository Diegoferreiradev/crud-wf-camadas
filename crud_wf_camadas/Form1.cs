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
            Listar();
        }


        private void Listar()
        {
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

            dataGridView.DataSource = funcionarioBLL.Listar();
        }



        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            Salvar(funcionario);
        }
    }
}

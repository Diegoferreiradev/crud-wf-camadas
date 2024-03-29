﻿using crud_wf_camadas.BLL;
using crud_wf_camadas.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

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
            txtNome.BackColor = Color.White;
            mtbCel.BackColor = Color.White;
            txtBairro.BackColor = Color.White;
        }

        private void Salvar(Funcionario funcionario)
        {
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

            if (txtNome.Text.Trim() == string.Empty || mtbCel.Text.Trim() == string.Empty || txtBairro.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Preencha os Campos obrigatórios!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.BackColor = Color.Beige;
                mtbCel.BackColor = Color.Beige;
                txtBairro.BackColor = Color.Beige;
            }
            else
            {
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

        }


        private void Listar()
        {
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

            dataGridView.DataSource = funcionarioBLL.Listar();

            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "Nome";
            dataGridView.Columns[2].HeaderText = "Sexo";
            dataGridView.Columns[3].HeaderText = "Tel.Fixo";
            dataGridView.Columns[4].HeaderText = "Celular";
            dataGridView.Columns[5].HeaderText = "Endereço";
            dataGridView.Columns[6].HeaderText = "Bairro";
            dataGridView.Columns[7].HeaderText = "Cidade";
            dataGridView.Columns[8].HeaderText = "UF";

            dataGridView.Columns[0].Width = 30;
            dataGridView.Columns[1].Width = 150;
            dataGridView.Columns[2].Width = 35;
            dataGridView.Columns[8].Width = 30;
        }


        private void Editar(Funcionario funcionario)
        {
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

            if (txtNome.Text.Trim() == string.Empty || mtbCel.Text.Trim() == string.Empty || txtBairro.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Preencha os Campos obrigatórios!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.BackColor = Color.Beige;
                mtbCel.BackColor = Color.Beige;
                txtBairro.BackColor = Color.Beige;
            }
            else
            {
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

            if (txtCodigo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Selecione um registro para poder removê-lo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MessageBox.Show("Deseja realmente excluir esse registro?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {

            }
            else
            {
                funcionario.IdFuncionario = Convert.ToInt32(txtCodigo.Text);

                funcionarioBLL.Excluir(funcionario);

                MessageBox.Show("Dados Removidos com Sucesso!");
                LimparDados();
                Listar();
            }
     
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

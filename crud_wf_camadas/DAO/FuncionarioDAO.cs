using System;
using MySql.Data.MySqlClient;
using crud_wf_camadas.Model;
using System.Data;

namespace crud_wf_camadas.DAO
{
    public class FuncionarioDAO : Conexao
    {

        MySqlCommand comando = null;

        public void Salvar(Funcionario funcionario)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO funcionario (nome, sexo, telefone, celular, endereco, bairro, cidade, estado)" +
                                           " VALUES (@nome, @sexo, @telefone, @celular, @endereco, @bairro, @cidade, @estado)", conexao);

                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@sexo", funcionario.Sexo);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@celular", funcionario.Celular);
                comando.Parameters.AddWithValue("@endereco", funcionario.Endereco);
                comando.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                comando.Parameters.AddWithValue("@cidade", funcionario.Cidade);
                comando.Parameters.AddWithValue("@estado", funcionario.Estado);

                comando.ExecuteNonQuery();

            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }


        public DataTable ListarDados()
        {
            try
            {
                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                comando = new MySqlCommand("SELECT * FROM funcionario ORDER BY nome ASC", conexao);

                da.SelectCommand = comando;
                da.Fill(dt);

                return dt;
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}

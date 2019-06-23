using MySql.Data.MySqlClient;
using System;

namespace crud_wf_camadas.DAO
{
    public class Conexao
    {
        string conectar = "Server=localhost;Database=empresa;Uid=root;Pwd=;";

        protected MySqlConnection conexao = null;


        public void AbrirConexao()
        {
            try
            {
                conexao = new MySqlConnection(conectar);
                conexao.Open();
            }
            catch (Exception erro)
            {

                throw erro;
            }

        }

        public void FecharConexao()
        {
            try
            {
                conexao = new MySqlConnection(conectar);
                conexao.Close();
            }
            catch (Exception erro)
            {

                throw erro;
            }

        }

    }
}

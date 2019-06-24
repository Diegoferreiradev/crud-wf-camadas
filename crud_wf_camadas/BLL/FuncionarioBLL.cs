using crud_wf_camadas.DAO;
using crud_wf_camadas.Model;
using System;
using System.Data;

namespace crud_wf_camadas.BLL
{
    public class FuncionarioBLL
    {
        FuncionarioDAO funcionarioDAO = new FuncionarioDAO();


        public void Salvar(Funcionario funcionario)
        {
            try
            {
                funcionarioDAO.Salvar(funcionario);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


        public DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = funcionarioDAO.ListarDados();

                return dt;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }


        public void Editar(Funcionario funcionario)
        {
            try
            {
                funcionarioDAO.Editar(funcionario);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        public void Excluir(Funcionario funcionario)
        {
            try
            {
                funcionarioDAO.Excluir(funcionario);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
    }
}

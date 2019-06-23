using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crud_wf_camadas.Model;
using crud_wf_camadas.DAO;
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

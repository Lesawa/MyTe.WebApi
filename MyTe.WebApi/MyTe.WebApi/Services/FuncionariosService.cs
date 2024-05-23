using MyTe.WebApi.DAL;
using MyTe.WebApi.Models.Contexts;
using MyTe.WebApi.Models.Entities;

namespace MyTe.WebApi.Services
{
    public class FuncionariosService
    {
        public GenericDao<Funcionario, string> FuncionariosDao { get; set; }
        public FuncionariosService(MyTeContext context)
        {
            this.FuncionariosDao = new GenericDao<Funcionario, string>(context);
        }
        public IEnumerable<Funcionario> Listar()
        {
            return FuncionariosDao.Listar();
        }
        public void Incluir(Funcionario funcionario)
        {
            FuncionariosDao.Adicionar(funcionario);
        }
        public void Alterar(Funcionario funcionario)
        {
            FuncionariosDao.Alterar(funcionario);
        }
        public void Remover(Funcionario funcionario)
        {
            FuncionariosDao.Remover(funcionario);
        }

        public Funcionario? Buscar(string email)
        {
            return FuncionariosDao.Buscar(email);
        }
    }
}
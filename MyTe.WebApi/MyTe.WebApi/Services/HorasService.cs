using MyTe.WebApi.Models.Contexts;
using MyTe.WebApi.Models.DTO;
using MyTe.WebApi.Models.Entities;

namespace MyTe.WebApi.Services
{
    public class HorasService
    {
        public MyTeContext myTeContext { get; set; }
        public HorasService(MyTeContext context)
        {
            //this.HorasDao = new GenericDao<LancamentoDeHora>(context);
            this.myTeContext = context;
        }
        public IEnumerable<FuncionariosDTO> ListarResumoFuncionarios()
        {
            //combinacao das 3 tabelas usando Context, sem precisar da generização
            var lista = from w in myTeContext.WBSs
                        join h in myTeContext.Horas on w.Id equals h.WBSId
                        join f in myTeContext.Funcionarios on h.FuncionarioId equals f.Id
                        select new FuncionariosDTO
                        {
                            IdFuncionario = f.Id,
                            WBSId = w.Id,
                            CodigoWBSId = w.CodigoWBS,
                            DescricaoWBS = w.Descricao,
                            RegistroData = h.RegistroData,
                            HorasTrabalhadas = h.HorasTrabalhadas,
                            NomeFuncionario = f.Nome,
                            EmailFuncionario = f.Email
                        };
            return lista.ToList();
        }
    }
}

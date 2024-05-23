using MyTe.WebApi.DAL;
using MyTe.WebApi.Models.Contexts;
using MyTe.WebApi.Models.Entities;

namespace MyTe.WebApi.Services
{
    public class WBSsService
    {
        public GenericDao<WBS, int> WBSsDao { get; set; }
        public WBSsService(MyTeContext context)
        {
            this.WBSsDao = new GenericDao<WBS, int>(context);
        }

        public IEnumerable<WBS> Listar()
        {
            return WBSsDao.Listar();
        }

        public void Incluir(WBS wbs)
        {
            WBSsDao.Adicionar(wbs);
        }

        public WBS? Buscar(int id)
        {
            return WBSsDao.Buscar(id);
        }
        public void Alterar(WBS wbs)
        {
            WBSsDao.Alterar(wbs);
        }

        public void Remover(WBS wbs)
        {
            WBSsDao.Remover(wbs);
        }
    }
}

using TesteCbr.DbContext;
using TesteCbr.Models;

namespace TesteCbr.Service
{
    public class TraducaoService
    {
        private readonly TraducaoContext _traducaoContext;

        public TraducaoService()
        {
            _traducaoContext = new TraducaoContext();
        }

        public List<TraducaoModel> GetTraducoes(int idSite, string palavra, string chave)
        {
            var response =_traducaoContext.getTraducao(idSite, palavra, chave);
            return response;
        }
    }
}

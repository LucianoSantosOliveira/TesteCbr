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

        public List<TraducaoModel> GetAllTraducoes()
        {
            var response =_traducaoContext.getAllTraducao();
            return response;
        }
    }
}

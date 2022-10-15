using Microsoft.Data.SqlClient;
using TesteCbr.Models;

namespace TesteCbr.DbContext
{
    public class TraducaoContext
    {
        string conectString;

        public TraducaoContext()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            conectString = configuration.GetConnectionString("Banco");
        }

        public List<TraducaoModel> getTraducao(int idSite, string palavra, string chave)
        {
            var traducoes = new List<TraducaoModel>();

            using (SqlConnection conection = new SqlConnection(conectString))
            {
                conection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("BuscaPalavrasNova", conection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@IDSITE", idSite);
                    sqlCommand.Parameters.AddWithValue("@Palavra", palavra);
                    sqlCommand.Parameters.AddWithValue("@CHAVE", chave);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var traducao = new TraducaoModel();
                            var t = reader.Cast<TraducaoModel>();
                            traducao.Id = int.Parse(reader["ID"].ToString());
                            traducao.PreferredLabel = reader["Preferred Label"].ToString();
                            traducao.Confirmar = reader["Confirmar"].ToString();
                            traducao.Sugestao = reader["Sugestao"].ToString();
                            traducao.Validacao = reader["Validacao"].ToString();
                            traducao.Sinonimo = reader["Sinonimo"].ToString();

                            traducoes.Add(traducao);
                        }
                    }
                }
            }

                return traducoes;
        }
    }
}

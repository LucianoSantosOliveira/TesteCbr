using Microsoft.Data.SqlClient;
using TesteCbr.Models;

namespace TesteCbr.DbContext
{
    public class TraducaoContext
    {
        string conectStrig = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TesteCbr;Integrated Security=True";

        public List<TraducaoModel> getAllTraducao()
        {
            var traducoes = new List<TraducaoModel>();

            using (SqlConnection conection = new SqlConnection(conectStrig))
            {
                conection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("BuscaPalavrasNova", conection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@IDSITE", 1);
                    sqlCommand.Parameters.AddWithValue("@Palavra", "<10mm");
                    sqlCommand.Parameters.AddWithValue("@CHAVE", "TESTE");
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var traducao = new TraducaoModel();
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

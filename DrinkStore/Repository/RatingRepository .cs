using Entity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {

        IConfiguration _configuration;
        public RatingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Rating> addRequest(Rating RatingDetails)
        {
            string connectionString = "Data Source=srv2\\pupils;Initial Catalog=Drinks;Integrated Security=True;Pooling=False";
            string host = RatingDetails.Host;
            string method = RatingDetails.Method;
            string path = RatingDetails.Path;
            //DateTime recordDate = RatingDetails.RecordDate;@recordDate,[Record_Date]

            string query = "INSERT INTO [RATING]([HOST],[METHOD],[PATH])" +
                             "values(@host,@method,@path)";
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            using (SqlCommand sqlcommand = new SqlCommand(query, sqlconnection))
            {
                sqlcommand.Parameters.Add("@HOST", SqlDbType.NVarChar, 50).Value = host;
                sqlcommand.Parameters.Add("@METHOD", SqlDbType.NVarChar, 50).Value = method;
                sqlcommand.Parameters.Add("@PATH", SqlDbType.NVarChar, 50).Value = path;
                //sqlcommand.Parameters.Add("@Record_Date", SqlDbType.DateTime,100).Value = recordDate;
                sqlcommand.Connection.Open();
                int result = sqlcommand.ExecuteNonQuery();
            }

            return new Rating();
        }


    }

}


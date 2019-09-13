using Microsoft.Data.SqlClient;

namespace SocialNetwork.DAL.App_data
{
    public class Connection
    {
        public Connection(string connectionString)
        {
            SqlConnection = new SqlConnection(@"Data Source=mssql.fhict.local;Initial Catalog=dbi404906_ocial;User ID=dbi404906_ocial;Password=123");
        }
        internal SqlConnection SqlConnection { get; }
    }
}

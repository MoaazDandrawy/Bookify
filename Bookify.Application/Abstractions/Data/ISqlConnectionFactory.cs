using System.Data;

namespace Bookify.Application.Abstractions.Data
{
    // i need a way to get a database connection so i can execute queries using dapper
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();//return new database connection to my sql DB w elly rag3 da momkn ykoon SqlConnection aw MySqlConnection 3la 7asb
    }
}

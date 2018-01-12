using System;
using System.Collections.Generic;
using System.Text;

namespace SQH.DataAccess.Contract
{
    public interface IDatabaseConfig
    {
        string ConnectionString();
    }

    public class DatabaseConfig : IDatabaseConfig
    {
        public string conString { get; set; }

        public DatabaseConfig(string connString)
        {
            conString = connString;
        }

        public string ConnectionString()
        {
            return conString;
        }
    }
}

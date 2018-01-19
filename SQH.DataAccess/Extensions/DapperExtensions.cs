using Dapper;
using SQH.DataAccess.Helper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SQH.DataAccess.Extensions
{
    public static class DapperExtensions
    {
        public static T Insert<T>(this IDbConnection cnn, string tableName, dynamic param)
        {
            IEnumerable<T> result = SqlMapper.Query<T>(cnn, DynamicQuery.GetInsertQuery(tableName, param), param);
            return result.FirstOrDefault();
        }

        public static void Update(this IDbConnection cnn, string tableName, dynamic param)
        {
            SqlMapper.Execute(cnn, DynamicQuery.GetUpdateQuery(tableName, param), param);
        }

        public static void Update(this IDbConnection cnn, string tableName, string conditions, dynamic param)
        {
            SqlMapper.Execute(cnn, DynamicQuery.GetUpdateQuery(tableName, conditions, param), param);
        }
    }
}
using Dapper;
using SQH.DataAccess.Contract;
using SQH.DataAccess.Extensions;
using SQH.DataAccess.Helper;
using SQH.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace SQH.DataAccess.Service
{
    public class DapperRepository<T> : IDapperRepository<T> where T : class
    {
        private readonly IDatabaseConfig config;
        public DapperRepository(IDatabaseConfig _config)
        {
            config = _config;
        }
        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(config.ConnectionString());
            }
        }

        internal virtual dynamic Mapping(T item)
        {
            return item;
        }

        public void Add(T item)
        {
            using (IDbConnection cn = Connection)
            {
                var parameters = (object)Mapping(item);
                cn.Open();
                cn.Insert<Int32>(typeof(T).Name, parameters);
            }
        }

        public void Remove(T item)
        {
            var dic = item.GetPrimaryKeyAttribute();

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                cn.Execute($"DELETE FROM {typeof(T).Name} WHERE {dic.Key}=@ID", new { ID = dic.Value });
            }
        }

        public void Update(T item)
        {
            using (IDbConnection cn = Connection)
            {
                var parameters = (object)Mapping(item);
                cn.Open();
                cn.Update(typeof(T).Name, parameters);
            }
        }

        public T FindByID(int id)
        {
            T item = default(T);
            var dic = item.GetPrimaryKeyAttribute();

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                item = cn.QueryFirstOrDefault<T>($"SELECT * FROM {typeof(T).Name}  WHERE {dic.Key}=@ID", new { ID = id });
            }
            return item;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> items = null;

            // extract the dynamic sql query and parameters from predicate
            QueryResult result = DynamicQuery.GetDynamicQuery(typeof(T).Name, predicate);

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                items = cn.Query<T>(result.Sql, (object)result.Param);
            }

            return items;
        }

        public IEnumerable<T> FindAll()
        {
            IEnumerable<T> items = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                items = cn.Query<T>($"SELECT * FROM {typeof(T).Name}");
            }
            return items;
        }
    }
}

using EasyOa.Common;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Model
{
    public abstract class ModelBase<T>
    {
        internal ISqlMapper mapper = Mapper.Instance();
        internal string table = typeof(T).Name;
        public int Insert()
        {
            return (int)mapper.Insert(this.table + ".Insert", this);
        }
        /// <summary>
        /// 获取运行时sql
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        internal static string GetSql(string statementName, object paramObject)
        {
            try
            {
                ISqlMapper mapper = IBatisNet.DataMapper.Mapper.Instance();
                IMappedStatement statement = mapper.GetMappedStatement(statementName);

                //记录数据库连接是否为方法内部打开
                var isAreadyOpenConnection = mapper.IsSessionStarted;
                if (!isAreadyOpenConnection) mapper.OpenConnection();
                RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, mapper.LocalSession);
                statement.PreparedCommand.Create(scope, mapper.LocalSession, statement.Statement, paramObject);
                string strSql = scope.PreparedStatement.PreparedSql;

                for (int i = scope.IDbCommand.Parameters.Count - 1; i >= 0; i--)
                {
                    IDataParameter pa = (IDataParameter)scope.IDbCommand.Parameters[i];
                    strSql = strSql.Replace(pa.ParameterName, "'" + pa.Value.ToString() + "'");
                }
                //如果数据库连接为此方法内部打开，则自行关闭；否则，不用管理
                if (!isAreadyOpenConnection) mapper.CloseConnection();
                return strSql;
            }
            catch (Exception error)
            {
                throw new Exception("打印sql语句出错:" + error.Message);
            }
        }
        /// <summary>
        /// 美化sql语句,去掉空格
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private static string SqlStatementFormat(string sql)
        {
            string prettySql = sql.RegexReplace(@"(\()\s+", "$1").RegexReplace(@"\s*(,)\s*", "$1").RegexReplace(@"\s+(\))", "$1");
            return prettySql;
        }
    }
}

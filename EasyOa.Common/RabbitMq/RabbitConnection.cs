using System.Net.NetworkInformation;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Common
{
    public class RabbitConnection
    {
        private static string mqpath = AppConfig.GetConfig("mqpath");
        public static IConnection GetConnection()
        {
            ConnectionFactory connectionFactory=new ConnectionFactory();
            connectionFactory.Uri = mqpath;
            try
            {
                return connectionFactory.CreateConnection();
            }
            catch (Exception)
            {
                throw new Exception("未能连接队列服务器：" + mqpath);
            }
        }
    }
}

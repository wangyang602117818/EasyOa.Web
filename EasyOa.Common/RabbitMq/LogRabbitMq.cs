using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RabbitMQ.Client;

namespace EasyOa.Common
{
    /// <summary>
    /// 日志队列
    /// </summary>
    public class LogRabbitMq
    {
        private static IConnection connection;
        private static List<IModel> channels = new List<IModel>();  //存取频道集合
        private static int channels_num = 3;  //频道个数
        private static string route_key = "sys_log";
        private static string queue_name = "sys_log_queue";
        private static string exchange_name = "sys_log_exchange";
        /// <summary>
        /// 队列初始化
        /// </summary>
        static LogRabbitMq()
        {
            connection = RabbitConnection.GetConnection();
            for (int i = 1; i <= channels_num; i++)
            {
                IModel channel = connection.CreateModel();
                channel.ExchangeDeclare(exchange_name, "direct", true);
                channel.QueueDeclare(queue_name, true, false, false, null);
                channel.QueueBind(queue_name, exchange_name, route_key);
                channels.Add(channel);
            }
        }
        /// <summary>
        /// 入队操作
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="persistent">持久化</param>
        public static void Enqueue(object data, bool persistent=false)
        {
            IModel channel = channels[new Random().Next(0, channels_num)];
            IBasicProperties property = channel.CreateBasicProperties();
            property.SetPersistent(persistent);  //消息持久化
            channel.BasicPublish(exchange_name, route_key, property, BinarySerializerHelper.ObjectToByteArray(data));
        }

    }
}

using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
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
            return (int)mapper.Insert(table + "Insert", this);
        }
    }
}

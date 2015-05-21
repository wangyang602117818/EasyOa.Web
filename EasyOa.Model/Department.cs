using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOa.Model
{
    public class Department : ModelBase<Department>
    {
        public int Id { get; set; }
        public string De_Name { get; set; }
        public string De_Code { get; set; }
        public string QPin { get; set; }
        public string JPin { get; set; }
        public int? Sort { get; set; }

        
    }
    
}

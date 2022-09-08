using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePleno.App.Model
{
    public class Operator : IModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

        public Operator(string code)
        {
            this.Code = code;
            Id = Guid.NewGuid();
        }       
    }

  
}

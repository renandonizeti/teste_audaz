using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePleno.App.Model
{    public class Fare : IModel
    {
        public Guid Id { get; set; }
        public Guid OperatorId { get; set; }
        public int Status { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public Fare()
        {
            Id = Guid.NewGuid();
            Status = 1;
        }
    }
}

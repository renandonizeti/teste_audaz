using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.App.Model;

namespace TestePleno.App.Services
{
    public class FareService
    {       

        public void Create(Fare fare)
        {
            Repository.Insert(fare);
        }

        public void Update(Fare fare)
        {
            Repository.Update(fare);
        }

        public Fare GetFareById(Guid fareId)
        {
            var fare = Repository.GetById<Fare>(fareId);
            return fare;
        }

        public List<Fare> GetFares()
        {
            var fares = Repository.GetAll<Fare>();
            return fares;
        }
    }
}

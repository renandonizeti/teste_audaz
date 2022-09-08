using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.App.Model;

namespace TestePleno.App.Services
{
    public class OperatorService
    {

        public Operator GetOperatorByCode(string code)
        {
            var operators = Repository.GetAll<Operator>();
            var selectedOperator = operators.FirstOrDefault(o => o.Code == code);
            
            if (selectedOperator == null) {
                selectedOperator = new Operator(code);
                Create(selectedOperator);
            }
               
            return selectedOperator;
        }

        public Operator GetOperatorById(Guid id)
        {
            var selectedOperator = Repository.GetById<Operator>(id);
            return selectedOperator;
        }

        public List<Operator> GetOperators()
        {
            var operators = Repository.GetAll<Operator>();
            return operators;
        }

        public void Create(Operator insertingOperator)
        {
            Repository.Insert(insertingOperator);
        }

        public void Update(Operator updatingOperator)
        {
            Repository.Update(updatingOperator);
        }
    }
}

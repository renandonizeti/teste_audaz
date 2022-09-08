using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.App.Model;
using TestePleno.App.Services;

namespace TestePleno.App.Controller
{
    public class FareController
    {
        private OperatorService _operatorService;
        private FareService _fareService;

        public FareController()
        {
            _operatorService = new OperatorService();
            _fareService = new FareService();
        }

        public void CreateFare(Fare fare, string operatorCode)
        {
            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            fare.OperatorId = selectedOperator.Id;

            var fareList = _fareService.GetFares();
            DateTime minimalDate = DateTime.Today.AddMonths(-6);
            var fareAlredyInList = fareList.FindAll(f => (f.OperatorId == selectedOperator.Id) &&  (f.Value == fare.Value) && (f.Status == 1) && (f.CreatedAt < minimalDate));
          
            if(fareAlredyInList.Count > 0)
                throw new Exception("Já existe uma tarifa cadastrada nos últimos 6 meses nessa operadora com o mesmo valor");

            _fareService.Create(fare);
        }
    }
}

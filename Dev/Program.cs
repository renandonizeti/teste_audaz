using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.App.Controller;
using TestePleno.App.Model;

namespace TestePleno
{
    class Program
    {
        static void Main(string[] args)
        {
            Fare fare; ;
            while (true)
            {
                fare = new Fare();
                Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
                var fareValueInput = Console.ReadLine();
                fare.Value = decimal.Parse(fareValueInput);
                fare.CreatedAt = DateTime.Now;

                Console.WriteLine("Informe o código da operadora para a tarifa:");
                Console.WriteLine("Exemplos: OP01, OP02, OP03...");
                var operatorCodeInput = Console.ReadLine();

                var fareController = new FareController();
                fareController.CreateFare(fare, operatorCodeInput);

                Console.WriteLine("Tarifa cadastrada com sucesso, pois não há nenhuma tarifa idêntica a essa cadastrada nos últimos 6 meses.!");
                Console.WriteLine("**************************************");

            }
        }
    }
}

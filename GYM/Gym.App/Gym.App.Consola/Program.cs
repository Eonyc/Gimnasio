using System;
//Esta clase tipo Console la vamos a utilizar de manera temporal para ejecutar
//la App mientras hacemos la capa de presentacion.

using Gym.App.Dominio;
using Gym.App.Persistencia;

namespace Gym.App.Consola
{
    class Program
    {
        //Creo un obj que me permite llamar los metodos CRUD
        private static IRepositorioCustomer _repoCustomer = new RepositorioCustomer(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            addCustomer();
        }
        private static void addCustomer(){

           var customer = new Customer{
                Name      = "Jesus Fernando",
                Surname   = "Martinez Izurieta",
                Age       = 54,
                Telephone = "3104474329", 
                Address   = "Cl 6 74A-50"
           };
           _repoCustomer.createCustomer(customer);

        }

    }
}

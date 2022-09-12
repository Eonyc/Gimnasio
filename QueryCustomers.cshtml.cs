using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Gym.App.Persistencia; 
using Gym.App.Dominio;

namespace Gym.App.Presentacion.Pages
{
    public class QueryCustomersModel : PageModel
    {
        //La sgte sentencia apunta hacioe el backend y realiza la
        //conexion a la BD.
        //[readonly] es una caracteristica de solo-lectura de la BD
        private readonly IRepositorioCustomer _repoCustomer;
        //Vamos a inicializar la variable [_repoCustomer] a traves del
        //constructor de la clase y con esto garantizamos la conexion a la
        //BD
        //En la lista [lstCustomer] almaceno la consulta
        public IEnumerable<Customer> lstCustomer {get; set;}     
        public QueryCustomersModel(IRepositorioCustomer repoCustomer)
        {
            _repoCustomer = repoCustomer;

        } 

        public void OnGet()
        {
            //inicializo la lst vacia
            lstCustomer = new List<Customer>();
            lstCustomer = _repoCustomer.consultCustomers();
        }
    }
}

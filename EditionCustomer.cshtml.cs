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
    public class EditionCustomerModel : PageModel
    {
        private readonly IRepositorioCustomer _repoCustomer;

        public Customer Customer {get; set;}

        public EditionCustomerModel(IRepositorioCustomer repoCustomer){
            _repoCustomer = repoCustomer;
        } 
        public void OnGet(int customerId)
        {
            Customer = _repoCustomer.consultCustomer(customerId);
        }
    }
}

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
        //Esta Propiedad para realizar validaciones debe incluirse, ya que el la Entidad
        //[Customer] tiene la propiedad [Required] en sus atributos 
        [BindProperty]
        public Customer Customer {get; set;}

        public EditionCustomerModel(IRepositorioCustomer repoCustomer){
            _repoCustomer = repoCustomer;
        }
        //El parametro [customerId] es la variable que captura el dato en la pagina
        //[QueryCustomers.cshtml] el la sentencia [asp-route-customerId=@Reg.Id]  
        public void OnGet(int customerId)
        {
            Customer = _repoCustomer.consultCustomer(customerId);
        }
        //El metodo [OnPost] recibe a traves del boton [submit] los datos de actualizacion
        public async Task<IActionResult> OnPost(){
            Console.WriteLine(Customer.Id);
            Customer = _repoCustomer.updateCustomer(Customer);
            if (Customer == null){
                return Page();
            }
            return RedirectToPage("/Customers/QueryCustomers");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Authorization;

using Gym.App.Dominio;
using Gym.App.Persistencia;

namespace Gym.App.Presentacion.Pages
{
    //[Authorize]
    public class EditByNutritionModel : PageModel
    {
        private readonly IRepositorioCustomer _repoCustomer;
        [BindProperty]
        public Customer customer {get; set;}

        public EditByNutritionModel(IRepositorioCustomer repoCustomer){
            _repoCustomer = repoCustomer;
        }

        public void OnGet()
        {
            customer = new Customer();
        }
        public async Task<IActionResult> OnPost(){
            customer = _repoCustomer.consultCustomerByDni(customer.Dni);
            if (customer==null){
                //Si no encuentra el cliente por su Dni, entonces se redirecciona a la
                //pagina de Error.
                return RedirectToPage("/Error");
            }
            //Si lo encuentra nos deja en la misma pagina para seguir contruyendo la pagina
            return Page();
        }
        //Como en la pagina [cshtml] tenemos dos metodos [post] una apunta a una
        //Consulta y la otra apunta a la Actualiacion del Cliente. 
        //Por eso utilizamos otro metodo [OnPost] y lo llamamos [OnPostNutrition] 
        public async Task<IActionResult> OnPostNutrition(){
            customer = _repoCustomer.updateCustomer(customer);
            if (customer!=null){
                return RedirectToPage("/Customers/QueryCustomers");
            }
            return  RedirectToPage("/Error");
        }
    }
}

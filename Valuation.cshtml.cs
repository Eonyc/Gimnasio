using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Gym.App.Dominio;
using Gym.App.Persistencia;

namespace Gym.App.Presentacion.Pages
{
    public class ValuationModel : PageModel
    {
        private readonly IRepositorioCustomer _repoCustomer;
        [BindProperty]
        public Value value {get; set;}
        public Customer customer {get; set;}

        public ValuationModel(IRepositorioCustomer repoCustomer){
            _repoCustomer = repoCustomer;
        }     
        public void OnGet()
        {
            value = new Value();
            customer = new Customer();  
        }

        public async Task<IActionResult> OnPost(int customerId){
            customer = _repoCustomer.consultCustomer(customerId);
            if (customer!=null){
                if(customer==null){
                    customer.Value = new List<Value>();
                    customer.Value.Add(value); 
                }else{
                   customer.Value.Add(value);  
                }
                _repoCustomer.updateCustomer(customer);
                return Page();
            }
            return  RedirectToPage("/Error");
        }
    }
}

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
    public class ClientNutritionModel : PageModel
    {
        private readonly IRepositorioCustomer _repoCustomer;
        [BindProperty]
        public Nutrition nutrition {get; set;}
        public Customer customer {get; set;}
        //Constructor
        public ClientNutritionModel(IRepositorioCustomer repoCustomer){
            _repoCustomer = repoCustomer;
        }     
        public void OnGet()
        {
            nutrition = new Nutrition();
            customer = new Customer();  
        }

        public async Task<IActionResult> OnPost(int customerId){
            //El metodo OnPost captura todos los elementos [input asp-for="nutrition.NumberOfDays"] 
            //de la pagina ClientNutrition.cshtml y con ellos puede ejecutar [customer.Nutritions.Add(nutrition)]
            
            customer = _repoCustomer.consultCustomer(customerId);
            if (customer!=null){
                if(customer.Nutritions == null){
                    //Si no tiene Reg de nutricion, crea una lst
                    customer.Nutritions = new List<Nutrition>();
                    //Agrega un 1mer elemento a la lst
                    customer.Nutritions.Add(nutrition); 
                }else{
                    //Agrega a la lst un nuevo reg de nutricion
                   customer.Nutritions.Add(nutrition);  
                }
                //Actualiza la BD con el cliente y su nutricion [1:*]
                _repoCustomer.updateCustomer(customer);
                return Page();
            }
            return  RedirectToPage("/Error");
        }
    }
}

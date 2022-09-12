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
    public class CreateCustomerModel : PageModel
    {
        //La caracteristica [BindProperty] me permite incluir en este Modelo
        //[CreateRecordModel] y en la clase [Customer] las validaciones
        //[Required] que se colocaron en la capa [Dominio] en la clase [Customer]  
        [BindProperty]
        public Customer Customer { get; set; }
        
        private readonly IRepositorioCustomer _repoCustomer;
        
        public CreateCustomerModel(IRepositorioCustomer repoCustomer){
            //Inicializacion a la BD
            _repoCustomer = repoCustomer;
        }
        public void OnGet()
        {
        }
        //La caracteristica [async] me permite tener el tiempo necesario
        //la conexion a la BD para transmitir los datos. Y me envia como
        //respuesta una accion.
        public async Task<IActionResult> onPost(){
            if(!ModelState.IsValid){
                //Como la info no se ha ido, quedese en la pagina.
                return Page();
            }
            _repoCustomer.createCustomer(Customer);
            return RedirectToPage("/Index");

        }
    }
}

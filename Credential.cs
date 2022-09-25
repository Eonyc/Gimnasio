//Vamos a usar el paquete del sistema
using System;
//Definimos la capa a utilizar
//El sgte paquete me permite incluir validaciones
using System.ComponentModel.DataAnnotations;

namespace Gym.App.Dominio
{
    public class Credential{
        //Definimos la funcionalidad de Propiedades, usando la
        //notacion Pascal (1mer caracter del atributo en Mayuscula)
        public int Id {get; set;}
        //[Required] //validacion, campo requerido 
        public string Email {get; set;}
        //[Required] //validacion, campo requerido
        public string Password {get; set;} 
    } 

}
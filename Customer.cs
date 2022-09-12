//Vamos a usar el paquete del sistema
using System;
using System.Collections.Generic;
//El sgte paquete me permite incluir validaciones
using System.ComponentModel.DataAnnotations;

//Definimos la capa a utilizar
namespace Gym.App.Dominio
{
    public class Customer{
        //Definimos la funcionalidad de Propiedades, usando la
        //notacion Pascal (1mer caracter del atributo en Mayuscula).
        public int Id {get; set;}
        //[Required] validacion, campo requerido
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int Dni {get; set;}
        [Required]
        public string Name {get; set;} 
        public string Surname {get; set;}
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int Age {get; set;}
        [Required]
        public string Telephone {get; set;}
        public string Address {get; set;} 
        //Definimos las relaciones de ASOCIACION

        //Clase Customer --> Credential (Multiplicidad 1:1)
        public Credential Credential {get; set;}
        //Clase  Customer --> Tracking (Multiplicidad 1:*)
        public System.Collections.Generic.List<Tracking> Tracking {get; set;} 
        //Clase  Customer --> Nutrition (Multiplicidad 1:*)
        public System.Collections.Generic.List<Nutrition> Nutrition {get; set;}
        //Clase  Customer --> Value (Multiplicidad 1:*)
        public System.Collections.Generic.List<Value> Value {get; set;}
        //Clase  Customer --> Routine (Multiplicidad 1:*)
        public System.Collections.Generic.List<Routine> Routine {get; set;}
    } 
}    
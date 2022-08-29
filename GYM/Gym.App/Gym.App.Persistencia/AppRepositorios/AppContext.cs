//Esta clase se llama para realizar la conexion a la BD
//EntityFramework (EF .Net Core)
using Microsoft.EntityFrameworkCore;

using Gym.App.Dominio;
//Definimos que todo lo que esta entre corchetes pertenece a la capa de
//Persistencia
namespace Gym.App.Persistencia
{
    //Los : sinifican que la clase AppContext hereda todas las caracteristicas
    //de la clase DbContext que pertenece a EntityFrameworkCore
    public class AppContext:DbContext{
        //Los atributos seran de tipo  Objeto; objetos ya construidos en
        //el EF .Net Core
        //Dbset es una clase del EF .net Core que realiza el Mapeo a la
        //BD, osea, crea una tabla a partir de una clase que esta en la
        //carpeta Entidades de la capa Dominio, por ejemplo la clase [Credential]
        //va a crear la tabla [Credentials].
         public DbSet<Credential> Credentials {get; set;} 
         public DbSet<Tracking> Trackings {get; set;}
         public DbSet<Nutrition> Nutritions {get; set;}
         public DbSet<Value> Values {get; set;}
         public DbSet<Exercise> Exercises  {get; set;}
         public DbSet<Routine> Routines {get; set;}   
         public DbSet<Customer> Customers {get; set;}
        //Vamos a configurar la conexion a la BD. 
        //Para ello vamos a realizar polimorfismo (overrride, sobreescribir)
        //con el sgte metodo (OnConfiguring) de la clase DbContext
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            //Si la conexion NO esta establecida
            if (!optionsBuilder.IsConfigured){
                //Establecemos la conexion, para ello pasamos la cadena de conexion con dos parametros.
                //El 1ro es el nombre del servidor (MSSQLlocalDB); por el momento de manera local,
                //mas adelante lo cambiamos cuando estemos en la nube. El 2do el nombre de la BD 
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = Gym_Tic5G");
            } 
        }
    }

}
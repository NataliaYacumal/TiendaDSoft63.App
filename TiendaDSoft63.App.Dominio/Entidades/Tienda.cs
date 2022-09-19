using System;

namespace TiendaDSoft63.App.Dominio{

    //Modela la tienda en el sistema
    public class Tienda{

        //Identificador unico en el sistena de tienda
        public int Id {get; set;}
        //Direccion donde está ubicada la tienda
        public string Direccion {get;set;}
        //Telefono de la tienda
        public string Telefono {get;set;}
        //Correo electrónico de la tienda
        public string Email {get;set;}
        //Relación entre Tienda y Producto
        public Producto Productos {get;set;}
    }
}
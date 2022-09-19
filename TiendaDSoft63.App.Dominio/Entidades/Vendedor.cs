using System;

namespace TiendaDSoft63.App.Dominio{

    //Modela el vendedor en el sistema
    public class Vendedor: Persona{
        
        //Fecha de vinculación del vendedor en la tienda
        public DateTime FechaVinculaciónVendedor {get;set;}
        //Relación entre el Vendedor y el Cliente
        public Cliente Clientes {get;set;}
        //Relación entre el Vendedor y el producto
        public Producto Productos {get;set;}
        //Relación entre el Vendedor y la tienda
        public Tienda TiendaDSoft {get;set;}
    }
}
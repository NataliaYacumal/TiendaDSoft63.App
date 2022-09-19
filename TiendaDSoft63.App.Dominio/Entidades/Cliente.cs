using System;

namespace TiendaDSoft63.App.Dominio{

    //Modela el Cliente que está registrado en el sistema
    public class Cliente: Persona{
        
        //Fecha de registro en el sistema
        public DateTime FechaRegistroSistema {get; set;}
        //Relación entre Cliente y Tienda
        public Tienda Tiendas {get; set;}
        //Relación entre Cliente y Producto
        public Producto Productos {get; set;}        
    }
    
}
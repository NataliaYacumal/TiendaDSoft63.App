using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TiendaDSoft63.App.Dominio;

namespace TiendaDSoft63.App.Persistencia
{
    public interface IRepositorioProducto
    {
        IEnumerable<Producto> GetAllProductos();
        Producto AddProducto(Producto producto);
        Producto UpdateProducto(Producto producto);
        void DeleteProducto(int idProducto);
        Producto GetProducto(int idProducto);
        //IEnumerable<Producto> GetProductoPorFiltro(int filtro);
    }
}
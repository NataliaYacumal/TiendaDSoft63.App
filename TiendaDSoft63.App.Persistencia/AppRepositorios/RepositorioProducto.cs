using System;
using System.Collections.Generic;
using System.Linq;
using TiendaDSoft63.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace TiendaDSoft63.App.Persistencia
{
    public class RepositorioProducto : IRepositorioProducto
    {
        /// <summary>
        /// Referencia al contexto de Producto
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioProducto(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Producto AddProducto(Producto producto)
        {
            var productoAdicionado = _appContext.Productos.Add(producto);
            _appContext.SaveChanges();
            return productoAdicionado.Entity;
        }

        public void DeleteProducto(int idProducto)
        {
            var productoEncontrado = _appContext.Productos.FirstOrDefault(p => p.Id == idProducto);
            if (productoEncontrado == null)
                return;
            _appContext.Productos.Remove(productoEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Producto> GetAllProductos()
        {
            return GetAllProductos_();
        }

        /*public IEnumerable<Producto> GetProductoPorFiltro(int filtro)
        {
            var productos = GetAllProductos(); // Obtiene todos los Producto
            if (productos != null)  //Si se tienen Producto
            {
                if (!int.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    productos = productos.Where(p => p.Precio.Contains(filtro));
                }
            }
            return productos;
        }*/

        public IEnumerable<Producto> GetAllProductos_()
        {
            return _appContext.Productos;
        }

        public Producto GetProducto(int idProducto)
        {
            return _appContext.Productos.FirstOrDefault(p => p.Id == idProducto);
        }

        public Producto UpdateProducto(Producto producto)
        {
            var productoEncontrado = _appContext.Productos.FirstOrDefault(p => p.Id == producto.Id);
            if (productoEncontrado != null)
            {
                productoEncontrado.Precio = producto.Precio;
                productoEncontrado.Tipo = producto.Tipo;
                _appContext.SaveChanges();
            }
            return productoEncontrado;
        }     
    }
}
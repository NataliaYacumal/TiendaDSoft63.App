using System;
using System.Collections.Generic;
using System.Linq;
using TiendaDSoft63.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace TiendaDSoft63.App.Persistencia
{
    public class RepositorioVendedor : IRepositorioVendedor
    {
        /// <summary>
        /// Referencia al contexto de Vendedor
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioVendedor(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Vendedor AddVendedor(Vendedor vendedor)
        {
            var vendedorAdicionado = _appContext.Vendedores.Add(vendedor);
            _appContext.SaveChanges();
            return vendedorAdicionado.Entity;
        }

        public void DeleteVendedor(int idVendedor)
        {
            var vendedorEncontrado = _appContext.Vendedores.FirstOrDefault(v => v.Id == idVendedor);
            if (vendedorEncontrado == null)
                return;
            _appContext.Vendedores.Remove(vendedorEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Vendedor> GetAllVendedores()
        {
            return GetAllVendedores_();
        }

        public IEnumerable<Vendedor> GetVendedorPorFiltro(string filtro)
        {
            var vendedores = GetAllVendedores(); // Obtiene todos los vendedores
            if (vendedores != null)  //Si se tienen vendedores
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    vendedores = vendedores.Where(v => v.Nombre.Contains(filtro));
                }
            }
            return vendedores;
        }

        public IEnumerable<Vendedor> GetAllVendedores_()
        {
            return _appContext.Vendedores;
        }

        public Vendedor GetVendedor(int idVendedor)
        {
            return _appContext.Vendedores.FirstOrDefault(v => v.Id == idVendedor);
        }

        public Vendedor UpdateVendedor(Vendedor vendedor)
        {
            var vendedorEncontrado = _appContext.Vendedores.FirstOrDefault(v => v.Id == vendedor.Id);
            if (vendedorEncontrado != null)
            {
                vendedorEncontrado.Nombre = vendedor.Nombre;
                vendedorEncontrado.Email = vendedor.Email;
                vendedorEncontrado.Documentos = vendedor.Documentos;
                vendedorEncontrado.Generos = vendedor.Generos;
                vendedorEncontrado.Telefono = vendedor.Telefono;
                vendedorEncontrado.FechaVinculaciónVendedor= vendedor.FechaVinculaciónVendedor;
                vendedorEncontrado.Clientes = vendedor.Clientes;
                vendedorEncontrado.Productos = vendedor.Productos;
                vendedorEncontrado.TiendaDSoft =vendedor.TiendaDSoft;
                _appContext.SaveChanges();
            }
            return vendedorEncontrado;
        }     
    }
}
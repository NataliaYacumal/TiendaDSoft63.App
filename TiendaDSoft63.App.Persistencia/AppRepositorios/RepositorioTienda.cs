using System;
using System.Collections.Generic;
using System.Linq;
using TiendaDSoft63.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace TiendaDSoft63.App.Persistencia
{
    public class RepositorioTienda : IRepositorioTienda
    {
        /// <summary>
        /// Referencia al contexto de Tienda
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioTienda(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Tienda AddTienda(Tienda tienda)
        {
            var tiendaAdicionado = _appContext.Tiendas.Add(tienda);
            _appContext.SaveChanges();
            return tiendaAdicionado.Entity;
        }

        public void DeleteTienda(int idTienda)
        {
            var tiendaEncontrado = _appContext.Tiendas.FirstOrDefault(t => t.Id == idTienda);
            if (tiendaEncontrado == null)
                return;
            _appContext.Tiendas.Remove(tiendaEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Tienda> GetAllTiendas()
        {
            return GetAllTiendas_();
        }

        public IEnumerable<Tienda> GetTiendaPorFiltro(string filtro)
        {
            var tiendas = GetAllTiendas(); // Obtiene todos las Tienda
            if (tiendas != null)  //Si se tienen Tiendas
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    tiendas = tiendas.Where(t => t.Direccion.Contains(filtro));
                }
            }
            return tiendas;
        }

        public IEnumerable<Tienda> GetAllTiendas_()
        {
            return _appContext.Tiendas;
        }

        public Tienda GetTienda(int idTienda)
        {
            return _appContext.Tiendas.FirstOrDefault(t => t.Id == idTienda);
        }

        public Tienda UpdateTienda(Tienda tienda)
        {
            var tiendaEncontrado = _appContext.Tiendas.FirstOrDefault(t => t.Id == tienda.Id);
            if (tiendaEncontrado != null)
            {
                tiendaEncontrado.Direccion = tienda.Direccion;
                tiendaEncontrado.Telefono = tienda.Telefono;
                tiendaEncontrado.Email = tienda.Email;
                _appContext.SaveChanges();
            }
            return tiendaEncontrado;
        }     
    }
}
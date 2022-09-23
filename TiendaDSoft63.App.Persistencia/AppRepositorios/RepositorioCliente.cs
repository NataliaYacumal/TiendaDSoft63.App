using System;
using System.Collections.Generic;
using System.Linq;
using TiendaDSoft63.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace TiendaDSoft63.App.Persistencia
{
    public class RepositorioCliente : IRepositorioCliente
    {
        /// <summary>
        /// Referencia al contexto de Cliente
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioCliente(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Cliente AddCliente(Cliente cliente)
        {
            var clienteAdicionado = _appContext.Clientes.Add(cliente);
            _appContext.SaveChanges();
            return clienteAdicionado.Entity;
        }

        public void DeleteCliente(int idCliente)
        {
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
            if (clienteEncontrado == null)
                return;
            _appContext.Clientes.Remove(clienteEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Cliente> GetAllClientes()
        {
            return GetAllClientes_();
        }

        public IEnumerable<Cliente> GetClientePorFiltro(string filtro)
        {
            var clientes = GetAllClientes(); // Obtiene todos los Clientes
            if (clientes != null)  //Si se tienen Clientes
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    clientes = clientes.Where(c => c.Nombre.Contains(filtro));
                }
            }
            return clientes;
        }

        public IEnumerable<Cliente> GetAllClientes_()
        {
            return _appContext.Clientes;
        }

        public Cliente GetCliente(int idCliente)
        {
            return _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
        }

        public Cliente UpdateCliente(Cliente cliente)
        {
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (clienteEncontrado != null)
            {
                clienteEncontrado.Nombre = cliente.Nombre;
                clienteEncontrado.Email = cliente.Email;
                clienteEncontrado.Documentos = cliente.Documentos;
                clienteEncontrado.Generos = cliente.Generos;
                clienteEncontrado.Telefono = cliente.Telefono;
                clienteEncontrado.FechaRegistroSistema= cliente.FechaRegistroSistema;
                //clienteEncontrado.Tiendas = cliente.Tiendas;
                //clienteEncontrado.Productos = cliente.Productos;
                _appContext.SaveChanges();
            }
            return clienteEncontrado;
        }     
    }
}
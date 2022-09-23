using System;
using System.Collections.Generic;
using System.Linq;
using TiendaDSoft63.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace TiendaDSoft63.App.Persistencia
{
    public class RepositorioAdministrador : IRepositorioAdministrador
    {
        /// <summary>
        /// Referencia al contexto de Administrador
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioAdministrador(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Administrador AddAdministrador(Administrador administrador)
        {
            var administradorAdicionado = _appContext.Administradores.Add(administrador);
            _appContext.SaveChanges();
            return administradorAdicionado.Entity;
        }

        public void DeleteAdministrador(int idAdministrador)
        {
            var administradorEncontrado = _appContext.Administradores.FirstOrDefault(a => a.Id == idAdministrador);
            if (administradorEncontrado == null)
                return;
            _appContext.Administradores.Remove(administradorEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Administrador> GetAllAdministradores()
        {
            return GetAllAdministradores_();
        }

        public IEnumerable<Administrador> GetAdministradorPorFiltro(string filtro)
        {
            var administradores = GetAllAdministradores(); // Obtiene todos los administradores
            if (administradores != null)  //Si se tienen administradores
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    administradores = administradores.Where(a => a.Nombre.Contains(filtro));
                }
            }
            return administradores;
        }

        public IEnumerable<Administrador> GetAllAdministradores_()
        {
            return _appContext.Administradores;
        }

        public Administrador GetAdministrador(int idAdministrador)
        {
            return _appContext.Administradores.FirstOrDefault(a => a.Id == idAdministrador);
        }

        public Administrador UpdateAdministrador(Administrador administrador)
        {
            var administradorEncontrado = _appContext.Administradores.FirstOrDefault(a => a.Id == administrador.Id);
            if (administradorEncontrado != null)
            {
                administradorEncontrado.Nombre = administrador.Nombre;
                administradorEncontrado.Email = administrador.Email;
                administradorEncontrado.Documentos = administrador.Documentos;
                administradorEncontrado.Generos = administrador.Generos;
                administradorEncontrado.Telefono = administrador.Telefono;
                administradorEncontrado.Usuario = administrador.Usuario;
                administradorEncontrado.contrasenna = administrador.contrasenna;
                administradorEncontrado.FechaVinculación = administrador.FechaVinculación;
                administradorEncontrado.Tiendas = administrador.Tiendas;
                _appContext.SaveChanges();
            }
            return administradorEncontrado;
        }     
    }
}
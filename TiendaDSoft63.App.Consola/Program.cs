using System;
using TiendaDSoft63.App.Dominio;
using TiendaDSoft63.App.Persistencia;
using System.Collections.Generic;

namespace TiendaDSoft63.App.Consola
{
    class Program
    {
        private static IRepositorioAdministrador _repoAdministrador = new RepositorioAdministrador(new Persistencia.AppContext());
        private static IRepositorioCliente _repoCliente = new RepositorioCliente(new Persistencia.AppContext());
        private static IRepositorioProducto _repoProducto = new RepositorioProducto(new Persistencia.AppContext());
        private static IRepositorioTienda _repoTienda = new RepositorioTienda(new Persistencia.AppContext());
        private static IRepositorioVendedor _repoVendedor = new RepositorioVendedor(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hola amigos, vamos a empezar a trabajar con las tablas!");
            //AddAdministrador();
            BuscarAdmistrador(1);
            //AddCliente();
           // BuscarCliente(2);
        }
        
        private static void AddAdministrador()
        {
            var administrador = new Administrador
            {
                Nombre = "Natalia Yacumal",
                Email = "nataliayacumal@gmail.com", 
                Documentos = Documento.CedulaCiudadania,
                Generos = Genero.femenino,
                Telefono = 55,
                Usuario = "naty.yacumal",
                contrasenna = "naty.yacumal",
                FechaVinculación = new DateTime(2020, 04, 12)

            };
            _repoAdministrador.AddAdministrador(administrador);
            Console.WriteLine("Administrador agregado satisfactoriamente!");
        }

        private static void AddCliente()
        {
            var cliente = new Cliente
            {
                Nombre = "Isabella Jimenez",
                Email = "isabellajimenez@gmail.com", 
                Documentos = Documento.TarjetaDeIdentidad,
                Generos = Genero.femenino,
                Telefono = 111111111,
                FechaRegistroSistema = new DateTime(2021, 05, 12)

            };
            _repoCliente.AddCliente(cliente);
            Console.WriteLine("Cliente agregado satisfactoriamente!");
        }

        private static void AddVendedor()
        {
            var vendedor = new Vendedor
            {
                Nombre = "Nelson Jiménez",
                Email = "nelsonjimenez@gmail.com", 
                Documentos = Documento.CedulaExtranjeria,
                Generos = Genero.masculino,
                Telefono = 333333333,
                FechaVinculaciónVendedor = new DateTime(1990, 04, 12)
                
            };
            _repoVendedor.AddVendedor(vendedor);
            Console.WriteLine("Vendedor agregado satisfactoriamente!");
        }

        private static void AddProducto()
        {
            var producto = new Producto
            {
                Precio = 250000,
                Tipo = Tipo.Moda                
            };
            _repoProducto.AddProducto(producto);
            Console.WriteLine("Producto agregado satisfactoriamente!");
        }

        private static void AddTienda()
        {
            var tienda = new Tienda
            {
                Direccion = "Carrera 54 #6-35",
                Telefono = "222222222",
                Email = "tiendadsoft63@gmail.com"                
            };
            _repoTienda.AddTienda(tienda);
            Console.WriteLine("Tienda agregada satisfactoriamente!");
        }

        private static void BuscarAdmistrador(int idAdministrador)
        {
            var administrador = _repoAdministrador.GetAdministrador(idAdministrador);
            Console.WriteLine("*************Administrador encontrado*************");
            Console.WriteLine("Nombre: " +administrador.Nombre + ". Email: " + administrador.Email);
        }

        private static void BuscarCliente(int idCliente)
        {
            var cliente = _repoCliente.GetCliente(idCliente);
            Console.WriteLine("***********Cliente encontrado***************");
            Console.WriteLine("Nombre: " +cliente.Nombre + ". Email: " + cliente.Email);
        }

        private static void BuscarVendedor(int idVendedor)
        {
            var vendedor = _repoVendedor.GetVendedor(idVendedor);
            Console.WriteLine("*************Vendedor encontrado************");
            Console.WriteLine("Nombre: " +vendedor.Nombre + ". Email: " + vendedor.Email);
        }

        private static void BuscarProducto(int idProducto)
        {
            var producto = _repoProducto.GetProducto(idProducto);
            Console.WriteLine("******Producto encontrado********");
            Console.WriteLine("Precio: " +producto.Precio + ". Tipo: " + producto.Tipo);
        }

        private static void BuscarTienda(int idTienda)
        {
            var tienda = _repoTienda.GetTienda(idTienda);
            Console.WriteLine("******Tienda encontrada********");
            Console.WriteLine("Dirección: " +tienda.Direccion + ". Tipo: " + tienda.Email);
        }

        private static void ListarAdministradoresFiltro()
        {
            var AdminA = _repoAdministrador.GetAdministradorPorFiltro("nar");
            foreach (Administrador a in AdminA)
            {
                Console.WriteLine(a.Nombre + " " + a.Email);
            }

        }

        private static void ListarClientesFiltro()
        {
            var ClientesT = _repoCliente.GetClientePorFiltro("e");
            foreach (Cliente c in ClientesT)
            {
                Console.WriteLine(c.Nombre + " " + c.Email);
            }

        }

    }
}

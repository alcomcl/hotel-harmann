using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDatos
{
    public class ServiceCliente : ClaseAbstracta<Cliente>
    {
        public override void ActualizarEntidad(Cliente entity)
        {
            Cliente cli = bbdd.Cliente.Where(c => c.RutCliente == entity.RutCliente).First<Cliente>();
            if (cli == null)
            {
                throw new ArgumentException("Cliente no encontrado");
            }
            else
            {
                cli.RutCliente = entity.RutCliente;
                cli.Nombre = entity.Nombre;
                cli.Apellidos = entity.Apellidos;
                cli.Email = entity.Email;
                cli.Direccion = entity.Direccion;
                cli.Telefono = entity.Telefono;

                bbdd.SaveChanges();
            }
        }

        public override void AgregarEntidad(Cliente entity)
        {
            bbdd.Cliente.Add(entity);
            bbdd.SaveChanges();
        }

        public override void EliminarEntidad(object pk)
        {
            Cliente cl = bbdd.Cliente.Where(c => c.RutCliente == pk).First<Cliente>();
            if (cl == null)
            {
                throw new ArgumentException("Cliente no encontrado");
            }
            else
            {
                bbdd.Cliente.Remove(cl);
                bbdd.SaveChanges();
            }
        }

        public override Cliente ObtenerEntidad(object pk)
        {
            throw new NotImplementedException();
        }

        public override List<Cliente> ObtenerEntidades()
        {
            return bbdd.Cliente.ToList<Cliente>();
        }
    }
}

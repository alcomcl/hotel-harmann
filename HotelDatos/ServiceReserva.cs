using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDatos
{
    public class ServiceReserva : ClaseAbstracta<Reserva>
    {
        public override void ActualizarEntidad(Reserva entity)
        {
            Reserva res = bbdd.Reserva.Where(c => c.IdReserva == entity.IdReserva).First<Reserva>();
            if(res == null)
            {
                throw new ArgumentException("Reserva no encontrada");
            }
            else
            {
                res.IdReserva = entity.IdReserva;
                res.RutCliente = entity.RutCliente;
                res.FechaIngreso = entity.FechaIngreso;
                res.FechaSalida = entity.FechaSalida;
                res.TipoHabitacion = entity.TipoHabitacion;
                res.CantHuespedes = entity.CantHuespedes;

                bbdd.SaveChanges();
            }
        }

        public override void AgregarEntidad(Reserva entity)
        {
            bbdd.Reserva.Add(entity);
            bbdd.SaveChanges();
        }

        public override void EliminarEntidad(object pk)
        {
            Reserva res = bbdd.Reserva.Where(c => c.IdReserva == pk).First<Reserva>();
            if (res == null)
            {
                throw new ArgumentException("Reserva no encontrada");
            }
            else
            {
                bbdd.Reserva.Remove(res);
                bbdd.SaveChanges();
            }
        }

        public override Reserva ObtenerEntidad(object pk)
        {
            throw new NotImplementedException();
        }

        public override List<Reserva> ObtenerEntidades()
        {
            return bbdd.Reserva.ToList<Reserva>();
        }
    }
}

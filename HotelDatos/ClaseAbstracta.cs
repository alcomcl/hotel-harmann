using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDatos
{
    public abstract class ClaseAbstracta<T>
    {
        protected HotelEntities bbdd = new HotelEntities();

        public abstract void AgregarEntidad(T entity);

        public abstract void ActualizarEntidad(T entity);

        public abstract void EliminarEntidad(Object pk);

        public abstract List<T> ObtenerEntidades();

        public abstract T ObtenerEntidad(Object pk);


    }
}

using System;

namespace Veoxteam.Infraestructure.Data.Shared
{
    public class BaseRepository
    {
        protected void Run(Action accion)
        {
            try
            {
                accion();
            }
            catch (Exception excepcion)
            {
                if (excepcion.InnerException != null)
                    throw new Exception(excepcion.InnerException.Message);
                throw new Exception(excepcion.Message);
            }
        }

        protected T Run<T>(Func<T> aoAccion)
        {
            try
            {
                return aoAccion();
            }
            catch (Exception excepcion)
            {
                if (excepcion.InnerException != null)
                    throw new Exception(excepcion.InnerException.Message);
                throw new Exception(excepcion.Message);
            }
        }
    }
}

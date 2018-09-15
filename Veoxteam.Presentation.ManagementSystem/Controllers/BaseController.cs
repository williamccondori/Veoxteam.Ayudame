using System;
using System.Web.Mvc;
using Veoxteam.Application.Dtos.Shared;

namespace Veoxteam.Presentation.ManagementSystem.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        protected Response<T> Run<T>(Func<Response<T>> action)
        {
            try
            {
                return action();
            }
            catch (ApplicationException exception)
            {
                return new Response<T>(exception.Message, exception.StackTrace);
            }
            catch (Exception exception)
            {
                return new Response<T>(exception.Message, exception.StackTrace);
            }
        }

        protected void Run(Action action)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                TempData["MensajeError"] = exception.Message;

                RedirectToRoute("~/Seguridad/Login");
            }
        }
    }
}
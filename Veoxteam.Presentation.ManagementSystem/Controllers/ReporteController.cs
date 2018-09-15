using System.Web.Mvc;
using Veoxteam.Application.Services.Implementation.ManagementSystem;
using Veoxteam.Application.Services.ManagementSystem;

namespace Veoxteam.Presentation.ManagementSystem.Controllers
{
    public class ReporteController : BaseController
    {
        IReportService _reportService;

        public ActionResult AccidenteTransito()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerCliente()
        {
            _reportService = new ReportService();
            return Json(Run(() => _reportService.GetByType("AT"))
            , JsonRequestBehavior.AllowGet);
        }
    }
}
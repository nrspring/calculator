using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Calculator.Core.Services;
using Calculator.Web.Models;

namespace Calculator.Web.Controllers
{
    public class HomeController : Controller
    {
        public ExpressionProcessor ProcessorExpressions { get; set; }

        public HomeController(Core.Services.ExpressionProcessor processorExpressions)
        {
            ProcessorExpressions = processorExpressions;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessValue(ProcessorModel model)
        {
            var result = ProcessorExpressions.Process(model.Value);
            return Json(result);
        }
    }
}
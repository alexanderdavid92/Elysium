namespace Elysium.Controllers
{
    using Elysium.Manager.Interfaces;
    using Elysium.Models;
    using System.Web.Mvc;

    [Authorize]
    public class EmployeeController : Controller
    {
        private IEmployeeManager employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee (EmployeeViewModel model)
        {
            return View();
        }
    }
}
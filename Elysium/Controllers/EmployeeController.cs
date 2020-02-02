namespace Elysium.Controllers
{
    using Elysium.HelperInterfaces;
    using Elysium.Manager.Interfaces;
    using Elysium.Models;
    using System;
    using System.Linq;
    using System.Web.Mvc;

    [Authorize]
    public class EmployeeController : Controller
    {
        private IEmployeeManager employeeManager;
        private IEmployeeHelper employeeHelper;
        public EmployeeController(IEmployeeManager employeeManager, IEmployeeHelper employeeHelper)
        {
            this.employeeManager = employeeManager;
            this.employeeHelper = employeeHelper;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var employeesDto = this.employeeManager.GetAll();
            var emplyeesViewModel = employeesDto.Select(x => this.employeeHelper.ConvertToViewModel(x)).ToList();
            return View(emplyeesViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new EmployeeViewModel
            {
                BirthDate = DateTime.UtcNow.AddYears(-20),
                EmploymentDate = DateTime.UtcNow
            };
            ViewData["EmployeeAction"] = "Create";
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEmployee(EmployeeViewModel model)
        {
            var employeeDto = this.employeeHelper.ConvertToDto(model);
            this.employeeManager.Add(employeeDto);

            var employeesDto = this.employeeManager.GetAll();
            var emplyeesViewModel = employeesDto.Select(x => this.employeeHelper.ConvertToViewModel(x)).ToList();
            return View("Index", emplyeesViewModel);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var employee = this.employeeManager.GetById(id);
            var employeeViewModel = this.employeeHelper.ConvertToViewModel(employee);

            ViewData["EmployeeAction"] = "Edit";
            return View("Create", employeeViewModel);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeViewModel model)
        {
            var employeeDto = this.employeeHelper.ConvertToDto(model);
            this.employeeManager.Edit(employeeDto);

            var employeesDto = this.employeeManager.GetAll();
            var emplyeesViewModel = employeesDto.Select(x => this.employeeHelper.ConvertToViewModel(x)).ToList();
            return View("Index", emplyeesViewModel);
        }
    }
}
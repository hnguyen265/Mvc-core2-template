using HSU.TS.Data.Configurations;
using HSU.TS.Data.Interfaces;
using HSU.TS.Data.Model;
using HSU.TS.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSU.TS.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork uoW;
        //private IStudentRepository studentRepository;
        private SessionConfig SessionConfig { get; set; }
        public StudentController(IUnitOfWork unitOfWork, IOptions<SessionConfig> config)
        {
            this.uoW = unitOfWork;
            SessionConfig = config.Value;
        }
        
        [Route("Student")]
        public IActionResult List()
        {
            return Content(SessionConfig.FirstMessage.Title);
            //var std = uoW.StudentRepository.GetAll();
           // return View(std);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            student.DateRegister = DateTime.Now;
            uoW.StudentRepository.Add(student);
            uoW.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

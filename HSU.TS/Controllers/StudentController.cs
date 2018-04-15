using HSU.TS.Data.Interfaces;
using HSU.TS.Data.Model;
using HSU.TS.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSU.TS.Controllers
{
    public class StudentController:Controller
    {
        private IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [Route("Student")]
        public IActionResult List()
        {
            var std = _studentRepository.GetAll();
            return View(std);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            _studentRepository.Create(student);
            return RedirectToAction("List");
        }
    }
}

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
    [Route("[controller]")]
   
    public class StudentController : Controller
    {
        private readonly IUnitOfWork uoW;
        private SessionConfig SessionConfig { get; set; }
        public StudentController(IUnitOfWork unitOfWork, IOptions<SessionConfig> config)
        {
            this.uoW = unitOfWork;
            SessionConfig = config.Value;
        }
       
        //[Route("Student")]
        [HttpGet("")]
        public async Task<IActionResult> List()
        {
            // return Content(SessionConfig.FirstMessage.Title);
            var std = await uoW.StudentRepository.GetAllAsync();
            return View(std);
        }

      [HttpGet("ListApi")]
        public async Task<IActionResult> ListAPI()
        {
            // return Content(SessionConfig.FirstMessage.Title);
            var std = await uoW.StudentRepository.GetAllAsync();
            return new ObjectResult(std);
        }

        [HttpGet("Stuff")]
        public IActionResult Post()
        {
            var item = uoW.StudentRepository.GetById(1);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //[Route("Post")]
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Post.ToListAsync());
        //}


        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult GetById(long id)
        {

            var item = uoW.StudentRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
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
        public IActionResult Update(long id)
        {
            var std = uoW.StudentRepository.GetByIdAsync(id);
            return View(std);
        }

        [HttpPost]
        public IActionResult Update(Student std)
        {
            if (!ModelState.IsValid)
            {

                return View(std);
            }

            uoW.StudentRepository.Update(std);
            uoW.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(long id)
        {
            var std = uoW.StudentRepository.GetByIdAsync(id);

            uoW.StudentRepository.Remove(std);
            uoW.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

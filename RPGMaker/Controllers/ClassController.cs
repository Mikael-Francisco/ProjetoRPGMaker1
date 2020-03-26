using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Common;
using DTO;
using Microsoft.AspNetCore.Mvc;
using RPGMaker.Models.Index;
using RPGMaker.Models.Inserts;

namespace RPGMaker.Controllers
{
    public class ClassController : Controller
    {
        private IClassService _classService;
        public ClassController(IClassService classService)
        {
            this._classService = classService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Class> classes = await _classService.GetAllClasses();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Class, ClassViewModel>();

                });

                IMapper mapper = configuration.CreateMapper();

                List<ClassViewModel> data = mapper.Map<List<ClassViewModel>>(classes);

                return View(data);
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClassInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClassInsertViewModel, Class>();
            });

            IMapper mapper = configuration.CreateMapper();
            Class dto = mapper.Map<Class>(viewModel);
            try
            {
                await _classService.Create(dto);
                return RedirectToAction("Index", "Class");
            }
            catch (RPGException ex)
            {
                ViewBag.ValidationErrors = ex.Errors;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }
    }
}
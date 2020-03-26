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
    public class RaceController : Controller
    {
        private IRaceService _raceService;
        public RaceController(IRaceService raceService)
        {
            this._raceService = raceService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Race> races = await _raceService.GetAllRaces();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Race, RaceViewModel>();

                });

                IMapper mapper = configuration.CreateMapper();

                List<RaceViewModel> data = mapper.Map<List<RaceViewModel>>(races);

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
        public async Task<IActionResult> Create(RaceInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RaceInsertViewModel, Race>();
            });

            IMapper mapper = configuration.CreateMapper();
            Race dto = mapper.Map<Race>(viewModel);
            try
            {
                await _raceService.Create(dto);
                return RedirectToAction("Index", "race");
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
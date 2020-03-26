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
    public class CreatureController : Controller
    {
        private ICreatureService _creatureService;
        private IClassService _classService;
        private IItemService _itemService;
        private IRaceService _raceService;
        private ITerritoryService _territoryService;

        public CreatureController(ICreatureService creatureService, IClassService classService, IItemService itemService, IRaceService raceService, ITerritoryService territoryService)
        {
            this._creatureService = creatureService;
            this._classService = classService;
            this._itemService = itemService;
            this._raceService = raceService;
            this._territoryService = territoryService;
        }

        public IActionResult Create()
        {
            ViewBag.Classes = _classService.GetAllClasses().Result;
            ViewBag.Items = _itemService.GetAllItems().Result;
            ViewBag.Races = _raceService.GetAllRaces().Result;
            ViewBag.Territories = _territoryService.GetAllTerritories().Result;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Creature> creatures = await _creatureService.GetAllCreatures();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Creature, CreatureViewModel>();

                });

                IMapper mapper = configuration.CreateMapper();

                List<CreatureViewModel> data = mapper.Map<List<CreatureViewModel>>(creatures);

                return View(data);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatureInsertViewModel viewModel)
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreatureInsertViewModel, Creature>();
            });

            IMapper mapper = configuration.CreateMapper();
            Creature dto = mapper.Map<Creature>(viewModel);
            try
            {
                await _creatureService.Create(dto);
                return RedirectToAction("Home", "Index");
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
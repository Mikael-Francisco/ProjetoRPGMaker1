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
    public class CharacterController : Controller
    {
        private ICharacterService _characterService;
        private IClassService _classService;
        private IItemService _itemService;
        private IRaceService _raceService;
        private ITerritoryService _territoryService;

        public CharacterController(ICharacterService characterService, IClassService classService, IItemService itemService, IRaceService raceService, ITerritoryService territoryService)
        {
            this._characterService = characterService;
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
                IEnumerable<Character> characters = await _characterService.GetAllCharacters();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Character, CharacterViewModel>();

                });

                IMapper mapper = configuration.CreateMapper();

                List<CharacterViewModel> data = mapper.Map<List<CharacterViewModel>>(characters);

                return View(data);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CharacterInsertViewModel viewModel)
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CharacterInsertViewModel, Character>();
            });

            IMapper mapper = configuration.CreateMapper();
            Character dto = mapper.Map<Character>(viewModel);
            try
            {
                await _characterService.Create(dto);
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
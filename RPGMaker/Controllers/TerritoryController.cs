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
    public class TerritoryController : Controller
    {
        private ITerritoryService _TerritoryService;
        public TerritoryController(ITerritoryService territoryService)
        {
            this._TerritoryService = territoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Territory> territories = await _TerritoryService.GetAllTerritories();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Territory, TerritoryViewModel>();

                });

                IMapper mapper = configuration.CreateMapper();

                List<TerritoryViewModel> data = mapper.Map<List<TerritoryViewModel>>(territories);

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
        public async Task<IActionResult> Create(TerritoryInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TerritoryInsertViewModel, Territory>();
            });

            IMapper mapper = configuration.CreateMapper();
            Territory dto = mapper.Map<Territory>(viewModel);
            try
            {
                await _TerritoryService.Create(dto);
                return RedirectToAction("Index", "Territory");
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
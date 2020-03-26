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
    public class ItemController : Controller
    {
        private IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            this._itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Item> items = await _itemService.GetAllItems();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Item, ItemViewModel>();

                });

                IMapper mapper = configuration.CreateMapper();

                List<ItemViewModel> data = mapper.Map<List<ItemViewModel>>(items);

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
        public async Task<IActionResult> Create(ItemInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItemInsertViewModel, Item>();
            });

            IMapper mapper = configuration.CreateMapper();
            Item dto = mapper.Map<Item>(viewModel);
            try
            {
                await _itemService.Create(dto);
                return RedirectToAction("Index", "Item");
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
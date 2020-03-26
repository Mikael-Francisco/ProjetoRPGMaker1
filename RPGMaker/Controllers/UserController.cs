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
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<User> users = await _userService.GetAllUsers();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserViewModel>();

                });

                IMapper mapper = configuration.CreateMapper();

                List<UserViewModel> data = mapper.Map<List<UserViewModel>>(users);

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
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(UserInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserInsertViewModel, User>();
            });

            IMapper mapper = configuration.CreateMapper();
            User dto = mapper.Map<User>(viewModel);
            try
            {
                await _userService.Create(dto);
                return RedirectToAction("Index", "User");
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
        [HttpGet]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                User user = await _userService.Authenticate(email, password);
                if (user.Permission == DTO.Enums.Permission.Master)
                {
                    return RedirectToAction("Index", "RPGMaker");
                }
                else
                {
                    return RedirectToAction("Create", "Character");

                }
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
            }
            return View();
        }
    }
}
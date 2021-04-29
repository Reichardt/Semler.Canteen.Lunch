using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Semler.Canteen.Lunch.Business.Exceptions;
using Semler.Canteen.Lunch.Business.Interfaces;
using Semler.Canteen.Lunch.Business.Services;
using Semler.Canteen.Lunch.Web.Models;

namespace Semler.Canteen.Lunch.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILocationRepository _locationRepository;
        private readonly ILunchOrderRepository _lunchOrderRepository;
        private readonly LunchService _lunchService;

        public HomeController(ILogger<HomeController> logger, ILocationRepository locationRepository, LunchService lunchService, ILunchOrderRepository lunchOrderRepository)
        {
            _logger = logger;
            _locationRepository = locationRepository;
            _lunchOrderRepository = lunchOrderRepository;
            _lunchService = lunchService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                LocationSelectListItems = IndexViewModel.GetLocationListItems(_locationRepository.ListAll()),
                LunchOrders = _lunchOrderRepository.ListAllByUserId(new Guid(HttpContext.User.FindFirst("Id").Value))
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddLunchOrder(IndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogDebug("ModelState is valid");

                try
                {
                    _lunchService.AddLunchOrder(new Guid(HttpContext.User.FindFirst("Id").Value), (Guid)model.LocationId, (DateTime)model.Date);
                    ViewData["FormSuccess"] = "Din bestilling er oprettet...";
                }
                catch (InvalidLunchOrderDateException)
                {
                    ViewData["FormError"] = "Din bestilling skal foretages mindst 2 dage før ønskede frokost dato...";
                }
                catch (Exception)
                {
                    ViewData["FormError"] = "Din bestilling er ikke oprettet...";
                }

            }

            model.LocationSelectListItems = IndexViewModel.GetLocationListItems(_locationRepository.ListAll());
            model.LunchOrders = _lunchOrderRepository.ListAllByUserId(new Guid(HttpContext.User.FindFirst("Id").Value));

            return View("Index", model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stefan.DataAccess.Entities;
using Stefan.Domain;
using Stefan.Web.ViewModels;

namespace Stefan.Web.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        public async Task<IActionResult> Index()
        {
            var manufacturerModels = await _manufacturerService.GetAll();
           
            var viewModel = new ManufacturerIndexViewModel()
            {
                Manufacturers = manufacturerModels.Select(m => new ManufacturerDetailsViewModel
                {
                    Name = m.Name,
                    LogoPath = m.LogoPath,
                    ViewOrder = m.ViewOrder,
                    Comment = m.Comment,
                    CreateDate = m.CreateDate,
                    Id = m.Id
                }).ToList()
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ManufacturerCreateViewModel viewModel)
        {
            var model = new Manufacturer
            {
                Name = viewModel.Name,
                LogoPath = viewModel.LogoPath,
                Comment = viewModel.Comment,
                ViewOrder = viewModel.ViewOrder
            };

            await _manufacturerService.Add(model);

            return RedirectToAction(nameof(Create));
        }
    }
}

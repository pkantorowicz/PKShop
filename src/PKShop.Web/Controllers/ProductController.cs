using MediatR;
using Microsoft.AspNetCore.Mvc;
using PKShop.Core.Notifications;
using PKShop.Struct.Services.Services;
using PKShop.Struct.Services.ViewModels;
using PKShop.Web.Extensions;
using System;
using System.Threading.Tasks;

namespace PKShop.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productservice;

        public ProductController(IProductService productService, 
            INotificationHandler<DomainNotification> notification) : base(notification)
        {
            _productservice = productService;
        }

        [HttpGet]
        [Route("products/browse")]
        public async Task<IActionResult> Index()
        {
            return View(await _productservice.BrowseAsync());
        }

        [HttpGet]   
        [Route("products/details/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            id.CheckForNulls(nameof(id));
            var product = await _productservice.GetAsync(id);
            product.CheckForNulls(nameof(product));
            return View(product);
        }

        [HttpGet]
        [Route("products/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("products/create")]
        public async Task<IActionResult> Create(ProductViewModel productVM)
        {
            if (!ModelState.IsValid)
            {
                return View(productVM);
            }
            await _productservice.CreateAsync(productVM);
            if (IsValidOperation())
            {
                ViewBag.Success = "Product Created!";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("products/edit/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            id.CheckForNulls(nameof(id));
            var product = await _productservice.GetAsync(id);
            product.CheckForNulls(nameof(product));
            return View(product);
        }

        [HttpPost]
        [Route("products/edit/{id:guid}")]
        public async Task<IActionResult> Edit(ProductViewModel productVM)
        {
            if (!ModelState.IsValid)
            {
                return View(productVM);
            }
            await _productservice.UpdateAsync(productVM);
            if (IsValidOperation())
            {
                ViewBag.Success = "Product updated!";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("products/remove/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            id.CheckForNulls(nameof(id));
            var product = await _productservice.GetAsync(id);
            product.CheckForNulls(nameof(product));
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [Route("products/remove/{id:guid}")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _productservice.RemoveAsync(id);
            if (IsValidOperation())
            {
                return View(await _productservice.GetAsync(id));
            }
            ViewBag.Success = "Product removed!";
            return RedirectToAction(nameof(Index));
        }

        [Route("products/history/{id:guid}")]
        public async Task<JsonResult> History(Guid id)
        {
            var productFromHistory = await _productservice.GetHistoryDataAsync(id);
            return Json(productFromHistory);
        }
    }
}
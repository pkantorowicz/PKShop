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
        public async Task<IActionResult> BrowseAsync()
        {
            var products = await _productservice.BrowseAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("products/details/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            id.CheckForNulls(nameof(id));
            var product = await _productservice.GetAsync(id);
            product.CheckForNulls(nameof(product));
            return Ok(product);
        }

        [HttpPost]
        [Route("products/create")]
        public async Task<IActionResult> Create([FromBody]ProductViewModel productVM)
        {
            await _productservice.CreateAsync(productVM);
            return NoContent();
        }

        [HttpPost]
        [Route("products/edit/{id:guid}")]
        public async Task<IActionResult> Edit([FromBody]ProductViewModel productVM)
        {
            await _productservice.UpdateAsync(productVM);
            return NoContent();
        }

        [HttpDelete]
        [Route("products/remove/{id:guid}")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _productservice.RemoveAsync(id);
            return NoContent();
        }

        [Route("products/history/{id:guid}")]
        public async Task<JsonResult> History(Guid id)
        {
            var productFromHistory = await _productservice.GetHistoryDataAsync(id);
            return Json(productFromHistory);
        }
    }
}
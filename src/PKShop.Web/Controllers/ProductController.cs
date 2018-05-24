using MediatR;
using Microsoft.AspNetCore.Mvc;
using PKShop.Core.Notifications;
using PKShop.Struct.Services.Services;
using PKShop.Struct.Services.ViewModels;
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
    }
}
using NorthwindModel.Repository;
using NorthwindService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public ActionResult Index()
        {
            return View(this.productService.GetAll());
        }
    }
}
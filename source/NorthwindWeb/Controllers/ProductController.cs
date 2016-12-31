using NorthwindModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepositoy;

        public ProductController()
        {
            this.productRepositoy = new ProductRepository();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(this.productRepositoy.GetAll());
        }
    }
}
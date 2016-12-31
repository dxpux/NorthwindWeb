using NorthwindModel;
using NorthwindModel.Repository;
using NorthwindService.Interface;
using NorthwindWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindWeb.Controllers
{
    /// <summary>
    /// 產品管理
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// 產品管理頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(this.productService.GetAll());
        }

        [HttpPost]
        public JsonResult JsonGetProducts()
        {
            try
            {
                return Json(new ReContent<IEnumerable<Product>>() { Success = true, Data = this.productService.GetAll() });
            }
            catch (Exception ex)
            {
                return Json(new ReContent<string>() { Success = false, Message = ex.Message });
            }
        }
    }
}
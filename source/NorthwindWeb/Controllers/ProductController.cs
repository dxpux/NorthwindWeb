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

        /// <summary>
        /// 取得產品清單 api
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 取得供應商 api
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult JsonGetSuppliers()
        {
            try
            {
                return Json(new ReContent<IEnumerable<Supplier>>() { Success = true, Data = this.productService.GetAllSupplier () });
            }
            catch (Exception ex)
            {
                return Json(new ReContent<string>() { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// 取得商品種類 api
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult JsonGetCategories()
        {
            try
            {
                return Json(new ReContent<IEnumerable<Category>>() { Success = true, Data = this.productService.GetAllCategory() });
            }
            catch (Exception ex)
            {
                return Json(new ReContent<string>() { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// 新增產品 api
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult JsonAddProduct(Product product)
        {
            try
            {
                this.productService.Add(product);
                return Json(new ReContent<string> { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new ReContent<string>() { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// 更新產品資訊 api
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult JsonModifyProduct(Product modifyProduct)
        {
            try
            {
                var product = this.productService.FindByID(modifyProduct.ProductID);
                if (product == null) throw new Exception("未知的 ProductID");
                product.ProductName = modifyProduct.ProductName;
                product.QuantityPerUnit = modifyProduct.QuantityPerUnit;
                product.CategoryID = modifyProduct.CategoryID;
                product.SupplierID = modifyProduct.SupplierID;
                product.UnitPrice = modifyProduct.UnitPrice;

                this.productService.Update(product);
                return Json(new ReContent<string> { Success = true });
            }
            catch (Exception ex)
            {
                return Json(new ReContent<string>() { Success = false, Message = ex.Message });
            }
        }
    }
}
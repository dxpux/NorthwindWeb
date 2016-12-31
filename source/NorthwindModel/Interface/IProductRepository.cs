using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindModel.Interface
{
    public interface IProductRepository
    {
        #region Product

        void Add(Product product);
        void Update(Product product);
        Product FindByName(string productName);
        IEnumerable<Product> GetAll();

        #endregion

        #region Supplier

        IEnumerable<Supplier> GetAllSupplier();

        #endregion

        #region Category

        IEnumerable<Category> GetAllCategory();

        #endregion
    }
}